using System.Collections;
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
        [SerializeField]
	    private bool _loaded;
		
		[Header("Labels")]
	    public TextMeshPro Name;
	    public TextMeshPro Label;
		public GameObject NamePanel;
		public GameObject LabelPanel;
		[SerializeField]
		private AssetDownloader _downloader;
		private Color _previousColor;
		
		[Header("Looking system")] 
		[SerializeField]
		private Vector3 _lookingPos;
		[SerializeField]
		private float _lookingSpeed;
		public GameObject FaceContainer;
		
		// Use this for initialization
		public void SetUp() {
			SetLabels();
		    LoadFaceModel();
		}

        public void Update() {



            if (_loaded) {
                //Apply setttings
                _loaded = false;
                FaceContainer.transform.GetChild(0).localPosition = Vector3.zero;
                Transform model = FaceContainer.transform.GetChild(0).GetChild(0).transform;
                model.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                model.transform.localRotation = Quaternion.Euler(0 , 180, 180);
                //apply textures
                for (int i = 0; i < model.childCount; i++) {
                    var texture = model.GetChild(i).gameObject.GetComponent<MeshRenderer>();
                    texture.material = FaceTexture;
                }
            }
			var targetRotation = Quaternion.LookRotation(_lookingPos - FaceContainer.transform.position);
			FaceContainer.transform.rotation = Quaternion.Slerp(FaceContainer.transform.rotation, targetRotation, _lookingSpeed * Time.deltaTime);
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
	            _downloader.AssetURI = SettingsLoader.Instance.Setting.base_url + fileLocation;
	        }
	        else {
	            MissingModel.SetActive(true);
	        }
	    }
	}
}
