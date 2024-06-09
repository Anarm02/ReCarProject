using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string isAdded = "Car added";
        public static string nameInvalid = "Invalid name";
        public static string isDeleted = "Car Deleted";
        public static string isUpdated = "Car updated";
        public static string CarImagesCount="Can't add more images";
        public static string  userNotExist="This user does'nt exist";
        public static string PasswordError="Wrong Password";
        public static string SuccessfullLogin="Login Successfull";
        public static string UserAlreadyExist="User already exist";
        public static string UserRegistered="User registered successfull";
        internal static string? AuthorizationDenied="You have no authority";
    }
}
