using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Documents;

namespace Wpf_Morbius.Services
{
    class LiveCallBack : ServiceLive.IServiceLiveCallback
    {
        private readonly List<double> _heartDataList;
        private readonly List<double> _tempDataList;

        public LiveCallBack()
        {
            _tempDataList = new List<double>();
            _heartDataList = new List<double>();
        }

        public List<double> HeartDataList
        {
            get { return _heartDataList; }
        }

        public List<double> TempDataList
        {
            get { return _tempDataList; }
        }

        public void PushDataHeart(double requestData)
        {
            Debug.Print("Heart: " + requestData);
            _heartDataList.Add(requestData);
        }

        public void PushDataTemp(double requestData)
        {
            Debug.Print("Temp: " + requestData);
            _tempDataList.Add(requestData);
        }
    }
}
