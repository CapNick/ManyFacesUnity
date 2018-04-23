using System.IO;
using Models;
using Newtonsoft.Json;
using UnityEngine;

namespace Controllers {

    public sealed class SettingsLoader {
        private static volatile SettingsLoader instance;
        private static object syncRoot = new Object();

        public Settings Setting { get; private set; }
        private string _filename = "config.json";

        private SettingsLoader() {
        }

        public static SettingsLoader Instance {
            get {
                if (instance == null) {
                    lock (syncRoot) {
                        if (instance == null) {
                            instance = new SettingsLoader();
                            instance.LoadSettings();
                        }   
                    }
                }

                return instance;
            }
        }

        public string LoadSettings() {
            string filePath = Path.Combine(Application.streamingAssetsPath, _filename);
            if (File.Exists(filePath)) {
                string dataAsJson = File.ReadAllText(filePath);
                Setting = JsonConvert.DeserializeObject<Settings>(dataAsJson);
                return "SettingsLoader ==> Loaded Settings Sucsessfully";
            }
            return "SettingsLoader ==> Error Loading Settings";
        }
    }
}