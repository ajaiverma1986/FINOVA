using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.UserMgr
{
    public class GetUserMasterResponse
    {
        // =========================================================
        // USER DETAILS
        // =========================================================

        public long UserMasterID { get; set; }

        public long? ParentId { get; set; }

        public int? UserTypeId { get; set; }
        public string? UserTypeName { get; set; }

        public long? OrganizationID { get; set; }
        public string? OrganizationName { get; set; }

        public string? DomainUserName { get; set; }
        public string? UserName { get; set; }

        public string? Title { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }

        public int GenderID { get; set; }

        public bool IsPasswordExpired { get; set; }

        public long UserId { get; set; }

        public bool IsLocked { get; set; }
        public DateTimeOffset? LockedTill { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }
        public string? RemarkReason { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }


        // =========================================================
        // DISTRIBUTOR DETAILS
        // =========================================================

        public long? DSUserMasterID { get; set; }

        public string? DSCode { get; set; }

        public string? DSName { get; set; }

        public string? DSEmail { get; set; }

        public string? DSMobileNo { get; set; }


        // =========================================================
        // MASTER DISTRIBUTOR DETAILS
        // =========================================================

        public long? MDSUserMasterID { get; set; }

        public string? MDSCode { get; set; }

        public string? MDSName { get; set; }

        public string? MDSEmail { get; set; }

        public string? MDSMobileNo { get; set; }
    }
    public class GetUserAddressResponse
    {
        public long UserAddressID { get; set; }
        public long UserMasterId { get; set; }

        public int AddressTypeId { get; set; }
        public string? AddressTypeName { get; set; }

        public string Pincode { get; set; }
        public long PincodeDataId { get; set; }

        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
    public class GetUserKycResponse
    {
        public long UserKYCID { get; set; }
        public long UserMasterId { get; set; }

        public int KycID { get; set; }
        public string? KycTypeName { get; set; }

        public string? DocumentNo { get; set; }
        public string? FileUrl { get; set; }
        public string? MediaExtension { get; set; }
        public string? MediaContentType { get; set; }
        public string? RejectedReason { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
    public class GetUserConfigurationResponse
    {
        public long ConfigurationId { get; set; }
        public long UserMasterId { get; set; }

        public decimal MinTxn { get; set; }
        public decimal MaxTxn { get; set; }

        public int ChargeTypeOn { get; set; }

        public int PlanId { get; set; }
        public string? PlanName { get; set; }

        public decimal MaxPayinamount { get; set; }
        public int MaxNoofcountPayin { get; set; }
        public int SameAmountPayinAllowed { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
    public class GetOtherDetailsResponse
    {
        public long OtherDetailId { get; set; }
        public long? UserMasterId { get; set; }

        public string? Pancard { get; set; }
        public string? AadharCard { get; set; }
        public string? GSTNo { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
    public class GetUserRoleResponse
    {
        public long UserRoleID { get; set; }

        public long UserMasterID { get; set; }

        public string? UserName { get; set; }
        public string? DisplayName { get; set; }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }

        public short RoleID { get; set; }

        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }

        public byte ApplicationID { get; set; }

        public byte Status { get; set; }
        public string? StatusName { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string? UpdatedByName { get; set; }
    }
    public class GetActiveUserRoleResponse
    {
        public long UserRoleID { get; set; }

        public long UserMasterID { get; set; }

        public short RoleID { get; set; }

        public string? RoleName { get; set; }

        public byte ApplicationID { get; set; }
    }
    public class ResetUserPasswordResponse
    {
        public bool IsPasswordReset { get; set; }

        public long UserMasterID { get; set; }

        public string? Message { get; set; }
    }
    public class GenerateUserCodeResponse
    {
        public string? UserCode { get; set; }
    }
    public class MapUserParentResponse
    {
        public long UserMasterID { get; set; }
        public long? ParentId { get; set; }
        public int? UserTypeId { get; set; }
        public int OrganizationID { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
    public class GetUserWalletResponse
    {
        public long UserDetailId { get; set; }

        public long? UserMasterId { get; set; }
        public string? UserName { get; set; }

        public decimal AvailableLimit { get; set; }
        public decimal ThresoldLimit { get; set; }
        public string? RemarkReason { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string? UpdatedByName { get; set; }
    }

    public class UpdateUserWalletResponse
    {
        public long UserDetailId { get; set; }
        public bool IsUpdated { get; set; }
        public string? Message { get; set; }
    }

    public class DeleteUserWalletResponse
    {
        public long UserDetailId { get; set; }
        public bool IsDeleted { get; set; }
        public string? Message { get; set; }
    }
    public class UpdateUserWalletThresoldLimitResponse
    {
        public long UserDetailId { get; set; }

        public long UserMasterId { get; set; }

        public decimal AvailableLimit { get; set; }

        public decimal ThresoldLimit { get; set; }

        public DateTime? ThresoldOn { get; set; }

        public long? ThresoldBy { get; set; }

        public string? ThresoldReason { get; set; }

        public bool IsUpdated { get; set; }

        public string? Message { get; set; }
    }
    public class GetThresoldUserListResponse
    {
        public long UserMasterID { get; set; }

        public long? ParentId { get; set; }
        public int? UserTypeId { get; set; }
        public int OrganizationID { get; set; }

        public string? UserName { get; set; }

        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public string? FullName { get; set; }
        public string? DisplayName { get; set; }

        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }

        public int UserStatus { get; set; }
        public string? UserStatusName { get; set; }

        // Wallet
        public long? UserDetailId { get; set; }

        public decimal AvailableLimit { get; set; }
        public decimal ThresoldLimit { get; set; }

        public DateTime? ThresoldOn { get; set; }
        public long? ThresoldBy { get; set; }
        public string? ThresoldReason { get; set; }

        public int? WalletStatus { get; set; }
        public string? WalletStatusName { get; set; }
        public string? UserTypeName { get; set; }

        // Threshold changed by
        public string? ThresoldByUserName { get; set; }
        public string? ThresoldByName { get; set; }
    }
}
