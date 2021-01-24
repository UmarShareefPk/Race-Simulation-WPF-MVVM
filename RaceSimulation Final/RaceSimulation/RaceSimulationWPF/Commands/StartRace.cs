using RaceSimulationWPF.Helpers;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using RaceSimulationWPF.ViewModel;
using System.Threading;
using System.Windows.Forms;

namespace RaceSimulationWPF.Commands
{
    class StartRace : ICommand
    {
        private RaceMainViewModel _vm;
        public StartRace(RaceMainViewModel vm)
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
            if(_vm.SelectedPersons.Count() == 0)
            {
                MessageBox.Show("Please select persons first.");
                return;
            }

            _vm.RaceResults.Clear();

            var sync = SynchronizationContext.Current;
            BackgroundWorker w = new BackgroundWorker();  // async
           
            w.DoWork += (sender, e) =>
            {               
                sync.Post(p => {
                    Race race = new Race(_vm);
                    race.StartRace();
                    
                }, null);
            };          
            w.RunWorkerAsync();         
        }

       
    }
}