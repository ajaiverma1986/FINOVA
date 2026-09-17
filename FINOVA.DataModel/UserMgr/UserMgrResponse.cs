using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.UserMgr
{
    public class GetUserMasterResponse
    {
        public long UserMasterID { get; set; }

        public int? UserTypeId { get; set; }
        public string? UserTypeName { get; set; }

        public long? OrganizationID { get; set; }
        public string? OrganizationName { get; set; }

        public string? DomainUserName { get; set; }
        public string? UserName { get; set; }

        public string? Title { get; set; }
        public string FirstName { get; set; }
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
}
