using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class Staff : MonoBehaviour {
        public Models.Staff AssignedStaff;
        [SerializeField]
        public Text Name;
        [SerializeField]
        public Text Room;
        [SerializeField]
        public Text Modules;
        [SerializeField]
        public Text Email;
        [SerializeField]
        public Text Phone;
        [SerializeField]
        public Text Position;
        [SerializeField]
        public Text Type;

        public void Update () {
            //checks for member of staff
            if (AssignedStaff != null) {
                //if member of staff is found the text elements are updated
                //check if each field has a value so we dont put in incorrect data into the field
                if (Name) {
                    Name.text = "Name: " + AssignedStaff.name;
                }
                if (Room) {
                    Room.text = "Room: " + AssignedStaff.room;
                }
                if (Modules) {
                    Modules.text = "Modules Taught: " + AssignedStaff.modules;
                }
                if (Email) {
                    Email.text = "Email Address: " + AssignedStaff.email;
                }
                if (Phone) {
                    Phone.text = "Phone Number: " + AssignedStaff.phone;
                }                
                if (Position) {
                    Position.text = "Position: " + AssignedStaff.position;
                }
                if (Type) {
                    Type.text = "Department: " + AssignedStaff._type;
                }

            }
        }

    }
}
