using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using RaceSimulationWPF.Model;
using RaceSimulationWPF.Helpers;

namespace RaceSimulationWPF.ViewModel
{
    /// <summary>
    /// Interaction logic for RaceMain.xaml
    /// </summary>
    public partial class RaceMain : Window
    {
        public RaceMain()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.CanMinimize;
        }

       
    }// class ends
}
