using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface IPlayer
    {
        string Name { get; }
        int PlayerNum { get; }

        public void PlayerInfo(string name, int pn);


    }
}
