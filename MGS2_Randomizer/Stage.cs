using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    public class Stage
    {
        public string AreaName { get; set; }
        public List<IGuard> Guards { get; set; }
        public Dictionary<int,int> ValidRoutes { get; set; }
    }

    public class GuardStages
    {
        public readonly Stage w00a = new Stage
        {
            AreaName = "Aft Deck",
            Guards = new List<IGuard>
            {
                new Attacker
                {
                    Id = 0xBF2379, Route = 5, StartingIndex = null, SubfunctionCreation = false, ReinforcementType = ReinforcementType.Normal, CallingBytes = new byte[] { 0x06, 0x07, 0x9A, 0xCC, 0x06, 0x79, 0x23, 0xBF }, ReinforcementTypeOffset = 0x35
                },
                new Watcher
                {
                    Id = 0x16539FC, Route = 0, StartingIndex = 0, SubfunctionCreation = false, CallingBytes = new byte[] { 0x77, 0xF7, 0xF7, 0x0D, 0xFC, 0x39, 0x65, 0x01 }, RouteOffset = 0x0A, StartingIndexOffset = new [] { 0x0D }
                },
                new Watcher
                {
                    Id = 0x26539FC, Route = 1, StartingIndex = 0, SubfunctionCreation = false, CallingBytes = new byte[] { 0x77, 0xF7, 0xF7, 0x0D, 0xFC, 0x39, 0x65, 0x02 }, RouteOffset = 0x0A, StartingIndexOffset = new [] { 0x0D }
                },
                new Watcher
                {
                    Id = 0x36539FC, Route = 4, StartingIndex = 1, SubfunctionCreation = false, CallingBytes = new byte[] { 0x77, 0xF7, 0xF7, 0x0D, 0xFC, 0x39, 0x65, 0x03 }, RouteOffset = 0x0A, StartingIndexOffset = new [] { 0x0D }
                },
            },
            ValidRoutes = new Dictionary<int, int> { { 0, 6 }, { 1, 3 }, { 2, 6 }, { 3, 22 }, { 4, 16 }, { 6, 16 }, { 7, 16 } }
        };

        public readonly Stage w00c = new Stage
        {
            AreaName = "Navigational Deck",
            Guards = new List<IGuard>
            {
                new Attacker
                {
                    Id = 0x1BF2379, Route = 20, StartingIndex = null, SubfunctionCreation = false, ReinforcementType = ReinforcementType.Normal, CallingBytes = new byte[] { 0x06, 0x07, 0x9A, 0xCC, 0x0D, 0x79, 0x23, 0xBF, 0x01 }, ReinforcementTypeOffset = 0x38
                },
                new Watcher
                {
                    Id = 0x9E2784, Route = 29, StartingIndex = 0, SubfunctionCreation = false, CallingBytes = new byte[] { 0x06, 0x77, 0xF7, 0xF7, 0x06, 0x84, 0x27, 0x9E }, RouteOffset = 0x0A, StartingIndexOffset = new [] { 0x0D }
                }
            },
            ValidRoutes = new Dictionary<int, int> { { 0, 4 }, { 29, 1 } }
        };

        public readonly Stage w01a = new Stage
        {
            AreaName = "Deck A, Crew's Quarters",
            Guards = new List<IGuard>
            {
                new Attacker
                {
                    Id = 0x1BF2379, Route = 0, StartingIndex = null, SubfunctionCreation = false, ReinforcementType = ReinforcementType.Normal, CallingBytes = new byte[] { 0x06, 0x07, 0x9A, 0xCC, 0x0D, 0x79, 0x23, 0xBF, 0x01 }, ReinforcementTypeOffset = 0x3F
                },
                new Attacker
                {
                    Id = 0x2BF2379, Route = 1, StartingIndex = null, SubfunctionCreation = false, ReinforcementType = ReinforcementType.Normal, CallingBytes = new byte[] { 0x06, 0x07, 0x9A, 0xCC, 0x0D, 0x79, 0x23, 0xBF, 0x02 }, ReinforcementTypeOffset = 0x3F
                },
                new Watcher
                {
                    Id = 0x1F7F777, Route = 4, StartingIndex = 0, SubfunctionCreation = true, CallingBytes = new byte[] { 0x00, 0xF5, 0xDD, 0x0D, 0x77, 0xF7, 0xF7, 0x01 }, RouteOffset = 0x08, StartingIndexOffset = new [] { 0x0, 0x40 }
                }
            },
            ValidRoutes = new Dictionary<int, int> { { 3, 3 }, { 4, 3 }, { 10, 6 } }
        };
    }
}
