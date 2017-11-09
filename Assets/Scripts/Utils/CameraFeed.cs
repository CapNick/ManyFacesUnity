using System;
using System.IO;
using UnityEngine;

//emgu.cv imports
using Emgu.CV;
using Emgu.CV.Structure;


public class CameraFeed : MonoBehaviour
{
	private VideoCapture _capture;
	private CascadeClassifier _cascadeClassifier;

	void Start()
	{
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


	private void GetImage()
	{
//		Mat frame = _capture.QueryFrame();
//		Mat smoothedFrame = new Mat();
//        CvInvoke.GaussianBlur(frame, smoothedFrame, new Size(3, 3), 1);

		Image<Bgr, byte> nextFrame = _capture.QueryFrame().ToImage<Bgr, byte>();

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
}