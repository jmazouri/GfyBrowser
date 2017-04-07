using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace GfyBrowser
{
    public class JsonConfiguration
    {
        [JsonIgnore]
        public string Path { get; private set; }

        public JsonConfiguration(string path)
        {
            Path = path;
        }

        public string BotToken { get; set; }
        public string GfyClientId { get; set; }
        public string GfySecret { get; set; }

        public void Load()
        {
            JsonConvert.PopulateObject(File.ReadAllText(Path), this);
        }

        public void Save()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(this));
        }
    }
}
