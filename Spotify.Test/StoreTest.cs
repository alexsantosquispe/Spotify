using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotify.Test.Mock;
using Spotify.Utils;

namespace Spotify.Test
{
    [TestClass]
    public class StoreTest
    {
        [TestMethod]
        public void GetValue()
        {
            IStore AppStore = new MockStore();
            Assert.IsTrue(AppStore.GetValue("Theme") == "Light");
        }

        [TestMethod]
        public void SetValue()
        {
            IStore AppStore = new MockStore();
            string key = "Theme", value = "Green";
            AppStore.SetValue(key, value);
            Assert.IsTrue(AppStore.GetValue("Theme") == value);
        }

        [TestMethod]
        public void RemoveValue()
        {
            IStore AppStore = new MockStore();
            string key = "Theme";
            AppStore.RemoveValue(key);
            Assert.IsTrue(AppStore.GetValue(key) == null);
        }
    }
}
