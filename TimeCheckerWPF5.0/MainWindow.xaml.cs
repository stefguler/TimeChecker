﻿using Microsoft.EntityFrameworkCore;
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
using TimeChecker.DAL.Data;
using TimeChecker.DAL.Models;
using TimeCheckerWPF5_0.Stores;
using TimeCheckerWPF5_0.ViewModels;
using TimeCheckerWPF5_0.Views;

namespace TimeCheckerWPF5_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NavigationStore navigationStore;

        public MainWindow()//ApplicationDbContext context)
        {

            InitializeComponent();

            Application.Current.Exit += new ExitEventHandler(ExitApp);
        }


        private void ExitApp(object sender, ExitEventArgs e)
        {
            MessageBox.Show("TimeChecker was terminated");
        }
    }
}