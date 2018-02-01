using UnityEngine;
using UnityEngine.UI;

namespace UI {
    class Staff : MonoBehaviour {
        public Models.Staff AssignedStaff;
        [SerializeField]
        public Text _name;
        [SerializeField]
        public Text _room;
        [SerializeField]
        public Text _modules;
        [SerializeField]
        public Text _email;
        [SerializeField]
        public Text _phone;
        [SerializeField]
        public Text _position;
        [SerializeField]
        public Text _type;

        public void Update () {
            //checks for member of staff
            if (AssignedStaff != null) {
                //if member of staff is found the text elements are updated
                //check if each field has a value so we dont put in incorrect data into the field
                if (_name) {
                    _name.text = AssignedStaff.name;
                }
                if (_room) {
                    _room.text = AssignedStaff.room;
                }
                if (_modules) {
                    _modules.text = AssignedStaff.modules;
                }
                if (_email) {
                    _email.text = AssignedStaff.email;
                }
                if (_phone) {
                    _phone.text = AssignedStaff.phone;
                }
                if (_type) {
                    _type.text = AssignedStaff._type;
                }

            }
        }

    }
}
