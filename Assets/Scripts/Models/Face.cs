using Controllers;
using Emgu.CV.Structure;
using Models;
using TMPro;
using TriLib;
using UnityEngine;

namespace Models {
	[RequireComponent(typeof(AssetDownloader))]
	public class Face : MonoBehaviour {

		[Header("Location Infomation")]
		public Vector2 Location;
		[Header("Elements")]
		public Staff Staff;
		[Header("Face")]
		public GameObject FaceModel;
		public GameObject MissingModel;

		[Header("Update")] 
		private bool _update;
		
		[Header("Labels")]
	    public TextMeshPro Name;
	    public TextMeshPro Label;
		public GameObject LabelPanel;
		
		private AssetDownloader _downloader;
		private Color _previousColor;
		private Vector3 _lookingPos;

		[Header("Faces Bounds")] 
		public GameObject Painting;

		public void Start () {
			Debug.Log(GetComponent<Collider>().bounds);
		}
		
		// Use this for initialization
		public void Setup (Staff staff) {
			_downloader = GetComponent<AssetDownloader>();
			Staff = staff;
//			Location = location;
			_downloader.WrapperGameObject = gameObject;
			LoadFaceModel();
			SetLabels();
		}

		public void Update() {
			
		}

		public void UpdateLookingPosition(Vector3 lookingPos) {
			_lookingPos = lookingPos;
		}

	    public void OnDrawGizmos() {
            Gizmos.DrawLine(transform.position, _lookingPos);
	    }

		private void SetLabels() {
			if (string.IsNullOrEmpty(Staff.ovr_name)) {
				Name.text = Staff.name;
			}
			else {
				Name.text = Staff.ovr_name;
			}

			if (string.IsNullOrEmpty(Staff.label)) {
				LabelPanel.SetActive(false);
			}
			else {
				LabelPanel.SetActive(true);
				Label.text = Staff.label;
			}
		}

		private void LoadFaceModel() {
			string fileLocation = Staff.model_file["url"];
			if (fileLocation != null) {
				_downloader.AssetURI = SettingsLoader.Instance.Setting.base_url + fileLocation;
			}
			else {
				MissingModel.SetActive(true);
			}
		}

    }
}
