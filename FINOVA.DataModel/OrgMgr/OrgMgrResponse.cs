

namespace FINOVA.DataModel.OrgMgr
{
    public class GetOrganizationResponse
    {
        public long OrganizationID { get; set; }

        public Guid OrganizationUID { get; set; }

        public string OrganizationCode { get; set; }

        public string OrganizationName { get; set; }

        public int? OrganizationTypeID { get; set; }

        public string? DisplayName { get; set; }

        public string? LegalName { get; set; }

        public string? Email { get; set; }

        public string? MobileNo { get; set; }

        public string? PhoneNo { get; set; }

        public string? Website { get; set; }

        public string? RegistrationNo { get; set; }

        public string? GSTIN { get; set; }

        public string? PAN { get; set; }

        public string? TAN { get; set; }

        public string? LogoPath { get; set; }

        public int? CurrencyID { get; set; }

        public int? TimeZoneID { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
