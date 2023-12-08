using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int PlayerNum { get; set; }

        

        public Player( ) 
        {
        }

        public void PlayerInfo(string name, int pn)
        {
            this.Name = name;
            this.PlayerNum = pn;
        }
    }
}
