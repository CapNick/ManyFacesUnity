using System;
using System.Collections;
using System.Collections.Generic;

namespace Models {
    [Serializable]
    public class Staff {
        public int id;
        public string name;
        public string room;
        public string email;
        public string phone;
        public string position;
        public string _type;
        
        public string ovr_name;
        public string ovr_room;
        public string ovr_email;
        public string ovr_phone;
        public string ovr_position;
        public string ovr_type;
        
        public Dictionary<string,string> model_file;
        public int _index;
        public string updated_at;
    }
}