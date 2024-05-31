namespace demonstrating_solid_principles.Classes
{
    public interface IAuthWithFacebook
    {
        public bool VerifyFacebookAcc(string facebookId, string email, string password);
    }
    
    public interface IAuthWithEmail
    {
        public bool VerifyAcc(string email, string password);
    }

    public class AuthWithFacebook : IAuthWithFacebook
    {
        public bool VerifyFacebookAcc(string facebookId, string email, string password)
        {
            var listOfSocialMediaUsername = new string[] { "jon", "dawg", "gaurav", "joerogan" };
            if (facebookId is not null && listOfSocialMediaUsername.Contains(facebookId) && password.Length > 8)
                return true;

            return false;
        }
    }


    public class AuthWithEmail : IAuthWithEmail
    {
        public bool VerifyAcc(string email, string password)
        {
            var listOfEmail = new string[] { "jon@gmail.com", "dawg@gmail.com", "gaurav@gmail.com", "joerogan@gmail.com" };
            if (email is not null && listOfEmail.Contains(email) && password.Length > 8)
                return true;

            return false;
        }
    }


    public class CallingCode(IAuthWithFacebook _authWithFacebook)
    {
        private readonly IAuthWithFacebook authWithFacebook = _authWithFacebook;

        public bool VerifyAuth(string userName, string email, string password)
        {
            return _authWithFacebook.VerifyFacebookAcc(userName, email, password);
        }
    }
}
