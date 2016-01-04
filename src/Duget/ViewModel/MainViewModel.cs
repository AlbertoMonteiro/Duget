using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using PropertyChanged;

namespace Duget.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        private ListType _listType;

        public MainViewModel()
        {
            if (IsInDesignMode || IsInDesignModeStatic)
            {
                ProjectName = "Cargas";
                ShowNoItemsFound = false;
                ShowLoading = false;
                ListType = ListType.Browse;

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
            }
        }

        public string ProjectName { get; set; }

        public bool ShowNoItemsFound { get; set; }

        public bool ShowLoading { get; set; }

        public bool ShowOnlinePackages => ListType == ListType.Browse;

        public bool ShowInstalledPackages => ListType == ListType.Installed;

        public bool ShowUpdatablePackages => ListType == ListType.Update;

        public ListType ListType { get; set; }

        public ObservableCollection<DugetPackage> Packages { get; set; }
    }
}