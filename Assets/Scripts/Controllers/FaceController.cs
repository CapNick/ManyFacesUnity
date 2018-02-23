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
		public float AreaWidth;
		public float AreaHeight;

		[Header("Screen info")]
		private int _width;
		private int _height;
		private int _facesPerLine = 12;

//		private LiveCameraFeed _cameraFeed;
		
		public void Awake() {
//			 _cameraFeed = new LiveCameraFeed();
			_width = Screen.width;
			_height = Screen.height;

		}

		// Use this for initialization
		void Start () {
			LoadFaces();
			Debug.Log("Total Faces " + _staffData.Members.Count);
		}
	
		// Update is called once per frame
		void Update () {
			
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

			int counter = 0;
			foreach (Staff staff in _staffData.Members) {
				GameObject face = Instantiate(FacePrefab);
				face.transform.SetParent(transform);
				//set the staff list reference
				face.GetComponent<Face2>().staff = staff;
				//transform position
			}
		}

		public void OnApplicationQuit() {
//			_cameraFeed.ShutDownFeed();
		}
		
	}
}
