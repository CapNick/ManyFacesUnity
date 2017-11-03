using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour {
	
	private List<Emotion> _animations = new List<Emotion>();

	//looking variables
	[SerializeField]
	private Transform _lookingTarget;

	[SerializeField] private Transform _leftEye;
	[SerializeField] private Transform _rightEye;

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


	public void Happy() {
		
	}

	public void Sad() {
		
	}

	public void Confused() {
		
	}

}
