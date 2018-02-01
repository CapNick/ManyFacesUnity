using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers { 
    public class StaffUIController : MonoBehaviour {

        public Models.StaffData staffData { set; private get; }

        public GameObject staffMemberPrefab;

        public GameObject staffList;

        List<GameObject> staffUIElements = new List<GameObject>();

	    // Use this for initialization
	    void Start () {
		    if(staffData != null) {

            }
	    }
	
	    // Update is called once per frame
	    void Update () {
		    
	    }
    }
}