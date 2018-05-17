using System.Collections.Generic;
using Models;
using OpenTK.Graphics;
using UnityEngine;

namespace Controllers {
    public class FaceLoader : MonoBehaviour {
        
        [Header("Faces Objects")]
        public GameObject FacePrefab;
        public List<GameObject> Faces;

        [Header("Data Loading")] 
        private StaffData _staffData  =  new StaffData();

        [Header("Spawning Area")] 
        private LayoutLoader _layoutLoader = new LayoutLoader();
//        private const float FaceWidth = 2.553752f;
//        private const float FaceHeight = 3.537174f;
        private const float FaceWidth = 1.0f;
        private const float FaceHeight = 1.3f;

        [Header("Screen info")] 
        public float ScreenWidth;
        public float ScreenHeight;
        public int FacesPerLine = 10;
        public int FacesLines = 4;

        public void Start() {
            ScreenHeight = Camera.main.orthographicSize;
            ScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height; 
            LoadScreenSettings();
            Debug.Log(_staffData.UpdateStaff());
	        LoadFaces();
            Debug.Log("Members of Staff: "+_staffData.Members.Count);
            Debug.Log("Screen Height: "+Mathf.FloorToInt(ScreenHeight));
            Debug.Log("Screen Width: "+Mathf.FloorToInt(ScreenWidth));
	        transform.position = new Vector3(-ScreenWidth+FaceWidth,ScreenHeight-FaceHeight);
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                ReloadFaces();
            }
        }
        
        public void ReloadFaces() {
            Debug.Log("Faces Updating...");
            Debug.Log("Clearing Faces...");
            foreach (GameObject face in Faces) {
                Destroy(face);
            }
			
        }

        private void LoadScreenSettings() {
            _layoutLoader.Getlayout();
            FacesLines = _layoutLoader.BoardLayout.height;
            FacesPerLine = _layoutLoader.BoardLayout.width;
        }

        private void LoadFaces() {

	        // to check the staff id
	        int iterator = 0;
	        for (int y = 0; y < FacesLines; y++) {
		        for (int x = 0; x < FacesPerLine; x++) {
			        Staff staff = _staffData.GetStaffMember(iterator);
			        if (staff != null) {
				        GameObject faceGameObject = Instantiate(FacePrefab, transform);
				        faceGameObject.name = staff.id.ToString("0");
				        Face face = faceGameObject.GetComponent<Face>();
				        face.Location = new Vector2(x,y);
				        face.Staff = staff;
				        face.SetUp();
				        faceGameObject.transform.position = new Vector3(x*2,-y*3);

				        Faces.Add(faceGameObject);
			        }

			        iterator++;
		        }
	        }
		}

        
        public void OnDrawGizmosSelected() {
            Gizmos.color = new Color(0,255,0,0.2f);

//            if (_layoutLoader.Getlayout()) {
//                Debug.Log(_layoutLoader.BoardLayout.height);
//                Debug.Log(_layoutLoader.BoardLayout.width);
//                for (int x = 0; x < _layoutLoader.BoardLayout.width; x++) {
//                    for (int y = 0; y < _layoutLoader.BoardLayout.height; y++) {
//                        
//                    }
//                }
//
//
//            }

//            for (int y = 0; y < FacesLines; y++) {
//                for (int x = 0; x < FacesPerLine; x++) {
//                    Gizmos.DrawCube(new Vector3((-ScreenWidth+FaceWidth)/2 + (FaceWidth + 0.553752f/2) * x + 0.553752f/3, 
//                        (-ScreenHeight+FaceHeight)/2  + (FaceHeight + 0.537174f/2)* y + 0.537174f), new Vector3(FaceWidth,FaceHeight,1f));
//                }
//            }
        }
    }
}