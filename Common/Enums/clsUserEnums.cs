using System;


namespace Common
{
    public class clsUserEnums
    {
        [Flags] 
        public enum enPermissions
        {
            None = 0,
            ManagePeople = 1 << 0,
            ManageDrivers = 1 << 1,
            ManageUsers = 1 << 2,
            ManageApplications = 1 << 3,
            ManageTests = 1 << 4,
            ManageLicenses = 1 << 5,
            
            All = -1
        }
        public enum enUserSearchBy
        {
            UserID = 1,
            UserName = 2,
            NationalNo = 3,
            PersonID = 4
        }
        public enum enUserOrderBy
        {
            UserID = 1,
            UserName = 2,
            IsActive = 3,
            NationalNo = 4,
            Gendor = 5,
            NationalityCountryID = 6,
            PersonID = 7
        }

    }
}
