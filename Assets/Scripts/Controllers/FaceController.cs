using System.Collections.Generic;
using System.IO;
using Emgu.CV;
using Models;
using UnityEngine;
using Utils;

namespace Controllers {
	public class FaceController : MonoBehaviour {
		
		public List<GameObject> Faces;
		
	    public GameObject Pane;

		public bool UsingCamera = false;

		private LiveCameraFeed _cameraFeed;

        //Tracking variables
	    private List<Vector3> lastFacePos;
	    private float speed = 0.5f;
		private int numFaces = 0;
		int xOffSet = 20;
		int yOffSet = 30;

        public void Awake() {
//			#if (LINUX || Windows)
	        if (UsingCamera) {
		        _cameraFeed = new LiveCameraFeed();
	        }

//			#endif
			lastFacePos = new List<Vector3>();
		}

		// Use this for initialization
		void Start () {
//			Faces = GetComponent<FaceLoader>().Faces;
			lastFacePos.Add (new Vector3 ());
			lastFacePos.Add (new Vector3 ());
			lastFacePos.Add (new Vector3 ());
			lastFacePos[0] = new Vector3 (0.0f, -7f, 20.0f);
        }
	
		// Update is called once per frame
		void Update () {
			if (UsingCamera) {
				GetImage();
			}

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
		
		

		public void OnApplicationQuit() {
			if (_cameraFeed != null) {
				_cameraFeed.ShutDownFeed();
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