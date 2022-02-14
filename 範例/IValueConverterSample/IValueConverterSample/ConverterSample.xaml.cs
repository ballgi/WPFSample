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

namespace IValueConverterSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConverterSample : Window
    {
        public ConverterSample()
        {
            InitializeComponent();
        }
    }

	public class YesNoToBooleanConverter : IValueConverter
	{
		/// <summary>
		/// 接收一個string作為輸入（value參數），然後將其轉換為布林值true或false值
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			switch (value.ToString().ToLower())
			{
				case "yes":
				case "oui":
					return true;
				case "no":
				case "non":
					return false;
			}
			return false;
		}

		/// <summary>
		/// 它假設一個bool類型的輸入值，然後返回英文單字
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((bool)value == true)
					return "yes";
				else
					return "no";
			}
			return "no";
		}
	}
}
