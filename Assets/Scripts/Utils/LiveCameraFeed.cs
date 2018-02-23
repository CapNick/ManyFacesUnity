using System;
using System.Drawing;
using System.IO;
using UnityEngine;

//emgu.cv imports
using Emgu.CV;
using Emgu.CV.Structure;

using System.Collections.Generic;


namespace Utils {
    public class LiveCameraFeed {
        public bool FoundFace { get; private set; }
        private VideoCapture _capture;
        private CascadeClassifier _cascadeClassifier;
        public List<Vector2> FaceLocations { get; private set; }

        public LiveCameraFeed () {
            Debug.Log("CameraFeed Initialisation starting.");
            CvInvoke.UseOpenCL = false;
            FaceLocations = new List<Vector2>();
            try {
                _capture = new VideoCapture();
            }
            catch (Exception e) {
                Debug.LogError(e);
            }
        }

        
        public void ShutDownFeed () {
            //releasing the camera after use
            if (_capture != null) {
                _capture.Dispose();
            }
        }

        //Detects if somebody is at the camera
        private IImage DetectPerson () {
            FaceLocations.Clear();
            //Get current frame
            Mat frame = _capture.QueryFrame();
            IImage image = frame;
            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            //check for any faces in current frame
            Utils.DetectFaceCV.Detect(
                image, "Assets/Resources/haarcascade_frontalface_default.xml",
                "Assets/Resources/haarcascade_eye.xml",
                faces, eyes,
                out detectionTime);

            //
            if (faces.Capacity > 0) {
                FoundFace = true;
                foreach (Rectangle face in faces) {
                    CvInvoke.Rectangle(image, face, new Rgba(1, 0, 0, 1).MCvScalar, 2);
                    FaceLocations.Add(new Vector2(face.X, face.Y));
//                    faceX = face.X;
//                    faceY = face.Y;
                }
            }
            else {
                FoundFace = false;
            }
            return image;

        }

    }
}