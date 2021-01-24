using RaceSimulationWPF.Helpers;
using System;
using System.Linq;
using System.Windows.Input;
using RaceSimulationWPF.ViewModel;
using System.Windows.Forms;
using System.IO;

namespace RaceSimulationWPF.Commands
{
    class Export : ICommand
    {
        private RaceMainViewModel _vm;
        public Export(RaceMainViewModel vm)
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
            var xmlformat = new ExportFormat();
            xmlformat.StartList = _vm.SelectedPersons.ToList();
            xmlformat.RaceResults = _vm.RaceResults.ToList();

            var xmlData = Helper.SerializeToXmlDocument(xmlformat);          
            
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";      
            saveFileDialog1.Title = "Save XML File";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xml";
            saveFileDialog1.Filter = "XML Files|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var newXmlFile = File.Create(saveFileDialog1.FileName))
                {
                    xmlData.Save(newXmlFile);
                    MessageBox.Show("File Saved.");
                }               
            }            
        }
        
    }
}
