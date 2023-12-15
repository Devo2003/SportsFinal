using SportsFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface ISports
    {
        string Name { get; set; }
        string Description { get; set; }

        string Sportsname { get; set; }
        string description { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void RemoveSport(ObservableCollection<SportsModel> sports, ref SportsModel chosenSport);
        void EditSportName();



    }
}
