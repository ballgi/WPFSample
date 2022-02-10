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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext binding
            this.DataContext = this;

            //後端binding 屬性
            #region 建立binding物件
            //path property
            Binding height = new Binding("Height");
            //source 
            height.Source = window;
            #endregion
            
            Wheight.SetBinding(TextBox.TextProperty, height);

            //後端 binding 事件
            btn1.MouseMove += Btn1_MouseMove;
        }

        private void Btn1_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("You MouseMov me at " + e.GetPosition(this).ToString());
        }


        private void exit(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
           
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            /*該屬性默認值為“Default" ==> 根據您綁定的屬性來更新，
              除了**Text屬性***之外的所有屬性在屬性更改時立即更新（PropertyChanged），
            而當目標元素丟失焦點時（LostFocus），Text屬性才會更新*/

            #region Explicit 明確updateSource才會更新
            BindingExpression binding = WWeidth.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource(); 
            #endregion
        }
    }
}
