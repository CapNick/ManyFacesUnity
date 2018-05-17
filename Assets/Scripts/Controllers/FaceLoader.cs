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
        private StaffData _staffData;

        [Header("Spawning Area")] 
        private LayoutLoader _layoutLoader;
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
            _staffData =  new StaffData();
            _layoutLoader = new LayoutLoader();
            LoadScreenSettings();
            Debug.Log(_staffData.UpdateStaff());
            Debug.Log("Members of Staff: "+_staffData.Members.Count);
            CreatePaintingsForLayout();
            Debug.Log("Screen Height: "+Mathf.FloorToInt(ScreenHeight));
            Debug.Log("Screen Width: "+Mathf.FloorToInt(ScreenWidth));
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

//        private void LoadFaces() {
////            int faceCounter = 0;
//           
////            for (int y = 0; y < FacesLines; y++) {
////                for (int x = 0; x < FacesPerLine; x++) {
////                    if (faceCounter  < _staffData.Members.Count) {
////                        GameObject faceGameObject = Instantiate(FacePrefab);
////                        faceGameObject.name = "Face: " + x + "," + y + " ID: " + faceCounter;
////                        //set the staff list reference
////                        Face face = faceGameObject.GetComponent<Face>();
////                        face.Setup(_staffData.Members[faceCounter]);
////	
////                        faceGameObject.transform.position = new Vector3((-ScreenWidth+FaceWidth)/2 + (FaceWidth + 0.553752f/2) * x + 0.553752f/3, 
////                            (-ScreenHeight+FaceHeight)/2  + (FaceHeight + 0.537174f/2)* y + 0.537174f);
////	
////                        faceGameObject.transform.SetParent(transform);
////                        Faces.Add(faceGameObject);
////                        faceCounter++;
////                    }
////					
////                }
////            }
////            LoadStaff();
//            int faceCounter = Mathf.FloorToInt(ScreenWidth * ScreenHeight);
//            
//            CreatePaintingsForLayout();
////            for (int i = 0; i < faceCounter; i++) {
////                Staff staff = _staffData.GetStaffMember(i);
////                if (staff != null) {
////                    GameObject faceGameObject = Instantiate(FacePrefab, transform.position, Quaternion.identity, transform);
////                    faceGameObject.name = "Face: " + i;
////                    Faces.Add(faceGameObject);
////
////                    //set the staff list reference
////                    Face face = faceGameObject.GetComponent<Face>();
////                    face.Setup(staff);
////                }
//////                else {
//////                    // if a blank is found, just add another to the counter.
//////                    faceCounter++;
//////                }
////            }
//            
//        }

        private void CreatePaintingsForLayout() {
            int faceCounter = 0;
            for (int x = 0; x < _layoutLoader.BoardLayout.width; x++) {
                for (int y = 0; y < _layoutLoader.BoardLayout.height; y++) {
                    GameObject faceGO = Instantiate(FacePrefab,  new Vector3(x* FaceWidth*2, y*FaceHeight*2), Quaternion.identity,transform);
                    faceGO.name = "("+x+","+y+")";
                    Faces.Add(faceGO);
                    Face face = faceGO.GetComponent<Face>();
                    face.Setup(_staffData.Members[faceCounter]);
                    faceCounter++;
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