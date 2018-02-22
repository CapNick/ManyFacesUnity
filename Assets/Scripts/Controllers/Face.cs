using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Controllers {
	public class Face : MonoBehaviour
	{
		float speed = 0.5f;
		public Transform ViewingLocation;

	    public CameraFeed cameraFeed;

		private List<Emotion> _animations = new List<Emotion>();

		private Vector3 lastFacePos = new Vector3();
		//looking variables
		[SerializeField]
		private Transform _lookingTarget;
		 
//		private float _maxEyeDepression;
//		private float _maxEyeElevation;
//
//		private float _eyeDilationVlaue;
//		private float _eyeUnDilationVlaue;
//
//		[SerializeField] private Transform _leftEye;
//		[SerializeField] private Transform _rightEye;
//		[SerializeField] private Transform _leftEyePupil;
//		[SerializeField] private Transform _rightEyePupil;

		void Start() {
			lastFacePos.x = 0.0f;
			lastFacePos.y = 7f;
			lastFacePos.z = 20.0f;
		}
		void Update()  {
		    //Vector3 mousepos = Input.mousePosition;
		    //mousepos.z = 500.0f;
		    //mousepos.y = mousepos.y - 500.0f;
		    //mousepos.x = mousepos.x - 500.0f;
		    //_lookingTarget.position = mousepos;

		    if (Utils.CameraFeed.FaceDetected()) {
				int desiredx = (int)(CameraFeed.faceX / 50);
				int desiredy = (int)(-CameraFeed.faceY / 100);

				if (desiredx > lastFacePos.x) {
					lastFacePos.x += speed;
				} else if (desiredx < lastFacePos.x) {
					lastFacePos.x -= speed;
				}

				if (desiredy > lastFacePos.y) {
					lastFacePos.y += speed;
				} else if (desiredy < lastFacePos.y) {
					lastFacePos.y -= speed;
				}

				//lastFacePos.x = (CameraFeed.faceX / 100);
				//lastFacePos.y = (-CameraFeed.faceY / 100);
				Debug.Log("Detected face at " + lastFacePos.x + ", " + lastFacePos.y);
		    }
		    else {
				int desiredx = 7;
				int desiredy = 0;

				if (desiredx > lastFacePos.x) {
					lastFacePos.x += speed;
				} else if (desiredx < lastFacePos.x) {
					lastFacePos.x -= speed;
				}

				if (desiredy > lastFacePos.y) {
					lastFacePos.y += speed;
				} else if (desiredy < lastFacePos.y) {
					lastFacePos.y -= speed;
				}
		    }

			_lookingTarget.position = lastFacePos;
		    transform.LookAt(_lookingTarget.position);

//		    _leftEye.LookAt(_lookingTarget.position);
//		    _rightEye.LookAt(_lookingTarget.position);
        }

		private void OnDrawGizmosSelected() {
			Gizmos.color = Color.red;
//			Gizmos.DrawLine(_leftEye.position, _lookingTarget.position);
//			Gizmos.DrawLine(_rightEye.position, _lookingTarget.position);
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
