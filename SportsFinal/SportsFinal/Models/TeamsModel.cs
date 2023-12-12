using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal.Models
{
    public class TeamsModel
    {
        public string Name { get; set; }
        public SportsModel SportsModel { get; set; }
        public List <PlayerModel> PlayerModels { get; set; }

        public TeamsModel() 
        {
        PlayerModels = new List<PlayerModel>();
        
        }
    }
}
