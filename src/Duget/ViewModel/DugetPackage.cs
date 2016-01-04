using NuGet;
using static System.String;

namespace Duget.ViewModel
{
    public class DugetPackage
    {
        public DugetPackage() { }

        public DugetPackage(string name, string author, string description, string image, string version)
        {
            Name = name;
            Author = author;
            FullDescription = description;
            Image = image;
            Version = version;
        }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Description => FullDescription.Substring(0, 200);
        public string FullDescription { get; set; }
        public string Image { get; set; }
        public string Version { get; set; }

        public static DugetPackage FromIPackage(IPackage package)
            => new DugetPackage(package.Title, Join(", ", package.Authors), package.Description, package.IconUrl?.ToString(), package.Version?.ToString());

        protected bool Equals(DugetPackage other) => string.Equals(Name, other.Name);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DugetPackage)obj);
        }

        public override int GetHashCode() => Name?.GetHashCode() ?? 0;

        public static bool operator ==(DugetPackage left, DugetPackage right) { return Equals(left, right); }
        public static bool operator !=(DugetPackage left, DugetPackage right) { return !Equals(left, right); }
    }
}