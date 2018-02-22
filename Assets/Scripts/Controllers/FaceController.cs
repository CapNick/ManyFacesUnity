using Models;
using UnityEngine;

namespace Controllers {
	public class FaceController : MonoBehaviour {
		public GameObject FacePrefab;
		public GameObject[] Faces;
		public int MembersOfStaff;
		
		private string _uri = "https://dev.capnick.co.uk/faces.json";
		private string file = "faces.json";
		private StaffData _staffData;  

		
		public void Awake() {
		
		}

		// Use this for initialization
		void Start () {
			_staffData = new StaffData(file);
			_staffData.LoadAllData();
			MembersOfStaff = _staffData.Members.Count;
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
		}
		
	}
}
