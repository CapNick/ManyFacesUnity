using System;
using UnityEngine;

namespace Controllers {
	public class Sun : MonoBehaviour {
		//Position of nottingham CS department
		private readonly float _latitude = 52.953385f;
		private readonly float _longitude = -1.187345f;

	
		private float _nextActionTime = 0.0f;
		public float Period = 0.1f;
		private DateTime _nowDateTime;
	
		private Utils.SunAngle sunAngle;
		// Use this for initialization
		public void Start () {
			_nowDateTime = DateTime.Now;
		}
	
		// Update is called once per frame
		public void Update () {
			if (Time.time > _nextActionTime ) {
				_nextActionTime += Period;
//			Testing for time updates
//			_nowDateTime = _nowDateTime.AddMinutes(1);
				sunAngle = Utils.SunPosition.CalculateSunPosition(_nowDateTime, _latitude, _longitude);
				transform.SetPositionAndRotation(transform.position, Quaternion.Euler((float)sunAngle.Altitude, (float)sunAngle.Azimuth ,0));
//			Debug.Log(_nowDateTime.Hour+":"+_nowDateTime.Minute);
			}
		}
	}
}
