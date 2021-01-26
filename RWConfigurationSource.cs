using Microsoft.Extensions.Configuration;
using System;

namespace RWConfiguration
{
    public class RWConfigurationSource : IConfigurationSource
    {
        private string path;
        public RWConfigurationSource(string path)
        {
            this.path = path;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new RWConfigurationProvider(path);
        }
    }
}
