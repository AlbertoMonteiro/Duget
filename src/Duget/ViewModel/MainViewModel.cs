using GalaSoft.MvvmLight;
using PropertyChanged;

namespace Duget.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                ProjectName = "Cargas";
                ShowNoItemsFound = true;
                ShowLoading = false;
            }
            else
            {
                ProjectName = "Cargas";
                // Code runs "for real"
            }
        }

        public string ProjectName { get; set; }

        public bool ShowNoItemsFound { get; set; }

        public bool ShowLoading { get; set; }
    }
}