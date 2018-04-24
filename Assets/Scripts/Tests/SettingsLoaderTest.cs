using Controllers;
using NUnit.Framework;
namespace Tests {
    public class SettingsLoaderTest {
        [Test]
        public void ReturnsSettingsFromFile() {
            Assert.AreEqual("SettingsLoader ==> Loaded Settings Sucsessfully" ,SettingsLoader.Instance.LoadSettings());
            
        }
        [Test]
        public void ReturnsSettingsStaffUrl() {
            SettingsLoader.Instance.LoadSettings();
            Assert.AreEqual("http://localhost:3000/faces/collection.json", SettingsLoader.Instance.Setting.staff_url);
        }
        [Test]
        public void ReturnsSettingsLayoutUrl() {
            SettingsLoader.Instance.LoadSettings();
            Assert.AreEqual("http://localhost:3000/layouts.json", SettingsLoader.Instance.Setting.layout_url);
        }
        [Test]
        public void ReturnsSettingsBaseUrl() {
            SettingsLoader.Instance.LoadSettings();
            Assert.AreEqual("http://localhost:3000/", SettingsLoader.Instance.Setting.base_url);
        }
        
    }
}