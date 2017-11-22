using System.Collections.Generic;
using UnityEngine;

namespace Controllers {
	public class Face : MonoBehaviour
	{

		public Transform ViewingLocation;
		
		private List<Emotion> _animations = new List<Emotion>();

		//looking variables
		[SerializeField]
		private Transform _lookingTarget;

		private float _maxEyeDepression;
		private float _maxEyeElevation;

		private float _eyeDilationVlaue;
		private float _eyeUnDilationVlaue;

		[SerializeField] private Transform _leftEye;
		[SerializeField] private Transform _rightEye;
		[SerializeField] private Transform _leftEyePupil;
		[SerializeField] private Transform _rightEyePupil;

		void Update()  {
			//updates target to be cursor position for testing
			//Vector3 mousepos = Input.mousePosition;
			//mousepos.z = 500.0f;
			//mousepos.y = mousepos.y - 500.0f;
			//mousepos.x = mousepos.x - 500.0f;
			//_lookingTarget.position = mousepos;

			Vector3 facepos = new Vector3();
			facepos.z = 30.0f;
			if (CameraFeed.FaceDetected ()) {
				facepos.z = 20.0f;
				facepos.x = CameraFeed.faceX / 80;
				facepos.y = (-CameraFeed.faceY / 80) + 10;
				Debug.Log ("Detected face at " + facepos.x + ", " + facepos.y); 
			} else {
				facepos.y = 7.38f;
				facepos.x = 0.0f;
			}

			_lookingTarget.position = facepos;
			transform.LookAt(_lookingTarget.position);
			
			_leftEye.LookAt(_lookingTarget.position);
			_rightEye.LookAt(_lookingTarget.position);
		}

		private void OnDrawGizmosSelected() {
			Gizmos.color = Color.red;
			Gizmos.DrawLine(_leftEye.position, _lookingTarget.position);
			Gizmos.DrawLine(_rightEye.position, _lookingTarget.position);
			Gizmos.DrawWireSphere(_lookingTarget.position, 0.5f);
		}

		public void DilatePupil() {
			
		}

		public void UnDilatePupil() {
			
		}
		
		

		public void Happy() {
		
		}

		public void Sad() {
		
		}

		public void Confused() {
		
		}

	}
}
