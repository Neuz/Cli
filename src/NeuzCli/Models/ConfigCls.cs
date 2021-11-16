using System.Text.Json.Serialization;

namespace NeuzCli.Models
{
    public class ConfigCls
    {
        [JsonPropertyName("source")]
        public string Source { get; set; } = "https://github.com/Neuz/Cli/raw/main/resource/index.json";
    }
}