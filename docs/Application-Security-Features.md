# Application Security Features
Version 1.0 | Prepared: 6 October 2026 | Basis: source-code review

## 1. Scope
This document describes security-related behavior implemented in the .NET 8 API, providers, repositories, shared libraries, SQL integration, and file-upload endpoints. React is the intended client, but its source is not present in this repository; no frontend security feature is claimed as implemented.

This is a documentation review, not a penetration test or a production security certification. Stored-procedure definitions, deployment controls, database permissions, and production infrastructure were not available. Credentials and encryption key values are intentionally excluded.

## 2. Control summary
| Area | Implemented behavior | Coverage / limitation |
| --- | --- | --- |
| Login authentication | User existence, active-status check, BCrypt password verification, application access check | Implemented in the login provider. |
| Token management | Custom token generation, SQL persistence, verification call, expiration method | Rejection of invalid/missing tokens is incomplete in the helper. |
| Authorization | Match required PermissionID against cached user/application permissions | Conditional; default permission NONE skips the check. |
| Password protection | BCrypt hashing in reviewed user/password methods | Strength policy is not established as universal across all password write paths. |
| Upload security | Size/type checks; KYC signature and organization checks | Controls differ by endpoint; no malware scan found. |
| Database access | Parameterized ADO.NET commands in reviewed repository flows | Stored-procedure internals and every inline SQL path were not audited. |
| Audit | Login action audit to SQL; named password-parameter mask | Coverage is not global; tokens may be captured. |
| Error handling / logs | Generic action-error response; structured SQL logging | Tokens/headers are logged; scope is controller action exceptions. |
| HTTP response caching | NoStore attributes on reviewed controllers | Not a complete browser or frontend cache policy. |
| Encryption utilities | AES/RSA helper code exists | Active use was not found in the searched API/provider/repository code. |

## 3. Authentication
POST /AA/Login receives username/password input and caller context. The provider:
1. Loads the user through AAC.usp_GetUserDetails.
2. Rejects unknown users.
3. Requires the Activated account status.
4. Verifies the submitted password against the stored BCrypt hash.
5. Checks application access through AAC.usp_ValidationApplicationPermissions.
6. Creates and persists a user token only after those checks succeed.

Failed login results include unknown user, inactive account, incorrect password, denied application access, and failed token creation. The login controller returns HTTP 200 for its application response envelope, including login errors. A frontend must inspect HasError and Errors.

These different errors reveal distinctions about account state. No login throttling, failed-attempt lockout, or MFA enforcement was found in the inspected API/provider code.

## 4. Tokens and session context
Requests supply apitoken and usertoken headers. Middleware also supports query-string fallback and resolves application/user context, organization information, caller identifiers, and cached permissions.

The user token is generated from a GUID using BCrypt.HashString; it is a custom token, not a JWT. AAC.usp_CreateUserToken persists the token alongside user/application-related inputs and an IP value. Recording IP does not establish IP-bound session enforcement.

AAC.usp_VerifyUserToken receives the API/user tokens, validateBothToken, and slidingExpiration flags. Helper defaults request both-token validation and sliding expiration. Exact expiration and extension rules depend on SQL procedures that were unavailable.

AuthenticationProvider.Logout calls AAC.usp_ExpireUserToken. No exposed logout controller endpoint was found, and no refresh-token endpoint was established.

### Important enforcement gap
AuthenticationHelper has AUTHENTICATION_FAILURE assignment commented out in both missing-token and invalid-token branches. Those branches clear cache but may return an ErrorResponse whose HasError is false. Therefore, calling the helper does not establish reliable rejection of an invalid session.

The KYC upload endpoint separately checks caller user ID and nonempty usertoken. This supplements that endpoint's checks; it does not fix the shared helper.

## 5. Authorization and organization checks
Permission records are loaded using AAC.usp_GetUserAccessPermissions and cached by application ID and user token. Records include RoleID and PermissionID.

AuthorizationHelper searches for a matching required PermissionID. Missing permission lists or no match produce AUTHORIZATION_FAILURE. It does not reload missing permissions itself.

AuthenticateAndAuthorize invokes that helper only when accessType is not NONE. Many reviewed controllers use the default NONE. The application therefore has a permission-check mechanism, but uniform operation-specific authorization was not demonstrated.

