
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wpf_Morbius.ViewModel
{
    class PatientDetailsViewModel : BaseViewModel
    {
        public string LastObservation
        {
            get
            {
                if (PatientViewModel.Patient.Observations != null &&
                    PatientViewModel.Patient.Observations.Any())
                {
                    return PatientViewModel.Patient.Observations.OrderByDescending(o => o.Date).Last().Comment;
                }

                return null;
            }
        }

        private List<KeyValuePair<DateTime, int>> _weightData;
        private List<KeyValuePair<DateTime, int>> _tensionData;

        public KeyValuePair<DateTime, int>[] WeightData
        {
            get { return _weightData.ToArray(); }
            set
            {
                if (_weightData.ToArray() != value)
                {
                    _weightData = value.ToList();
                    OnPropertyChanged("WeightData");
                }
            }
        }

        public KeyValuePair<DateTime, int>[] TensionData
        {
            get { return _tensionData.ToArray(); }
            set
            {
                if (_tensionData.ToArray() != value)
                {
                    _tensionData = value.ToList();
                    OnPropertyChanged("TensionData");
                }
            }
        }

        public PatientDetailsViewModel()
        {
            _weightData = new List<KeyValuePair<DateTime, int>>();
            _tensionData = new List<KeyValuePair<DateTime, int>>();

            UpdateChart();
        }

        public void UpdateChart()
        {
            if (PatientViewModel.Patient == null)
                return;

            var observations = PatientViewModel.Patient.Observations;

            if (observations == null || observations.Length == 0)
                return;

            DateTime date = observations.First().Date;
            foreach (var observation in observations)
            {
                if (DateTime.Compare(date, observation.Date) != 0)
                {
                    _weightData.Add(new KeyValuePair<DateTime, int>(observation.Date, observation.Weight));
                    _tensionData.Add(new KeyValuePair<DateTime, int>(observation.Date, observation.BloodPressure));
                }
                date = observation.Date;
            }

            OnPropertyChanged("WeightData");
            OnPropertyChanged("TensionData");
        }
    }
}