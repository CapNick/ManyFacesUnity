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
	    Vector3 lastFacePos;
	    private float speed = 0.5f;
		private int numFaces = 0;
		int xOffSet = -70;
		int yOffSet = 70;

        public void Awake() {
//			#if (LINUX || Windows)
	        if (UsingCamera) {
		        _cameraFeed = new LiveCameraFeed();
	        }

//			#endif
		}

		// Use this for initialization
		void Start () {
			Faces = GetComponent<FaceLoader>().Faces;
			lastFacePos = new Vector3 (0.0f, -7f, -20.0f);

		    if (UsingCamera) {
		        InvokeRepeating("GetImage",0, 0.2f);
		    }

        }
	
		// Update is called once per frame
		void Update () {
			

			if (_cameraFeed != null) {
				//update faces looking ps
			    if (_cameraFeed.FoundFace) {
			        Debug.Log("Faces: " + _cameraFeed.FaceLocations.Count);
					numFaces = _cameraFeed.FaceLocations.Count;
					int desiredx = (int) (_cameraFeed.FaceLocations[0].x / xOffSet);
					int desiredy = (int) (-_cameraFeed.FaceLocations[0].y / yOffSet);

					if (desiredx > lastFacePos.x) {
						Vector3 temp = lastFacePos;
						float newX = lastFacePos.x + speed;
						lastFacePos = new Vector3(newX, temp.y, temp.z);

					}
					else if (desiredx < lastFacePos.x) {
						Vector3 temp = lastFacePos;
						float newX = lastFacePos.x - speed;
						lastFacePos = new Vector3(newX, temp.y, temp.z);
					}

					if (desiredy > lastFacePos.y) {
						Vector3 temp = lastFacePos;
						float newY = lastFacePos.y + speed;
						lastFacePos = new Vector3(temp.x, newY, temp.z);
					}
					else if (desiredy < lastFacePos.y) {
						Vector3 temp = lastFacePos;
						float newY = lastFacePos.y - speed;
						lastFacePos = new Vector3(temp.x, newY, temp.z);
					}
				}

                //Debug.Log(lastFacePos);

                foreach (GameObject face in Faces) {
				    face.GetComponent<Face>().UpdateLookingPosition(lastFacePos);
                    face.GetComponent<Face>().FaceContainer.transform.LookAt(lastFacePos);
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