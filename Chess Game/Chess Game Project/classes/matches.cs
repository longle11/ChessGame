using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_Project.classes
{
    public class matches
    {
        public string _id { get; set; }
        public List<matchPlayer> players { get; set; }
        public string status { get; set; }
        public int count { get; set; }
        public int betPoints { get; set; }
        public string roomName { get; set; }
        public string ownerRoom { get; set; }
        public string ipRoom { get; set; }
    }
}
