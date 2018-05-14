﻿using UnityEngine;
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
                if (AssignedStaff.ovr_name != null || AssignedStaff.ovr_name != "") {
                    _name = AssignedStaff.ovr_name;
                }
                string room = AssignedStaff.room;
                if (AssignedStaff.ovr_room != null || AssignedStaff.ovr_room != "") {
                    _name = AssignedStaff.ovr_room;
                }
                string email = AssignedStaff.email;
                if (AssignedStaff.ovr_email != null || AssignedStaff.ovr_email != "") {
                    _name = AssignedStaff.ovr_email;
                }
                string phone =  AssignedStaff.phone;
                if (AssignedStaff.ovr_phone != null || AssignedStaff.ovr_phone != "") {
                    _name = AssignedStaff.ovr_phone;
                }
                string position = AssignedStaff.position;
                if (AssignedStaff.ovr_position != null || AssignedStaff.ovr_position != "") {
                    _name = AssignedStaff.ovr_position;
                }
                string type = AssignedStaff._type;
                if (AssignedStaff.ovr_type != null || AssignedStaff.ovr_type != "") {
                    _name = AssignedStaff.ovr_type;
                }

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
