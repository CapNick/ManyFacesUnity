using System.Collections.Generic;
using System.IO;
using Emgu.CV;
using Models;
using UnityEngine;
using Utils;

namespace Controllers {
	public class FaceController : MonoBehaviour {
		[Header("Faces Objects")]
		public GameObject FacePrefab;
		public List<GameObject> Faces;
	    public GameObject Pane;
		
//		[Header("Data Loading")]
		private StaffData _staffData;
		public List<Staff> StaffList;

		[Header("Spawning Area")] 
		private const float FaceWidth = 2.553752f;
		private const float FaceHeight = 3.537174f;

		[Header("Screen info")] 
		public float ScreenWidth;
		public float ScreenHeight;
		public int FacesPerLine = 10;
		public int FacesLines = 4;

		private LayoutLoader _layoutLoader;

		private LiveCameraFeed _cameraFeed;

        //Tracking variables
	    private List<Vector3> lastFacePos;
	    private float speed = 0.5f;
		private int numFaces = 0;
		int xOffSet = 20;
		int yOffSet = 30;

        public void Awake() {
//			#if (LINUX || Windows)
//			_cameraFeed = new LiveCameraFeed();
//			#endif
			
			lastFacePos = new List<Vector3>();
		}

		// Use this for initialization
		void Start () {
			ScreenHeight = Camera.main.orthographicSize * 2.0f;
			ScreenWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
			_layoutLoader = new LayoutLoader();
			LoadScreenSettings();
			LoadStaff();
			StaffList = _staffData.Members;
			LoadFaces();
			Debug.Log("Total Faces " + _staffData.Members.Count);
			lastFacePos.Add (new Vector3 ());
			lastFacePos.Add (new Vector3 ());
			lastFacePos.Add (new Vector3 ());
			lastFacePos[0] = new Vector3 (0.0f, -7f, 20.0f);
        }
	