### KYC access example
POST /UserMgr/UploadUserKycFile loads the target and caller records:
- Own-user uploads are allowed by this ownership check.
- Same-organization uploads pass this organization check.
- A different organization requires UPLOAD_KYC permission.
- Failed explicit permission checks return HTTP 403.

This check is specific to KYC upload. It does not establish organization isolation for every read/write endpoint.

## 6. Password security
Reviewed user/password methods hash passwords using BCrypt.HashPassword. Login and password-change logic use BCrypt.Verify instead of plaintext equality.

PasswordChecker.IsStrongPassword requires:
- At least eight characters.
- An uppercase letter and a lowercase letter.
- A digit or one of the helper's accepted special characters.

The authentication provider applies this policy in password-change and OTP-reset methods. Password change verifies the old password before submitting the update.

Limits:
- Password-change/reset provider methods do not by themselves establish exposed HTTP endpoints.
- ForgotPassword and ResetPassword contain placeholder behavior.
- The OTP-reset path exists, but OTP issuance, attempt limits, expiry, and the SQL matching contract were not verified.
- A reviewed UserDetailsProvider method hashes MobileNo as a password value. Hashing does not make a predictable initial credential secret; confirm that method's role and endpoint reachability.
- A universal strength requirement across all creation/reset paths was not established.

## 7. Upload and file controls
| Control | User KYC upload | Company-account attachment |
| --- | --- | --- |
| Allowed extensions | PDF, JPG/JPEG, PNG | PDF, JPG/JPEG, PNG |
| File-size limit | 10 MB; request limit 11 MB | 5 MB on reviewed create flow |
| Content checks | PDF/PNG/JPEG signature prefix | Extension check in reviewed create flow |
| Caller checks | Identity/token presence and ownership/organization/permission logic | Shared authentication helper call |
| Filename | Generated user-ID/GUID-based filename | Generated GUID-based filename |
| Storage | Configured PartnerDocument/user-ID directory | wwwroot/uploads/company-account/organization-ID |

KYC signature checks reject obvious format mismatches; they do not establish full content sanitization or malware scanning.

The application enables static-file serving. Company-account attachments saved beneath wwwroot may be served by static-file middleware, independently of controller checks. Per-file access protection was not demonstrated.

File writes and SQL writes are separate operations. A file saved before business/database failure can remain without a corresponding successful record.

## 8. SQL access and input validation
BaseDatabase uses SqlCommand and SqlParameter; reviewed repository methods pass values as parameters to stored procedures. This keeps those values separate from command text.

Provider validations include required fields, positive identifiers/amounts, nonnegative transaction fees/margins, string normalization, and selected length checks. Controllers also apply endpoint-specific validation and request binding.

These controls are scoped to reviewed operations. The presence of stored procedures does not prove all SQL is injection-safe: dynamic SQL inside procedures and all inline query construction were not reviewed. Database least privilege, encrypted connections, backups, and at-rest encryption are not established by this source review.

## 9. Audit trail
POST /AA/Login has AuditApi configured to include headers and response body, while excluding request body and model state.

Program startup configures Audit.NET SQL storage:
- Schema/table: dbo.Event.
- Event identifier: EventId.
- Serialized event payload: Data.
- Update timestamp: LastUpdatedDate.

OnEventSaving masks Password when the named userLoginRequest action parameter is available. This is a narrow password mask, not general redaction.

No other AuditApi annotation was found in the searched controllers. Configuring the SQL provider does not automatically establish audit coverage for all actions. Headers and login response bodies can carry tokens; retention, access control, and tamper resistance were not verified.

## 10. Application logging and error disclosure
Controllers that register the exception filter send action exceptions to LoggingService.LogError and return HTTP 500 with a SERVER_ERROR envelope. The filter does not place the exception stack trace into that response.

LoggingService creates structured NLog events with message, stack trace, inner exception, URL, caller metadata, headers, and tokens. The NLOG logger writes Info-and-higher events to the SQL target through dbo.usp_Log_add using LoggingDB.

LogMessage and LogWarning require explicit calls. NLog internal diagnostics are written separately to admin_logging_error.txt.

Logging limitations:
- Token/header properties may expose session credentials in logs.
- A controller exception filter is not a guarantee of handling exceptions throughout middleware/startup.
- Developer exception pages are enabled in the Development environment.
- Logging retention, restricted access, delivery reliability, and log integrity were not tested.

