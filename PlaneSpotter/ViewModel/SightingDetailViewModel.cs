using PlaneSpotter.Domain.Model;
using PlaneSpotter.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotter.ViewModel
{
    public class SightingDetailViewModel : ViewModelBase
    {
        private readonly SelectedSightingStore _selectedSightingStore;
        private Sighting SelectedSighting => _selectedSightingStore.SelectedSighting;

        public SightingDetailViewModel(SelectedSightingStore selectedSightingStore)
        //public SightingDetailViewModel(string planename, string planemake, string planemodel, string planeregitration, string spotter, string location, string datetime, string photo)
        {
            _selectedSightingStore = selectedSightingStore;
            _selectedSightingStore.SelectedSightingChanged += _selectedSightingStore_SelectedSightingChanged;
        }

        private void _selectedSightingStore_SelectedSightingChanged()
        {
            OnPropertyChanged(nameof(IsSightingSelected));
            OnPropertyChanged(nameof(Planemake));
            OnPropertyChanged(nameof(Planemodel));
            OnPropertyChanged(nameof(Planeregitration));
            OnPropertyChanged(nameof(Location));
            OnPropertyChanged(nameof(Datetime));
            OnPropertyChanged(nameof(Photo));
        }

        public bool IsSightingSelected => SelectedSighting != null;
        public string Planemake => SelectedSighting?.Planemake ?? "";
        public string Planemodel => SelectedSighting?.Planemodel ?? "";
        public object Planeregitration => SelectedSighting?.Planeregistration ?? "";
        public string Location => SelectedSighting?.Location ?? "";
        public DateTime Datetime => SelectedSighting?.DateTime ?? DateTime.Now;
        public string Photo => SelectedSighting?.Photo ?? "";
    }
}
