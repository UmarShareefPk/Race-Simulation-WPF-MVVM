using RaceSimulationWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using RaceSimulationWPF.ViewModel;

namespace RaceSimulationWPF.Commands
{
    class SelectPersons : ICommand
    {
        private RaceMainViewModel _vm;
        public SelectPersons(RaceMainViewModel vm)
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

            var filter = _vm.EntryList.Where(p => p.Id == sId).ToList<Person>()[0];

            var nlist = new List<Person>();
            
            foreach (Person p in _vm.SelectedPersons) // Add all priviously selected
            {
                nlist.Add(new Person { Id = p.Id, Name = p.Name, Country = p.Country });
            }
            var per = new Person { Id = filter.Id, Name = filter.Name, Country = filter.Country };

            if (!nlist.Exists(p => p.Id == per.Id)) // if not already added then add
                nlist.Add(per);

            _vm.SelectedPersons = nlist;
        }
        
    }
}
