using Common.Queries;
using DVLD_DAL;
using DVLD_DTO;
using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{

    public class clsUser_BLL : IBLL
    {

        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;

        public clsUser_DTO User { get; set; }
        public IDTO DTO { get => User; set => value = User; }

        public clsUser_BLL()
        {
            this.User = new clsUser_DTO
            {
                UserID = -1,
                UserName = string.Empty,
                Password = string.Empty,
                IsActive = false,
                Permissions = 0,

                PersonID = -1,
                NationalNo = "",
                FirstName = string.Empty,
                SecondName = string.Empty,
                ThirdName = string.Empty,
                LastName = string.Empty,
                DateOfBirth = DateTime.Now,
                Gendor = 0,
                Address = string.Empty,
                Phone = string.Empty,
                Email = string.Empty,
                NationalityCountryID = -1,
                ImagePath = string.Empty
            };
            this.Mode = enMode.Create;
        }

        public clsUser_BLL(clsUser_DTO User)
        {
            this.User = User;

            this.Mode = enMode.Update;
        }

        public static int GetCount(IQuery query)
        {
            return clsUser_DAL.LoadCount(query as clsUserQuery);
        }
        private bool _AddNewUser()
        {

            this.User.UserID = clsUser_DAL.CreateUser(this.User);
            return (this.User.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUser_DAL.UpdateUser(this.User);
        }

        public static clsUser_BLL Find(int UserID)
        {
            clsUser_DTO Model = clsUser_DAL.LoadUserByID(UserID);

            return Model == null ? null : new clsUser_BLL(Model);
        }
        public static clsUser_BLL Find(string UserName)
        {
            clsUser_DTO Model = clsUser_DAL.LoadUserByUserName(UserName);

            return Model == null ? null : new clsUser_BLL(Model);
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUser_DAL.DeleteUser(UserID);
        }
        public static bool DeleteUserByPersonID(int PersonID)
        {
            return clsUser_DAL.DeleteUserByPersonID(PersonID);
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateUser();

            }

            return false;
        }

        public static bool Login(string UserName, string Password)
        {
            clsCurrentUser.SetUser( clsUser_DAL.Login(UserName, Password));
            return clsCurrentUser.User != null;
        }

        public bool CheckAccessPermission(int Permission)
        {

            if (this.User.Permissions == -1) return true;


            return ((this.User.Permissions & Permission) == Permission);
        }
        public static List<clsUser_DTO> GetUsers()
        {
            return clsUser_DAL.LoadUsers();
        }
        public static List<clsUser_DTO> GetUsers(int Offset, int CountRows, IQuery Query)
        {
            return clsUser_DAL.LoadUsers(Offset, CountRows , Query as clsUserQuery);
        }

    }
}
