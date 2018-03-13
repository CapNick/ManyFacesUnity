using Models;
using UnityEngine;

namespace Models {
	public class Face2 : MonoBehaviour {

		public Staff staff;
		public Renderer[] FaceRenderers;

		public bool Selected = false;

		private Color _previousColor;
		private Vector3 _lookingPos;

		public bool DEBUG;


		[Header("Faces Bounds")] 
		public GameObject Painting;
//		public Vector3 Bounds;
			
		// Use this for initialization
		void Start () {
			_previousColor = FaceRenderers[0].material.color;
//			Bounds = Painting.GetComponent<Renderer>().bounds.size;
		}
	
		// Update is called once per frame
		void Update () {
			if (DEBUG) {
				UpdateHeadColor();
			}
		}

		public void UpdateLookingPosition(Vector3 lookingPos) {
			_lookingPos = lookingPos;
			//set anything else needed
		}

		private void UpdateHeadColor() {
			if (Selected) {
				foreach (var rend in FaceRenderers) {
					rend.material.color = Color.red;
				}
			}
			else {
				foreach (var rend in FaceRenderers) {
					rend.material.color = _previousColor;
				}
			}
		}

	    public void OnDrawGizmos()
	    {
            Gizmos.DrawLine(transform.position, _lookingPos);
	    }


    }
}
