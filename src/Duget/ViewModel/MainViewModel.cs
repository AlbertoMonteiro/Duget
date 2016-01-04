using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using NuGet;
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
                        FullDescription = "Entity Framework is Microsoft's recommended data access technology for new applications.",
                        Name = "EntityFramework",
                        Version = "6.1.3",
                        Image = "http://go.microsoft.com/fwlink/?LinkID=386613"
                    },
                    new DugetPackage {
                        Author = "James Newton-King",
                        FullDescription = "Json.NET is a popular high-performance JSON framework for .NET",
                        Name = "Json.NET",
                        Version = "8.0.1",
                        Image = "http://www.newtonsoft.com/content/images/nugeticon.png"
                    },
                    new DugetPackage {
                        Author = "jQuery Foundation,  Inc.",
                        FullDescription = @"jQuery is a new kind of JavaScript Library.
        jQuery is a fast and concise JavaScript Library that simplifies HTML document traversing, event handling, animating, and Ajax interactions for rapid web development. jQuery is designed to change the way that you write JavaScript.
        NOTE: This package is maintained on behalf of the library owners by the NuGet Community Packages project at http://nugetpackages.codeplex.com/",
                        Name = "jQuery",
                        Version = "2.1.4"
                    }
                };
            }
            else
            {
                ProjectName = "Cargas";
                ShowLoading = false;
                ListType = ListType.Browse;
                LoadPackages();
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


        public void LoadPackages()
        {
            Packages = new ObservableCollection<DugetPackage>();

            //Connect to the official package repository
            var repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");

            //Get the list of all NuGet packages with ID 'EntityFramework'       
            var packages = repo.Search("", false).Take(10).ToList().ToList().Select(DugetPackage.FromIPackage);

            //Iterate through the list and print the full name of the pre-release packages to console
            foreach (var p in packages)
                Packages.Add(p);
        }
    }
}