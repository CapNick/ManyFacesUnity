using Models;
using UnityEngine;

namespace Controllers {
    public class HandSelectorController : MonoBehaviour {
        public Camera MainCamera;
        public GameObject StaffPanel;
        
        public float FaceWidth = 2.553752f;
        public float FaceHeight = 2.553752f;

        private LayoutLoader layout;

        public void Start() {
            layout = new LayoutLoader();
            layout.Getlayout();
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
                    StaffPanel.SetActive(true);
                    StaffPanel.GetComponent<UI.Staff>().AssignedStaff = face.Staff;
                    MoveStaffPanel(face);
                }
                else {
                    StaffPanel.GetComponent<UI.Staff>().ClearStaff();
                    StaffPanel.SetActive(false);
                }
            }
        }

        private void MoveStaffPanel(Face face) {
            //TODO: This wil need some better configuring in the future
            if (face.Location.x < layout.BoardLayout.width-2) {
//                face.transform.position + face.GetComponent<Collider>().bounds.size.x / 2 + ;
                StaffPanel.transform.position =  new Vector3(face.transform.position.x + (FaceWidth / 2), face.transform.position.y+FaceHeight, -2f);

            }
            else {
                StaffPanel.transform.position = new Vector3(face.transform.position.x - (FaceWidth * FaceWidth) - (FaceWidth / 3) , face.transform.position.y+FaceHeight, -2f);
            }
        }
    }
}