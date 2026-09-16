

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
   
}
