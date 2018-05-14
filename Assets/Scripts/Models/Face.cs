﻿using Controllers;
using Models;
using TMPro;
using TriLib;
using UnityEngine;

namespace Models {
	[RequireComponent(typeof(AssetDownloader))]
	public class Face : MonoBehaviour {

		[Header("Location Infomation")]
		public Vector2 Location;
		[Header("Elements")]
		public Staff Staff;
		[Header("Face")]
		public GameObject FaceModel;
		public GameObject MissingModel;
		
	    public TextMeshPro Name;
	    public TextMeshPro Label;
		
		private AssetDownloader _downloader;
		private Color _previousColor;
		private Vector3 _lookingPos;

		[Header("Faces Bounds")] 
		public GameObject Painting;
			
		// Use this for initialization
		void Start () {
			_downloader = GetComponent<AssetDownloader>();
			_downloader.WrapperGameObject = gameObject;
			LoadFaceModel();
		}

		void Update() {
			
		}

		public void UpdateLookingPosition(Vector3 lookingPos) {
			_lookingPos = lookingPos;
			
		}

	    public void OnDrawGizmos() {
            Gizmos.DrawLine(transform.position, _lookingPos);
	    }
		
		

		private void LoadFaceModel() {
			string fileLocation = Staff.model_file["url"];
			if (fileLocation != null) {
				_downloader.AssetURI = SettingsLoader.Instance.Setting.base_url + fileLocation;
			}
			else {
				MissingModel.SetActive(true);
			}
		}

    }
}
