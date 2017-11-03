using System;
using System.Drawing;
using System.IO;
using UnityEngine;

//emgu.cv imports
using Emgu.CV;
using Emgu.CV.Cvb;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;
using UnityEditor;

public class CameraFeed : MonoBehaviour {

	private Capture cap;
	private CascadeClassifier _cascadeClassifier;

	
	void Start() 
	{
		cap = new Capture();
				
		_cascadeClassifier = new CascadeClassifier("Assets/Resources/haarcascade_frontalface_default.xml");									

		
	}

	public void Update() {
		GetImage();
	}
	

	private void GetImage()
	{
		using (Image<Bgr, byte> nextFrame = cap.QueryFrame())
		{
			if (nextFrame != null)
			{
				// there's only one channel (greyscale), hence the zero index
				//var faces = nextFrame.DetectHaarCascade(haar)[0];
				Image<Gray, byte> grayFrame = nextFrame.Convert<Gray, byte>();
				Size imageSize = new Size();
				var faces = _cascadeClassifier.DetectMultiScale(grayFrame, 1.1, 4, imageSize, Size.Empty);

				
				
				foreach (var face in faces)
				{
					nextFrame.Draw(face, new Bgr(0,double.MaxValue,0), 3);
				}
				MemoryStream mem = new MemoryStream();
				nextFrame.Bitmap.Save(mem, nextFrame.Bitmap.RawFormat);
				
				Texture2D camera = new Texture2D(1920, 1080);
				camera.LoadImage(mem.ToArray());
				
				GetComponent<Renderer>().material.mainTexture = camera;
			}
		}
	}
	void OnApplicationQuit() {
	//releasing the camera after use
		if (cap != null) {
			cap.Dispose();
		}
	}
}
