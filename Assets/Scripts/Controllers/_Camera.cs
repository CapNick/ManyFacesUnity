using UnityEngine;

namespace Controllers
{
	public class _Camera : MonoBehaviour
	{

		[SerializeField] private Transform _restingPosition;
		[SerializeField] private Transform _viewingPosition;

		[SerializeField] private GameObject _userInterface;
		[SerializeField] private GameObject _selectedHead;

		// Use this for initialization
		void Start ()
		{
			transform.position = _restingPosition.position;
		}
	     
		Ray ray;
		RaycastHit hit;
		
		void Update()
		{
			
			
			
			
			if (Input.GetMouseButtonDown(0))
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.transform.CompareTag("Head"))
					{
//						_viewingPosition = hit.transform.GetChild("CameraPosition").transform;
						Debug.Log(hit.transform.childCount);
						_selectedHead = hit.transform.gameObject;
						_userInterface.gameObject.SetActive(true);
					}
				}
			}
			if (_viewingPosition != null)
			{
				transform.position = _viewingPosition.position;
			}
			else
			{
				transform.position = _restingPosition.position;
			}
		}

		public void resetCameraPosition()
		{
			_viewingPosition = null;
			_selectedHead = null;
			_userInterface.SetActive(false);
		}
	}
}
