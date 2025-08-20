using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    internal class Config
    {
        [JsonPropertyName("mgs2ExePath")]
        public string Mgs2ExePath { get; set; }
        [JsonPropertyName("lastOptionsSelected")]
        public RandomizationOptions LastOptionsSelected { get; set; }
    }
}
