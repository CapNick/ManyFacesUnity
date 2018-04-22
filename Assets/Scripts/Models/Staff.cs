using System;
using System.Collections;

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
        public string ovr_modules;
        public string ovr_email;
        public string ovr_phone;
        
        public bool visible;
        public IList model_file;
        public string _index;

    }
}