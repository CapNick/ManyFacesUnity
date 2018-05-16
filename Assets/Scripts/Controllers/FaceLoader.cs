using System.Collections.Generic;
using Models;
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
        private const float FaceWidth = 2.553752f;
        private const float FaceHeight = 3.537174f;

        [Header("Screen info")] 
        public float ScreenWidth;
        public float ScreenHeight;
        public int FacesPerLine = 10;
        public int FacesLines = 4;

        public void Start() {
            ScreenHeight = Camera.main.orthographicSize;
            ScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            _layoutLoader = new LayoutLoader();
            LoadScreenSettings();
            LoadStaff();
            LoadFaces();
            Debug.Log("Screen Height: "+ScreenHeight);
            Debug.Log("Screen Width: "+ScreenWidth);
        }
        
        
        public void ReloadFaces() {
            Debug.Log("Faces Updating...");
            Debug.Log("Clearing Faces...");
            foreach (GameObject face in Faces) {
                Destroy(face);
            }
//			LoadFaces();
        }

        private void LoadScreenSettings() {
            _layoutLoader.Getlayout();
            FacesLines = _layoutLoader.BoardLayout.height;
            FacesPerLine = _layoutLoader.BoardLayout.width;

        }
		

        private void LoadStaff() {
            if (_staffData == null) {
                _staffData = new StaffData();
                _staffData.UpdateStaff();
            }
        }


        private void LoadFaces() {
//            for (int y = 0; y < FacesLines; y++) {
//                for (int x = 0; x < FacesPerLine; x++) {
//                    if (faceCounter  < _staffData.Members.Count) {
//                        GameObject faceGameObject = Instantiate(FacePrefab);
//                        faceGameObject.name = "Face: " + x + "," + y + " ID: " + faceCounter;
//                        //set the staff list reference
//                        Face face = faceGameObject.GetComponent<Face>();
//                        face.Setup(_staffData.Members[faceCounter], new Vector2(x,y));
//	
//                        faceGameObject.transform.position = new Vector3((-ScreenWidth+FaceWidth)/2 + (FaceWidth + 0.553752f/2) * x + 0.553752f/3, 
//                            (-ScreenHeight+FaceHeight)/2  + (FaceHeight + 0.537174f/2)* y + 0.537174f);
//	
//                        faceGameObject.transform.SetParent(transform);
//                        Faces.Add(faceGameObject);
//                        faceCounter++;
//                    }
//					
//                }
//            }
            
//            GameObject faceGameObject = Instantiate(FacePrefab);
//            faceGameObject.name = "Face: " +  + "," + y + " ID: " + faceCounter;
//            //set the staff list reference
//            Face face = faceGameObject.GetComponent<Face>();
//            face.Setup(_staffData.Members[faceCounter], new Vector2(,));
            int faceCounter = _staffData.Members.Count;
            for (int i = 0; i < faceCounter; i++) {
                Staff staff = _staffData.GetStaff(i);
                if (staff != null) {
                    GameObject faceGameObject = Instantiate(FacePrefab, transform.position, Quaternion.identity, transform);
                    faceGameObject.name = "Face: " + i;
                    Faces.Add(faceGameObject);
                    
                    Debug.Log(FacePrefab.GetComponent<BoxCollider>().bounds.size.x);
                    Debug.Log(FacePrefab.GetComponent<BoxCollider>().bounds.size.y);
                    Debug.Log(FacePrefab.GetComponent<BoxCollider>().bounds.size.z);
                    //set the staff list reference
                    Face face = faceGameObject.GetComponent<Face>();
                    face.Setup(staff);
                }
                else {
                    // if a blank is found, just add another to the counter.
                    faceCounter++;
                }
            }
            
        }

        private void CreatePaintingsForLayout() {
            
        }
        
        public void OnDrawGizmosSelected() {
            Gizmos.color = new Color(0,255,0,0.2f);
            
            for (int y = 0; y < FacesLines; y++) {
                for (int x = 0; x < FacesPerLine; x++) {
                    Gizmos.DrawCube(new Vector3((-ScreenWidth+FaceWidth)/2 + (FaceWidth + 0.553752f/2) * x + 0.553752f/3, 
                        (-ScreenHeight+FaceHeight)/2  + (FaceHeight + 0.537174f/2)* y + 0.537174f), new Vector3(FaceWidth,FaceHeight,1f));
                }
            }
        }
    }
}