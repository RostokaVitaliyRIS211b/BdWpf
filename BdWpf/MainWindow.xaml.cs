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
    }
}