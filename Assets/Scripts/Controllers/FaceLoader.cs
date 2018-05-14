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
        public List<Staff> StaffList;

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
            ScreenHeight = Camera.main.orthographicSize * 2.0f;
            ScreenWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
            _layoutLoader = new LayoutLoader();
            LoadScreenSettings();
            LoadStaff();
            StaffList = _staffData.Members;
            LoadFaces();
            Debug.Log("Total Faces " + _staffData.Members.Count);
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
//			int horMult = Mathf.FloorToInt(ScreenHeight / FaceHeight);
//			int vertMult = Mathf.FloorToInt(ScreenWidth / FaceWidth);
//			Debug.Log(horMult);
//			Debug.Log(vertMult);

            _layoutLoader.Getlayout();
			
            FacesLines = _layoutLoader.BoardLayout.height;
            FacesPerLine = _layoutLoader.BoardLayout.width;

        }
		

        private void LoadStaff() {
            if (_staffData == null) {
                _staffData = new StaffData();
                Debug.Log(_staffData.GetStaff());
            }
        }


        private void LoadFaces() {
            int faceCounter = 0;
            for (int y = 0; y < FacesLines; y++) {
                for (int x = 0; x < FacesPerLine; x++) {
                    if (faceCounter  < _staffData.Members.Count) {
                        GameObject faceGameObject = Instantiate(FacePrefab);
                        faceGameObject.name = "Face: " + x + "," + y + " ID: " + faceCounter;
                        //set the staff list reference
                        Face face = faceGameObject.GetComponent<Face>();
                        face.Staff = _staffData.Members[faceCounter];
                        face.Location = new Vector2(x,y);
	
                        faceGameObject.transform.position = new Vector3((-ScreenWidth+FaceWidth)/2 + (FaceWidth + 0.553752f/2) * x + 0.553752f/3, 
                            (-ScreenHeight+FaceHeight)/2  + (FaceHeight + 0.537174f/2)* y + 0.537174f);
	
                        faceGameObject.transform.SetParent(transform);
                        Faces.Add(faceGameObject);
                        faceCounter++;
                    }
					
                }
            }
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