using Models;
using UnityEngine;

namespace Controllers {
    public class HandSelectorController : MonoBehaviour {
        public Camera MainCamera;
        
        public GameObject StaffPanel;

        private float width;
        private float height;
        
        private const float FaceWidth = 2.553752f;
        private const float FaceHeight = 3.537174f;

        public void Start() {
            width = StaffPanel.GetComponent<RectTransform>().rect.width;
            height = StaffPanel.GetComponent<RectTransform>().rect.height;
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
                    Face2 face = hit.collider.GetComponent<Face2>();
                    StaffPanel.GetComponent<UI.Staff>().AssignedStaff = face.staff;
                    MoveStaffPanel(face);
                }
                else {
                    StaffPanel.GetComponent<UI.Staff>().ClearStaff();
                }
            }
        }

        private void MoveStaffPanel(Face2 face) {
            //TODO: This wil need some better configuring in the future
            if (face.Location.x < 8) {
//                face.transform.position + face.GetComponent<Collider>().bounds.size.x / 2 + ;
                StaffPanel.transform.position = MainCamera.WorldToScreenPoint(new Vector3(face.transform.position.x + FaceWidth/2 + width/2, face.transform.position.y + FaceHeight/2 + height/2)) ;

            }
            else {
                StaffPanel.transform.position = MainCamera.WorldToScreenPoint(new Vector3(face.transform.position.x - FaceWidth/2 - width/2, face.transform.position.y + FaceHeight/2 + height/2)) ;

            }
        }
    }
}