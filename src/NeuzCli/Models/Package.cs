namespace NeuzCli.Models
{
    public class PackageCls
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string HomePage { get; set; }
        public LicenseCls License { get; set; }
        public List<VersionCls> Versions { get; set; }

        public class VersionCls
        {
            public string Name { get; set; }
            public string Url { get; set; }

            public override string ToString() => $"{Name}";
        }

        public class LicenseCls
        {
            public string Name { get; set; }
            public string Url { get; set; }

            public override string ToString() => $"{Name} ({Url})";
        }
    }
}