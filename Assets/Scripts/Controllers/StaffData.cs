using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;
using Newtonsoft.Json;
using UnityEngine;

namespace Controllers { 
    public class StaffData {
        public List<Staff> Members { get; private set; }

        public StaffData() {
            Members = new List<Staff>();
        }

        //loads data from a json string and serializes it into the members array
        public string UpdateStaff () {
            List<Staff> members = GetStaff();

            if (members.Count > 0) {
                Members = members;
                OrderStaff();
                return "StaffData ==> Staff Data Loaded Sucessfully";
            }
            return "StaffData ==> There was an issue with loading the staff data";
        }
        
        private void OrderStaff() {
            Members = Members.OrderBy(s => s._index).ToList();
        }

        private List<Staff> GetStaff() {
            List<Staff> tempList = new List<Staff>();
            WWW webRequest = new WWW(SettingsLoader.Instance.Setting.staff_url);
            while (!webRequest.isDone) {
                //infinate loop to make sure it is fully downloaded before proceeding.
            }
            string json = webRequest.text;
            
            if (json != "") {
                tempList = JsonConvert.DeserializeObject<List<Staff>>(json);
            }

            return tempList;
        }

        public bool CheckForUpdates () {
            
            return false;
        }

        public Staff GetStaffMember(int index) {
            return Members.Find(staff => staff._index == index);
        }
	    
    }
}