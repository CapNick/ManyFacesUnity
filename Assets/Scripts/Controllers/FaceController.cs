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
		public bool DEBUG = false;
	    public GameObject Pane;

		public Vector2Int CameraDimensions;
		
//		[Header("Data Loading")]
		private string _uri = "https://dev.capnick.co.uk/faces.json";
		private string file = "faces.json";
		private StaffData _staffData;

		private const float FaceWidth = 2.553752f;
		private const float FaceHeight = 3.537174f;

		[Header("Screen info")] 
		public float ScreenWidth;
		public float ScreenHeight;
		private int _facesPerLine = 10;
		private int _facesLines = 4;
		private int _maxFacesInScene = 36;

		private LiveCameraFeed _cameraFeed;

        //Tracking variables
	    private Vector3 lastFacePos = new Vector3();
	    private float speed = 0.5f;

        public void Awake() {
			 _cameraFeed = new LiveCameraFeed();
		}

		// Use this for initialization
		void Start () {
			ScreenHeight = Camera.main.orthographicSize * 2.0f;
			ScreenWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
			LoadFaces();
			Debug.Log("Total Faces " + _staffData.Members.Count);
		    lastFacePos.x = 0.0f;
		    lastFacePos.y = 7f;
		    lastFacePos.z = 20.0f;
        }
	
		// Update is called once per frame
		void Update () {

            GetImage();

			if (Input.GetKeyDown(KeyCode.Space)) {
				ReloadFaces();
			}

		    
            //update faces looking ps
		    if (_cameraFeed.FoundFace)
		    {
		        int desiredx = (int)(_cameraFeed.FaceLocations[0].x / 50);
		        int desiredy = (int)(-_cameraFeed.FaceLocations[0].y / 100);

		        if (desiredx > lastFacePos.x) {
		            lastFacePos.x += speed;
		        }
		        else if (desiredx < lastFacePos.x) {
		            lastFacePos.x -= speed;
		        }

		        if (desiredy > lastFacePos.y) {
		            lastFacePos.y += speed;
		        }
		        else if (desiredy < lastFacePos.y) {
		            lastFacePos.y -= speed;
		        }

		        Debug.Log("Detected face at " + lastFacePos.x + ", " + lastFacePos.y);
            }
		    else
		    {
		        int desiredx = 7;
		        int desiredy = 0;

		        if (desiredx > lastFacePos.x) {
		            lastFacePos.x += speed;
		        }
		        else if (desiredx < lastFacePos.x) {
		            lastFacePos.x -= speed;
		        }

		        if (desiredy > lastFacePos.y) {
		            lastFacePos.y += speed;
		        }
		        else if (desiredy < lastFacePos.y) {
		            lastFacePos.y -= speed;
		        }
		    }

		    foreach (GameObject face in Faces) {
		        face.transform.LookAt(lastFacePos);
		        face.GetComponent<Face>().UpdateLookingPosition(lastFacePos);
		    }
        }
		
		public void ReloadFaces() {
			Debug.Log("Faces Updating...");
			Debug.Log("Clearing Faces...");
			foreach (GameObject face in Faces) {
				Destroy(face);
			}

			LoadFaces();
		}

		public void LoadFaces() {
			if (_staffData == null) {
				_staffData = new StaffData(file);
				_staffData.LoadAllData();
			}
			
			int horMult = (int)Mathf.Floor(ScreenHeight / FaceHeight);
			int vertMult = (int)Mathf.Floor(ScreenWidth / FaceWidth);
			Debug.Log(horMult);
			Debug.Log(vertMult);
			
			int faceCounter = 0;
			for (int y = 0; y < _facesLines; y++) {
				for (int x = 0; x < _facesPerLine; x++) {
					GameObject face = Instantiate(FacePrefab);
					face.name = "Face: " + x + "," + y + " ID: " + faceCounter;
                    //set the staff list reference
				    Face face2 = face.GetComponent<Face>();
					face2.staff = _staffData.Members[faceCounter];
					face2.Location = new Vector2(x,y);
					face2.DEBUG = DEBUG;
					

					face.transform.position = new Vector3((-ScreenWidth+FaceWidth)/2 + (FaceWidth + 0.553752f/2) * x + 0.553752f/3, 
						(-ScreenHeight+FaceHeight)/2  + (FaceHeight + 0.537174f/2)* y + 0.537174f);
					face.transform.SetParent(transform);
				    Faces.Add(face);
                    faceCounter++;
				}
			}
		}

		public void OnApplicationQuit() {
			_cameraFeed.ShutDownFeed();
		}

		public void OnDrawGizmosSelected() {
			Gizmos.color = new Color(0,255,0,0.2f);
			for (int y = 0; y < _facesLines; y++) {
				for (int x = 0; x < _facesPerLine; x++) {
					Gizmos.DrawCube(new Vector3((-ScreenWidth+FaceWidth)/2 + (FaceWidth + 0.553752f/2) * x + 0.553752f/3, 
						(-ScreenHeight+FaceHeight)/2  + (FaceHeight + 0.537174f/2)* y + 0.537174f), new Vector3(FaceWidth,FaceHeight,1f));
				}
			}
		}

	    private void GetImage () {
	        IImage nextFrame = _cameraFeed.DetectPerson(); ;
	        MemoryStream mem = new MemoryStream();
	        nextFrame.Bitmap.Save(mem, nextFrame.Bitmap.RawFormat);
	        //change this when necessary
	        Texture2D cameraFeed = new Texture2D(CameraDimensions.x, CameraDimensions.y);
	        cameraFeed.LoadImage(mem.ToArray());

	        Pane.GetComponent<Renderer>().material.mainTexture = cameraFeed;

	    }
    }
}
