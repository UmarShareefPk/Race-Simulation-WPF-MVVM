using System;
using System.ComponentModel;

namespace RaceSimulationWPF.Model
{
    public class RaceResult : INotifyPropertyChanged
    {
        private Person competitor;
        private string irm;
        private int? rank;
        private DateTime? eventTime;
        private double? netTime;

        public Person Competitor
        {
            get
            {
                return competitor;
            }
            set
            {
                competitor = value;
                OnPropertyChanged("Competitor");
            }
        }

        public string Irm
        {
            get
            {
                return irm;
            }
            set
            {
                irm = value;
                OnPropertyChanged("Irm");
            }
        }

        public int? Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
                OnPropertyChanged("Rank");
            }
        }

        public DateTime? EventTime
        {
            get
            {
                return eventTime;
            }
            set
            {
                eventTime = value;
                OnPropertyChanged("EventTime");
            }
        }

        public double? NetTime
        {
            get
            {
                return netTime;
            }
            set
            {
                netTime = value;
                OnPropertyChanged("NetTime");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    } // end class
}
