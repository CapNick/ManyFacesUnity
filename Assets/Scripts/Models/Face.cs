using Controllers;
using Models;
using TriLib;
using UnityEngine;

namespace Models {
	[RequireComponent(typeof(AssetDownloader))]
	public class Face : MonoBehaviour {

		[Header("Location Infomation")]
		public Vector2 Location;
		[Header("Elements")]
		public Staff Staff;
		public GameObject FaceModel;
		public string MissingModel = "question_mark.fbx";

		private AssetDownloader _downloader;
		private AssetLoader _loader;
		private Color _previousColor;
		private Vector3 _lookingPos;

		[Header("Faces Bounds")] 
		public GameObject Painting;
			
		// Use this for initialization
		void Start () {
			_downloader = GetComponent<AssetDownloader>();
			_loader = new AssetLoader();
			LoadFace();
		}

		void Update() {
			
		}

		public void UpdateLookingPosition(Vector3 lookingPos) {
			_lookingPos = lookingPos;
			
		}

	    public void OnDrawGizmos() {
            Gizmos.DrawLine(transform.position, _lookingPos);
	    }

		private void LoadFace() {
			string fileLocation = Staff.model_file["url"];
			if (fileLocation != null) {
				if (_loader != null) {
					_loader.Dispose();
				}
				_downloader.AssetURI = SettingsLoader.Instance.Setting.base_url + fileLocation;
			}
			else {
				_loader.LoadFromFile(Application.streamingAssetsPath+"/models/"+MissingModel);
			}
		}

    }
}
