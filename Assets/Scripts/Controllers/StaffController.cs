using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Controllers {
    public class StaffController : MonoBehaviour {

        [SerializeField]
        private StaffUIController staffUIController;

        //url to the json data, this is going to change to the actual application
        private string _uri = "https://dev.capnick.co.uk/faces.json";
        private static string file = "faces.json";
        private StaffData staffData = new StaffData(file);  
              

        public void Start () {
            DontDestroyOnLoad(gameObject);
            Debug.Log(staffData.LoadAllData());
            //once we have the data we set the reference to the staff data to the ui controller
            //so that the data can be used
            staffUIController.StaffData = staffData;
        }

        public void Update () {
            // checks if there has been any changes to the data backend
            if (staffData.CheckForUpdates()) {
                //if it has it tells the staffData to update

            }
        }

    }
}
