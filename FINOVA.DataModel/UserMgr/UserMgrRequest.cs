

using Microsoft.AspNetCore.Http;

namespace FINOVA.DataModel.UserMgr
{
    public class ChangeUserPasswordRequest
    {
        public long UserMasterID { get; set; }

        public string Password { get; set; }

        public bool IsPasswordExpired { get; set; }
    }


    public class LockUserMasterRequest
    {
        public long UserMasterID { get; set; }

        public DateTimeOffset? LockedTill { get; set; }

        public string? RemarkReason { get; set; }
    }
    public class CreateUserMasterRequest
    {
        public int? UserTypeId { get; set; }

        public int OrganizationID { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Title { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public int GenderID { get; set; }

        public bool IsPasswordExpired { get; set; } = false;

        public long UserId { get; set; } = 0;

        public bool IsLocked { get; set; } = false;

        public DateTimeOffset? LockedTill { get; set; }

        public int Status { get; set; } = 1;

        public string? EmailId { get; set; }

        public string? MobileNo { get; set; }

        public string? RemarkReason { get; set; }
    }
    public class UpdateUserMasterRequest
    {
        public long UserMasterID { get; set; }

        public int? UserTypeId { get; set; }

        public int OrganizationID { get; set; }

        public string? UserName { get; set; }

        public string? Title { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public int GenderID { get; set; }

        public int Status { get; set; }

        public string? EmailId { get; set; }

        public string? MobileNo { get; set; }

        public string? RemarkReason { get; set; }
    }
    public class CreateUserAddressRequest
    {
        public long UserMasterId { get; set; }
        public int AddressTypeId { get; set; }
        public string Pincode { get; set; }
        public long PincodeDataId { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int Status { get; set; } = 1;
    }

    public class UpdateUserAddressRequest
    {
        public long UserAddressID { get; set; }
        public long UserMasterId { get; set; }
        public int AddressTypeId { get; set; }
        public string Pincode { get; set; }
        public long PincodeDataId { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int Status { get; set; }
    }
    public class CreateUserKycRequest
    {
        public long UserMasterId { get; set; }
        public int KycID { get; set; }
        public string? DocumentNo { get; set; }
        public string? FileUrl { get; set; }
        public string? MediaExtension { get; set; }
        public string? MediaContentType { get; set; }
        public string? RejectedReason { get; set; }
        public int Status { get; set; } = 1;
    }
    public class CreateUserKycUploadRequest
    {
        public long UserMasterId { get; set; }

        public int KycID { get; set; }

        public string? DocumentNo { get; set; }

        public IFormFile? File { get; set; }

        public string? RejectedReason { get; set; }

        public int Status { get; set; } = 1;
    }

    public class UpdateUserKycRequest
    {
        public long UserKYCID { get; set; }
        public long UserMasterId { get; set; }
        public int KycID { get; set; }
        public string? DocumentNo { get; set; }
        public string? FileUrl { get; set; }
        public string? MediaExtension { get; set; }
        public string? MediaContentType { get; set; }
        public string? RejectedReason { get; set; }
        public int Status { get; set; }
    }
    public class UpdateUserKycUploadRequest
    {
        public long UserKycMasterId { get; set; }

        public long UserMasterId { get; set; }

        public int KycID { get; set; }

        public string? DocumentNo { get; set; }

        public IFormFile? File { get; set; }

        public string? RejectedReason { get; set; }

        public int Status { get; set; } = 1;
    }
    public class CreateUserBankAccountRequest
    {
        public long UserMasterID { get; set; }
        public long BankId { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string Ifsccode { get; set; }
        public string? BranchAddress { get; set; }
        public string? FileUrl { get; set; }

        public string? MediaExtension { get; set; }

        public string? MediaContentType { get; set; }
        public string? RejectedReason { get; set; }
        public int Status { get; set; } = 1;
    }

    public class UpdateUserBankAccountRequest
    {
        public long OriginatorAccountID { get; set; }
        public long UserMasterID { get; set; }
        public long BankId { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string Ifsccode { get; set; }
        public string? BranchAddress { get; set; }
        public string? FileUrl { get; set; }

        public string? MediaExtension { get; set; }

        public string? MediaContentType { get; set; }
        public string? RejectedReason { get; set; }
        public int Status { get; set; }
    }
    public class CreateUserBankAccountUploadRequest
    {
        public long UserMasterID { get; set; }

        public int BankId { get; set; }

        public string? AccountName { get; set; }

        public string? AccountNo { get; set; }

        public string? Ifsccode { get; set; }

        // Add your other existing fields here

        public IFormFile? File { get; set; }

        public int Status { get; set; } = 1;
    }
    public class UpdateUserBankAccountUploadRequest
    {
        public long OriginatorAccountID { get; set; }

        public long UserMasterID { get; set; }

        public int BankId { get; set; }

        public string? AccountName { get; set; }

        public string? AccountNo { get; set; }

        public string? Ifsccode { get; set; }

        // Add your other existing fields here

        // Optional during update
        public IFormFile? File { get; set; }

        public int Status { get; set; } = 1;
    }
    public class GetUserBankAccountResponse
    {
        public long OriginatorAccountID { get; set; }

        public long UserMasterID { get; set; }

        public long BankId { get; set; }
        public string? BankName { get; set; }

        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string Ifsccode { get; set; }

        public string? BranchAddress { get; set; }
        public string? Filename { get; set; }
        public string? RejectedReason { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class CreateUserConfigurationRequest
    {
        public long UserMasterId { get; set; }
        public decimal MinTxn { get; set; } = 0;
        public decimal MaxTxn { get; set; } = 0;
        public int ChargeTypeOn { get; set; } = 2;
        public int PlanId { get; set; } = 1;
        public decimal MaxPayinamount { get; set; } = 0;
        public int MaxNoofcountPayin { get; set; } = 0;
        public int SameAmountPayinAllowed { get; set; } = 0;
    }

    public class UpdateUserConfigurationRequest
    {
        public long ConfigurationId { get; set; }
        public long UserMasterId { get; set; }
        public decimal MinTxn { get; set; }
        public decimal MaxTxn { get; set; }
        public int ChargeTypeOn { get; set; }
        public int PlanId { get; set; }
        public decimal MaxPayinamount { get; set; }
        public int MaxNoofcountPayin { get; set; }
        public int SameAmountPayinAllowed { get; set; }
    }
    public class CreateOtherDetailsRequest
    {
        public long? UserMasterId { get; set; }
        public string? Pancard { get; set; }
        public string? AadharCard { get; set; }
        public string? GSTNo { get; set; }
        public int Status { get; set; } = 1;
    }

    public class UpdateOtherDetailsRequest
    {
        public long OtherDetailId { get; set; }
        public long? UserMasterId { get; set; }
        public string? Pancard { get; set; }
        public string? AadharCard { get; set; }
        public string? GSTNo { get; set; }
        public int Status { get; set; }
    }
    public class CreateUserRoleRequest
    {
        public long UserMasterID { get; set; }
        public short RoleID { get; set; }
        public byte ApplicationID { get; set; }
        public byte Status { get; set; } = 1;
    }

    public class UpdateUserRoleRequest
    {
        public long UserRoleID { get; set; }
        public long UserMasterID { get; set; }
        public short RoleID { get; set; }
        public byte ApplicationID { get; set; }
        public byte Status { get; set; }
    }

    public class GetUserRoleRequest
    {
        public long? UserRoleID { get; set; }
        public long? UserMasterID { get; set; }
        public short? RoleID { get; set; }
        public byte? ApplicationID { get; set; }
        public byte? Status { get; set; }
    }
    public class GetUserRolesByUserRequest
    {
        public long UserMasterID { get; set; }

        public byte? ApplicationID { get; set; }

        public byte? Status { get; set; }
    }


    public class GetUserRolesByRoleRequest
    {
        public short RoleID { get; set; }

        public byte? ApplicationID { get; set; }

        public byte? Status { get; set; }
    }


    public class GetActiveUserRolesRequest
    {
        public long UserMasterID { get; set; }

        public byte ApplicationID { get; set; }
    }
}
