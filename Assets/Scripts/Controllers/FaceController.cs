using System.Collections.Generic;
using Models;
using UnityEngine;
using Utils;

namespace Controllers {
	public class FaceController : MonoBehaviour {
		[Header("Faces Objects")]
		public GameObject FacePrefab;
		public List<GameObject> Faces;
		
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
		public int ScreenWidth;
		public int ScreenHeight;
		private int _facesPerLine = 12;

		private LiveCameraFeed _cameraFeed;
		
		public void Awake() {
			 _cameraFeed = new LiveCameraFeed();
		}

		// Use this for initialization
		void Start () {
			ScreenHeight = Screen.height;
			ScreenWidth = Screen.width;
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
//			transform.position = 
			int facesX = _facesPerLine;
			int facesY = _staffData.Members.Count/_facesPerLine;
			int faceCounter = 0;
			for (int x = 0; x < facesX; x++) {
				for (int y = 0; y < facesY; y++) {
					GameObject face = Instantiate(FacePrefab);
					Faces.Add(face);
					face.name = "Face: " + x + "," + y + " ID: " + faceCounter;
					//set the staff list reference
					face.GetComponent<Face2>().staff = _staffData.Members[faceCounter];

					face.transform.position = new Vector3(-facesX/2 +  x * FaceOffsetX, -facesY/2 + y * FaceOffsetY,0);

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
