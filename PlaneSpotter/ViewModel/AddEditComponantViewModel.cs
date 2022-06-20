using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlaneSpotter.ViewModel
{
    public class AddEditComponantViewModel : ViewModelBase
    {
        private string _PlaneModel;
        public string PlaneModel 
        {
            get
            {
                return _PlaneModel;
            }
            set
            {
                _PlaneModel = value;
                OnPropertyChanged(nameof(PlaneModel));
                OnPropertyChanged(nameof(ValiedForm));
            }
        }

        private string _PlaneMake;
        public string PlaneMake
        {
            get
            {
                return _PlaneMake;
            }
            set
            {
                _PlaneMake = value;
                OnPropertyChanged(nameof(PlaneMake));
                OnPropertyChanged(nameof(ValiedForm));
            }
        }

        private string _PlaneRegistration;
        public string PlaneRegistration
        {
            get
            {
                return _PlaneRegistration;
            }
            set
            {
                string[] strings = value.Split('-');
                if (value.Length >= 3 && value.Length <= 8)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value.IndexOf('-') == 1 || value.IndexOf('-') == 2))
                        {
                            _PlaneRegistration = value;
                            OnPropertyChanged(nameof(PlaneRegistration));
                            OnPropertyChanged(nameof(ValiedForm));
                        }
                    }
                }
            }
        }

        private string _Location;
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private DateTime _DateTime;
        public DateTime DatenTime
        {
            get
            {
                return _DateTime;
            }
            set
            {
                _DateTime = value;
                OnPropertyChanged(nameof(DatenTime));
                OnPropertyChanged(nameof(ValiedForm));
            }
        }

        private string _Photo;

        public string Photo
        {
            get
            {
                return _Photo;
            }
            set
            {
                _Photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }

        public bool ValiedForm => !string.IsNullOrEmpty(PlaneModel) && !string.IsNullOrEmpty(PlaneMake) && !string.IsNullOrEmpty(PlaneRegistration) && DateTime.Compare(DatenTime, DateTime.Now) < 0;
        public ICommand Submit { get; }
        public ICommand Cancel { get; }

        public AddEditComponantViewModel(ICommand submit, ICommand cancel)
        {
            Submit = submit;
            Cancel = cancel;
        }
    }
}
