using RaceSimulationWPF.Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using RaceSimulationWPF.ViewModel;

namespace RaceSimulationWPF.Commands
{
    class Reset : ICommand
    {
        private RaceMainViewModel _vm;
        public Reset(RaceMainViewModel vm)
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
            var emptyList = new List<Person>() { };
            var emptyList1 = new List<RaceResult>() { };

            _vm.EntryList = emptyList;
            _vm.SelectedPersons = emptyList;
            _vm.RaceResults = emptyList1;
            _vm.RaceStatus = "";
            _vm.RaceStatusBackgroudColor = "White";
            _vm.EnableActions = true;
        }
        
    }
}
