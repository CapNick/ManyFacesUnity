using System;

namespace Models {
    [Serializable]
    public class Staff
    {
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
        public string model_url;
        public string order;

    }
}