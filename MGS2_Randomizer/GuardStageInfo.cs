using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    public class GuardStageInfo
    {
        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public List<IGuard> Guards { get; set; }
        public Dictionary<int,int> ValidRoutes { get; set; }
        public bool RouteDeterminedInSubfunction { get; set; }
        public bool IndexDeterminedInSubfunction { get; set; }
    }

    public static class GuardStage
    {
        //TODO: eventually go through w00c and w24d, and maybe reinforcements too?
        public static readonly GuardStageInfo w00a = new GuardStageInfo
        {
            AreaCode = "w00a",
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
            ValidRoutes = new Dictionary<int, int> { { 0, 6 }, { 1, 3 }, { 2, 6 }, { 3, 22 }, { 4, 16 }, { 6, 16 }, { 7, 16 }, { 9, 16 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w00c = new GuardStageInfo
        {
            AreaCode = "w00c",
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
        }; //not bothering with this room atm

        public static readonly GuardStageInfo w01a = new GuardStageInfo
        {
            AreaCode = "w01a",
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
            ValidRoutes = new Dictionary<int, int> { { 2, 2 }, { 3, 3 }, { 4, 3 }, { 5, 2 },{ 6, 6 },{ 7, 2 },{ 8, 3 },{ 9, 2 },{ 10, 6 },{ 11, 3 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w01b = new GuardStageInfo
        { //unfinished because I think I am overcooking this and there's a much simpler solution to what I'm looking to do.
            AreaCode = "w01b",
            AreaName = "Deck B, Crew's Quarters, Starboard",
            Guards = new List<IGuard>
            {
                new Watcher
                {
                    Id = 0x1F7F777, Route = 7, StartingIndex = 0, SubfunctionCreation = true, CallingBytes = new byte[] { 0x00, 0xF5, 0xDD, 0x0D, 0x77, 0xF7, 0xF7, 0x01 }, RouteOffset = 0x08, StartingIndexOffset = new [] { 0x0, 0x40 }
                },
                new Watcher
                {
                    Id = 0x2F7F777, Route = 13, StartingIndex = 0, SubfunctionCreation = true, CallingBytes = new byte[] { 0x00, 0xF5, 0xDD, 0x0D, 0x77, 0xF7, 0xF7, 0x02 }, RouteOffset = 0x08, StartingIndexOffset = new [] { 0x0, 0x40 }
                }
            },
            ValidRoutes = new Dictionary<int, int> { { 4, 13 }, { 5, 14 }, { 6, 1 }, { 8, 1 }, { 9, 5 }, { 10, 3 }, { 11, 3 }, { 12, 1 }, { 14, 1 } }
        }; //All valid routes found.

        public static readonly GuardStageInfo w01c = new GuardStageInfo
        {
            AreaCode = "w01c",
            AreaName = "Deck C, Crew's Quarters",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 1, 7 },{ 4, 4 }, { 7, 5 }, { 9, 5 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w01d = new GuardStageInfo
        {
            AreaCode = "w01d",
            AreaName = "Deck D, Crew's Quarters",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 12 }, { 1, 1 }, { 7, 8 }, { 9, 8 }, { 10, 7 },{ 11, 2 }, { 12, 5 }, { 13, 5 }, { 15, 7 }, { 16, 2 }, { 17, 3 }, { 18, 4 }, { 19, 6 }, { 20, 2 }, { 21, 10 }, { 22, 8 }, { 23, 2 }, { 24, 3 }, { 25, 23 }, { 26, 1 }, { 27, 1 } }
        }; //added all valid routes. route 28 is the one used by the guard that spawns when you go into the pantry.

        public static readonly GuardStageInfo w01f = new GuardStageInfo
        {
            AreaCode = "w01f",
            AreaName = "Deck A, Crew's Lounge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 4 },{ 1, 6 }, { 2, 4 },{ 5, 2 },{ 8, 1 },{ 9, 2 },{ 10, 2 },{ 11, 2 },{ 12, 1 },{ 17, 1 },{ 18, 7 },{ 19, 15 },{ 20, 6 },{ 21, 5 },{ 22, 2 },{ 23, 6 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w02a = new GuardStageInfo
        {
            AreaCode = "w02a",
            AreaName = "Engine Room",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 1, 3 },{ 5, 6 },{ 6, 3 },{ 7, 18 },{ 8, 21 },{ 9, 9 },{ 10, 2 },{ 11, 2 },{ 12, 1 },{ 17, 5 },{ 18, 5 },{ 20, 5 },{ 21, 1 },{ 22, 8 },{ 23, 1 },{ 27, 8 },{ 29, 11 },{ 30, 7 },{ 31, 10 },{ 32, 2 },{ 34, 2 },{ 35, 2 },{ 36, 1 },{ 40, 5 },{ 41, 24 },{ 44, 1 },{ 45, 2 },{ 46, 2 },{ 47, 2 },{ 48, 1 },{ 49, 1 },{ 50, 1 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w03a = new GuardStageInfo
        {
            AreaCode = "w03a",
            AreaName = "Deck-2, Port",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 1 },{ 1, 7 },{ 2, 2 },{ 3, 6 },{ 4, 1 },{ 8, 1 },{ 13, 1 } }
        }; //defenders

        public static readonly GuardStageInfo w03b = new GuardStageInfo
        {
            AreaCode = "w03b",
            AreaName = "Deck-2, Starboard",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 3, 1 },{ 4, 1 } }
        }; //no patrolling guards

        public static readonly GuardStageInfo w11a = new GuardStageInfo
        {
            AreaCode = "w11a",
            AreaName = "Strut A - Sea Dock",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 1, 4 },{ 2, 6 },{ 4, 4 },{ 5, 3 },{ 6, 4 },{ 9, 4 },{ 10, 4 },{ 11, 4 } }
        }; //two attackers, one patrol

        public static readonly GuardStageInfo w12a = new GuardStageInfo
        {
            AreaCode = "w12a",
            AreaName = "Strut A - Roof",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 6 },{ 4, 19 } },
            RouteDeterminedInSubfunction = true,
            IndexDeterminedInSubfunction = true
        }; //added all valid routes

        public static readonly GuardStageInfo w12b = new GuardStageInfo
        {
            AreaCode = "w12b",
            AreaName = "Strut A - Pump Room",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 5, 1 }, { 6, 18 }, { 8, 1 }, { 9, 2 }, { 10, 6 }, { 11, 7 }, { 12, 5 }, { 13, 5 } },
            RouteDeterminedInSubfunction = true,
            IndexDeterminedInSubfunction = true
        }; //added all valid routes

        public static readonly GuardStageInfo w12c = new GuardStageInfo
        {
            AreaCode = "w12c",
            AreaName = "Strut A - Roof",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 1, 1 }, { 2, 1 }, { 3, 6 }, { 4, 19 } },
            RouteDeterminedInSubfunction = true,
            IndexDeterminedInSubfunction = true
        }; //added all valid routes

        public static readonly GuardStageInfo w13a = new GuardStageInfo
        {
            AreaCode = "w13a",
            AreaName = "AB Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 4 },{ 1, 4 },{ 4, 4 },{ 5, 4 },{ 6, 4 },{ 7, 4 },{ 8, 2 },{ 9, 2 },{ 10, 2 },{ 11, 1 },{ 12, 1 },{ 13, 1 },{ 14, 4 },{ 15, 4 },{ 16, 1 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w13b = new GuardStageInfo
        {
            AreaCode = "w13b",
            AreaName = "AB Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 4 }, { 1, 4 }, { 4, 4 }, { 5, 4 }, { 6, 4 }, { 7, 4 }, { 8, 2 }, { 9, 2 }, { 10, 2 }, { 11, 1 }, { 12, 1 }, { 13, 1 }, { 14, 4 }, { 15, 4 }, { 16, 1 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w14a = new GuardStageInfo
        {
            AreaCode = "w14a",
            AreaName = "Strut B - Transformer Room",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 3, 10 },{ 4, 6 },{ 5, 4 } },
            RouteDeterminedInSubfunction = true,
            IndexDeterminedInSubfunction = true
        }; //added all valid routes

        public static readonly GuardStageInfo w15a = new GuardStageInfo
        {
            AreaCode = "w15a",
            AreaName = "BC Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 2 }, { 1, 5 }, { 7, 4 }, { 8, 4 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w15b = new GuardStageInfo
        {
            AreaCode = "w15b",
            AreaName = "BC Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 2 }, { 1, 5 }, { 7, 4 },{ 8, 4 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w16b = new GuardStageInfo
        {
            AreaCode = "w16b",
            AreaName = "Strut C - Dining Hall",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 3, 36 },{ 4, 18 } },
            RouteDeterminedInSubfunction = true,
            IndexDeterminedInSubfunction = true
        }; //added all valid routes

        public static readonly GuardStageInfo w17a = new GuardStageInfo
        {
            AreaCode = "w17a",
            AreaName = "CD Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 2 }, { 3, 18 },{ 4, 6 },{ 5, 10 },{ 6, 10 },{ 7, 8 },{ 8, 8 },{ 9, 4 },{ 10, 4 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w18a = new GuardStageInfo
        {
            AreaCode = "w18a",
            AreaName = "Strut D - Sediment Pool",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 16 },{ 1, 20 },{ 2, 4 },{ 4, 15 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w19a = new GuardStageInfo
        {
            AreaCode = "w19a",
            AreaName = "DE Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 12 },{ 1, 26 },{ 2, 4 },{ 5, 16 },{ 6, 6 },{ 7, 4 }, { 8, 4 },{ 9, 4 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w20a = new GuardStageInfo
        {
            AreaCode = "w20a",
            AreaName = "Strut E - Parcel Room",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 6, 26 },{ 7, 12 },{ 8, 8 },{ 9, 8 },{ 10, 9 },{ 11, 6 },{ 12, 1 }, { 13, 1 },{ 14, 1 },{ 15, 1 },{ 16, 16 },{ 17, 10 },{ 18, 1 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w20b = new GuardStageInfo
        {
            AreaCode = "w20b",
            AreaName = "Strut E - Heliport",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 2, 6 },{ 3, 20 },{ 4, 7 },{ 5, 2 } },
            RouteDeterminedInSubfunction = true,
            IndexDeterminedInSubfunction = true
        }; //added all valid routes

        public static readonly GuardStageInfo w20d = new GuardStageInfo
        {
            AreaCode = "w20d",
            AreaName = "Strut E - Heliport",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 2, 6 }, { 3, 20 }, { 4, 7 }, { 5, 2 } },
            RouteDeterminedInSubfunction = true,
            IndexDeterminedInSubfunction = true
        }; //added all valid routes

        public static readonly GuardStageInfo w21a = new GuardStageInfo
        {
            AreaCode = "w21a",
            AreaName = "EF Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 1 },{ 1, 26 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w22a = new GuardStageInfo
        {
            AreaCode = "w22a",
            AreaName = "Strut F - Warehouse",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 2, 24 }, { 3, 23 }, { 4, 24 }, { 5, 23 }, { 6, 6 }, { 7, 8 }, { 8, 24 }, { 9, 23 }, { 10, 6 }, { 11, 4 }, { 12, 26 }, { 13, 26 }, { 14, 8 }, { 15, 17 }, { 16, 6 }, { 17, 24 }, { 18, 12 }, { 19, 8 }, { 20, 4 }, { 21, 4 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w23a = new GuardStageInfo
        {
            AreaCode = "w23a",
            AreaName = "FA Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 10, 6 }, { 11, 6 }, { 15, 14 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w23b = new GuardStageInfo
        {
            AreaCode = "w23b",
            AreaName = "FA Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 10, 6 }, { 11, 6 }, { 15, 14 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w24a = new GuardStageInfo
        {
            AreaCode = "w24a",
            AreaName = "Shell 1 Core",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 1, 5 }, { 2, 4 }, { 3, 10 }, { 4, 9 }, { 5, 2 }, { 10, 4 }, { 11, 2 }, { 12, 2 }, { 13, 1 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w24d = new GuardStageInfo
        {
            AreaCode = "w24d",
            AreaName = "Shell 1 Core B2 - Computer Room",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 5, 14 }, { 12, 18 }, { 13, 9 }, { 14, 7 }, { 17, 18 } }
        }; //not bothering with this room atm

        public static readonly GuardStageInfo w25b = new GuardStageInfo
        {
            AreaCode = "w25b",
            AreaName = "Shell 1,2 Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 4 },{ 1, 6 },{ 5, 3 },{ 6, 3 } }
        }; //does not have watchers

        public static readonly GuardStageInfo w25c = new GuardStageInfo
        {
            AreaCode = "w25c",
            AreaName = "Strut L Perimeter",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 3 },{ 1, 3 },{ 4, 4 },{ 5, 6 },{ 9, 1 } }
        }; //does not have watchers

        public static readonly GuardStageInfo w25d = new GuardStageInfo
        {
            AreaCode = "w25d",
            AreaName = "KL Connecting Bridge",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 3, 12 }, { 4, 3 }, { 5, 4 }, { 7, 1 }, { 8, 4 }, { 9, 5 }, { 11, 2 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w28a = new GuardStageInfo
        {
            AreaCode = "w28a",
            AreaName = "Strut L - Sewage Treatment Facility",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 3 }, { 1, 2 }, { 2, 1 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w31d = new GuardStageInfo
        {
            AreaCode = "w31d",
            AreaName = "Shell 2 Core, 1F Air Purification Room",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 6 }, { 1, 8 }, { 2, 10 }, { 3, 16 }, { 4, 8 }, { 6, 12 }, { 7, 4 }, { 8, 2 }, { 9, 8 }, { 10, 6 }, { 11, 2 }, { 12, 1 }, { 13, 11 }, { 14, 1 }, { 15, 10 }, { 16, 6 }, { 17, 4 }, { 18, 1 }, { 19, 4 }, { 20, 1 }, { 21, 28 }, { 22, 1 }, { 23, 10 }, { 24, 8 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w41a = new GuardStageInfo
        {
            AreaCode = "w41a",
            AreaName = "Arsenal Gear - Stomach",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 5, 1 } }
        }; //no patrolling guards

        public static readonly GuardStageInfo w42a = new GuardStageInfo
        {
            AreaCode = "w42a",
            AreaName = "Arsenal Gear - Jujenum",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 12 },{ 1, 4 },{ 2, 6 },{ 3, 4 },{ 4, 8 },{ 5, 13 } }
        }; //added all valid routes

        public static readonly GuardStageInfo w44a = new GuardStageInfo
        {
            AreaCode = "w44a",
            AreaName = "Arsenal Gear - Ileum",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 49, 1 }, { 50, 1 }, { 51, 1 }, { 52, 1 }, { 53, 1 }, { 54, 1 }, { 55, 1 } }
        }; //no patrolling guards

        public static readonly GuardStageInfo w45a = new GuardStageInfo
        {
            AreaCode = "w45a",
            AreaName = "Arsenal Gear - Sigmoid Colon",
            Guards = null,
            ValidRoutes = new Dictionary<int, int> { { 0, 1 },{ 1, 1 },{ 8, 1 },{ 9, 1 },{ 11, 1 } }
        }; //no patrolling guards

        public static List<GuardStageInfo> GuardStageList = new List<GuardStageInfo>
        {
            w00a, w00c, w01a, w01b, w01c, w01d, w01f, w02a, w03a, w03b,
            w11a, w12a, w12b, w12c, w13a, w13b, w14a, w15a, w15b, w16b,
            w17a, w18a, w19a, w20a, w20b, w20d, w21a, w22a, w23a, w23b,
            w24a, w24d, w25b, w25c, w25d, w28a, w31d, w41a, w42a, w44a,
            w45a
        };
    }
}
