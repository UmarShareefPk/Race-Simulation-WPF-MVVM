using RaceSimulationWPF.Helpers;
using RaceSimulationWPF.ViewModel;
using System;
using System.Windows.Input;
using System.Windows.Forms;

namespace RaceSimulationWPF.Commands
{
    class LoadPersons : ICommand
    {
        private RaceMainViewModel _vm;
        public LoadPersons(RaceMainViewModel vm)
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
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.DefaultExt = "xml";
                openFileDialog.Filter = "XML Files|*.xml";

                if (openFileDialog.ShowDialog() == true)
                {
                    string s = openFileDialog.FileName;
                    var list = Helper.GetPersonsFromXML(s);
                    _vm.EntryList = list;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loadind XML file. Please make sure the file is correct.");
            }
        }
    }
}
