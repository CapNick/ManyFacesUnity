using Models;
using UnityEngine;

namespace Controllers {
    public class HandSelectorController : MonoBehaviour {
        public Camera MainCamera;
        public GameObject StaffPanel;
        
        private const float FaceWidth = 2.553752f;
        private const float FaceHeight = 3.537174f;

        public void Start() {

        }
        
        public void Update() {
            Vector3 position = Input.mousePosition;
            
            transform.position = MainCamera.ScreenToWorldPoint(position);
            HoverSelect(position);
        }

        private void HoverSelect(Vector3 position) {
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.CompareTag("Face")) {
                    Face face = hit.collider.GetComponent<Face>();
                    StaffPanel.GetComponent<UI.Staff>().AssignedStaff = face.Staff;
                    MoveStaffPanel(face);
                }
                else {
                    StaffPanel.GetComponent<UI.Staff>().ClearStaff();
                }
            }
        }

        private void MoveStaffPanel(Face face) {
            //TODO: This wil need some better configuring in the future
            if (face.Location.x < 8) {
//                face.transform.position + face.GetComponent<Collider>().bounds.size.x / 2 + ;
                StaffPanel.transform.position =  new Vector3(face.transform.position.x + FaceWidth/2, face.transform.position.y + FaceHeight/2, -2f);

            }
            else {

            }
        }
    }
}