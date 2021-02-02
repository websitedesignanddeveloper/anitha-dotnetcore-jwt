using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Diagnostics;

using WebAppJwt.Models;
using WebAppJwt.ViewModels.Module1;


namespace WebAppJwt.ViewModels.Main
{
    public class ViewModelMainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        #region Property

        //public InputParameters inPara;
        //public OutputParameters outPara;

        private bool isThemeDark = false;
        public bool IsThemeDark
        {
            get { return isThemeDark; }
            set
            {
                isThemeDark = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsThemeDark"));
                isThemeAltered();
            }
        }

        private bool _isRunOnGoing = false;
        public bool isRunOnGoing
        {
            get { return _isRunOnGoing; }
            set
            {
                _isRunOnGoing = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isRunOnGoing"));
              //  App.RunAnalysis_ViewModel.DisplaySettings.isRunOnGoing = _isRunOnGoing;
            }
        }

        private string _windowTitle = "Welcome to River-X";
        public string windowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("windowTitle"));
            }
        }

        private bool _isUnitSI = true;
        public bool isUnitSI
        {
            get { return _isUnitSI; }
            set
            {
                _isUnitSI = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isUnitSI"));
                if (_isUnitSI)
                {
                    Unit = "SI";
                }
                else
                {
                    Unit = "English";
                }
                UnitSetup();

               /* if (App.MainWindow_ViewModel.caseSelectedIndex > -1)
                {
                    if (_isUnitSI)
                    {
                        App.Module1_ViewModel.English_To_SI(App.Module1_ViewModel.DisplaySettings);
                        App.Module2_ViewModel.English_To_SI(App.Module2_ViewModel.DisplaySettings);
                        App.Module3_ViewModel.English_To_SI(App.Module3_ViewModel.DisplaySettings);
                        App.Module4_ViewModel.English_To_SI(App.Module4_ViewModel.DisplaySettings);
                        App.Module5_ViewModel.English_To_SI();
                    }
                    else
                    {
                        App.Module1_ViewModel.SI_To_English(App.Module1_ViewModel.DisplaySettings);
                        App.Module2_ViewModel.SI_To_English(App.Module2_ViewModel.DisplaySettings);
                        App.Module3_ViewModel.SI_To_English(App.Module3_ViewModel.DisplaySettings);
                        App.Module4_ViewModel.SI_To_English(App.Module4_ViewModel.DisplaySettings);
                        App.Module5_ViewModel.SI_To_English();
                    }
                }*/
            }
        }

        private string _Unit = "SI";
        public string Unit
        {
            get { return _Unit; }
            set
            {
                _Unit = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Unit"));
            }
        }

        private Case _currCase = new Case();
        public Case currCase
        {
            get { return _currCase; }
            set
            {
                _currCase = value;
                OnPropertyChanged(new PropertyChangedEventArgs("currCase"));
            }
        }

        private bool _isContentEnabled;
        public bool isContentEnabled
        {
            get { return _isContentEnabled; }
            set
            {
                _isContentEnabled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isContentEnabled"));
            }
        }

        private bool _isWindowEnabled;
        public bool isWindowEnabled
        {
            get { return _isWindowEnabled; }
            set
            {
                _isWindowEnabled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isWindowEnabled"));
            }
        }

        private int _moduleSelectedIndex = -1;
        public int moduleSelectedIndex
        {
            get { return _moduleSelectedIndex; }
            set
            {
                _moduleSelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("moduleSelectedIndex"));
            }
        }

        private int _caseSelectedIndex = -1;
        public int caseSelectedIndex
        {
            get { return _caseSelectedIndex; }
            set
            {
                _caseSelectedIndex = value;
                OnPropertyChanged(new PropertyChangedEventArgs("caseSelectedIndex"));
                setSelectedCase();
                if (_caseSelectedIndex > -1)
                {
                    isContentEnabled = true;
                }
                else
                {
                    isContentEnabled = false;
                }
            }
        }

        private DataTable _dtCases = new DataTable();
        public DataTable dtCases
        {
            get { return _dtCases; }
            set
            {
                _dtCases = value;
                OnPropertyChanged(new PropertyChangedEventArgs("dtCases"));
            }
        }


        private String _txtQuickHelp;
        public String txtQuickHelp
        {
            get { return _txtQuickHelp; }
            set
            {
                _txtQuickHelp = value;
                OnPropertyChanged(new PropertyChangedEventArgs("txtQuickHelp"));
            }
        }


        private String _txtStatus;
        public String txtStatus
        {
            get { return _txtStatus; }
            set
            {
                _txtStatus = value;
                OnPropertyChanged(new PropertyChangedEventArgs("txtStatus"));
            }
        }        

        #endregion 

        #region Constructor
        public ViewModelMainWindow()
        {
          /*  dtCases.Columns.Add(new DataColumn(TblStruct.Case.ID, typeof(int)));
            dtCases.Columns.Add(new DataColumn(TblStruct.Case.CaseName, typeof(string)));
            dtCases.Columns.Add(new DataColumn(TblStruct.Case.CaseStatus, typeof(string)));

            inPara = new InputParameters();
            outPara = new OutputParameters();*/
        }

        #endregion



        #region Methods For Handling Cases

        public void readAllCases()
        {
            /*MainDB db = new MainDB();
            DataTable dt = new DataTable();
            int currSelectIdx = this.caseSelectedIndex;
            string[] selections = new string[] { TblStruct.Case.ID, TblStruct.Case.CaseName, TblStruct.Case.CaseStatus };

            db.select(TblStruct.Case.tblName, selections, dt);

            dtCases.Rows.Clear();
            DataRow row;
            for (int i=0; i<dt.Rows.Count; i++)
            {
                row = dtCases.NewRow();
                row[TblStruct.Case.ID] = dt.Rows[i][TblStruct.Case.ID];
                row[TblStruct.Case.CaseName] = dt.Rows[i][TblStruct.Case.CaseName];
                row[TblStruct.Case.CaseStatus] = dt.Rows[i][TblStruct.Case.CaseStatus];
                dtCases.Rows.Add(row);
            }

            if (dtCases.Rows.Count < 1 || currSelectIdx > dtCases.Rows.Count - 1)
            {
                this.caseSelectedIndex = dtCases.Rows.Count - 1;
            }
            else
            {
                this.caseSelectedIndex = currSelectIdx;
            }*/
        }

        public void refreshMainWindow()
        {
           /* App.MainWindow_ViewModel.currCase.isCaseSavePending = false;
            readAllCases();
            UnitSetup();
            App.RunAnalysis_ViewModel.refreshRunModule();
            App.Module5_ViewModel.refreshView();
            App.Report_ViewModel.refreshView();*/
        }

        public void createNewCase()
        {
           /* MainDB db = new MainDB();

            App.Module1_ViewModel.DisplaySettings = new ViewSettingsModule1();
            App.Module2_ViewModel.DisplaySettings = new Module2.ViewSettingsModule2();
            App.Module3_ViewModel.DisplaySettings = new Module3.ViewSettingsModule3();
            App.Module4_ViewModel.DisplaySettings = new Module4.ViewSettingsModule4();
            App.Module5_ViewModel.DisplaySettings = new Module5.ViewSettingsModule5();
            this.setDefaultData();

            db.bulkInsertNewCase();            
            refreshMainWindow();

            // SETTING THE CASE SELECTION INDEX TO THE NEW INSERT
            // ==================================================
            App.MainWindow_ViewModel.caseSelectedIndex = App.MainWindow_ViewModel.dtCases.Rows.Count - 1;
            */
        }

        public void copyCase(string caseName, string caseDesc)
        {

           /* MainDB db = new MainDB();

            // RESETTING COPY-SETTINGS
            // =======================

            App.MainWindow_ViewModel.currCase.CaseName = caseName;
            App.MainWindow_ViewModel.currCase.CaseDescription = caseDesc;
            App.MainWindow_ViewModel.currCase.isECAAnalysisAvail = false;
            App.MainWindow_ViewModel.currCase.isFatigueAnalysisAvail = false;
            App.MainWindow_ViewModel.currCase.isModelAvail = false;
            App.MainWindow_ViewModel.currCase.isStaticAnalysisAvail = false;

            App.Module2_ViewModel.DisplaySettings = new Module2.ViewSettingsModule2();
            App.Module3_ViewModel.DisplaySettings = new Module3.ViewSettingsModule3();
            App.Module4_ViewModel.DisplaySettings = new Module4.ViewSettingsModule4();
            App.Module5_ViewModel.DisplaySettings = new Module5.ViewSettingsModule5();
            //this.setDefaultData();

            db.insertNewCase();
            refreshMainWindow();

            // SETTING THE CASE SELECTION INDEX TO THE NEW INSERT
            // ==================================================
            App.MainWindow_ViewModel.caseSelectedIndex = App.MainWindow_ViewModel.dtCases.Rows.Count - 1;
            */
        }

        public void updateCaseDescription()
        {
           /* string CaseID = App.MainWindow_ViewModel.currCase.CaseID;

            MainDB db = new MainDB();

            db.AddParameter(TblStruct.Case.CaseName, DbType.String);
            db.AddParameter(TblStruct.Case.CaseDescription, DbType.String);

            object[] param = new object[2];
            param[0] = App.MainWindow_ViewModel.currCase.CaseName;
            param[1] = App.MainWindow_ViewModel.currCase.CaseDescription;

            db.update(TblStruct.Case.tblName, param, TblStruct.Case.ID, CaseID); 

            refreshMainWindow();
            */
        }

        private void setDefaultData()
        {
          /*  App.Module1_ViewModel.setDefaultData();

            App.MainWindow_ViewModel.currCase.CaseStatus = "New";
            App.MainWindow_ViewModel.currCase.isECAAnalysisAvail = false;
            App.MainWindow_ViewModel.currCase.isFatigueAnalysisAvail = false;
            App.MainWindow_ViewModel.currCase.isModelAltered = false;
            App.MainWindow_ViewModel.currCase.isModelAvail = false;
            App.MainWindow_ViewModel.currCase.isStaticAnalysisAvail = false;
            */
        }

        void setSelectedCase()
        {
            /*if (caseSelectedIndex > -1)
            {
                //inPara = new InputParameters();
                //outPara = new OutputParameters();
                //bool isOK = true;
                chkIfCaseIsSaved();

                App.MainWindow_ViewModel.currCase.CaseID = dtCases.Rows[caseSelectedIndex][TblStruct.Case.ID].ToString();
                App.MainWindow_ViewModel.currCase.CaseName = dtCases.Rows[caseSelectedIndex][TblStruct.Case.CaseName].ToString();
                App.MainWindow_ViewModel.currCase.CaseStatus = dtCases.Rows[caseSelectedIndex][TblStruct.Case.CaseStatus].ToString();
                // App.MainWindow_ViewModel.currCase.CaseIndex = caseSelectedIndex;

                // Module-1 setups
                // ==================================================================
                App.Module1_ViewModel.DisplaySettings = new ViewSettingsModule1();
                MainDB db = new MainDB();
                db.selectSingleCase();

                App.Module2_ViewModel.DisplaySettings = new Module2.ViewSettingsModule2();
                App.Module3_ViewModel.DisplaySettings = new Module3.ViewSettingsModule3();                    

                if (App.Module1_ViewModel.DisplaySettings.RiverData.FlowModel == null)
                {
                    App.Module1_ViewModel.FlowModelSelectedIndex = -1;
                }
                else if (App.Module1_ViewModel.DisplaySettings.RiverData.FlowModel == "Chezy")
                {
                    App.Module1_ViewModel.FlowModelSelectedIndex = 0;
                }
                else
                {
                    App.Module1_ViewModel.FlowModelSelectedIndex = 1;
                }

                App.Module1_ViewModel.DisplaySettings.SoilData.CmbSoilTypeSelectedIndex = App.Module1_ViewModel.DisplaySettings.SoilData.DicSoilClassToIndx[App.Module1_ViewModel.DisplaySettings.SoilData.SoilTypeClass];
                App.Module1_ViewModel.DisplaySettings.RiverData.UpdateDischargeChart();
                App.Module1_ViewModel.DisplaySettings.EcaData.UpdateStressStrain();
                // =====================================================================
                // Other Module setups
                // =========================================================================
                App.Module2_ViewModel.loadModelChecker();
                App.Module3_ViewModel.loadModule3();
                App.Module4_ViewModel.loadModule4();
                App.Module5_ViewModel.refreshView();
                App.RunAnalysis_ViewModel.refreshRunModule();
                App.Report_ViewModel.refreshView();

                App.MainWindow_ViewModel.currCase.isCaseSavePending = false;


            }*/
        }

        void CaseClearSettings()
        {
           /* App.Module1_ViewModel.DisplaySettings = new ViewSettingsModule1();
            App.Module1_ViewModel.StandardData = new ViewSettingsModule1();
            App.Module2_ViewModel.DisplaySettings = new Module2.ViewSettingsModule2();
            App.Module3_ViewModel.DisplaySettings = new Module3.ViewSettingsModule3();
            App.Module4_ViewModel.DisplaySettings = new Module4.ViewSettingsModule4();
            App.Module5_ViewModel.DisplaySettings = new Module5.ViewSettingsModule5();
            App.RunAnalysis_ViewModel.DisplaySettings = new RunAnalyses.ViewSettingsRunAnalysis();
            //App.RunAnalysis_ViewModel = new RunAnalyses.ViewModelRunAnalysis_rv02();
            App.MainWindow_ViewModel.currCase.isCaseSavePending = false;
            */
        }

        public void chkIfCaseIsSaved()
        {
           /* if (App.MainWindow_ViewModel.currCase.isCaseSavePending)
            {
                System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("The case is not saved.\n\n" +
                    "Do you wish to save it?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);

                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    saveCase();
                }
                else
                {
                    App.MainWindow_ViewModel.currCase.isCaseSavePending = false;
                    App.Module1_ViewModel.DisplaySettings.isRiverEventTableStrctChanged = false;
                    App.Module1_ViewModel.DisplaySettings.EcaData.IsCyclicTblStrctChanged = false;
                    App.Module1_ViewModel.DisplaySettings.EcaData.isStressStrainAltered = false;
                    App.Module1_ViewModel.ConvertStandardToDisplay(App.Module1_ViewModel.StandardData, App.Module1_ViewModel.DisplaySettings);
                }
            }*/
        }

        private void isThemeAltered()
        {
           /* Application.Current.Resources.MergedDictionaries.Clear();
            if (this.IsThemeDark)
            {
                // Adding Material Design Theme
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml", UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml", UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Orange.xaml", UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Blue.xaml", UriKind.RelativeOrAbsolute)
                });


                // Adding my style Theme

                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("Themes/MaterialDesignTheme.Overrides.xaml", UriKind.RelativeOrAbsolute)
                }); 
            }
            else
            {

                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml", UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml", UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.indigo.xaml", UriKind.RelativeOrAbsolute)
                });
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml", UriKind.RelativeOrAbsolute)
                });

                // Adding my style

                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                {
                    Source = new Uri("Themes/MaterialDesignTheme.Overrides.xaml", UriKind.RelativeOrAbsolute)
                });            
            }*/
        }

        public void UnitSetup()
        {
            /*App.Module1_ViewModel.DisplayedUnits.setUnitText(this.Unit);
            App.Module2_ViewModel.DisplayedUnits.setUnitText(this.Unit);
            App.Module3_ViewModel.DisplayedUnits.setUnitText(this.Unit);
            App.Module4_ViewModel.DisplayedUnits.setUnitText(this.Unit);*/
        }




        void saveCase()
        {
           /* if (App.MainWindow_ViewModel.caseSelectedIndex > -1)
            {
                MainDB db = new MainDB();
                string CaseID = App.MainWindow_ViewModel.currCase.CaseID;
                if (!App.Module1_ViewModel.isDisplayEqualToStandard(App.Module1_ViewModel.DisplaySettings, App.Module1_ViewModel.StandardData))
                {
                    string errMessage = "";
                    if (App.Module1_ViewModel.ValidateDataEntries.isOkToSaveCase(ref errMessage))
                    {
                        if (App.MainWindow_ViewModel.currCase.isECAAnalysisAvail || App.MainWindow_ViewModel.currCase.isFatigueAnalysisAvail || App.MainWindow_ViewModel.currCase.isStaticAnalysisAvail)
                        {

                            #region CHECKING IF BASIC ENTRIES ARE ALTERED THEN DELETING THE CORRESPONDING RESULTS

                            // CHECKING IF BASIC ENTRIES ARE ALTERED
                            // =====================================
                            if (App.Module1_ViewModel.DisplaySettings.isBasicEntryAltered)
                            {
                                System.Windows.Forms.DialogResult diagResult = System.Windows.Forms.MessageBox.Show("If you continue all existing results for this case would be deleted.\n\n" +
                            "Do you wish to continue?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                                if (diagResult == System.Windows.Forms.DialogResult.Yes)
                                {
                                    db.deleteAllOutputs(CaseID);
                                    App.MainWindow_ViewModel.currCase.isModelAvail = false;
                                    App.MainWindow_ViewModel.currCase.isECAAnalysisAvail = false;
                                    App.MainWindow_ViewModel.currCase.isFatigueAnalysisAvail = false;
                                    App.MainWindow_ViewModel.currCase.isStaticAnalysisAvail = false;
                                    App.MainWindow_ViewModel.currCase.isCaseSavePending = false;

                                    db.updateSingleCase();
                                    App.Module1_ViewModel.DisplaySettings.isRiverEventTableStrctChanged = false;
                                    App.Module1_ViewModel.DisplaySettings.EcaData.IsCyclicTblStrctChanged = false;
                                    App.Module1_ViewModel.DisplaySettings.EcaData.isStressStrainAltered = false;

                                    App.Module1_ViewModel.DisplaySettings.isBasicEntryAltered = false;
                                    App.Module1_ViewModel.DisplaySettings.isFatigueEntryAltered = false;
                                    App.Module1_ViewModel.DisplaySettings.isECAEntryAltered = false;
                                }
                            }

                            #endregion

                            #region CHECKING IF FATIGUE ENTRIES ARE ALTERED THEN DELETING THE CORRESPONDING RESULTS

                            // CHECKING IF FATIGUE ENTRIES ARE ALTERED
                            // =======================================
                            if (App.Module1_ViewModel.DisplaySettings.isFatigueEntryAltered)
                            {
                                // CHECKING IF ECA RESULTS DEPENDS ON FATIGUE RESULTS
                                // ==================================================
                                if (App.Module1_ViewModel.StandardData.EcaData.LoadingEntrySelectionIndex == 0)
                                {
                                    System.Windows.Forms.DialogResult diagResult = System.Windows.Forms.MessageBox.Show("If you continue any existing Fatigue and ECA results for this case would be deleted.\n\n" +
                            "Do you wish to continue?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                                    if (diagResult == System.Windows.Forms.DialogResult.Yes)
                                    {

                                        db.deleteECAOutputs(CaseID);
                                        db.deleteFatigueOutput(CaseID);
                                        //db.delete(TblStruct.OutECA.tblName, TblStruct.OutECA.FID, CaseID);
                                        //db.delete(TblStruct.OutEcaFAD.tblName, TblStruct.OutEcaFAD.FID, CaseID);
                                        //db.delete(TblStruct.OutEcaFCG.tblName, TblStruct.OutEcaFCG.FID, CaseID);
                                        //db.delete(TblStruct.OutFatigue.tblName, TblStruct.OutFatigue.FID, TblStruct.Models.tblName, TblStruct.Models.ID, TblStruct.Models.FID, CaseID);

                                        App.MainWindow_ViewModel.currCase.isECAAnalysisAvail = false;
                                        App.MainWindow_ViewModel.currCase.isFatigueAnalysisAvail = false;
                                        App.MainWindow_ViewModel.currCase.isCaseSavePending = false;

                                        db.updateSingleCase();

                                        App.Module1_ViewModel.DisplaySettings.isRiverEventTableStrctChanged = false;
                                        App.Module1_ViewModel.DisplaySettings.EcaData.IsCyclicTblStrctChanged = false;
                                        App.Module1_ViewModel.DisplaySettings.EcaData.isStressStrainAltered = false;

                                        App.Module1_ViewModel.DisplaySettings.isBasicEntryAltered = false;
                                        App.Module1_ViewModel.DisplaySettings.isFatigueEntryAltered = false;
                                        App.Module1_ViewModel.DisplaySettings.isECAEntryAltered = false;
                                    }
                                }
                                else
                                {
                                    System.Windows.Forms.DialogResult diagResult = System.Windows.Forms.MessageBox.Show("If you continue any existing Fatigue results for this case would be deleted.\n\n" +
                            "Do you wish to continue?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                                    if (diagResult == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        db.deleteFatigueOutput(CaseID);
                                        //db.delete(TblStruct.OutFatigue.tblName, TblStruct.OutFatigue.FID, TblStruct.Models.tblName, TblStruct.Models.ID, TblStruct.Models.FID, CaseID);

                                        App.MainWindow_ViewModel.currCase.isFatigueAnalysisAvail = false;
                                        App.MainWindow_ViewModel.currCase.isCaseSavePending = false;

                                        db.updateSingleCase();

                                        App.Module1_ViewModel.DisplaySettings.isRiverEventTableStrctChanged = false;
                                        App.Module1_ViewModel.DisplaySettings.EcaData.IsCyclicTblStrctChanged = false;
                                        App.Module1_ViewModel.DisplaySettings.EcaData.isStressStrainAltered = false;

                                        App.Module1_ViewModel.DisplaySettings.isBasicEntryAltered = false;
                                        App.Module1_ViewModel.DisplaySettings.isFatigueEntryAltered = false;
                                        App.Module1_ViewModel.DisplaySettings.isECAEntryAltered = false;
                                    }
                                }

                            }

                            #endregion

                            #region CHECKING IF ECA ENTRIES ARE ALTERED THEN DELETING THE CORRESPONDING RESULTS

                            // CHECKING IF ECA ENTRIES ARE ALTERED
                            // ===================================
                            if (App.Module1_ViewModel.DisplaySettings.isECAEntryAltered)
                            {
                                System.Windows.Forms.DialogResult diagResult = System.Windows.Forms.MessageBox.Show("If you continue any existing ECA results for this case would be deleted.\n\n" +
                            "Do you wish to continue?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                                if (diagResult == System.Windows.Forms.DialogResult.Yes)
                                {
                                    db.deleteECAOutputs(CaseID);
                                    //db.delete(TblStruct.OutECA.tblName, TblStruct.OutECA.FID, CaseID);
                                    //db.delete(TblStruct.OutEcaFAD.tblName, TblStruct.OutEcaFAD.FID, CaseID);
                                    //db.delete(TblStruct.OutEcaFCG.tblName, TblStruct.OutEcaFCG.FID, CaseID);

                                    App.MainWindow_ViewModel.currCase.isECAAnalysisAvail = false;
                                    App.MainWindow_ViewModel.currCase.isCaseSavePending = false;

                                    db.updateSingleCase();

                                    App.Module1_ViewModel.DisplaySettings.isRiverEventTableStrctChanged = false;
                                    App.Module1_ViewModel.DisplaySettings.EcaData.IsCyclicTblStrctChanged = false;
                                    App.Module1_ViewModel.DisplaySettings.EcaData.isStressStrainAltered = false;

                                    App.Module1_ViewModel.DisplaySettings.isBasicEntryAltered = false;
                                    App.Module1_ViewModel.DisplaySettings.isFatigueEntryAltered = false;
                                    App.Module1_ViewModel.DisplaySettings.isECAEntryAltered = false;
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            db.deleteModels(CaseID);
                            App.MainWindow_ViewModel.currCase.isModelAvail = false;
                            db.updateSingleCase();
                            App.MainWindow_ViewModel.currCase.isCaseSavePending = false;
                            App.Module1_ViewModel.DisplaySettings.isRiverEventTableStrctChanged = false;
                            App.Module1_ViewModel.DisplaySettings.EcaData.IsCyclicTblStrctChanged = false;
                            App.Module1_ViewModel.DisplaySettings.EcaData.isStressStrainAltered = false;
                        }
                    }
                    else
                    {
                        // THE ENTRY CHECK RETURN FALSE (ENTRIES HAS ERROR).
                        // =================================================
                        System.Windows.Forms.MessageBox.Show(errMessage);
                        return; 
                    }
                    
                }
                else
                {
                    App.MainWindow_ViewModel.currCase.isCaseSavePending = false;
                    App.Module1_ViewModel.DisplaySettings.isRiverEventTableStrctChanged = false;
                    App.Module1_ViewModel.DisplaySettings.EcaData.IsCyclicTblStrctChanged = false;
                    App.Module1_ViewModel.DisplaySettings.EcaData.isStressStrainAltered = false;

                    App.Module1_ViewModel.DisplaySettings.isBasicEntryAltered = false;
                    App.Module1_ViewModel.DisplaySettings.isFatigueEntryAltered = false;
                    App.Module1_ViewModel.DisplaySettings.isECAEntryAltered = false;
                }

                refreshMainWindow();
            }*/
        }
        


   

        public void deleteCase()
        {
          /*  MainDB db = new MainDB();
            bool isOk=db.deleteSingleCase();
            if (isOk)
            {
                CaseClearSettings();
                refreshMainWindow();
            }*/
        }



       
        public void helpDoc()
        {
           /* try
            {
                System.Diagnostics.Process.Start(App.srcHelpDocPaths);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("The help document is not available!");
            }*/
        }

    
        public void helpTheoryDoc()
        {
          /*  try
            {
                System.Diagnostics.Process.Start(App.srcHelpTheoryDocPaths);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("The help document is not available!");
            }*/
        }






        #endregion

        #region Methods For Handling Projects

     
        bool isProjectSaved()
        {
            bool isOK = true;
            /*
            if (App.MainWindow_ViewModel.caseSelectedIndex > -1)
            {
                if(App.MainWindow_ViewModel.currCase.isCaseSavePending)
                {
                    System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("The case is not saved.\n\n" +
                        "Do you wish to continue?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);

                    if (dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        isOK = false;
                    }
                }
            }     
            */
            return isOK;
        }

        public void openPrj()
        {
            if (isProjectSaved())
            {
              /*  string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                FileManagement fileDB = new FileManagement();

                if (App.dbFilePath != null)
                {
                    defaultPath = App.dbFilePath;
                }
                

                bool isSelect = fileDB.openPrj(defaultPath);

                if (isSelect)
                {
                    // App.refreshProject();
                    CaseClearSettings();
                    fileDB.registerCurrPathToRecentPaths(App.dbFilePath);
                    refreshMainWindow();
                }*/
            }
        }


        public void newPrj()
        {
            if (isProjectSaved())
            {
                string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                /*FileManagement fileDB = new FileManagement();

                if (App.dbFilePath != null)
                {
                    defaultPath = App.dbFilePath;
                }


                bool isSelect = fileDB.createNewPrj(defaultPath);

                if (isSelect)
                {
                    // App.refreshProject();
                    CaseClearSettings();
                    fileDB.registerCurrPathToRecentPaths(App.dbFilePath);
                    refreshMainWindow();
                }*/
            }
        }
     
        void saveAsPrj()
        {
            if (isProjectSaved())
            {
                string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
               /* FileManagement fileDB = new FileManagement();

                if (App.dbFilePath != null)
                {
                    defaultPath = App.dbFilePath;
                }


                bool isSelect = fileDB.createCopyPrj(defaultPath);

                if (isSelect)
                {
                    // App.refreshProject();
                    CaseClearSettings();
                    fileDB.registerCurrPathToRecentPaths(App.dbFilePath);
                    refreshMainWindow();
                }*/
            }

        }
        #endregion
    }
}
