using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace Models { 
    public class StaffData {

        public List<Staff> Members { get; private set; }

        private string dataAsJson;
        //loads data from a json string and serializes it into the members array
        public string LoadData (string fileName) {
            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
            if (File.Exists(filePath)) {
                dataAsJson = File.ReadAllText(filePath);
                // Pass the json to JsonUtility, and tell it to create a GameData object from it.
                Members = JsonConvert.DeserializeObject<List<Staff>>(dataAsJson);
                return "StaffData ==> Staff Data Loaded Sucessfully";
            }
            else {
                return "StaffData ==> There was an issue with loading the staff data";
            }
        }
        //checks data currently in the array to see if the members of staff have been updated
        public void UpdateData (string jsonString) {
            //TODO
        }


	
	    
    }
}