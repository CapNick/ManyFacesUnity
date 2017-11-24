using UnityEngine;
using System.Collections.Generic;
using System.Net;
using Models;

namespace Controllers {
    public class StaffController : MonoBehaviour {
        //url to the json data, this is going to change to the actual application
        private string _uri = "https://dev.capnick.co.uk/data.json";
        
        private List<Staff> _staffList = new List<Staff>();

        public void Start() {
                                   
            WebClient client = new WebClient ();
            

//            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
            
            ServicePointManager.ServerCertificateValidationCallback =
                delegate
                { return true; };

            // Add json header in case the 
            // requested URI contains a query.

            client.Headers.Add(HttpRequestHeader.ContentType, "text/json");
            string reply = client.DownloadString (_uri);
            
        }
        
    }
}