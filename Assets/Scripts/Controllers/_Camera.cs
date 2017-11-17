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
	     
		void Update()
		{
			
		}
	}
}
