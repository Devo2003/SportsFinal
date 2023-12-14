using SportsFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal.Models
{
    public class SportsModel : PropertyChangeFunctions, ISports
    {
        //Sports should have a name and the description
        public string Sportsname { get; set; }
        public string description { get; set; }

        public string Name
        {
            get { return Sportsname; }
            set
            {
                if (Sportsname != value)
                {
                    Sportsname = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public static SportsModel CreateNewSport()
        {
            return new SportsModel { Name = "Sport name", Description = "Describe sport" };
        }

        public void RemoveSport(ObservableCollection<SportsModel> sports, ref SportsModel chosenSport)
        {
            if (chosenSport != null)
            {
                sports.Remove(chosenSport);
                chosenSport = null;
            }
        }


        // Edit Sport Name
        public void EditSportName()
        {
            InputDialog dialog = new InputDialog("Edit Sport Name", "Enter a new name:", Name);
            dialog.ShowDialog();

            // Update the sport name if the result is not null
            if (dialog.Result != null)
            {
                Name = dialog.Result;
            }
        }

    }
}
