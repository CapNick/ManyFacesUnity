using UnityEngine;

namespace Controllers {
    public class HandSelectorController : MonoBehaviour {
        public Camera MainCamera;

        public Transform previousSelected;

        private float holdCounter;
        
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

                    if (previousSelected.Equals(objectHit)) {
                        holdCounter++;
                    }
                    else {
                        previousSelected = objectHit;
                        holdCounter = 0;
                    }

//                    objectHit.GetComponent<Renderer>().material.color = Color.black;
                    
                }
                else {
                    previousSelected = null;
                    holdCounter = 0;
                }
            }

        }
        
        
    }
}