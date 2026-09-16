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
}
