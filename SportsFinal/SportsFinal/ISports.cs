﻿using SportsFinal.Models;
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

        public string Sportsname { get; set; }
        public string description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName) { }
        public void RemoveSport(ObservableCollection<SportsModel> sports, ref SportsModel chosenSport);
        public void EditSportName();


    }
}
