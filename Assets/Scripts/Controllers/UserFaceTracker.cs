using System;
using UnityEngine;

namespace Controllers
{
	public class UserFaceTracker : MonoBehaviour
	{
		CameraFeed cameraFeed;
		void Start()
		{
			cameraFeed = new CameraFeed ();
			cameraFeed.Start();

		}

		void Update()
		{
			cameraFeed.Update ();
		}
	}
}


