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


namespace TimeCheckerWPF5._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationDbContext _context;
        DateTime currentDate = DateTime.Now;
        private int _TimeentryId;


        public MainWindow()
        {

            InitializeComponent();
            SetUp();
            LoadDatagrid();
        }


        public void SetUp()
        {
            _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TimeChecker;Trusted_Connection=True;MultipleActiveResultSets=true")
               .Options);
        }

        private void LoadDatagrid()
        {
            var timeentryitems = _context.Timeentry.ToList();
            TimeentryGrid.ItemsSource = timeentryitems;
        }

        public void clearData()
        {
            Type_txt.Clear();
            Comment_txt.Clear();
            User_txt.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }


        private void Insert(object sender, RoutedEventArgs e)
        {
            short Type_int = Int16.Parse(Type_txt.Text);

            var record = new Timeentry()
            {
                Type = Type_int,
                DateTime = currentDate,
                Comment = Comment_txt.Text,
                User = User_txt.Text,
            };

            _context.Timeentry.Add(record);

            _context.SaveChanges();

           // _TimeentryId = record.ID;

            LoadDatagrid();

        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int ID_int = Int32.Parse(ID_txt.Text);

            var existing = _context.Timeentry.Single(x => x.ID == ID_int);
            //var existing = _context.Timeentry.Single(x => x.Type == 2);

            _context.Timeentry.Remove(existing);

            _context.SaveChanges();

            LoadDatagrid();
        }


        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            int ID_int = Int32.Parse(ID_txt.Text);
            short Type_int = Int16.Parse(Type_txt.Text);

            var existing = _context.Timeentry.Single(x => x.ID == ID_int);


            existing.Type = Type_int;
            existing.DateTime = currentDate;
            existing.Comment = Comment_txt.Text;
            existing.User = User_txt.Text;

            _context.SaveChanges();

            LoadDatagrid();

        }
    }
}




//public void InsertTimeentry()
//{
//    var record = new Timeentry()
//    {
//        Type = 6,
//        Comment = "Organize meeting to discuss the project"
//    };

//    _context.Timeentry.Add(record);

//    _context.SaveChanges();

//}