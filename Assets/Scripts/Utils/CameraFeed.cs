using System;
using System.Drawing;
using System.IO;
using UnityEngine;

//emgu.cv imports
using Emgu.CV;
using Emgu.CV.Structure;

using System.Collections.Generic;


namespace Utils {
    public class CameraFeed : MonoBehaviour {
        private VideoCapture _capture;
        private CascadeClassifier _cascadeClassifier;
        public static float faceX;
        public static float faceY;
        public GameObject pane;
		public static List<Rectangle> faces = new List<Rectangle>();

        void Start () {
            Debug.Log("CameraFeed Initialisation starting.");
            CvInvoke.UseOpenCL = false;

            try {
                _capture = new VideoCapture();
            }
            catch (Exception e) {
                Debug.LogError(e);
            }
        }

        void Update () {
            if (_capture != null) {
                GetImage();
            }
        }


        //Puts image on UI
        private void GetImage () {
            IImage nextFrame = DetectPerson();
            MemoryStream mem = new MemoryStream();
            nextFrame.Bitmap.Save(mem, nextFrame.Bitmap.RawFormat);
            //change this when necessary
            Texture2D cameraFeed = new Texture2D(1280, 720);
            cameraFeed.LoadImage(mem.ToArray());

            pane.GetComponent<Renderer>().material.mainTexture = cameraFeed;

        }

        void OnApplicationQuit () {
            //releasing the camera after use
            if (_capture != null) {
                _capture.Dispose();
            }
        }

        //Detects if somebody is at the camera
        private IImage DetectPerson () {
            //Get current frame
            Mat frame = _capture.QueryFrame();
            IImage image = frame;
            long detectionTime;
            
            List<Rectangle> eyes = new List<Rectangle>();
			faces.Clear();
            //check for any faces in current frame
            Utils.DetectFaceCV.Detect(
                image, "Assets/Resources/haarcascade_frontalface_default.xml",
                "Assets/Resources/haarcascade_eye.xml",
                faces, eyes,
                out detectionTime);

            //
            if (faces.Capacity > 0) {
                foreach (Rectangle face in faces) {
                    CvInvoke.Rectangle(image, face, new Rgba(1, 0, 0, 1).MCvScalar, 2);
                    faceX = face.X;
                    faceY = face.Y;
                }
            }
            else {
				faces.Clear();
				Debug.Log ("No face found");
            }
            return image;

        }
			
    }
}