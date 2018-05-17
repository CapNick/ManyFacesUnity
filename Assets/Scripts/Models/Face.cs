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
		public Material FaceTexture;

		[Header("Update")] 
		private bool _update;
		
		[Header("Labels")]
	    public TextMeshPro Name;
	    public TextMeshPro Label;
		public GameObject NamePanel;
		public GameObject LabelPanel;
		
		private AssetDownloader _downloader;
		private Color _previousColor;
		
		[Header("Looking system")] 
		[SerializeField]
		private Vector3 _lookingPos;
		[SerializeField]
		private float _lookingSpeed;
		public GameObject FaceContainer;

		public void Start () {
			Debug.Log(GetComponent<Collider>().bounds);
			_downloader = GetComponent<AssetDownloader>();

		}
		
		// Use this for initialization
		public void SetUp() {
			SetLabels();
			LoadFaceModel();
		}

		public void Update() {
//			var targetRotation = Quaternion.LookRotation(_lookingPos - FaceContainer.transform.position);
//			FaceContainer.transform.rotation = Quaternion.Slerp(FaceContainer.transform.rotation, targetRotation, _lookingSpeed * Time.deltaTime);
		}

		public void UpdateLookingPosition(Vector3 lookingPos) {
			_lookingPos = lookingPos;
		}

	    public void OnDrawGizmos() {
            Gizmos.DrawLine(transform.position, _lookingPos);
	    }

		private void SetLabels() {
			NamePanel.SetActive(true);
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
				Debug.Log(SettingsLoader.Instance.Setting.base_url + fileLocation);
				_downloader.AssetURI = SettingsLoader.Instance.Setting.base_url + fileLocation;
				while (!_downloader.IsDone) {
					// run loop till it is done
					
				}

				// we get the childeren and set the texture to the presaved one to make use of the vertex colors
				int childCount = FaceContainer.transform.GetChild(0).childCount;
				if (childCount > 0) {
					for (int i = 0; i < childCount; i++) {
						FaceContainer.transform.GetChild(0).GetChild(i).GetComponent<Renderer>().material = FaceTexture;
					}
				}
				
				
//				_downloader.WrapperGameObject.GetComponentInChildren<GameObject>().transform.localScale = new Vector3(0.04f,0.04f,0.04f);
//				_downloader.WrapperGameObject.GetComponentInChildren<GameObject>().transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
			}
			else {
				MissingModel.SetActive(true);
			}
		}
		
		
    }
}
