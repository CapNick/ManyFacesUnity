using Models;
using UnityEngine;

namespace Models {
	public class Face2 : MonoBehaviour {

		public Staff staff;
		public Renderer[] FaceRenderers;

		public bool Selected = false;

		private Color _previousColor;
			
		// Use this for initialization
		void Start () {
			_previousColor = FaceRenderers[0].material.color;
		}
	
		// Update is called once per frame
		void Update () {
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

//		//cursor hover over entered
//		public void OnTriggerEnter(Collider col) {
//			if (col.gameObject.CompareTag("Cursor")) {
//				Selected = true;
//			}
//		}
//
//		//cursor hover over leave 
//		private void OnTriggerExit(Collider col) {
//			if (col.gameObject.CompareTag("Cursor")) {
//				Selected = false;
//			}
//		}
	}
}
