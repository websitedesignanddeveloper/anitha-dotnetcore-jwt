using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
//using LiveCharts;
//using LiveCharts.Wpf;
//using LiveCharts.Defaults;

using WebAppJwt.Models;

namespace WebAppJwt.ViewModels.Module1
{
    public class InpRiverData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        #region Constructor
        public InpRiverData()
        {
         
        }

        #endregion
        // ==========================================================================
        // INPUT PARAMETERS
        // ==========================================================================

        private string _FlowModel;
        public string FlowModel
        {
            get { return _FlowModel; }
            set
            {
                _FlowModel = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FlowModel"));             
            }
        }

        private string _ChezyCoeff;
        public string ChezyCoeff
        {
            get { return _ChezyCoeff; }
            set
            {
                _ChezyCoeff = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ChezyCoeff"));
            }
        }

        private string _xAxisTitle = "q (Discharge) (m³/s/m)";
        public string xAxisTitle
        {
            get { return _xAxisTitle; }
            set
            {
                _xAxisTitle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("xAxisTitle"));
            }
        }

        private string _ManningCoeff;
        public string ManningCoeff
        {
            get { return _ManningCoeff; }
            set
            {
                _ManningCoeff = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ManningCoeff"));
            }
        }

        private string _Coeff;
        public string Coeff
        {
            get { return _Coeff; }
            set
            {
                _Coeff = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Coeff"));
            }
        }

        private string _Ip;
        public string Ip
        {
            get { return _Ip; }
            set
            {
                _Ip = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Ip"));
            }
        }

        private string _NumEvents;
        public string NumEvents
        {
            get { return _NumEvents; }
            set
            {
                _NumEvents = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NumEvents"));
            }
        }

        private string _qMin;
        public string qMin
        {
            get { return _qMin; }
            set
            {
                _qMin = value;
                OnPropertyChanged(new PropertyChangedEventArgs("qMin"));
            }
        }

        private string _qMax;
        public string qMax
        {
            get { return _qMax; }
            set
            {
                _qMax = value;
                OnPropertyChanged(new PropertyChangedEventArgs("qMax"));
            }
        }

        private DataTable _dtDuration = new DataTable();
        public DataTable dtDuration
        {
            get { return _dtDuration; }
            set
            {
                _dtDuration = value;
                OnPropertyChanged(new PropertyChangedEventArgs("dtDuration"));
            }
        }

       

        public void UpdateNumRowsDurationTable()
        {
            int numRows = Convert.ToInt32(this.NumEvents);
            double qMaxVal = Convert.ToDouble(this.qMax);
            double qMinVal = Convert.ToDouble(this.qMin);
            double delq = (qMaxVal - qMinVal) / (numRows - 1);

            // The default probablity distribution is considered as P(q) = qMin / q. 
            // Then the accumulated probablity is normalized in the range of 1000.

            dtDuration.Rows.Clear();
            DataRow row;
            double sum = 0;
            for (int i = 0; i < numRows; i++)
            {                
                row = dtDuration.NewRow();
                row["EventNum"] = i + 1;
               
                dtDuration.Rows.Add(row);
            }

            double factor = 1000 / sum;
            double last_pq = 0;
            for (int i = 0; i < numRows; i++)
            {
                if (i == numRows - 1)
                {
                   
                }
                else
                {
                    if (i != 0)
                    {
                       
                    }
                 
                }               
            }

            UpdateDischargeChart();
        }

        public void UpdateMinMaxDurationTable()
        {
            int numRows = Convert.ToInt32(this.NumEvents);
            double qMaxVal = Convert.ToDouble(this.qMax);
            double qMinVal = Convert.ToDouble(this.qMin);
            double delq = (qMaxVal - qMinVal) / (numRows - 1);

            for (int i = 0; i < numRows; i++)
            {
                if (i == numRows - 1)
                {
                  
                }
                else
                {
                  
                }
            }

            UpdateDischargeChart();
        }

        public void UpdateCellValueDurationTable(int i, int j, string cellValue)
        {
            dtDuration.Rows[i][j] = cellValue;
        }

        public void UpdateDischargeChart()
        {
            int numRows = Convert.ToInt32(this.NumEvents);
           

            for (int i = 0; i < numRows; i++)
            {
                double YY = 0;
               
                if (i == 0)
                {
                 
                }
                else
                {
                    
                }

               
            }

           
        }
    }
}
