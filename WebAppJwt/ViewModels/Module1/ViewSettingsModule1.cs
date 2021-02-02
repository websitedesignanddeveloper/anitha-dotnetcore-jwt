using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

using WebAppJwt.Models;

namespace WebAppJwt.ViewModels.Module1
{
    public class ViewSettingsModule1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        #region Constructor

        public ViewSettingsModule1()
        {

        }

        #endregion

        #region Properties

        private bool _isRiverEventTableStrctChanged = false;
        public bool isRiverEventTableStrctChanged
        {
            get
            {
                return _isRiverEventTableStrctChanged;
            }
            set
            {
                _isRiverEventTableStrctChanged = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isRiverEventTableStrctChanged"));
            }
        }

        private bool _isBasicEntryAltered = false;
        public bool isBasicEntryAltered
        {
            get { return _isBasicEntryAltered; }
            set { _isBasicEntryAltered = value; OnPropertyChanged(new PropertyChangedEventArgs("isBasicEntryAltered")); }
        }

        private bool _isFatigueEntryAltered = false;
        public bool isFatigueEntryAltered
        {
            get { return _isFatigueEntryAltered; }
            set { _isFatigueEntryAltered = value; OnPropertyChanged(new PropertyChangedEventArgs("isFatigueEntryAltered")); }
        }

        private bool _isECAEntryAltered = false;
        public bool isECAEntryAltered
        {
            get { return _isECAEntryAltered; }
            set { _isECAEntryAltered = value; OnPropertyChanged(new PropertyChangedEventArgs("isECAEntryAltered")); }
        }


        private InpPipeData _PipeData = new InpPipeData();
        public InpPipeData PipeData
        {
            get { return _PipeData; }
            set { _PipeData = value; OnPropertyChanged(new PropertyChangedEventArgs("PipeData")); }
        }

        private InpFunctionalData _FuncData = new InpFunctionalData();
        public InpFunctionalData FuncData
        {
            get { return _FuncData; }
            set { _FuncData = value; OnPropertyChanged(new PropertyChangedEventArgs("FuncData")); }
        }

        private InpRiverData _RiverData = new InpRiverData();
        public InpRiverData RiverData
        {
            get { return _RiverData; }
            set { _RiverData = value; OnPropertyChanged(new PropertyChangedEventArgs("RiverData")); }
        }

        private InpCrossingData _CrossData = new InpCrossingData();
        public InpCrossingData CrossData
        {
            get { return _CrossData; }
            set { _CrossData = value; OnPropertyChanged(new PropertyChangedEventArgs("CrossData")); }
        }

        private InpSoilData _SoilData = new InpSoilData();
        public InpSoilData SoilData
        {
            get { return _SoilData; }
            set { _SoilData = value; OnPropertyChanged(new PropertyChangedEventArgs("SoilData")); }
        }

        private InpFatigueData _FatData = new InpFatigueData();
        public InpFatigueData FatData
        {
            get { return _FatData; }
            set { _FatData = value; OnPropertyChanged(new PropertyChangedEventArgs("FatData")); }
        }

        private InpECAData _EcaData = new InpECAData();
        public InpECAData EcaData
        {
            get { return _EcaData; }
            set { _EcaData = value; OnPropertyChanged(new PropertyChangedEventArgs("EcaData")); }
        }

        #endregion


        #region Methods

