using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class Staff : MonoBehaviour {
        public Models.Staff AssignedStaff;
        public Text Name;
        public Text Room;
        public Text Email;
        public Text Phone;
        public Text Position;
        public Text Type;

        public void Update () {
            //checks for member of staff
            if (AssignedStaff != null) {
                //if member of staff is found the text elements are updated
                //check if each field has a value so we dont put in incorrect data into the field

                string _name =  AssignedStaff.name;
                string room = AssignedStaff.room;
                string email = AssignedStaff.email;
                string phone =  AssignedStaff.phone;
                string position = AssignedStaff.position;
                string type = AssignedStaff._type;

                Name.text = "Name: " + _name;
                Room.text = "Room: " + room;
                Email.text = "Email Address: " + email;
                Phone.text = "Phone Number: " + phone;
                Position.text = "Position: " + position;
                Type.text = "Department: " + type;

            }
        }

        public void ClearStaff() {
            AssignedStaff = null;
        }
        

    }
}
