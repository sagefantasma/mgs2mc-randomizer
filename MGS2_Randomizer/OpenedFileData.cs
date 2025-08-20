using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    internal class OpenedFileData
    {
        public GcxEditor GcxEditor { get; set; }
        public List<DecodedProc> DecodedProcs { get; set; }
        public ProcEditor ProcEditor { get; set; }
    }
}