        public void CopySettingsTo(ViewSettingsModule1 vwSet1)
        {
            // Copy this Functional Data to vwSet1 
            // ================================================
            vwSet1.PipeData.Ds = this.PipeData.Ds.ToString();
            vwSet1.PipeData.E = this.PipeData.E.ToString();
            vwSet1.PipeData.EConc = this.PipeData.EConc.ToString();
            vwSet1.PipeData.surfaceRoughness = this.PipeData.surfaceRoughness.ToString();
            vwSet1.PipeData.tCoat = this.PipeData.tCoat.ToString();
            vwSet1.PipeData.tConc = this.PipeData.tConc.ToString();
            vwSet1.PipeData.WT = this.PipeData.WT.ToString();
            vwSet1.PipeData.fc = this.PipeData.fc.ToString();
            vwSet1.PipeData.rhoCoat = this.PipeData.rhoCoat.ToString();
            vwSet1.PipeData.rhoConc = this.PipeData.rhoConc.ToString();
            vwSet1.PipeData.rhoSteel = this.PipeData.rhoSteel.ToString();
            vwSet1.PipeData.alfaT = this.PipeData.alfaT.ToString();
            vwSet1.PipeData.nu = this.PipeData.nu.ToString();
            vwSet1.PipeData.AmpCD = this.PipeData.AmpCD.ToString();
            vwSet1.PipeData.AmpCL = this.PipeData.AmpCL.ToString();
            vwSet1.PipeData.YieldStress = this.PipeData.YieldStress.ToString();

            // Copy this Functional Data to vwSet1 
            // ================================================
            vwSet1.FuncData.Pin = this.FuncData.Pin.ToString();
            vwSet1.FuncData.Pout = this.FuncData.Pout.ToString();
            vwSet1.FuncData.g = this.FuncData.g.ToString();
            vwSet1.FuncData.rhoContent = this.FuncData.rhoContent.ToString();
            vwSet1.FuncData.rhoWater = this.FuncData.rhoWater.ToString();
            vwSet1.FuncData.Tin = this.FuncData.Tin.ToString();
            vwSet1.FuncData.Tout = this.FuncData.Tout.ToString();
            vwSet1.FuncData.Tres = this.FuncData.Tres.ToString();

            // Copy this River Data to vwSet1 
            // ===========================================
            vwSet1.RiverData.Coeff = this.RiverData.Coeff.ToString();
            vwSet1.RiverData.FlowModel = this.RiverData.FlowModel.ToString();
            vwSet1.RiverData.Ip = this.RiverData.Ip.ToString();
            vwSet1.RiverData.NumEvents = this.RiverData.NumEvents.ToString();
            vwSet1.RiverData.qMax = this.RiverData.qMax.ToString();
            vwSet1.RiverData.qMin = this.RiverData.qMin.ToString();

            int num = Convert.ToInt32(this.RiverData.NumEvents);
            vwSet1.RiverData.dtDuration.Rows.Clear();
            DataRow row;
            for (int i = 0; i < num; i++)
            {
                row = vwSet1.RiverData.dtDuration.NewRow();
                foreach (DataColumn col in vwSet1.RiverData.dtDuration.Columns)
                {
                    row[col.ColumnName] = this.RiverData.dtDuration.Rows[i][col.ColumnName].ToString();
                }
                vwSet1.RiverData.dtDuration.Rows.Add(row);
            }

            // Copy this Crossing Data to vwSet1 
            // ===========================================
            vwSet1.CrossData.minLspan = this.CrossData.minLspan.ToString();
            vwSet1.CrossData.maxLspan = this.CrossData.maxLspan.ToString();
            vwSet1.CrossData.numLspan = this.CrossData.numLspan.ToString();
            vwSet1.CrossData.minGap = this.CrossData.minGap.ToString();
            vwSet1.CrossData.maxGap = this.CrossData.maxGap.ToString();
            vwSet1.CrossData.numGap = this.CrossData.numGap.ToString();
            vwSet1.CrossData.minDelonD = this.CrossData.minDelonD.ToString();
            vwSet1.CrossData.minHeonD = this.CrossData.minHeonD.ToString();
            vwSet1.CrossData.minTheta = this.CrossData.minTheta.ToString();
            vwSet1.CrossData.minZonD = this.CrossData.minZonD.ToString();

            // Copy this Soil Data to vwSet1 
            // ===========================================
            vwSet1.SoilData.CL = this.SoilData.CL.ToString();
            vwSet1.SoilData.CV = this.SoilData.CV.ToString();
            vwSet1.SoilData.Cu = this.SoilData.Cu.ToString();
            vwSet1.SoilData.eSoil = this.SoilData.eSoil.ToString();
            vwSet1.SoilData.fc = this.SoilData.fc.ToString();
            vwSet1.SoilData.fphi = this.SoilData.fphi.ToString();
            vwSet1.SoilData.FricAngle = this.SoilData.FricAngle.ToString();
            vwSet1.SoilData.Ip = this.SoilData.Ip.ToString();
            vwSet1.SoilData.MuL = this.SoilData.MuL.ToString();
            vwSet1.SoilData.NuSoil = this.SoilData.NuSoil.ToString();
            vwSet1.SoilData.OCR = this.SoilData.OCR.ToString();
            vwSet1.SoilData.SoilSubWeight = this.SoilData.SoilSubWeight.ToString();
            vwSet1.SoilData.SoilStiffModelSelectionIndex = Convert.ToInt32(this.SoilData.SoilStiffModelSelectionIndex);
            vwSet1.SoilData.SoilTypeClass = this.SoilData.SoilTypeClass.ToString();
            vwSet1.SoilData.SoilType = this.SoilData.SoilType.ToString();
        }


