using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using PropertyChanged;

namespace Duget.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                ProjectName = "Cargas";
                ShowNoItemsFound = false;
                ShowLoading = false;

                Packages = new ObservableCollection<DugetPackage>
                {
                    new DugetPackage {
                        Author = "Microsoft",
                        Description = "Entity Framework is Microsoft's recommended data access technology for new applications.",
                        Name = "EntityFramework",
                        Version = "6.1.3",
                        Image = "http://go.microsoft.com/fwlink/?LinkID=386613"
                    },
                    new DugetPackage {
                        Author = "James Newton-King",
                        Description = "Json.NET is a popular high-performance JSON framework for .NET",
                        Name = "Json.NET",
                        Version = "8.0.1",
                        Image = "http://www.newtonsoft.com/content/images/nugeticon.png"
                    }
                };
            }
            else
            {
                ProjectName = "Cargas";
                ShowLoading = true;
                // Code runs "for real"
            }
        }

        public string ProjectName { get; set; }

        public bool ShowNoItemsFound { get; set; }

        public bool ShowLoading { get; set; }

        public ObservableCollection<DugetPackage> Packages { get; set; }
    }
}