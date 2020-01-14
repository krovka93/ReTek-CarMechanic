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
using System.Windows.Shapes;
using ReTek_CarMechanical.ViewModels;

namespace ReTek_CarMechanical.Views
{
    /// <summary>
    /// Interaction logic for ServiceView.xaml
    /// </summary>
    public partial class ServiceView : Window
    {
        public ServiceView()
        {
            InitializeComponent();
            DataContext = new ServiceViewModel();
        }
    }
}
