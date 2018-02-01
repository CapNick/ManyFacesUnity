using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers { 
    public class StaffUIController : MonoBehaviour {

        public Models.StaffData StaffData { set; private get; }

        public GameObject StaffMemberPrefab;

        public GameObject StaffList;

        List<GameObject> _staffUiElements = new List<GameObject>();

	    // Use this for initialization
	    void Start () {
		    if(StaffData != null) {
				// if staff data is populated instantiate the staff member prefab
			    foreach (Models.Staff staff in StaffData.Members) {
				    GameObject staffMember = Instantiate(StaffMemberPrefab);
				    staffMember.transform.SetParent(StaffList.transform, false);
				    staffMember.GetComponent<UI.Staff>().AssignedStaff = staff;
				    _staffUiElements.Add(staffMember);
			    } 
		    }
	    }
	
	    // Update is called once per frame
	    void Update () {
		    
	    }
    }
}
