using System.Collections.Generic;
using Models;
using UnityEngine;
using Utils;

namespace Controllers {
	public class FaceController : MonoBehaviour {
		[Header("Faces Objects")]
		public GameObject FacePrefab;
		public List<GameObject> Faces;
		public bool DEBUG = false;
		
//		[Header("Data Loading")]
		private string _uri = "https://dev.capnick.co.uk/faces.json";
		private string file = "faces.json";
		private StaffData _staffData;

		[Header("Spawning Area")] 
		public float FaceOffsetX;
		public float FaceOffsetY;
		public float AreaWidth;
		public float AreaHeight;

		[Header("Screen info")] 
		public float ScreenWidth;
		public float ScreenHeight;
		private int _facesPerLine = 10;
		private int _facesLines = 4;
		private int _maxFacesInScene = 36;

		private LiveCameraFeed _cameraFeed;
		
		public void Awake() {
			 _cameraFeed = new LiveCameraFeed();
		}

		// Use this for initialization
		void Start () {
			ScreenHeight = Camera.main.orthographicSize * 2.0f;
			ScreenWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
			LoadFaces();
			Debug.Log("Total Faces " + _staffData.Members.Count);
		}
	
		// Update is called once per frame
		void Update () {
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

			LoadFaces();
		}

		public void LoadFaces() {
			if (_staffData == null) {
				_staffData = new StaffData(file);
				_staffData.LoadAllData();
			}
			Debug.Log(_staffData.Members.Count/_facesPerLine);
			
			
			
			
			int faceCounter = 0;
			for (int y = 0; y < _facesLines; y++) {
				for (int x = 0; x < _facesPerLine; x++) {
					GameObject face = Instantiate(FacePrefab);
					Faces.Add(face);
					face.name = "Face: " + x + "," + y + " ID: " + faceCounter;
					//set the staff list reference
					Face2 face2 = face.GetComponent<Face2>();
					face2.staff = _staffData.Members[faceCounter];
					face2.DEBUG = DEBUG;
					face.transform.position = new Vector3(0, 0, 0);

					face.transform.SetParent(transform);
					faceCounter++;
				}
			}
		}

		public void OnApplicationQuit() {
			_cameraFeed.ShutDownFeed();
		}
		
	}
}
