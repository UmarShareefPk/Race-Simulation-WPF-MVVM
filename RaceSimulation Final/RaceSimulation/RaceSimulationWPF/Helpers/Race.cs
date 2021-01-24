using RaceSimulationWPF.Model;
using RaceSimulationWPF.ViewModel;
using SwissTiming.Timing.AcquisitionSimulator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RaceSimulationWPF.Helpers
{
    public class Race
    {
        private RaceMainViewModel _vm;     
        private Simulator simulator;
        private DateTime StartTime; 
        public Race(RaceMainViewModel vm)
        {
            _vm = vm;            
        }

        public void StartRace()
        {
            IList<Person> sPersons = Helper.SortPersonList(_vm.SelectedPersons);
         
            List<Competitor> competitors = new List<Competitor>();

            foreach (var person in sPersons)
            {
                competitors.Add(new Competitor(person.Name, person.Id));
            }
            
            simulator = new Simulator(StartKind.MassStart);
            simulator.Initialize(competitors);
            simulator.RaceStarted += s_RaceStarted;
            simulator.CompetitorChanged += s_CompetitorChanged;
            simulator.RaceCompleted += s_RaceCompleted;
            
            _vm.RaceStatus = "Race has Started.".ToUpper();
            _vm.RaceStatusBackgroudColor = "Black";
            _vm.EnableActions = false;

            StartTime = DateTime.Now;                
            simulator.Start();
            
           
            //while (s.IsRunning) { }
        }

        private void s_RaceCompleted(object sender, RaceCompletedEventArgs e)
        {
            List<RaceResult> lst = new List<RaceResult>();           

            var person = _vm.SelectedPersons.Where(p => p.Id == e.Bib).First();  // Get current competitor and add in result
            lst.Add(new RaceResult
            {
                Competitor = new Person { Id = person.Id, Country = person.Country, Name = person.Name },
                Irm = null,
                EventTime = e.EventTime,
                Rank =null,
                NetTime = Math.Round((e.EventTime - StartTime).TotalSeconds , 1)  // calculate net time in seconds and round to 1 decimal place
            });

            foreach (RaceResult rr in _vm.RaceResults)   // add previously added competitors
            {
                lst.Add(new RaceResult
                {
                    Competitor = new Person { Id = rr.Competitor.Id, Country = rr.Competitor.Country, Name = rr.Competitor.Name },
                    Irm = rr.Irm,
                    EventTime = rr.EventTime,
                    Rank = rr.Rank,
                    NetTime = rr.NetTime
                });
            }
            _vm.RaceResults = lst;      
            _vm.RaceStatusColor = "LightGreen";
            _vm.RaceResults = Helper.SortResultsAndAssignRanks(_vm.RaceResults);   // Sort all competitors and assign ranks
            int rank = (int)_vm.RaceResults.Where(rr => rr.Competitor.Id == e.Bib)   // Get Rank to display on live window
                                           .First().Rank;
                                           
            _vm.RaceStatus = person.Name + " has completed the race.  RANK : " + rank;
            if (_vm.SelectedPersons.Count == _vm.RaceResults.Count)  // race eneded 
            {
               
                _vm.RaceStatus = "Race has finished.".ToUpper();
                _vm.RaceStatusColor = "White";
                _vm.EnableActions = true;
            }
                
        }

        private void s_RaceStarted(object sender, RaceStartedEventArgs e)
        {
            
        }

        private void s_CompetitorChanged(object sender, CompetitorChangedEventArgs e)
        {
            List<RaceResult> lst = new List<RaceResult>();

            var person = _vm.SelectedPersons.Where(p => p.Id == e.Bib).First();
            lst.Add(new RaceResult
            {
                Competitor = new Person { Id = person.Id, Country = person.Country, Name = person.Name },
                Irm = e.Irm.ToString(),
                Rank = null,
                EventTime = null,
                NetTime = null
            });

            foreach (RaceResult rr in _vm.RaceResults)
            {
                lst.Add(new RaceResult
                {
                    Competitor = new Person { Id = rr.Competitor.Id, Country = rr.Competitor.Country, Name = rr.Competitor.Name },
                    Irm = rr.Irm,
                    EventTime = rr.EventTime,
                    Rank = rr.Rank,
                    NetTime = rr.NetTime
                });
            }

            _vm.RaceResults = lst;
            

            _vm.RaceStatus = person.Name + " Competitor Changed. IRM : " + e.Irm;

            if(e.Irm.ToString().ToUpper() == "DNF")
                _vm.RaceStatusColor = "Orange";
            else if (e.Irm.ToString().ToUpper() == "DNF")
                _vm.RaceStatusColor = "Yellow";
            else if (e.Irm.ToString().ToUpper() == "DSQ")
                _vm.RaceStatusColor = "SkyBlue";

            _vm.RaceResults = Helper.SortResultsAndAssignRanks(_vm.RaceResults);
            if (_vm.SelectedPersons.Count == _vm.RaceResults.Count)
            {
              
                _vm.RaceStatus = "Race has finished.".ToUpper();
                _vm.RaceStatusColor = "White";
                _vm.EnableActions = true;
            }
        }

    }

}
