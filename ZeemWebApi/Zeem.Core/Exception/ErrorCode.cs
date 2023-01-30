namespace Zeem.Core.Exception
{
    public enum ErrorCode
    {
        UserRegistration_Password_Not_Matched = 10001,
        UserRegistration_Email_Already_Exist = 10002,
        UserRegistration_Username_Already_Exist = 10003,

        UserAuthentication_Mobile_Not_Verified = 10011,
        UserAuthentication_Email_Not_Verified = 10012,
        UserAuthentication_User_Is_Locked = 10013,
        UserAuthentication_Invalid_Username_Or_Password = 10014,
    }
}
