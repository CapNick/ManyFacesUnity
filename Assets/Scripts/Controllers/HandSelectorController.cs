using Models;
using UnityEngine;

namespace Controllers {
    public class HandSelectorController : MonoBehaviour {
        public Camera MainCamera;
        
        public UI.Staff StaffPannel;
        
        public void Update() {
            Vector3 position = Input.mousePosition;
            position.z = 10;
            
            transform.position = MainCamera.ScreenToWorldPoint(position);

        }
        
        
    }
}