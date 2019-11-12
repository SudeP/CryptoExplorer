using Newtonsoft.Json;
using System;

namespace BTC.Tools
{
    public class Client
    {
        public string Id { get; set; }
        public long Time { get; set; }
        public long Height { get; set; }
        public string Hash { get; set; }
        public string DocPath { get; set; }
        public string State { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
