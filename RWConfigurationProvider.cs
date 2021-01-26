using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RWConfiguration
{
    class RWConfigurationProvider : IConfigurationProvider
    {
        private string path;
        private Dictionary<string, string> pairs;

        public RWConfigurationProvider(string path)
        {
            this.path = path;
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
        {
            return Enumerable.Empty<string>();
        }

        public IChangeToken GetReloadToken()
        {
            return NullChangeToken.Singleton;
        }

        public void Load()
        {
            pairs = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
        }

        public void Set(string key, string value)
        {
            pairs[key] = value;
            File.WriteAllText(path, JsonConvert.SerializeObject(pairs, Formatting.Indented));
        }

        public bool TryGet(string key, out string value)
        {
            return pairs.TryGetValue(key, out value);
        }
    }
}
