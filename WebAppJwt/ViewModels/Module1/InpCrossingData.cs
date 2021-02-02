using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace WebAppJwt.ViewModels.Module1
{
    public class InpCrossingData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public InpCrossingData()
        {

        }

        private bool _isLspanRangeChecked = false;
        public bool isLspanRangeChecked
        {
            get { return _isLspanRangeChecked; }
            set { _isLspanRangeChecked = value; OnPropertyChanged(new PropertyChangedEventArgs("isLspanRangeChecked")); }
        }

        private bool _isGapRangeChecked = false;
        public bool isGapRangeChecked
        {
            get { return _isGapRangeChecked; }
            set { _isGapRangeChecked = value; OnPropertyChanged(new PropertyChangedEventArgs("isGapRangeChecked")); }
        }

        private string _minLspan;
        public string minLspan
        {
            get { return _minLspan; }
            set { _minLspan = value; OnPropertyChanged(new PropertyChangedEventArgs("minLspan")); }
        }

        private string _maxLspan;
        public string maxLspan
        {
            get { return _maxLspan; }
            set { _maxLspan = value; OnPropertyChanged(new PropertyChangedEventArgs("maxLspan")); }
        }

        private string _numLspan;
        public string numLspan
        {
            get { return _numLspan; }
            set { _numLspan = value; OnPropertyChanged(new PropertyChangedEventArgs("numLspan")); }
        }

        private string _minGap;
        public string minGap
        {
            get { return _minGap; }
            set { _minGap = value; OnPropertyChanged(new PropertyChangedEventArgs("minGap")); }
        }

        private string _maxGap;
        public string maxGap
        {
            get { return _maxGap; }
            set { _maxGap = value; OnPropertyChanged(new PropertyChangedEventArgs("maxGap")); }
        }

        private string _numGap;
        public string numGap
        {
            get { return _numGap; }
            set { _numGap = value; OnPropertyChanged(new PropertyChangedEventArgs("numGap")); }
        }

        private string _minTheta;
        public string minTheta
        {
            get { return _minTheta; }
            set { _minTheta = value; OnPropertyChanged(new PropertyChangedEventArgs("minTheta")); }
        }

        private string _minHeonD;
        public string minHeonD
        {
            get { return _minHeonD; }
            set { _minHeonD = value; OnPropertyChanged(new PropertyChangedEventArgs("minHeonD")); }
        }

        private string _minZonD;
        public string minZonD
        {
            get { return _minZonD; }
            set { _minZonD = value; OnPropertyChanged(new PropertyChangedEventArgs("minZonD")); }
        }

        private string _minDelonD;
        public string minDelonD
        {
            get { return _minDelonD; }
            set { _minDelonD = value; OnPropertyChanged(new PropertyChangedEventArgs("minDelonD")); }
        }
    }
}
