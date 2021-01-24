using Microsoft.Win32;
using RaceSimulationWPF.Helpers;
using RaceSimulationWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RaceSimulationWPF.Commands;
using RaceSimulationWPF.ViewModel;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace RaceSimulationWPF.Commands
{
    class RemovePersons : ICommand
    {
        private RaceMainViewModel _vm;
        public RemovePersons(RaceMainViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter == null)
                return;

            int sId = int.Parse(parameter.ToString());
            var filter = _vm.SelectedPersons.Where(p => p.Id != sId).ToList<Person>();
            _vm.SelectedPersons = filter;
        }
        
    }
}
