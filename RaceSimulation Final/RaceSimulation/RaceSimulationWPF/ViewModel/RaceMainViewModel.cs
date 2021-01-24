using RaceSimulationWPF.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using RaceSimulationWPF.Commands;

namespace RaceSimulationWPF.ViewModel
{

    public class RaceMainViewModel : INotifyPropertyChanged
{
        private IList<Person> _EntryList;
        private IList<Person> _SelectedPersons;
        private IList<RaceResult> _RaceResults;
        private string _raceStatusColor;
        private string _raceStatus;
        private string _raceStatusBackgroudColor;
        private bool _enableActions;
        public RaceMainViewModel() 
        {
            _EntryList = new List<Person>(){ };
            _SelectedPersons = new List<Person>() { };
            _RaceResults = new List<RaceResult>() { };
            _raceStatus = "";
            _raceStatusColor = "White";
            _raceStatusBackgroudColor = "White";
            _enableActions = true;
        }

        public  IList<Person> EntryList
        {
            get { return _EntryList; }
            set 
            { 
                _EntryList = value; 
                OnPropertyChanged("EntryList"); 
            }
        }

        public IList<Person> SelectedPersons
        {
            get { return _SelectedPersons; }
            set 
            { 
                _SelectedPersons = value; 
                OnPropertyChanged("SelectedPersons"); 
            }
        }

        public IList<RaceResult> RaceResults
        {
            get { return _RaceResults; }
            set
            {
                _RaceResults = value;
                OnPropertyChanged("RaceResults");
            }
        }

        public string RaceStatus
        {
            get { return _raceStatus; }
            set
            {
                _raceStatus = value;
                OnPropertyChanged("RaceStatus");
            }
        }

        public string RaceStatusColor
        {
            get { return _raceStatusColor; }
            set
            {
                _raceStatusColor = value;
                OnPropertyChanged("RaceStatusColor");
            }
        }

        public string RaceStatusBackgroudColor
        {
            get { return _raceStatusBackgroudColor; }
            set
            {
                _raceStatusBackgroudColor = value;
                OnPropertyChanged("RaceStatusBackgroudColor");
            }
        }

        public bool EnableActions
        {
            get { return _enableActions; }
            set
            {
                _enableActions = value;
                OnPropertyChanged("EnableActions");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        ///////////// Commands ///////////////

        private ICommand mLoadPersons;
        public ICommand LoadPersonsCommand
        {
            get
            {
                if (mLoadPersons == null)
                    mLoadPersons = new LoadPersons(this);
                return mLoadPersons;
            }
            set
            {
                mLoadPersons = value;
            }
        }


        private ICommand mSelectPersons;
        public ICommand SelectPersonsCommand
        {
            get
            {
                if (mSelectPersons == null)
                    mSelectPersons = new SelectPersons(this);
                return mSelectPersons;
            }
            set
            {
                mSelectPersons = value;
            }
        }

        private ICommand mStartRace;
        public ICommand StartRaceCommand
        {
            get
            {
                if (mStartRace == null)
                    mStartRace = new StartRace(this);
                return mStartRace;
            }
            set
            {
                mStartRace = value;
            }
        }

        private ICommand mExport;
        public ICommand ExportCommand
        {
            get
            {
                if (mExport == null)
                    mExport = new Export(this);
                return mExport;
            }
            set
            {
                mExport = value;
            }
        }

        private ICommand mReset;
        public ICommand ResetCommand
        {
            get
            {
                if (mReset == null)
                    mReset = new Reset(this);
                return mReset;
            }
            set
            {
                mReset = value;
            }
        }

        private ICommand mRemovePersons;
        public ICommand RemovePersonsCommand
        {
            get
            {
                if (mRemovePersons == null)
                    mRemovePersons = new RemovePersons(this);
                return mRemovePersons;
            }
            set
            {
                mRemovePersons = value;
            }
        }


        /// ///////  End Commands /////////////




    } // End of class
} // End of namespace
