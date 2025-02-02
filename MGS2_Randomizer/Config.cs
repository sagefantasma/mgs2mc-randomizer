using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    /*
     * {
  "mgs2ExePath": "C:/Program Files (x86)/Steam/steamapps/common/MGS2/METAL GEAR SOLID2.exe",
  "lastOptionsSelected": {
    "NoHardLogicLocks": true,
    "NikitaShell2": true,
    "RandomizeStartingItems": false,
    "RandomizeAutomaticRewards": false,
    "RandomizeClaymores": false,
    "RandomizeC4": false,
    "IncludeRations": false,
    "AllWeaponsSpawnable": false
  }
}
*/
    internal class Config
    {
        [JsonPropertyName("mgs2ExePath")]
        public string Mgs2ExePath { get; set; }
        [JsonPropertyName("lastOptionsSelected")]
        public MGS2Randomizer.RandomizationOptions LastOptionsSelected { get; set; }
    }
}