		// Update is called once per frame
		void Update () {

//            GetImage();


			if (_cameraFeed != null) {
				//update faces looking ps
				if (_cameraFeed.FoundFace) {
					numFaces = _cameraFeed.FaceLocations.Count;
					int desiredx = (int) (_cameraFeed.FaceLocations[0].x / xOffSet);
					int desiredy = (int) (-_cameraFeed.FaceLocations[0].y / yOffSet);

					if (desiredx > lastFacePos[0].x) {
						Vector3 temp = lastFacePos[0];
						float newX = lastFacePos[0].x + speed;
						lastFacePos[0] = new Vector3(newX, temp.y, temp.z);

					}
					else if (desiredx < lastFacePos[0].x) {
						Vector3 temp = lastFacePos[0];
						float newX = lastFacePos[0].x - speed;
						lastFacePos[0] = new Vector3(newX, temp.y, temp.z);
					}

					if (desiredy > lastFacePos[0].y) {
						Vector3 temp = lastFacePos[0];
						float newY = lastFacePos[0].y + speed;
						lastFacePos[0] = new Vector3(temp.x, newY, temp.z);
					}
					else if (desiredy < lastFacePos[0].y) {
						Vector3 temp = lastFacePos[0];
						float newY = lastFacePos[0].y - speed;
						lastFacePos[0] = new Vector3(temp.x, newY, temp.z);
					}

					if (numFaces == 2) {
						desiredx = (int) (_cameraFeed.FaceLocations[1].x / xOffSet);
						desiredy = (int) (-_cameraFeed.FaceLocations[1].y / yOffSet);

						if (desiredx > lastFacePos[1].x) {
							Vector3 temp = lastFacePos[1];
							float newX = lastFacePos[1].x + speed;
							lastFacePos[1] = new Vector3(newX, temp.y, temp.z);
						}
						else if (desiredx < lastFacePos[1].x) {
							Vector3 temp = lastFacePos[1];
							float newX = lastFacePos[1].x - speed;
							lastFacePos[1] = new Vector3(newX, temp.y, temp.z);
						}

						if (desiredy > lastFacePos[1].y) {
							Vector3 temp = lastFacePos[1];
							float newY = lastFacePos[1].y + speed;
							lastFacePos[1] = new Vector3(temp.x, newY, temp.z);
						}
						else if (desiredy < lastFacePos[1].y) {
							Vector3 temp = lastFacePos[1];
							float newY = lastFacePos[1].y - speed;
							lastFacePos[1] = new Vector3(temp.x, newY, temp.z);
						}
					}

					if (numFaces == 3) {
						desiredx = (int) (_cameraFeed.FaceLocations[2].x / xOffSet);
						desiredy = (int) (-_cameraFeed.FaceLocations[2].y / yOffSet);

						if (desiredx > lastFacePos[2].x) {
							Vector3 temp = lastFacePos[2];
							float newX = lastFacePos[2].x + speed;
							lastFacePos[2] = new Vector3(newX, temp.y, temp.z);
						}
						else if (desiredx < lastFacePos[2].x) {
							Vector3 temp = lastFacePos[2];
							float newX = lastFacePos[2].x - speed;
							lastFacePos[2] = new Vector3(newX, temp.y, temp.z);
						}

						if (desiredy > lastFacePos[2].y) {
							Vector3 temp = lastFacePos[2];
							float newY = lastFacePos[2].y + speed;
							lastFacePos[2] = new Vector3(temp.x, newY, temp.z);
						}
						else if (desiredy < lastFacePos[2].y) {
							Vector3 temp = lastFacePos[2];
							float newY = lastFacePos[2].y - speed;
							lastFacePos[2] = new Vector3(temp.x, newY, temp.z);
						}
					}

					Debug.Log("Detected face at " + lastFacePos[0].x + ", " + lastFacePos[0].y);
				}
				else {
					int desiredx = 7;
					int desiredy = 0;

					if (desiredx > lastFacePos[0].x) {
						Vector3 temp = lastFacePos[0];
						float newX = lastFacePos[0].x + speed;
						lastFacePos[0] = new Vector3(newX, temp.y, temp.z);

					}
					else if (desiredx < lastFacePos[0].x) {
						Vector3 temp = lastFacePos[0];
						float newX = lastFacePos[0].x - speed;
						lastFacePos[0] = new Vector3(newX, temp.y, temp.z);
					}

					if (desiredy > lastFacePos[0].y) {
						Vector3 temp = lastFacePos[0];
						float newY = lastFacePos[0].y + speed;
						lastFacePos[0] = new Vector3(temp.x, newY, temp.z);
					}
					else if (desiredy < lastFacePos[0].y) {
						Vector3 temp = lastFacePos[0];
						float newY = lastFacePos[0].y - speed;
						lastFacePos[0] = new Vector3(temp.x, newY, temp.z);
					}
				}
				
				

				int faceIndex = 0;
				foreach (GameObject face in Faces) {
					if (faceIndex < 18) {
						face.transform.LookAt(lastFacePos[0]);
						face.GetComponent<Face>().UpdateLookingPosition(lastFacePos[0]);
						faceIndex++;
					}
					else if (faceIndex < 36) {
						if (numFaces == 2) {
							face.transform.LookAt(lastFacePos[1]);
							face.GetComponent<Face>().UpdateLookingPosition(lastFacePos[1]);
							faceIndex++;
						}
						else {
							face.transform.LookAt(lastFacePos[0]);
							face.GetComponent<Face>().UpdateLookingPosition(lastFacePos[0]);
							faceIndex++;
						}
					}
					else {
						if (numFaces == 3) {
							face.transform.LookAt(lastFacePos[2]);
							face.GetComponent<Face>().UpdateLookingPosition(lastFacePos[2]);
							faceIndex++;
						}
						else {
							face.transform.LookAt(lastFacePos[0]);
							face.GetComponent<Face>().UpdateLookingPosition(lastFacePos[0]);
							faceIndex++;
						}

					}

				}
			}
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
				_staffData.GetStaff();
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

		public void OnApplicationQuit() {
			if (_cameraFeed != null) {
				_cameraFeed.ShutDownFeed();
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

	    private void GetImage () {
	        IImage nextFrame = _cameraFeed.DetectPerson();
		    //checks if the debug plane is active or not
		    if (Pane.activeInHierarchy) {
			    MemoryStream mem = new MemoryStream();
			    nextFrame.Bitmap.Save(mem, nextFrame.Bitmap.RawFormat);
			    //change this when necessary
			    Texture2D cameraFeed = new Texture2D(1280, 720);
			    cameraFeed.LoadImage(mem.ToArray());

			    Pane.GetComponent<Renderer>().material.mainTexture = cameraFeed;
		    }
	    }
    }
}