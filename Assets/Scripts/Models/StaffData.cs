using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace Models { 
    public class StaffData {
        public List<Staff> Members { get; private set; }
        private string dataAsJson;
        private string filename;

        public StaffData(string filename) {
            this.filename = filename;
        }

        //loads data from a json string and serializes it into the members array
        public string LoadAllData () {
            //we look inside of streaming assets for the file (temp solution)
            //TODO: Look up website to check for changes if changes exsist download the file and overwrite.
            string filePath = Path.Combine(Application.streamingAssetsPath, filename);
            if (File.Exists(filePath)) {
                dataAsJson = File.ReadAllText(filePath);
                // Pass the json to JsonUtility, and tell it to create a GameData object from it.
                Members = JsonConvert.DeserializeObject<List<Staff>>(dataAsJson);
                LoadModels();
                return "StaffData ==> Staff Data Loaded Sucessfully";
            }
            else {
                return "StaffData ==> There was an issue with loading the staff data";
            }
            
            
        }

        public void LoadModels() {
            string filePath = Application.streamingAssetsPath;
            foreach (var staff in Members) {
                if (staff.visible) {
                    if (File.Exists(Path.Combine(filePath, "testing.fbx"))) {
                        
                    }
                }
            }
        }
        
        //checks data currently in the array to see if the members of staff have been updated
        public void UpdateData () {
            //TODO
        }

        public bool CheckForUpdates () {
            return false;
        }
	    
    }
}