## 11. Cache behavior
Identity and permission records use process-local IMemoryCache entries with a 15-minute absolute expiration. This is not the SQL token expiry.

Invalid-token handling removes raw token keys, while context and permission entries use formatted cache keys. These removals may not invalidate the intended entries. ClearAll currently does nothing. Immediate role-change propagation and logout-driven invalidation are therefore not demonstrated.

NoStore response-cache attributes exist on reviewed controllers, including login and KYC. They do not define how React stores session data or rendered records.

## 12. Configuration, transport, and encryption boundaries
CORS currently permits any origin, method, and header. This enables broad browser API access; it is not an access-control restriction.

Swagger and Swagger UI are enabled without an environment condition in startup. HTTPS redirection, HSTS, rate-limiter registration, and standard ASP.NET authentication/authorization middleware were not found in the inspected startup. TLS and network access controls may exist externally, but were not verified.

Database credential material is present in repository configuration, including nlog.config. Encryption helper code also contains fixed key/IV material. Values are excluded from this document.

An AES helper uses a 16-byte key despite its name containing 256; the name is not evidence of AES-256 protection. No active call sites for the searched AES/RSA helpers were found in API/provider/repository code. Encryption utilities are therefore not evidence that application data or HTTP requests are encrypted.

## 13. React frontend security status
No React source was available. Implemented frontend controls cannot be documented from this repository.

Integration requirements derived from the API contract:
1. Send tokens in headers and avoid the query-string fallback.
2. Inspect HTTP status and the HasError/Errors envelope.
3. Treat UI permission visibility as presentation, with server checks governing access.
4. Define session storage, logout, token redaction, and session recovery.
5. Match endpoint-specific file restrictions before submission.
6. Avoid declaring a successful write solely from HTTP 200.

XSS controls, CSP, cookie flags, CSRF controls, frontend dependency checks, and browser storage protections were not verified.

## 14. Follow-up items
These items are derived from observed code limits; they are not changes made by this documentation task.

| Order | Item | Required outcome |
| --- | --- | --- |
| 1 | Invalid-token handling | Set authentication errors and stop protected execution for missing/invalid tokens. |
| 2 | Endpoint permissions and ownership | Specify required permissions and organization/record checks per operation. |
| 3 | Credentials and token disclosure | Remove committed credential/key material from configuration; redact tokens/headers in audit and logs. |
| 4 | File access | Establish authorized document retrieval and appropriate storage exposure. |
| 5 | Token lifecycle and cache | Expose the intended logout contract; invalidate formatted cache entries and define token TTL. |
| 6 | Deployment boundaries | Confirm frontend origin policy, Swagger access, TLS, and environment configuration. |
| 7 | Password and login controls | Review initial passwords, strength-policy coverage, lockout/throttling, and reset completion. |
| 8 | Audit coverage | Define which operations require audit and verify their capture, access, and retention. |

## 15. Source evidence
The references below point to implementation files. They describe code evidence, not runtime test results.

- [API startup](../FINOVA.API/Program.cs)
- [Login controller](../FINOVA.API/Controllers/AAController.cs)
- [Authentication helper](../FINOVA.API/Security/AuthenticationHelper.cs)
- [Authorization helper](../FINOVA.API/Security/AuthorizationHelper.cs)
- [Authentication provider](../FINOVA.Provider/AuthenticationProvider.cs)
- [Authentication repository](../FINOVA.Repository/AuthenticationRepository.cs)
- [Password policy helper](../FINOVA.Commonlib/Security/PasswordChecker.cs)
- [User details provider](../FINOVA.Provider/UserDetailsProvider.cs)
- [KYC upload](../FINOVA.API/Controllers/UserMgrFilesController.cs)
- [Company-account upload](../FINOVA.API/Controllers/WalletController.cs)
- [Database parameter helpers](../FINOVA.Database/BaseDatabase.cs)
- [Memory cache](../FINOVA.Commonlib/Cache/MemoryCachingService.cs)
- [Exception filter](../FINOVA.API/Common/FINOVAExceptionFilterService.cs)
- [Logging service](../FINOVA.Logging/LoggingService.cs)
- [NLog target configuration](../FINOVA.API/nlog.config)
- [AES utility](../FINOVA.Commonlib/Utility/AESEncDec256.cs)
