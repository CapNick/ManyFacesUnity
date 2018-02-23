using Models;
using UnityEngine;

namespace Controllers {
	public class Face2 : MonoBehaviour {


		public Staff staff;
		public Mesh FaceMesh;

		public bool Selected = false;
			
		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
			
		}

		//cursor hover over entered
		public void OnTriggerEnter(Collider col) {
			if (col.gameObject.CompareTag("Cursor")) {
				Selected = true;
			}
		}

		//cursor hover over leave 
		private void OnTriggerExit(Collider col) {
			if (col.gameObject.CompareTag("Cursor")) {
				Selected = false;
			}
		}
	}
}
