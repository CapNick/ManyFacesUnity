using Models;
using TriLib;
using UnityEngine;

namespace Models {
	[RequireComponent(typeof(AssetDownloader))]
	public class Face : MonoBehaviour {

		[Header("Location Infomation")]
		public Vector2 Location;
		public bool Visible;
		[Header("Elements")]
		public Staff staff;
		public Renderer[] FaceRenderers;
		public GameObject FaceModel;
		public bool Selected = false;
		public float Progress = 0;

		private AssetDownloader _downloader;
		private Color _previousColor;
		private Vector3 _lookingPos;

		[Header("Faces Bounds")] 
		public GameObject Painting;
			
		// Use this for initialization
		void Start () {
			_downloader = GetComponent<AssetDownloader>();
			_downloader.AssetURI = staff.model_url;
			//visability
			Visible = staff.visible;
			
			if (FaceModel != null) {
				FaceModel.SetActive(staff.visible);
				if (staff.visible) {
					gameObject.tag = "Face";
					
				}
			}
			

		}

		void Update() {
			if (!_downloader.IsDone) {
				Progress = _downloader.Progress;
			}
		}

		public void UpdateLookingPosition(Vector3 lookingPos) {
			_lookingPos = lookingPos;
			
			//set anything else needed
		}

	    public void OnDrawGizmos()
	    {
            Gizmos.DrawLine(transform.position, _lookingPos);
	    }

    }
}
