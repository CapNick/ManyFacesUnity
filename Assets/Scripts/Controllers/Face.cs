using System.Collections.Generic;
using UnityEngine;

namespace Controllers {
	public class Face : MonoBehaviour {
	
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
