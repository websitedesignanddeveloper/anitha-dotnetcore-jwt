using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace WebAppJwt.ViewModels.Module1
{
    public class InpFunctionalData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public InpFunctionalData()
        {

        }

        // ==========================================================================
        // INPUT PARAMETERS
        // ==========================================================================

        private string _rhoWater;
        public string rhoWater
        {
            get { return _rhoWater; }
            set
            {
                _rhoWater = value;
                OnPropertyChanged(new PropertyChangedEventArgs("rhoWater"));
            }
        }

        private string _Tout;
        public string Tout
        {
            get { return _Tout; }
            set
            {
                _Tout = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Tout"));
            }
        }

        private string _Tin;
        public string Tin
        {
            get { return _Tin; }
            set
            {
                _Tin = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Tin"));
            }
        }

        private string _Pin;
        public string Pin
        {
            get { return _Pin; }
            set
            {
                _Pin = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Pin"));
            }
        }

        private string _Pout;
        public string Pout
        {
            get { return _Pout; }
            set
            {
                _Pout = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Pout"));
            }
        }

        private string _rhoContent;
        public string rhoContent
        {
            get { return _rhoContent; }
            set
            {
                _rhoContent = value;
                OnPropertyChanged(new PropertyChangedEventArgs("rhoContent"));
            }
        }

        private string _Tres;
        public string Tres
        {
            get { return _Tres; }
            set
            {
                _Tres = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Tres"));
            }
        }

        private string _g;
        public string g
        {
            get { return _g; }
            set
            {
                _g = value;
                OnPropertyChanged(new PropertyChangedEventArgs("g"));
            }
        }
    }
}
