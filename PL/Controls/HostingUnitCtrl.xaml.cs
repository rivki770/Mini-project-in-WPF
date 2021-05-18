using BE;
using BL;
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

namespace PL.Controls
{
    /// <summary>
    /// Interaction logic for UnitHostingCtrl.xaml
    /// </summary>
    public partial class UnitHostingCtrl : UserControl
    {

        public HostingUnit CurrHostingUnit { get; set; }
        private IAppLogic app { get; set; }
        public UnitHostingCtrl(HostingUnit _CurrHostingUnit, IAppLogic _app)
        {
            this.app = _app;
            this.CurrHostingUnit = _CurrHostingUnit;
            InitializeComponent();
            hostUnitGrid.DataContext = CurrHostingUnit;
        }
       
    }
}
