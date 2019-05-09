using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotify.Service;
using Spotify.Test.Mock;

namespace Spotify.Test
{
    [TestClass]
    public class FireBaseAuthTest
    {
        [TestMethod]
        public void Signin()
        {
            IFirebaseAuth firebaseAuth = new MockFirebaseAuth();
            string email1 = "alex",
                   password1 = "",
                   email2 = "",
                   password2 = "123",
                   email3 = "alex.santos@jalasoft.com",
                   password3 = "123456";

            Assert.IsFalse(firebaseAuth.SignIn(email1, password1));
            Assert.IsFalse(firebaseAuth.SignIn(email2, password2));
            Assert.IsTrue(firebaseAuth.SignIn(email3, password3));
        }
    }
}
