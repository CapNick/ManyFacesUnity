using UnityEngine;

namespace Models {
    public class SelectorLight : MonoBehaviour
    {
        [SerializeField] private Light _selectionLight;

        public void Start()
        {
            _selectionLight = GetComponent<Light>();
        }


        public void OnMouseOver()
        {
            _selectionLight.enabled = true;
            Debug.Log("Mouse Over");
        }

        public void OnMouseExit()
        {
            _selectionLight.enabled = false;
            Debug.Log("Mouse Left");


        }
    }
}