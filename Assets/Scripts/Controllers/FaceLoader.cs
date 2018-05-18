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
	    //The sizes of the face containers at scale of 1 width and height
        private const float FaceWidth = 1.2f;
        private const float FaceHeight = 1.8f;

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

	        _staffData.UpdateStaff();
			LoadFaces();
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
//				        faceGameObject.transform.position = new Vector3(x + x*FaceWidth+FaceWidth,-(y + y*FaceHeight+FaceHeight));
				        face.transform.position = new Vector3(FaceWidth * 2.2f * x, FaceHeight * 2.1f * -y);
//				        face.transform.position = new Vector3(FacesPerLine / 2f - x, FacesLines / 2f - y);
				        Faces.Add(faceGameObject);
			        }

			        iterator++;
		        }
	        }
		}

        
        public void OnDrawGizmosSelected() {
            Gizmos.color = new Color(0,255,0,0.2f);

            for (int y = 0; y < FacesLines; y++) {
                for (int x = 0; x < FacesPerLine; x++) {
                    Gizmos.DrawCube(new Vector3(FaceWidth*2.2f*x,FaceHeight*2.1f*-y ), new Vector3(FaceWidth*2,FaceHeight*2,1f));
                }
            }
        }
    }
}