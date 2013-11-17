

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows.Documents;
using Wpf_Morbius.Services;

namespace Wpf_Morbius.ViewModel
{
    class PatientLiveViewModel : BaseViewModel
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private BackgroundWorker _dataUpdater = new BackgroundWorker();

        private LiveCallBack _callBackClass;

        private List<KeyValuePair<DateTime, double>> _heartData;
        private List<KeyValuePair<DateTime, double>> _tempData;

        private string _state;
        private List<string> _heartDataList;

        public string State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        public KeyValuePair<DateTime, double>[] HeartData
        {
            get { return _heartData.ToArray(); }
            set
            {
                if (_heartData.ToArray() != value)
                {
                    _heartData = value.ToList();
                    OnPropertyChanged("HeartData");
                }
            }
        }

        public KeyValuePair<DateTime, double>[] TempData
        {
            get { return _tempData.ToArray(); }
            set
            {
                if (_tempData.ToArray() != value)
                {
                    _tempData = value.ToList();
                    OnPropertyChanged("TempData");
                }
            }
        }

        public PatientLiveViewModel()
        {
            _callBackClass = new LiveCallBack();
            var slc = new ServiceLive.ServiceLiveClient(new InstanceContext(_callBackClass));

            _state = "Waiting...";
            _heartDataList = new List<string>();

            _heartData = new List<KeyValuePair<DateTime, double>>();
            _tempData = new List<KeyValuePair<DateTime, double>>();

            _worker.DoWork += new DoWorkEventHandler((s, e) => slc.Subscribe());
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);

            _dataUpdater.DoWork += new DoWorkEventHandler((s, e) => UpdateData());

            _worker.RunWorkerAsync();
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            State = "Finished !";
            _dataUpdater.RunWorkerAsync();
        }

        private void UpdateData()
        {
            while (true)
            {
                if (_heartData.Count > 10)
                    _heartData.RemoveAt(0);

                if (_tempData.Count > 10)
                    _tempData.RemoveAt(0);

                try
                {
                    var heartData = _callBackClass.HeartDataList;
                    var tempData = _callBackClass.TempDataList;

                    if (heartData != null && heartData.Count > 0)
                    {
                        _heartData.Add(new KeyValuePair<DateTime, double>(DateTime.Now, heartData.Last()));
                    }

                    if (tempData != null && tempData.Count > 0)
                    {
                        _tempData.Add(new KeyValuePair<DateTime, double>(DateTime.Now, tempData.Last()));
                    }

                    OnPropertyChanged("HeartData");
                    OnPropertyChanged("TempData");

                    Thread.Sleep(1000);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}