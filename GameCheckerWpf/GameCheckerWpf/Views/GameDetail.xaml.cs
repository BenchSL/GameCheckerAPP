﻿using GameCheckerAPI.Models;
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

namespace GameCheckerWpf.Views
{
    /// <summary>
    /// Interaction logic for GameDetail.xaml
    /// </summary>
    public partial class GameDetail : UserControl
    {
        public GameDetail()
        {
            InitializeComponent();
        }

        public void SetGameData(GameModel gameData)
        {
            // Display gameData in the controls of GameDetailsWindow
            // For example:
            // gameNameTextBlock.Text = gameData.Name;
            // ...
        }
    }
}
