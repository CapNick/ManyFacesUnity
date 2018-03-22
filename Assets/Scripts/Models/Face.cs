using Models;
using UnityEngine;

namespace Models {
	public class Face : MonoBehaviour {

		[Header("Location Infomation")]
		public Vector2 Location;
		public bool Visible;
		[Header("Elements")]
		public Staff staff;
		public Renderer[] FaceRenderers;
		public GameObject FaceModel;
		public bool Selected = false;

		private Color _previousColor;
		private Vector3 _lookingPos;

		[Header("Faces Bounds")] 
		public GameObject Painting;
			
		// Use this for initialization
		void Start () {
			_previousColor = FaceRenderers[0].material.color;
			//visability
			Visible = staff.visible;
			FaceModel.SetActive(staff.visible);
			if (staff.visible) {
				gameObject.tag = "Face";
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
