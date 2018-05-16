using System.Collections.Generic;
using Models;
using Newtonsoft.Json;
using UnityEngine;

namespace Controllers {
    public class LayoutLoader {
        public Layout BoardLayout;

        public bool Getlayout() {
            WWW webRequest = new WWW(SettingsLoader.Instance.Setting.layout_url);
            while (!webRequest.isDone) {
                //infinate loop to make sure it is fully downloaded before proceeding.
            }
            string json = webRequest.text;
            if (json != "") {
                BoardLayout = JsonConvert.DeserializeObject<List<Layout>>(json)[0];
                
                return true;
            }

            return false;
        }
        
    }
}