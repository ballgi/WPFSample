using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace 範例WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<User> users = new List<User>();

        //對資料源 response
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();

            users.Add(new User() { Name = "John Doe" });
            users.Add(new User() { Name = "Jane Doe" });

            lbUsers.ItemsSource = users;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "New user" });
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
                (lbUsers.SelectedItem as User).Name = "Random Name";
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
                users.Remove(lbUsers.SelectedItem as User);
        }

        //public class User
        //{
        //    public string Name { get; set; }
        //}

        //反應 data objecct的變化[INotifyPropertyChanged]
        public class User : INotifyPropertyChanged
        {
            private string name;
            public string Name
            {
                get { return this.name; }
                set
                {
                    if (this.name != value)
                    {
                        this.name = value;
                        this.NotifyPropertyChanged();
                    }
                }
            }
            
            #region NotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            //public void NotifyPropertyChanged(string propName)
            //CallerMemberName取得 呼叫端(方法的)方法或屬性名稱
            public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                //if (this.PropertyChanged != null)
                //    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            } 
            #endregion
        }
    }
}