        public void CopySettingsFrom(ViewSettingsModule1 vwSet1)
        {
            // Copy vwSet1 Functional Data to this
            // ================================================
            this.PipeData.Ds = vwSet1.PipeData.Ds.ToString();
            this.PipeData.E = vwSet1.PipeData.E.ToString();
            this.PipeData.EConc = vwSet1.PipeData.EConc.ToString();
            this.PipeData.surfaceRoughness = vwSet1.PipeData.surfaceRoughness.ToString();
            this.PipeData.tCoat = vwSet1.PipeData.tCoat.ToString();
            this.PipeData.tConc = vwSet1.PipeData.tConc.ToString();
            this.PipeData.WT = vwSet1.PipeData.WT.ToString();
            this.PipeData.fc = vwSet1.PipeData.fc.ToString();
            this.PipeData.rhoCoat = vwSet1.PipeData.rhoCoat.ToString();
            this.PipeData.rhoConc = vwSet1.PipeData.rhoConc.ToString();
            this.PipeData.rhoSteel = vwSet1.PipeData.rhoSteel.ToString();
            this.PipeData.alfaT = vwSet1.PipeData.alfaT.ToString();
            this.PipeData.nu = vwSet1.PipeData.nu.ToString();
            this.PipeData.AmpCD = vwSet1.PipeData.AmpCD.ToString();
            this.PipeData.AmpCL = vwSet1.PipeData.AmpCL.ToString();
            this.PipeData.YieldStress = vwSet1.PipeData.YieldStress.ToString();

            // Copy vwSet1 Functional Data to this 
            // ================================================
            this.FuncData.Pin = vwSet1.FuncData.Pin.ToString();
            this.FuncData.Pout = vwSet1.FuncData.Pout.ToString();
            this.FuncData.g = vwSet1.FuncData.g.ToString();
            this.FuncData.rhoContent = vwSet1.FuncData.rhoContent.ToString();
            this.FuncData.rhoWater = vwSet1.FuncData.rhoWater.ToString();
            this.FuncData.Tin = vwSet1.FuncData.Tin.ToString();
            this.FuncData.Tout = vwSet1.FuncData.Tout.ToString();
            this.FuncData.Tres = vwSet1.FuncData.Tres.ToString();

            // Copy vwSet1 River Data to this 
            // ===========================================
            this.RiverData.Coeff = vwSet1.RiverData.Coeff.ToString();
            this.RiverData.FlowModel = vwSet1.RiverData.FlowModel.ToString();
            this.RiverData.Ip = vwSet1.RiverData.Ip.ToString();
            this.RiverData.NumEvents = vwSet1.RiverData.NumEvents.ToString();
            this.RiverData.qMax = vwSet1.RiverData.qMax.ToString();
            this.RiverData.qMin = vwSet1.RiverData.qMin.ToString();

            int num = Convert.ToInt32(vwSet1.RiverData.NumEvents);
            this.RiverData.dtDuration.Rows.Clear();
            DataRow row;
            for (int i = 0; i < num; i++)
            {
                row = this.RiverData.dtDuration.NewRow();
                foreach (DataColumn col in this.RiverData.dtDuration.Columns)
                {
                    row[col.ColumnName] = vwSet1.RiverData.dtDuration.Rows[i][col.ColumnName].ToString();
                }
                this.RiverData.dtDuration.Rows.Add(row);
            }

            // Copy vwSet1 Crossing Data to this 
            // ===========================================
            this.CrossData.minLspan = vwSet1.CrossData.minLspan.ToString();
            this.CrossData.maxLspan = vwSet1.CrossData.maxLspan.ToString();
            this.CrossData.numLspan = vwSet1.CrossData.numLspan.ToString();
            this.CrossData.minGap = vwSet1.CrossData.minGap.ToString();
            this.CrossData.maxGap = vwSet1.CrossData.maxGap.ToString();
            this.CrossData.numGap = vwSet1.CrossData.numGap.ToString();
            this.CrossData.minDelonD = vwSet1.CrossData.minDelonD.ToString();
            this.CrossData.minHeonD = vwSet1.CrossData.minHeonD.ToString();
            this.CrossData.minTheta = vwSet1.CrossData.minTheta.ToString();
            this.CrossData.minZonD = vwSet1.CrossData.minZonD.ToString();

            // Copy vwSet1 Soil Data to this 
            // ===========================================
            this.SoilData.CL = vwSet1.SoilData.CL.ToString();
            this.SoilData.CV = vwSet1.SoilData.CV.ToString();
            this.SoilData.Cu = vwSet1.SoilData.Cu.ToString();
            this.SoilData.eSoil = vwSet1.SoilData.eSoil.ToString();
            this.SoilData.fc = vwSet1.SoilData.fc.ToString();
            this.SoilData.fphi = vwSet1.SoilData.fphi.ToString();
            this.SoilData.FricAngle = vwSet1.SoilData.FricAngle.ToString();
            this.SoilData.Ip = vwSet1.SoilData.Ip.ToString();
            this.SoilData.MuL = vwSet1.SoilData.MuL.ToString();
            this.SoilData.NuSoil = vwSet1.SoilData.NuSoil.ToString();
            this.SoilData.OCR = vwSet1.SoilData.OCR.ToString();
            this.SoilData.SoilSubWeight = vwSet1.SoilData.SoilSubWeight.ToString();
            this.SoilData.SoilStiffModelSelectionIndex = Convert.ToInt32(vwSet1.SoilData.SoilStiffModelSelectionIndex);
            this.SoilData.SoilTypeClass = vwSet1.SoilData.SoilTypeClass.ToString();
            this.SoilData.SoilType = vwSet1.SoilData.SoilType.ToString();
        }
        #endregion

    }
}
