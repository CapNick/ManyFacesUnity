using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;
using Newtonsoft.Json;
using UnityEngine;

namespace Controllers { 
    public class StaffData {
        public List<Staff> Members { get; private set; }
        private string _dataAsJson;
        

        public StaffData() {
            Members = new List<Staff>();
        }

        //loads data from a json string and serializes it into the members array
        public string UpdateStaff () {
            WWW webRequest = new WWW(SettingsLoader.Instance.Setting.staff_url);
            while (!webRequest.isDone) {
                //infinate loop to make sure it is fully downloaded before proceeding.
            }
            string json = webRequest.text;
            if (json != "") {
                Members = JsonConvert.DeserializeObject<List<Staff>>(json);
                OrderStaff();
                return "StaffData ==> Staff Data Loaded Sucessfully";
            }

            return "StaffData ==> There was an issue with loading the staff data";
        }
        
        private void OrderStaff() {
            Members = Members.OrderBy(s => s._index).ToList();
        }

        //checks data currently in the array to see if the members of staff have been updated
        public void UpdateData () {
            //TODO
        }

        public bool CheckForUpdates () {
            return false;
        }

        public Staff GetStaff(int index) {
            return Members.Find(staff => staff._index == index);
        }
	    
    }
}