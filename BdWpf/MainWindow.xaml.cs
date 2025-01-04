using Microsoft.EntityFrameworkCore;
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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BdWpf
{
    public partial class MainWindow : Window
    {
        ApplicationContext db = null!;
        public MainWindow()
        {
            InitializeComponent();
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=7331").Options;
            db= new ApplicationContext(options);
            var results = db.Database.SqlQueryRaw<string>("SELECT table_name FROM information_schema.tables WHERE table_schema='public'").ToArray();
            queryList.ItemsSource =results;
            queryTextbox.TextWrapping=TextWrapping.Wrap;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Database.CloseConnection();
            db.Dispose();
            db=null;
        }

        private void Button_SqlQuery_Click(object sender, RoutedEventArgs e)
        {
            if(queryTextbox.Text.Length>0)
            {
                try
                {
                    db.Database.ExecuteSqlRaw(queryTextbox.Text);
                    MessageBox.Show("Запрос успешно обработан");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_SqlTable_Click(object sender, RoutedEventArgs e)
        {
            string s = queryList.SelectedItem as string;
            switch (s)
            {
                case "typesoforganizations":
                    dataGrid.ItemsSource = db.typesoforganizations.ToArray();
                    break;
                case "typesofjournals":
                    dataGrid.ItemsSource =  db.typesofjournals.ToArray();
                    break;
                case "namesofjournals":
                    dataGrid.ItemsSource =  db.namesofjournals.ToArray();
                    break;
                case "statusesofdelivery":
                    dataGrid.ItemsSource =  db.statusesofdelivery.ToArray();
                    break;
                case "statusesofsubscription":
                    dataGrid.ItemsSource =  db.statusesofsubscription.ToArray();
                    break;
                case "literatureoragnizations":
                    dataGrid.ItemsSource =  db.literatureoragnizations.ToArray();
                    break;
                case "journals":
                    dataGrid.ItemsSource =  db.journals.ToArray();
                    break;
                case "subscribers":
                    dataGrid.ItemsSource = db.subscribers.ToArray();
                    break;
                case "subscriptions":
                    dataGrid.ItemsSource = db.subscriptions.ToArray();
                    break;
                default:
                    break;
            }
        }

        private void Button_UndeliveredJournals_Click(object sender, RoutedEventArgs e)
        {
            var result = db.subscriptions.FromSqlRaw("SELECT * FROM subscriptions WHERE idofstatusdelivery=2").ToArray();
            dataGrid.ItemsSource = result;
        }
    }
}