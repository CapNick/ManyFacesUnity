using Models;
using UnityEngine;

namespace Controllers {
    public class HandSelectorController : MonoBehaviour {
        public Camera MainCamera;

        public GameObject previousSelected;

        private float holdCounter;
        
        public UI.Staff StaffPannel;
        
        public void Update() {
            Vector3 position = Input.mousePosition;
            position.z = 10;
            
            transform.position = MainCamera.ScreenToWorldPoint(position);

            Debug.Log(holdCounter);
            
            RaycastHit hit;
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                if (objectHit.CompareTag("Face")) {

                    if (previousSelected != null ) {
                        
                        holdCounter++;
                        if (holdCounter > 100) {
                            objectHit.gameObject.GetComponent<Face2>().Selected = true;
                            StaffPannel.AssignedStaff = objectHit.GetComponent<Face2>().staff;
                        }
                    }
                    else {
                        previousSelected = objectHit.gameObject;
                        objectHit.gameObject.GetComponent<Face2>().Selected = false;
                        holdCounter = 0;
                        StaffPannel.AssignedStaff = null;
                    }

//                    objectHit.GetComponent<Renderer>().material.color = Color.black;
                    
                }
                else {
                    if (previousSelected != null) {
                        objectHit.gameObject.GetComponent<Face2>().Selected = false;
//                        previousSelected = null;
                        StaffPannel.AssignedStaff = null;
                        holdCounter = 0;
                    }
                }
            }

        }
        
        
    }
}