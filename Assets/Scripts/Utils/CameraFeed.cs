using System;
using System.Drawing;
using System.IO;
using UnityEngine;

//emgu.cv imports
using Emgu.CV;
using Emgu.CV.Structure;

using System.Collections.Generic;


namespace Utils
{
	public class CameraFeed : MonoBehaviour
	{
		private VideoCapture _capture;
		private CascadeClassifier _cascadeClassifier;
		int _time = 0;

		void Start()
		{
			Debug.Log("CameraFeed Initialisation starting.");
			CvInvoke.UseOpenCL = false;

			try
			{
				_capture = new VideoCapture();
			}
			catch (Exception e)
			{
				Debug.LogError(e);
			}
		}

		public void Update()
		{
			if (_capture != null)
			{
				GetImage();
			}
		}


		//Puts image on UI
		private void GetImage()
		{
			//		Mat frame = _capture.QueryFrame();
			//		Mat smoothedFrame = new Mat();
			//        CvInvoke.GaussianBlur(frame, smoothedFrame, new Size(3, 3), 1);

			//Image<Bgr, byte> nextFrame = _capture.QueryFrame().ToImage<Bgr, byte>();
			IImage nextFrame = DetectPerson();
			MemoryStream mem = new MemoryStream();
			nextFrame.Bitmap.Save(mem, nextFrame.Bitmap.RawFormat);
			Texture2D cameraFeed = new Texture2D(1920, 1080);
			cameraFeed.LoadImage(mem.ToArray());

			GetComponent<Renderer>().material.mainTexture = cameraFeed;

		}

		void OnApplicationQuit()
		{
			//releasing the camera after use
			if (_capture != null)
			{
				_capture.Dispose();
			}
		}

		//Detects if somebody is at the camera
		private IImage DetectPerson()
		{
			//Get current frame
			Mat frame = _capture.QueryFrame();
			IImage image = frame;
			long detectionTime;
			List<Rectangle> faces = new List<Rectangle>();
			List<Rectangle> eyes = new List<Rectangle>();

			//check for any faces in current frame
			DetectFaceCV.Detect(
				image, "Assets/Resources/haarcascade_frontalface_default.xml",
				"Assets/Resources/haarcascade_eye.xml",
				faces, eyes,
				out detectionTime);

			//
			if (faces.Capacity > 0)
			{
				Debug.Log("Found " + faces.Capacity + "faces. Tried to draw a square");
				foreach (Rectangle face in faces)
					CvInvoke.Rectangle(image, face, new Rgba(1, 0, 0, 1).MCvScalar, 2);
			}
			return image;

		}
	}
}