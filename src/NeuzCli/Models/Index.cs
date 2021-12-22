using System.Text.Json.Serialization;

namespace NeuzCli.Models;

public class IndexCls
{
    public DateTime UpdateTime { get; set; } = DateTime.Now;

    public List<PackageCls> Packages { get; set; } = new();

    public class PackageCls
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? HomePage { get; set; }
        public string? Url { get; set; }
        public string? Hash { get; set; }
        public string? DefaultPath { get; set; }
        public LicenseCls? License { get; set; }
        public ExecutorCls? Executor { get; set; } = null;
        public ExecutorCls? Installer { get; set; } = null;
        public ExecutorCls? UnInstaller { get; set; } = null;
        public PackageTypeEnum PackageType { get; set; } = PackageTypeEnum.Tool;


        public class LicenseCls
        {
            public string? Name { get; set; }
            public string? Url { get; set; }

            public override string ToString() => $"{Name} ({Url})";
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum PackageTypeEnum
        {
            Runtime,
            Service,
            Tool
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ExecuteTypeEnum
        {
            Script,
            Exe,
            InsideMySQL,
            InsideNginx,
        }

        public class ExecutorCls
        {
            public string? Path { get; set; }
            public string? Args { get; set; }
            public ExecuteTypeEnum ExecuteType { get; set; }
        }
    }
}