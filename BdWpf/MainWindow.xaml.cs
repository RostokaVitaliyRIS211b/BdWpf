﻿using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace BdWpf
{
    public partial class MainWindow : Window
    {
        ApplicationContext db = null;
        public MainWindow()
        {
            InitializeComponent();
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=7331").Options;
            db= new ApplicationContext(options);
            List<string> results = db.Database.SqlQueryRaw<string>("SELECT table_name FROM information_schema.tables WHERE table_schema='public'").ToList();
            queryList.ItemsSource =results;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Database.CloseConnection();
            db.Dispose();
            db=null;
        }

        private void Button_SqlQuery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_SqlTable_Click(object sender, RoutedEventArgs e)
        {
            string s = queryList.SelectedItem as string;
            switch (s)
            {
                case "typesoforganizations":
                    dataGrid.ItemsSource = db.typesoforganizations.ToList();
                    break;
                case "typesofjournals":
                    dataGrid.ItemsSource = db.typesofjournals.ToList();
                    break;
                case "namesofjournals":
                    dataGrid.ItemsSource = db.namesofjournals.ToList();
                    break;
                case "statusesofdelivery":
                    dataGrid.ItemsSource = db.statusesofdelivery.ToList();
                    break;
                case "statusesofsubscription":
                    dataGrid.ItemsSource = db.statusesofsubscription.ToList();
                    break;
                case "literatureoragnizations":
                    dataGrid.ItemsSource = db.literatureoragnizations.ToList();
                    break;
                case "journals":
                    dataGrid.ItemsSource = db.journals.ToList();
                    break;
                case "subscribers":
                    dataGrid.ItemsSource = db.subscribers.ToList();
                    break;
                case "subscriptions":
                    dataGrid.ItemsSource = db.subscriptions.ToList();
                    break;
                default:
                    break;
            }

        }
    }
}