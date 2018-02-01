using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Controllers {
    public class StaffController : MonoBehaviour {
        //url to the json data, this is going to change to the actual application
        private string _uri = "https://dev.capnick.co.uk/faces.json";
        private string file = "faces.json";
        private StaffData staffData = new StaffData();        

        public void Start () {
            DontDestroyOnLoad(gameObject);
            Debug.Log(staffData.LoadData(file));
        }

        private void LoadStaffData (string rawJson) {

        }

    }
}