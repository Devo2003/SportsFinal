﻿using SportsFinal.Models;
using SportsFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportsFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BaseViewModel();
        }
        /*
        private void AddSport_Click(object sender, RoutedEventArgs e)
        {
            ((BaseViewModel)DataContext).Sports.Add(new Models.SportsModel { Name = "Sport Name", Description = "Describe the Sport" });

        }

        private void AddTeam_Click(object sender, RoutedEventArgs e)
        {
            ((BaseViewModel)DataContext).Teams.Add(new TeamsModel { Name = "New Team", SportsModel = ((BaseViewModel)DataContext).ChosenSport });
        }
        */
    }
}
