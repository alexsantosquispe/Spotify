using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotify.Utils;

namespace Spotify.Test
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void ValidatorIsEmail()
        {
            string email1 = "",
                email2 = "juan.perez",
                email3 = "juan.perez@jalasoft.com";

            Assert.IsFalse(Validator.isEmailAddress(email1));
            Assert.IsFalse(Validator.isEmailAddress(email2));
            Assert.IsTrue(Validator.isEmailAddress(email3));
            Assert.IsFalse(Validator.isEmailAddress(null));
        }

        [TestMethod]
        public void ValidatorIsEmpty()
        {
            string word1 = "",
                word2 = "this is a test",
                word3 = "     ";

            Assert.IsTrue(Validator.IsEmpty(word1));
            Assert.IsFalse(Validator.IsEmpty(word2));
            Assert.IsFalse(Validator.IsEmpty(word3));
        }
    }
}
