using MathNet.Numerics.Random;
using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MGS2_Randomizer.MGS2Randomizer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MGS2_Randomizer
{
    public class MGS2Randomizer
    {
        private DirectoryInfo ResourceSuperDirectory { get; set; }
        private DirectoryInfo OriginalGcxFilesDirectory { get; set; }
        private List<string> GcxFileDirectory { get; set; }

        private static MGS2ItemSet _vanillaItems;
        private static MGS2ItemSet _randomizedItems;
        public Random Randomizer { get; set; }
        public int Seed { get; set; }
        private readonly byte[] TankerWeaponArray = new byte[] { 0x39, 0x21, 0x80, 0x01, 0x5C };
        private readonly byte[] TankerInitializeWeaponsArray = new byte[] { 0x21, 0x80, 0x01, 0x5C };
        private readonly byte[] TankerInitializeItemsArray = new byte[] { 0x21, 0x80, 0x01, 0xEC };
        private readonly byte[] PlantWeaponArray = new byte[] { 0x39, 0x21, 0x80, 0x02, 0xAC };
        private readonly byte[] PlantItemArray = new byte[] { 0x39, 0x21, 0x80, 0x03, 0x3C };
        private readonly byte[] PlantInitializeWeaponArray = new byte[] { 0x21, 0x80, 0x02, 0xAC };
        private readonly byte[] PlantInitializeItemsArray = new byte[] { 0x21, 0x80, 0x03, 0x3C };
        private readonly byte[] StartingItemCountBytes = new byte[] { 0x14, 0x06, 0x02, 0x7D };
        private readonly byte[] EmptyInitializeItemsArray = new byte[] { 0xC2, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1, 0xC1 };
        private readonly int ItemIndexOffset = 6;
        private readonly int ItemCountOffset = 7;
        private readonly byte WeaponIndexBase = 0xBB;
        private readonly byte ItemIndexBase = 0xBD;
        private string SpoilerContents = "";
        private readonly byte[] NormalVisionSetBytes = new byte[] { 0x39, 0x11, 0x00, 0x01, 0xDE, 0x01 };
        private readonly byte[] AlertVisionSetBytes = new byte[] { 0xA0, 0x39, 0x11, 0x00, 0x01, 0xE0, 0x01 };
        private readonly byte[] EvasionVisionSetBytes = new byte[] { 0x39, 0x11, 0x00, 0x01, 0xE2, 0x01 };
        private readonly byte[] HearingRangeSetBytes = new byte[] { 0xA0, 0x39, 0x11, 0x00, 0x01, 0xE4, 0x01 };
        private readonly byte[] LifeValueSetBytes = new byte[] { 0x39, 0x11, 0x00, 0x01, 0xE6, 0x01 };
        private readonly byte[] HitsToStunSetBytes = new byte[] { 0x37, 0x11, 0x00, 0x01, 0xE8 };
        private readonly byte[] SleepDurationSetBytes = new byte[] { 0x39, 0x19, 0x00, 0x01, 0xEC, 0x01 };
        private readonly byte[] StunVisionSetBytes = new byte[] { 0x39, 0x19, 0x00, 0x01, 0xF0, 0x01 };
        private readonly byte[] Unknown1SetBytes = new byte[] { 0x37, 0x11, 0x00, 0x01, 0xEA };
        private readonly byte[] Unknown2SetBytes = new byte[] { 0x37, 0x11, 0x00, 0x01, 0xF4 };
        private readonly byte[] BulC4InitBytes = { 0x11, 0xBB, 0xDB, 0x06 };
        private const byte GcxDecimalZero = 0xC1;
        private const byte GcxDecimalOne = 0xC2;
        private readonly string[] ElectricalRoomSpawns = new[] { "ElectricalRoom", "Vents1", "Vents2" };


        private static List<RandomizedItem> MasterRaidenItemAwardOptions = new List<RandomizedItem> {
            new RandomizedItem{Index = 1 + GcxDecimalZero, Count = 2 + GcxDecimalZero, Name = "Ration" }, 
            new RandomizedItem{Index = 3 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Cold Medicine" },
            new RandomizedItem{Index = 4 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "Bandages" },
            new RandomizedItem{Index = 5 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "Pentazemin" },
            new RandomizedItem{Index = 6 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "B.D.U" },
            new RandomizedItem{Index = 7 + GcxDecimalZero,Count = 1 + GcxDecimalZero, Name = "Body Armor" },
            new RandomizedItem{Index = 8 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Stealth" },
            new RandomizedItem{Index = 9 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Mine Detector" },
            new RandomizedItem{Index = 10 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Sensor A" }, 
            new RandomizedItem{Index = 11 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Sensor B" },
            new RandomizedItem{Index = 12 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "N.V.G." }, 
            new RandomizedItem{Index = 13 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Thermal Goggles" },
            new RandomizedItem{Index = 14 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Scope" }, 
            new RandomizedItem{Index = 15 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Digital Camera" },
            new RandomizedItem{Index = 16 + GcxDecimalZero, Count = 21 + GcxDecimalZero, Name = "Box 1" }, 
            new RandomizedItem{Index = 17 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Cigarettes" },
            /*new RandomizedItem{Index = 18 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Card 1" },*/ 
            new RandomizedItem{Index = 19 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Shaver" },
            new RandomizedItem{Index = 20 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Phone" }, 
            new RandomizedItem{Index = 22 + GcxDecimalZero, Count = 21 + GcxDecimalZero, Name = "Box 2" },
            new RandomizedItem{Index = 23 + GcxDecimalZero, Count = 21 + GcxDecimalZero, Name = "Box 3" },
            new RandomizedItem{Index = 25 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "A.P. Sensor" },
            new RandomizedItem{Index = 26 + GcxDecimalZero, Count = 21 + GcxDecimalZero, Name = "Box 4" }, 
            new RandomizedItem{Index = 27 + GcxDecimalZero, Count = 21 + GcxDecimalZero, Name = "Box 5" },
            new RandomizedItem{Index = 29 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "SOCOM Suppressor" }, 
            new RandomizedItem{Index = 30 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "AK Suppressor" },
            new RandomizedItem{Index = 34 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "M.O. Disc" }, 
            new RandomizedItem{Index = 36 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Infinity Wig" },
            new RandomizedItem{Index = 37 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Blue Wig" }, 
            new RandomizedItem{Index = 38 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Orange Wig" },
            /*new RandomizedItem{Index = 18 + GcxDecimalZero, Count = 2 + GcxDecimalZero, Name = "Card 2" }, 
             * new RandomizedItem{Index = 18 + GcxDecimalZero, Count = 3 + GcxDecimalZero, Name = "Card 3" },
            new RandomizedItem{Index = 18 + GcxDecimalZero, Count = 4 + GcxDecimalZero, Name = "Card 4" }, 
            new RandomizedItem{Index = 18 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "Card 5" }*/ 
        };
        private List<RandomizedItem> RaidenItemAwardOptions;

        private static List<RandomizedItem> MasterRaidenWeaponAwardOptions = new List<RandomizedItem> {
            new RandomizedItem{Index = 3 + GcxDecimalZero, Count = 12 + GcxDecimalZero, Name = "SOCOM" }, 
            new RandomizedItem{Index = 5 + GcxDecimalZero, Count = 10 + GcxDecimalZero, Name = "RGB6" },
            new RandomizedItem{Index = 7 + GcxDecimalZero, Count = 10 + GcxDecimalZero, Name = "Stinger" }, 
            new RandomizedItem{Index = 14 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Coolant" },
            new RandomizedItem{Index = 18 + GcxDecimalZero, Count = 60 + GcxDecimalZero, Name = "M4" }, 
            new RandomizedItem{Index = 19 + GcxDecimalZero, Count = 20 + GcxDecimalZero, Name = "PSG1T" },
            new RandomizedItem{Index = 21 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "Book" }, 
            new RandomizedItem{Index = 6 + GcxDecimalZero, Count = 10 + GcxDecimalZero, Name = "Nikita" },
            new RandomizedItem{Index = 1 + GcxDecimalZero, Count = 15 + GcxDecimalZero, Name = "M9" }, 
            new RandomizedItem{Index = 4 + GcxDecimalZero, Count = 10 + GcxDecimalZero, Name = "PSG1" },
            new RandomizedItem{Index = 8 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "Claymore" }, 
            new RandomizedItem{Index = 8 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "C4" },
            new RandomizedItem{Index = 10 + GcxDecimalZero, Count = 2 + GcxDecimalZero, Name = "Chaff Grenade" }, 
            new RandomizedItem{Index = 11 + GcxDecimalZero, Count = 2 + GcxDecimalZero, Name = "Stun Grenade" },
            new RandomizedItem{Index = 12 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Directional Microphone" }, 
            new RandomizedItem{Index = 15 + GcxDecimalZero, Count = 60 + GcxDecimalZero, Name = "AKS-74u" },
            new RandomizedItem{Index = 16 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "Magazine" }, 
            new RandomizedItem{Index = 17 + GcxDecimalZero, Count = 2 + GcxDecimalZero, Name = "Grenade" },
        };
        private List<RandomizedItem> RaidenWeaponAwardOptions;

        private static List<RandomizedItem> MasterSnakeItemAwardOptions = new List<RandomizedItem> { 
            new RandomizedItem { Index = 1 + GcxDecimalZero, Count = 2 + GcxDecimalZero, Name = "Ration" },
            new RandomizedItem{Index = 3 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Cold Medicine" },
            new RandomizedItem{Index = 4 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "Bandage" },
            new RandomizedItem{Index = 5 + GcxDecimalZero, Count = 5 + GcxDecimalZero, Name = "Pentazemin" }, 
            new RandomizedItem{Index = 8 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Stealth" },
            new RandomizedItem{Index = 9 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Mine Detector" }, 
            new RandomizedItem{Index = 13 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Thermals" },
            new RandomizedItem{Index = 21 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Camera" }, 
            new RandomizedItem{Index = 15 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Digital Camera" },
            new RandomizedItem{Index = 16 + GcxDecimalZero, Count = 21 + GcxDecimalZero, Name = "Box 1" }, 
            new RandomizedItem{Index = 17 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Cigarettes" },
            new RandomizedItem{Index = 19 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Shaver" }, 
            new RandomizedItem{Index = 25 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "A.P. Sensor" },
            new RandomizedItem{Index = 35 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "USP Suppressor" }, 
            new RandomizedItem{Index = 32 + GcxDecimalZero, Count = 1 + GcxDecimalZero, Name = "Bandana" } 
        };
        private List<RandomizedItem> SnakeItemAwardOptions;

        private static List<RandomizedItem> MasterSnakeWeaponAwardOptions = new List<RandomizedItem> {
            new RandomizedItem{Index = 2 + GcxDecimalZero, Count = 12 + GcxDecimalZero, Name = "USP" }, 
            new RandomizedItem{Index = 1 + GcxDecimalZero, Count = 15 + GcxDecimalZero, Name = "M9" },
            new RandomizedItem{Index = 11 + GcxDecimalZero, Count = 4 + GcxDecimalZero, Name = "Stun Grenade" }, 
            new RandomizedItem{Index = 10 + GcxDecimalZero, Count = 4 + GcxDecimalZero, Name = "Chaff Grenade" },
            new RandomizedItem{Index = 17 + GcxDecimalZero, Count = 4 + GcxDecimalZero, Name = "Grenade" }, 
            new RandomizedItem{Index = 16 + GcxDecimalZero, Count = 10 + GcxDecimalZero, Name = "Magazine" } 
        };
        private List<RandomizedItem> SnakeWeaponAwardOptions;

        public MGS2Randomizer(string mgs2Directory, int seed = 0)
        {
            if (Directory.Exists(mgs2Directory))
            {
                DirectoryInfo gcxDirectory = new DirectoryInfo(mgs2Directory + "\\assets\\gcx\\eu\\_bp");
                SaveOldFiles(gcxDirectory);
                GcxFileDirectory = Directory.EnumerateFiles(gcxDirectory.FullName).ToList();
                ResourceSuperDirectory = new DirectoryInfo(mgs2Directory + "\\eu\\stage");

                if (seed == 0)
                {
                    Seed = new Random(DateTime.UtcNow.Hour + DateTime.UtcNow.Minute + DateTime.UtcNow.Second + DateTime.UtcNow.Millisecond).Next();
                }
                else
                {
                    Seed = seed;
                }

                Randomizer = new Random(Seed);
                VanillaItems.BuildVanillaItems();
            }
            else
            {
                throw new DirectoryNotFoundException("Invalid directory provided, please provide the full path to your MGS2 install location.");
            }
        }

        private void BuildVanillaItemSet()
        {
            RandomizationForm._logger.Debug("Building vanilla item set...");
            _vanillaItems = new MGS2ItemSet
            {
                //0x30 spawns in tanker
                TankerPart1 = new ItemSet(VanillaItems.TankerPart1),
                TankerPart2 = new ItemSet(VanillaItems.TankerPart2),
                TankerPart3 = new ItemSet(VanillaItems.TankerPart3),

                //0xd3 spawns in plant
                PlantSet1 = new ItemSet(VanillaItems.PlantSet1),
                PlantSet2 = new ItemSet(VanillaItems.PlantSet2),
                PlantSet3 = new ItemSet(VanillaItems.PlantSet3),
                PlantSet4 = new ItemSet(VanillaItems.PlantSet4),
                PlantSet5 = new ItemSet(VanillaItems.PlantSet5),
                PlantSet6 = new ItemSet(VanillaItems.PlantSet6),
                PlantSet7 = new ItemSet(VanillaItems.PlantSet7),
                PlantSet8 = new ItemSet(VanillaItems.PlantSet8),
                PlantSet9 = new ItemSet(VanillaItems.PlantSet9),
                PlantSet10 = new ItemSet(VanillaItems.PlantSet10),

                PlantCard0Set = new ItemSet(VanillaItems.PlantCard0Set),
                PlantCard1Set = new ItemSet(VanillaItems.PlantCard1Set),
                PlantCard2Set = new ItemSet(VanillaItems.PlantCard2Set),
                PlantCard3Set = new ItemSet(VanillaItems.PlantCard3Set),
                PlantCard4Set = new ItemSet(VanillaItems.PlantCard4Set),
                PlantCard5Set = new ItemSet(VanillaItems.PlantCard5Set),

                CardRandomizationFirstProgressionItems = new List<Item>(LogicRequirements.CardRandomizationFirstProgressionItems),
                CardRandomizationSecondProgressionItems = new List<Item>(LogicRequirements.CardRandomizationSecondProgressionItems),
                CardRandomizationThirdProgressionItems = new List<Item>(LogicRequirements.CardRandomizationThirdProgressionItems)
            };
        }

        private List<PointF> GetWalkableAreaForEFConnectingBridge()
        {
            return new List<PointF>
            {

                new PointF(0xED4F, 0xFFFEDC3D),
                new PointF(0xCF29, 0xFFFEDCFD),
                new PointF(0xCE0F, 0xFFFEDE6E),
                new PointF(0xCF47, 0xFFFEDFE9),
                new PointF(0xD16F, 0xFFFEE0A9),
                new PointF(0xD16F, 0xFFFEE48B),
                new PointF(0xCEC0, 0xFFFEE53E),
                new PointF(0xCD88, 0xFFFEE67B),
                new PointF(0xCD88, 0xFFFEFA69),
                new PointF(0xCED7, 0xFFFEFBCA),
                new PointF(0xD696, 0xFFFEFBCA),
                new PointF(0xD74A, 0xFFFEFC7E),
                new PointF(0xD74C, 0xFFFF2EC2),
                new PointF(0xD696, 0xFFFF2F76),
                new PointF(0xCF19, 0xFFFF2F77),
                new PointF(0xCD87, 0xFFFF30FB),
                new PointF(0xCD86, 0xFFFF44DE),
                new PointF(0xCEA2, 0xFFFF4601),
                new PointF(0xD0BA, 0xFFFF4601),
                new PointF(0xD16E, 0xFFFF46B6),
                new PointF(0xD170, 0xFFFF4A98),
                new PointF(0xD0BA, 0xFFFF4B57),
                new PointF(0xCF63, 0xFFFF4B57),
                new PointF(0xCE0F, 0xFFFF4C67),
                new PointF(0xCF62, 0xFFFF4E43),
                new PointF(0xE4BF, 0xFFFF4E43),
                new PointF(0xE57F, 0xFFFF4F03),
                new PointF(0xE57F, 0xFFFF5361),
                new PointF(0xE4BF, 0xFFFF5421),
                new PointF(0xC508, 0xFFFF5421),
                new PointF(0xC449, 0xFFFF5362),
                new PointF(0xC449, 0xFFFF4F03),
                new PointF(0xC509, 0xFFFF4E43),
                new PointF(0xC719, 0xFFFF4E43),
                new PointF(0xC831, 0xFFFF4D22),
                new PointF(0xC705, 0xFFFF4B57),
                new PointF(0xC585, 0xFFFF4B57),
                new PointF(0xC4D0, 0xFFFF4A98),
                new PointF(0xC4D2, 0xFFFF46B6),
                new PointF(0xC585, 0xFFFF4601),
                new PointF(0xC7AF, 0xFFFF4602),
                new PointF(0xC8B8, 0xFFFF448C),
                new PointF(0xC8B9, 0xFFFF3102),
                new PointF(0xC73A, 0xFFFF2F76),
                new PointF(0xBFA9, 0xFFFF2F77),
                new PointF(0xBEF4, 0xFFFF2EC3),
                new PointF(0xBEF6, 0xFFFF1955),
                new PointF(0xBDB1, 0xFFFF1808),
                new PointF(0x5D6D, 0xFFFF1808),
                new PointF(0x5C40, 0xFFFF1A14),
                new PointF(0x5C3E, 0xFFFF1B3B),
                new PointF(0x5B8A, 0xFFFF1BF0),
                new PointF(0x57A8, 0xFFFF1BF0),
                new PointF(0x56E9, 0xFFFF1B3B),
                new PointF(0x56E9, 0xFFFF19CD),
                new PointF(0x552E, 0xFFFF188F),
                new PointF(0x533D, 0xFFFF2D11),
                new PointF(0x4CF5, 0xFFFF2D11),
                new PointF(0x4CEB, 0xFFFF0EC9),
                new PointF(0x533D, 0xFFFF0EC9),
                new PointF(0x5537, 0xFFFF12B1),
                new PointF(0x56E9, 0xFFFF101D),
                new PointF(0x5C40, 0xFFFF1006),
                new PointF(0x5EFC, 0xFFFF133A),
                new PointF(0xBC39, 0xFFFF133A),
                new PointF(0xBEF6, 0xFFFF1078),
                new PointF(0xBFA9, 0xFFFEFBC8),
                new PointF(0xC676, 0xFFFEFBC9),
                new PointF(0xC8B8, 0xFFFEFA4C),
                new PointF(0xC8B9, 0xFFFEE7B7),
                new PointF(0xC5CE, 0xFFFEE53E),
                new PointF(0xC59A, 0xFFFEDFE9),
                new PointF(0xC831, 0xFFFEDE34),
                new PointF(0xC508, 0xFFFEDCFD),
                new PointF(0xC508, 0xFFFED71F),
                new PointF(0xED4F, 0xFFFED7A3)
            };
        }

        private byte[] EnlargeClaymoreFunction(string gcxFile)
        {
            GcxEditor w21a = new GcxEditor();
            w21a.CallDecompiler(gcxFile);
            List<DecodedProc> contentTree = w21a.BuildContentTree();
            DecodedProc claymoreSpawningFunction = contentTree.Find(x => x.Name == "proc_0x223D85 ");
            byte[] customClaymoreFunctionContents = File.ReadAllBytes("w21a_custom_claymores.proc");
            claymoreSpawningFunction.RawContents = customClaymoreFunctionContents;
            return w21a.BuildGcxFile();
        }

        private void MoveClaymores(ref byte[] gcxContents, List<PointF> walkableArea, int leftWall, int rightSideLowerCatwalk)
        {
            List<int> claymores = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x85, 0xD6, 0x78 });

            PointF randomPoint;

            foreach (int claymore in claymores)
            {
                randomPoint = GetRandomPointInPolygon(walkableArea, Randomizer);
                // Rerandomize any rolls that are on the stairs leading to lower catwalk
                while (randomPoint.X < leftWall && randomPoint.X > rightSideLowerCatwalk)
                {
                    randomPoint = GetRandomPointInPolygon(walkableArea, Randomizer);
                }
                int xPos = (int)randomPoint.X;
                uint yPos = (uint)randomPoint.Y;

                Array.Copy(BitConverter.GetBytes(xPos), 0, gcxContents, claymore + 0xB, 2);

                // Claymores on the lower catwalk need to be, well, lowered.
                if (xPos < rightSideLowerCatwalk)
                {
                    Array.Copy(BitConverter.GetBytes(0xFFFFFA20), 0, gcxContents, claymore + 0x10, 4);
                }

                Array.Copy(BitConverter.GetBytes(yPos), 0, gcxContents, claymore + 0x15, 4); //the FFFF should be untouched with this and still work
            }
        }

        private void RandomizeClaymores()
        {
            RandomizationForm._logger.Debug("Randomizing claymores...");
            int leftWall = 0xBF68;
            int rightSideLowerCatwalk = 0xABB0;

            List<PointF> walkableArea = GetWalkableAreaForEFConnectingBridge();

            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w21a"));

            byte[] modifiedGcxContents = EnlargeClaymoreFunction(gcxFile);
            File.WriteAllBytes(gcxFile, modifiedGcxContents);

            byte[] gcxContents = File.ReadAllBytes(gcxFile);

            MoveClaymores(ref gcxContents, walkableArea, leftWall, rightSideLowerCatwalk);

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        #region ChatGPT polygon interior randomization magic
        public static bool IsPointInPolygon(PointF p, List<PointF> polygon)
        {
            bool inside = false;
            int n = polygon.Count;
            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                if (((polygon[i].Y > p.Y) != (polygon[j].Y > p.Y)) &&
                    (p.X < (polygon[j].X - polygon[i].X) * (p.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    inside = !inside;
                }
            }
            return inside;
        }

        // Get the bounding box of the polygon
        public static RectangleF GetBoundingBox(List<PointF> polygon)
        {
            float minX = float.MaxValue, minY = float.MaxValue, maxX = float.MinValue, maxY = float.MinValue;

            foreach (var point in polygon)
            {
                if (point.X < minX) minX = point.X;
                if (point.X > maxX) maxX = point.X;
                if (point.Y < minY) minY = point.Y;
                if (point.Y > maxY) maxY = point.Y;
            }

            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }

        // Generate a random point inside the polygon
        public static PointF GetRandomPointInPolygon(List<PointF> polygon, Random rand)
        {
            var boundingBox = GetBoundingBox(polygon);

            PointF randomPoint;
            do
            {
                // Generate random point within the bounding box
                float x = (float)(rand.NextDouble() * boundingBox.Width + boundingBox.Left);
                float y = (float)(rand.NextDouble() * boundingBox.Height + boundingBox.Top);
                randomPoint = new PointF(x, y);
            }
            while (!IsPointInPolygon(randomPoint, polygon));  // Check if it's inside the polygon

            return randomPoint;
        }
        #endregion

        private void AddTankerStartingItemsToPool()
        {
            //Add M9, Camera, Cigs and AP Sensor to randomization pool
            KeyValuePair<Location, Item> newSpawn1 = _vanillaItems.TankerPart3.Entities.First(spawn => spawn.Key.Name == "RightsideLifeboats" && spawn.Key.GcxFile == "w00a");
            _vanillaItems.TankerPart3.Entities[newSpawn1.Key] = MGS2Weapons.M9;

            KeyValuePair<Location, Item> newSpawn2 = _vanillaItems.TankerPart3.Entities.First(spawn => spawn.Key.Name == "UnderLeftsideStairs" && spawn.Key.GcxFile == "w00a");
            _vanillaItems.TankerPart3.Entities[newSpawn2.Key] = MGS2Items.Camera1;

            KeyValuePair<Location, Item> newSpawn3 = _vanillaItems.TankerPart3.Entities.First(spawn => spawn.Key.Name == "UnderRightsideStairs" && spawn.Key.GcxFile == "w01b");
            _vanillaItems.TankerPart3.Entities[newSpawn3.Key] = MGS2Items.Cigs;

            KeyValuePair<Location, Item> newSpawn4 = _vanillaItems.TankerPart1.Entities.First(spawn => spawn.Key.Name == "Bar" && spawn.Key.GcxFile == "w01f");
            _vanillaItems.TankerPart3.Entities[newSpawn4.Key] = MGS2Items.APSensor;

            if (!_vanillaItems.TankerPart1.ItemsNeededToProgress.Contains(MGS2Weapons.M9))
                _vanillaItems.TankerPart1.ItemsNeededToProgress.Add(MGS2Weapons.M9);
            if (!_vanillaItems.TankerPart3.ItemsNeededToProgress.Contains(MGS2Items.Camera1))
                _vanillaItems.TankerPart3.ItemsNeededToProgress.Add(MGS2Items.Camera1);
        }

        private void AddPlantStartingItemsToPool()
        {
            //Add AP Sensor and Scope to randomization pool
            KeyValuePair<Location, Item> newSpawn1 = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.Name == "BottomFloorMiddleCrates" && spawn.Key.GcxFile == "w22a");
            _vanillaItems.PlantSet10.Entities[newSpawn1.Key] = MGS2Items.APSensor;
            _vanillaItems.PlantCard5Set.Entities[newSpawn1.Key] = MGS2Items.APSensor;

            KeyValuePair<Location, Item> newSpawn2 = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.Name == "BottomFloorParkourBoxes" && spawn.Key.GcxFile == "w22a");
            _vanillaItems.PlantSet10.Entities[newSpawn2.Key] = MGS2Items.Scope1;
            _vanillaItems.PlantCard5Set.Entities[newSpawn2.Key] = MGS2Items.Scope1;
        }

        private List<RandomizedItem> BuildRandomStartingItems(int itemCount, bool isPlant)
        {
            List<RandomizedItem> randomStartingItems = new List<RandomizedItem>();

            for (int i = 0; i < itemCount; i++)
            {
                RandomizedItem randomItem = GetRandomItem(false, isPlant);
                if (randomStartingItems.Contains(randomItem))
                {
                    i--;
                }
                else
                {
                    randomStartingItems.Add(randomItem);
                }
            }

            return randomStartingItems;
        }

        private void RandomizeTankerStartingWeapon(byte[] gcxContents)
        {
            byte[] snakeStartingAmmoBytes = new byte[] { 0x11, 0x00, 0x0A, 0x5C };
            byte[] emptyInitializeWeaponsArray = new byte[] { 0xC2, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0, 0xC0 };

            //Snake starts with M9, so randomize that
            List<int> snakeWeaponAward = GcxEditor.FindAllSubArray(gcxContents, TankerInitializeWeaponsArray);
            RandomizedItem randomTankerStartingWeapon = GetRandomItem(true, false);
            int indexToModify = randomTankerStartingWeapon.Index - GcxDecimalZero;
            byte[] newInitializeWeaponsArray = new byte[emptyInitializeWeaponsArray.Length + 3];
            Array.Copy(emptyInitializeWeaponsArray, newInitializeWeaponsArray, indexToModify);
            Array.Copy(snakeStartingAmmoBytes, 0, newInitializeWeaponsArray, indexToModify, snakeStartingAmmoBytes.Length);
            Array.Copy(emptyInitializeWeaponsArray, indexToModify + 1, newInitializeWeaponsArray, indexToModify + 4, emptyInitializeWeaponsArray.Length - indexToModify - 1);
            foreach (int location in snakeWeaponAward)
            {
                Array.Copy(newInitializeWeaponsArray, 0, gcxContents, location + 6, newInitializeWeaponsArray.Length);
            }
            //^this works, but oh my lord is this over-engineered. I can just... insert C0s until I get where I need to be, then insert the ammo bytes, then fill out with C0s. christ.
        }

        private void RemoveCameraAwardedInW00a()
        {
            //use only result from `39218001ECF1D6C2` and set the ending C2 to C1
            string w00aFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w00a"));
            byte[] w00aByteContents = File.ReadAllBytes(w00aFile);

            int cameraIndex = GcxEditor.FindSubArray(w00aByteContents, new byte[] { 0x39, 0x21, 0x80, 0x01, 0xEC, 0xF1, 0xD6, 0xC2 }) + 7;

            w00aByteContents[cameraIndex] = GcxDecimalZero;
            File.WriteAllBytes(w00aFile, w00aByteContents);
        }

        private void FixW00aDemoBug()
        {
            //Fixing the inventory bug that occurs if you watch the M9 pad demo on w00a
            string w00a = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w00a"));
            byte[] w00aContents = File.ReadAllBytes(w00a);

            List<int> autoMenuInitId = GcxEditor.FindAllSubArray(w00aContents, new byte[] { 0x86, 0x3A, 0xA2 });

            w00aContents[autoMenuInitId[0] + 8] = GcxDecimalZero;
            w00aContents[autoMenuInitId[0] + 9] = GcxDecimalZero;

            w00aContents[autoMenuInitId[1] + 14] = GcxDecimalZero;
            w00aContents[autoMenuInitId[1] + 18] = GcxDecimalZero;
            File.WriteAllBytes(w00a, w00aContents);
        }

        private List<int> GetRaidenItemAwardLocations(byte[] gcxContents)
        {
            List<int> raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantInitializeItemsArray);
            //We only want the first 6 item declarations, so remove any coming after 6 until we have only 6.
            while (raidenItemAward.Count > 6)
            {
                raidenItemAward.RemoveAt(6);
            }
            //Remove the first call as well because the first call is also invalid
            raidenItemAward.RemoveAt(0);

            return raidenItemAward;
        }

        private List<int> GetSnakeItemAwardLocations(byte[] gcxContents)
        {
            List<int> snakeItemAward = GcxEditor.FindAllSubArray(gcxContents, TankerInitializeItemsArray);
            while (snakeItemAward.Count > 5)
            {
                snakeItemAward.RemoveAt(5);
            }

            return snakeItemAward;
        }

        private void UpdateD13tGcx(byte[] newInitializeItemsArray)
        {
            string d13tGcx = GcxFileDirectory.Find(file => file.Contains("scenerio_stage_d13t"));
            byte[] d13tContents = File.ReadAllBytes(d13tGcx);
            List<int> d13tRaidenItemAward = GcxEditor.FindAllSubArray(d13tContents, PlantInitializeItemsArray);
            while (d13tRaidenItemAward.Count > 5)
            {
                d13tRaidenItemAward.RemoveAt(5);
            }
            foreach (int location in d13tRaidenItemAward)
            {
                Array.Copy(newInitializeItemsArray, 0, d13tContents, location + 6, newInitializeItemsArray.Length);
            }

            File.WriteAllBytes(d13tGcx, d13tContents);
        }

        private void UpdateTitleGcx(byte[] gcxContents, List<RandomizedItem> randomStartingItems, List<int> itemAwardLocations, bool isPlant = false)
        {
            List<int> selectedRandomItemIndices = new List<int>();
            foreach (RandomizedItem item in randomStartingItems)
            {
                selectedRandomItemIndices.Add(item.Index - GcxDecimalZero);
            }
            selectedRandomItemIndices.Sort();

            byte[] newInitializeItemsArray = new byte[EmptyInitializeItemsArray.Length + 3];
            newInitializeItemsArray[0] = GcxDecimalOne;
            for (int i = 1; i < newInitializeItemsArray.Length; i++)
            {
                if (selectedRandomItemIndices.Contains(i))
                {
                    if (selectedRandomItemIndices.Count > 1)
                    {
                        newInitializeItemsArray[i] = GcxDecimalOne;
                        selectedRandomItemIndices.Remove(i);
                    }
                    else
                    {
                        Array.Copy(StartingItemCountBytes, 0, newInitializeItemsArray, i, StartingItemCountBytes.Length);
                        i += 3;
                    }
                }
                else
                {
                    newInitializeItemsArray[i] = GcxDecimalZero;
                }
            }
            foreach (int location in itemAwardLocations)
            {
                Array.Copy(newInitializeItemsArray, 0, gcxContents, location + 6, newInitializeItemsArray.Length);
            }

            if (isPlant)
            {
                UpdateD13tGcx(newInitializeItemsArray);
            }
        }

        private void RandomizeStartingItems()
        {
            RandomizationForm._logger.Debug("Randomizing starting items...");
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_n_title"));
            byte[] gcxContents = File.ReadAllBytes(gcxFile);

            #region Tanker
            RandomizeTankerStartingWeapon(gcxContents);

            //Snake starts with Camera, cigs, and (possibly) AP Sensor.
            List<int> snakeItemAward = GetSnakeItemAwardLocations(gcxContents);

            List<RandomizedItem> randomTankerStartingItems = BuildRandomStartingItems(3, false);

            //if not starting with Camera, modify w00a to not automatically award the Camera
            if (!randomTankerStartingItems.Any(x => x.Name == "Camera"))
            {
                RemoveCameraAwardedInW00a();
            }

            UpdateTitleGcx(gcxContents, randomTankerStartingItems, snakeItemAward);
            
            AddTankerStartingItemsToPool();

            FixW00aDemoBug();
            #endregion

            #region Plant
            //Raiden only starts with the AP sensor and Scope, so randomize those
            List<int> raidenItemAward = GetRaidenItemAwardLocations(gcxContents);

            List<RandomizedItem> randomPlantStartingItems = BuildRandomStartingItems(2, true);

            UpdateTitleGcx(gcxContents, randomPlantStartingItems, raidenItemAward, true);

            AddPlantStartingItemsToPool();
            #endregion

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private RandomizedItem GetRandomItem(bool isWeapon = false, bool isPlant = true)
        {
            RandomizedItem randomizedItem;

            if (isPlant)
            {
                if (isWeapon)
                {
                    int randomChoice = Randomizer.Next(RaidenWeaponAwardOptions.Count);
                    randomizedItem = RaidenWeaponAwardOptions[randomChoice];
                    RaidenWeaponAwardOptions.Remove(randomizedItem);
                }
                else
                {
                    int randomChoice = Randomizer.Next(RaidenItemAwardOptions.Count);
                    randomizedItem = RaidenItemAwardOptions[randomChoice];
                    RaidenItemAwardOptions.Remove(randomizedItem);
                }

            }
            else
            {
                if (isWeapon)
                {
                    int randomChoice = Randomizer.Next(SnakeWeaponAwardOptions.Count);
                    randomizedItem = SnakeWeaponAwardOptions[randomChoice];
                    SnakeWeaponAwardOptions.Remove(randomizedItem);
                }
                else
                {
                    int randomChoice = Randomizer.Next(SnakeItemAwardOptions.Count);
                    randomizedItem = SnakeItemAwardOptions[randomChoice];
                    SnakeItemAwardOptions.Remove(randomizedItem);
                }
            }

            return randomizedItem;
        }

        private void AddAutomaticRewardsToPools()
        {
            Location uspLocation = _vanillaItems.TankerPart3.Entities.First(spawn => spawn.Key.GcxFile == "w01f" && spawn.Key.Name == "StinkyRationMan").Key;
            _vanillaItems.TankerPart3.Entities[uspLocation] = MGS2Weapons.Usp;
            if (!_vanillaItems.TankerPart2.ItemsNeededToProgress.Contains(MGS2Weapons.Usp))
                _vanillaItems.TankerPart2.ItemsNeededToProgress.Add(MGS2Weapons.Usp);

            Location socomLocation = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.GcxFile == "w12b" && spawn.Key.Name == "Locker1").Key;
            _vanillaItems.PlantSet10.Entities[socomLocation] = MGS2Weapons.Socom;
            _vanillaItems.PlantCard5Set.Entities[socomLocation] = MGS2Weapons.Socom;

            Location cigsLocation = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.GcxFile == "w12a" && spawn.Key.Name == "RightCage").Key;
            _vanillaItems.PlantSet10.Entities[cigsLocation] = MGS2Items.Cigs;
            _vanillaItems.PlantCard5Set.Entities[cigsLocation] = MGS2Items.Cigs;

            Location sensorALocation = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.GcxFile == "w16a" && spawn.Key.Name == "LadiesRoom2").Key;
            _vanillaItems.PlantSet10.Entities[sensorALocation] = MGS2Items.SensorA;
            _vanillaItems.PlantCard5Set.Entities[sensorALocation] = MGS2Items.SensorA;

            Location coolantSprayLocation = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.GcxFile == "w16a" && spawn.Key.Name == "MensRoom").Key;
            _vanillaItems.PlantSet10.Entities[coolantSprayLocation] = MGS2Weapons.Coolant;
            _vanillaItems.PlantCard5Set.Entities[coolantSprayLocation] = MGS2Weapons.Coolant;

            Location bduLocation = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.GcxFile == "w18a" && spawn.Key.Name == "UnderStairs").Key;
            _vanillaItems.PlantSet10.Entities[bduLocation] = MGS2Items.BDU;
            _vanillaItems.PlantCard5Set.Entities[bduLocation] = MGS2Items.BDU;

            Location phoneLocation = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.GcxFile == "w20a" && spawn.Key.Name == "UnderConveyerBelt").Key;
            _vanillaItems.PlantSet10.Entities[phoneLocation] = MGS2Items.Phone;
            _vanillaItems.PlantCard5Set.Entities[phoneLocation] = MGS2Items.Phone;

            Location moDiskLocation = _vanillaItems.PlantSet10.Entities.First(spawn => spawn.Key.GcxFile == "w31d" && spawn.Key.Name == "ElectricalRoom2").Key;
            _vanillaItems.PlantSet10.Entities[moDiskLocation] = MGS2Items.MoDisc;
            _vanillaItems.PlantCard5Set.Entities[moDiskLocation] = MGS2Items.MoDisc;
        }

        private void AddCardsToPools()
        {
            Location card1Location = _vanillaItems.PlantCard5Set.Entities.First(spawn => spawn.Key.GcxFile == "w14a" && spawn.Key.Name == "Locker1").Key;
            _vanillaItems.PlantCard5Set.Entities[card1Location] = MGS2Items.Card1;

            Location card2Location = _vanillaItems.PlantCard5Set.Entities.First(spawn => spawn.Key.GcxFile == "w22a" && spawn.Key.Name == "LockerNearNode1").Key;
            _vanillaItems.PlantCard5Set.Entities[card2Location] = MGS2Items.Card2;

            Location card3Location = _vanillaItems.PlantCard5Set.Entities.First(spawn => spawn.Key.GcxFile == "w22a" && spawn.Key.Name == "C4Room2").Key;
            _vanillaItems.PlantCard5Set.Entities[card3Location] = MGS2Items.Card3;

            Location card4Location = _vanillaItems.PlantCard5Set.Entities.First(spawn => spawn.Key.GcxFile == "w31b" && spawn.Key.Name == "MiddleHallwayAlcove").Key;
            _vanillaItems.PlantCard5Set.Entities[card4Location] = MGS2Items.Card4;

            Location card5Location = _vanillaItems.PlantCard5Set.Entities.First(spawn => spawn.Key.GcxFile == "w31d" && spawn.Key.Name == "LeftsideAlcove").Key;
            _vanillaItems.PlantCard5Set.Entities[card5Location] = MGS2Items.Card5;
        }

        private void CheckAndRemoveFromCardPools(RandomizedItem item, ItemSet itemSetAdjusted)
        {
            Item itemToRemove;
            if (itemSetAdjusted.Name == "Card0Set" && LogicRequirements.CardRandomizationFirstProgressionItems.Any(progressiveItem => progressiveItem.Name == item.Name))
            {
                itemToRemove = _vanillaItems.CardRandomizationFirstProgressionItems.Find(x => x.Name == item.Name);
                _vanillaItems.CardRandomizationFirstProgressionItems.Remove(itemToRemove);
            }
            if (itemSetAdjusted.Name == "Card1Set" && LogicRequirements.CardRandomizationSecondProgressionItems.Any(progressiveItem => progressiveItem.Name == item.Name))
            {
                itemToRemove = _vanillaItems.CardRandomizationSecondProgressionItems.Find(x => x.Name == item.Name);
                _vanillaItems.CardRandomizationSecondProgressionItems.Remove(itemToRemove);
            }
            if (itemSetAdjusted.Name == "Card2Set" && LogicRequirements.CardRandomizationThirdProgressionItems.Any(progressiveItem => progressiveItem.Name == item.Name))
            {
                itemToRemove = _vanillaItems.CardRandomizationThirdProgressionItems.Find(x => x.Name == item.Name);
                _vanillaItems.CardRandomizationThirdProgressionItems.Remove(itemToRemove);
            }
        }

        private void RemoveFromFatmanOnward(RandomizedItem item)
        {
            Item itemToRemove = _vanillaItems.PlantSet3.ItemsNeededToProgress.Find(x => x.Name == item.Name);
            if (itemToRemove != null)
            {
                _vanillaItems.PlantSet3.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet4.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet5.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet6.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet7.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet10.ItemsNeededToProgress.Remove(itemToRemove);
            }
        }

        private void RemoveFromShell1ElevatorOnward(RandomizedItem item)
        {
            Item itemToRemove = _vanillaItems.PlantSet3.ItemsNeededToProgress.Find(x => x.Name == item.Name);
            if (itemToRemove != null)
            {
                _vanillaItems.PlantSet4.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet5.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet6.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet7.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet10.ItemsNeededToProgress.Remove(itemToRemove);
            }
        }

        private void RemoveFromAmesOnward(RandomizedItem item)
        {
            Item itemToRemove = _vanillaItems.PlantSet3.ItemsNeededToProgress.Find(x => x.Name == item.Name);
            if (itemToRemove != null)
            {
                _vanillaItems.PlantSet5.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet6.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet7.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet10.ItemsNeededToProgress.Remove(itemToRemove);
            }
        }

        private void RemoveFromShellsConnectingBridgeOnward(RandomizedItem item)
        {
            Item itemToRemove = _vanillaItems.PlantSet3.ItemsNeededToProgress.Find(x => x.Name == item.Name);
            if (itemToRemove != null)
            {
                _vanillaItems.PlantSet6.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet7.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet10.ItemsNeededToProgress.Remove(itemToRemove);
            }
        }

        private void RemoveFromJohnsonOnward(RandomizedItem item)
        {
            Item itemToRemove = _vanillaItems.PlantSet3.ItemsNeededToProgress.Find(x => x.Name == item.Name);
            if (itemToRemove != null)
            {
                _vanillaItems.PlantSet7.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet10.ItemsNeededToProgress.Remove(itemToRemove);
            }
        }

        private void RemoveFromEmmaOnward(RandomizedItem item)
        {
            Item itemToRemove = _vanillaItems.PlantSet3.ItemsNeededToProgress.Find(x => x.Name == item.Name);
            if (itemToRemove != null)
            {
                _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet10.ItemsNeededToProgress.Remove(itemToRemove);
            }
        }

        private void RemoveFromStrutLOnward(RandomizedItem item)
        {
            Item itemToRemove = _vanillaItems.PlantSet3.ItemsNeededToProgress.Find(x => x.Name == item.Name);
            if (itemToRemove != null)
            {
                _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(itemToRemove);
                _vanillaItems.PlantSet10.ItemsNeededToProgress.Remove(itemToRemove);
            }
        }

        private void RemoveFromAfterStrutL(RandomizedItem item)
        {
            Item itemToRemove = _vanillaItems.PlantSet3.ItemsNeededToProgress.Find(x => x.Name == item.Name);
            if (itemToRemove != null)
            {
                _vanillaItems.PlantSet10.ItemsNeededToProgress.Remove(itemToRemove);
            }
        }

        private void CheckAndRemoveFromRequirements(RandomizedItem item, ItemSet itemSetAdjusted)
        {
            CheckAndRemoveFromCardPools(item, itemSetAdjusted);
            switch (itemSetAdjusted.Name)
            {
                //Pliskin cutscene affects all item sets
                //Stillman cutscene affects all item sets
                //Ninja cutscene affects BeforeShells, BeforeJohnson, Before Emma, Before Strut L
                //President cutscene affects Before Emma, Before Strut L
                //Emma affects before strut L
                case "Before Pliskin":
                case "Before Stillman":
                case "Before Fatman":
                    RemoveFromFatmanOnward(item);
                    break;
                case "Before Shell 1 Elevator":
                    RemoveFromShell1ElevatorOnward(item);
                    break;
                case "Before Ames":
                    RemoveFromAmesOnward(item);
                    break;
                case "Before Shells Connecting Bridge":
                    RemoveFromShellsConnectingBridgeOnward(item);
                    break;
                case "Before Johnson":
                    RemoveFromJohnsonOnward(item);
                    break;
                case "Before Emma":
                    RemoveFromEmmaOnward(item);
                    break;
                case "Before Strut L":
                    RemoveFromStrutLOnward(item);
                    break;
                case "After Strut L":
                    RemoveFromAfterStrutL(item);
                    break;
            }
        }

        private void RandomizeOlgaReward(ref string spoiler)
        {
            //Olga gives USP
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w00c"));
            byte[] gcxContents = File.ReadAllBytes(gcxFile);
            List<int> snakeWeaponAward = GcxEditor.FindAllSubArray(gcxContents, TankerWeaponArray);

            RandomizedItem randomizedReward = GetRandomItem(true, false);
            spoiler += $"Olga will give you {randomizedReward.Name} after defeating her.\n";
            gcxContents[snakeWeaponAward[0] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[snakeWeaponAward[0] + ItemCountOffset] = randomizedReward.Count;

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private void RandomizePliskinRewards(ref string spoiler, bool randomizeCards)
        {
            //Pliskin gives SOCOM & Cigs
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w14a"));
            byte[] gcxContents = File.ReadAllBytes(gcxFile);

            List<int> raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);
            RandomizedItem randomizedReward = GetRandomItem(false);
            CheckAndRemoveFromRequirements(randomizedReward, randomizeCards ? _vanillaItems.PlantCard0Set : _vanillaItems.PlantSet1);
            spoiler += $"Pliskin will give you {randomizedReward.Name} on Strut B.\n";
            gcxContents[raidenItemAward[0] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenItemAward[0] + ItemCountOffset] = randomizedReward.Count;
            gcxContents[raidenItemAward[1] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenItemAward[1] + ItemCountOffset] = randomizedReward.Count;

            List<int> raidenWeaponAward = GcxEditor.FindAllSubArray(gcxContents, PlantWeaponArray);
            randomizedReward = GetRandomItem(true);
            CheckAndRemoveFromRequirements(randomizedReward, randomizeCards ? _vanillaItems.PlantCard0Set : _vanillaItems.PlantSet1);
            spoiler += $"Pliskin will give you {randomizedReward.Name} on Strut B.\n";
            gcxContents[raidenWeaponAward[2] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenWeaponAward[2] + ItemCountOffset] = randomizedReward.Count;
            gcxContents[raidenWeaponAward[3] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenWeaponAward[3] + ItemCountOffset] = randomizedReward.Count;

            File.WriteAllBytes(gcxFile, gcxContents);

            gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_d010p01"));
            gcxContents = File.ReadAllBytes(gcxFile);
            raidenWeaponAward = GcxEditor.FindAllSubArray(gcxContents, PlantWeaponArray);
            gcxContents[raidenWeaponAward[0] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenWeaponAward[0] + ItemCountOffset] = randomizedReward.Count;
            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private void RandomizeStillmanRewards(ref string spoiler, bool randomizeCards)
        {
            //Stillman gives Card 1, Sensor A & Coolant Spray
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w16a"));
            byte[] gcxContents = File.ReadAllBytes(gcxFile);
            List<int> raidenWeaponAward = GcxEditor.FindAllSubArray(gcxContents, PlantWeaponArray);
            RandomizedItem randomizedReward = GetRandomItem(true);
            CheckAndRemoveFromRequirements(randomizedReward, randomizeCards ? _vanillaItems.PlantCard0Set : _vanillaItems.PlantSet2);
            spoiler += $"Stillman will give you {randomizedReward.Name} on Strut C.\n";
            gcxContents[raidenWeaponAward[0] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenWeaponAward[0] + ItemCountOffset] = randomizedReward.Count;

            List<int> raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);

            randomizedReward = GetRandomItem(false);
            CheckAndRemoveFromRequirements(randomizedReward, randomizeCards ? _vanillaItems.PlantCard0Set : _vanillaItems.PlantSet2);
            spoiler += $"Stillman will give you {randomizedReward.Name} on Strut C.\n";
            gcxContents[raidenItemAward[1] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenItemAward[1] + ItemCountOffset] = randomizedReward.Count;

            if (randomizeCards)
            {
                randomizedReward = GetRandomItem(false);
                CheckAndRemoveFromRequirements(randomizedReward, _vanillaItems.PlantCard0Set);
                spoiler += $"Stillman will give you {randomizedReward.Name} on Strut C.\n";
                gcxContents[raidenItemAward[2] + ItemIndexOffset] = randomizedReward.Index;
                gcxContents[raidenItemAward[2] + ItemCountOffset] = randomizedReward.Count;

                File.WriteAllBytes(gcxFile, gcxContents);

                //looks like Card 1 gets actually set in w16b, so we will set it here as well
                gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w16b"));
                gcxContents = File.ReadAllBytes(gcxFile);
                raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);
                gcxContents[raidenItemAward[1] + ItemIndexOffset] = randomizedReward.Index;
                gcxContents[raidenItemAward[1] + ItemCountOffset] = randomizedReward.Count;
            }

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private void RandomizeNinjaRewards(ref string spoiler, bool randomizeCards)
        {
            //Ninja gives Card 2, BDU & Phone
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w20d"));
            byte[] gcxContents = File.ReadAllBytes(gcxFile);
            List<int> raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);
            RandomizedItem randomizedReward = new RandomizedItem();

            if (randomizeCards)
            {
                randomizedReward = GetRandomItem(false);
                CheckAndRemoveFromRequirements(randomizedReward, _vanillaItems.PlantCard1Set);
                spoiler += $"Cyborg Ninja will give you {randomizedReward.Name} on Strut E.\n";
                gcxContents[raidenItemAward[1] + ItemIndexOffset] = randomizedReward.Index;
                gcxContents[raidenItemAward[1] + ItemCountOffset] = randomizedReward.Count;
            }

            RandomizedItem randomizedReward2 = GetRandomItem(false);
            CheckAndRemoveFromRequirements(randomizedReward, randomizeCards ? _vanillaItems.PlantCard1Set : _vanillaItems.PlantSet4);
            spoiler += $"Cyborg Ninja will give you {randomizedReward2.Name} on Strut E.\n";
            gcxContents[raidenItemAward[2] + ItemIndexOffset] = randomizedReward2.Index;
            gcxContents[raidenItemAward[2] + ItemCountOffset] = randomizedReward2.Count;

            RandomizedItem randomizedReward3 = GetRandomItem(false);
            CheckAndRemoveFromRequirements(randomizedReward, randomizeCards ? _vanillaItems.PlantCard1Set : _vanillaItems.PlantSet4);
            spoiler += $"Cyborg Ninja will give you {randomizedReward3.Name} on Strut E.\n";
            gcxContents[raidenItemAward[3] + ItemIndexOffset] = randomizedReward3.Index;
            gcxContents[raidenItemAward[3] + ItemCountOffset] = randomizedReward3.Count;

            File.WriteAllBytes(gcxFile, gcxContents);


            gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w20b"));
            gcxContents = File.ReadAllBytes(gcxFile);
            raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);

            if (randomizeCards)
            {
                gcxContents[raidenItemAward[1] + ItemIndexOffset] = randomizedReward.Index;
                gcxContents[raidenItemAward[1] + ItemCountOffset] = randomizedReward.Count;
            }

            gcxContents[raidenItemAward[2] + ItemIndexOffset] = randomizedReward2.Index;
            gcxContents[raidenItemAward[2] + ItemCountOffset] = randomizedReward2.Count;

            gcxContents[raidenItemAward[3] + ItemIndexOffset] = randomizedReward3.Index;
            gcxContents[raidenItemAward[3] + ItemCountOffset] = randomizedReward3.Count;

            File.WriteAllBytes(gcxFile, gcxContents);

            gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w20c"));
            gcxContents = File.ReadAllBytes(gcxFile);
            raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);

            if (randomizeCards)
            {
                gcxContents[raidenItemAward[1] + ItemIndexOffset] = randomizedReward.Index;
                gcxContents[raidenItemAward[1] + ItemCountOffset] = randomizedReward.Count;
            }

            gcxContents[raidenItemAward[2] + ItemIndexOffset] = randomizedReward2.Index;
            gcxContents[raidenItemAward[2] + ItemCountOffset] = randomizedReward2.Count;

            gcxContents[raidenItemAward[3] + ItemIndexOffset] = randomizedReward3.Index;
            gcxContents[raidenItemAward[3] + ItemCountOffset] = randomizedReward3.Count;

            File.WriteAllBytes(gcxFile, gcxContents);


            gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_d021p01"));
            gcxContents = File.ReadAllBytes(gcxFile);
            raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);

            gcxContents[raidenItemAward[0] + ItemIndexOffset] = randomizedReward3.Index;
            gcxContents[raidenItemAward[0] + ItemCountOffset] = randomizedReward3.Count;

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private void RandomizeAmesReward(ref string spoiler)
        {
            //Ames gives Card 3
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w24b"));
            byte[] gcxContents = File.ReadAllBytes(gcxFile);
            List<int> raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);

            RandomizedItem randomizedReward = GetRandomItem(false);
            CheckAndRemoveFromRequirements(randomizedReward, _vanillaItems.PlantCard2Set);
            spoiler += $"Ames will give you {randomizedReward.Name} in the Hostage Room.\n";
            gcxContents[raidenItemAward[0] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenItemAward[0] + ItemCountOffset] = randomizedReward.Count;

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private void RandomizePresidentRewards(ref string spoiler, bool randomizeCards)
        {
            //President gives Card 4 & MO Disk
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w31a"));
            byte[] gcxContents = File.ReadAllBytes(gcxFile);
            List<int> raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);
            RandomizedItem randomizedReward = new RandomizedItem();

            if (randomizeCards)
            {
                randomizedReward = GetRandomItem(false);
                CheckAndRemoveFromRequirements(randomizedReward, _vanillaItems.PlantSet8);
                spoiler += $"President Johnson will give you {randomizedReward.Name} on Shell 2.\n";
                gcxContents[raidenItemAward[0] + ItemIndexOffset] = randomizedReward.Index;
                gcxContents[raidenItemAward[0] + ItemCountOffset] = randomizedReward.Count;
            }

            randomizedReward = GetRandomItem(false);
            CheckAndRemoveFromRequirements(randomizedReward, _vanillaItems.PlantSet8);
            spoiler += $"President Johnson will give you {randomizedReward.Name} on Shell 2.\n";
            gcxContents[raidenItemAward[1] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenItemAward[1] + ItemCountOffset] = randomizedReward.Count;

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private void RandomizeEmmaReward(ref string spoiler)
        {
            //Emma gives Card 5 
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w25d"));
            byte[] gcxContents = File.ReadAllBytes(gcxFile);
            List<int> raidenItemAward = GcxEditor.FindAllSubArray(gcxContents, PlantItemArray);

            RandomizedItem randomizedReward = GetRandomItem(false);
            CheckAndRemoveFromRequirements(randomizedReward, _vanillaItems.PlantSet10);
            spoiler += $"Emma will give you {randomizedReward.Name} on the KL Connecting Bridge.\n";
            gcxContents[raidenItemAward[0] + ItemIndexOffset] = randomizedReward.Index;
            gcxContents[raidenItemAward[0] + ItemCountOffset] = randomizedReward.Count;

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private string RandomizeAutomaticRewards(bool randomizeCards)
        {
            //Insert automatic rewards into the spawning pools
            RandomizationForm._logger.Debug("Randomizing automatic rewards...");
            AddAutomaticRewardsToPools();
            string spoiler = "";

            RandomizeOlgaReward(ref spoiler);

            RandomizePliskinRewards(ref spoiler, randomizeCards);

            RandomizeStillmanRewards(ref spoiler, randomizeCards);

            RandomizeNinjaRewards(ref spoiler, randomizeCards);

            if (randomizeCards)
            {
                RandomizeAmesReward(ref spoiler);
            }

            RandomizePresidentRewards(ref spoiler, randomizeCards);

            if (randomizeCards)
            {
                RandomizeEmmaReward(ref spoiler);
            }

            //Snake HF Blade
            //TODO: implement

            return spoiler;
        }

        private GuardValues GetRandomGuardValues(bool valueConsistency = false, float insanityScalar = .25f)
        {
            //Value consistency will decide whether values will be all relatively similar, or completely random (i.e., guards could have drastically different hearing and vision values if false)
            //Insanity scalar will be used to "rein in" the randomization - .25f is right around the normal range for the game)

            byte scaledByteMax = (byte)((0xFF - GcxDecimalZero) * insanityScalar + GcxDecimalZero);
            short normalVision = (short)(Randomizer.Next(0, 0x7FFF) * insanityScalar);
            short alertVision = (short)(Randomizer.Next(0, 0x7FFF) * insanityScalar);
            short evasionVision = (short)(Randomizer.Next(0, 0x7FFF) * insanityScalar);
            short hearingRange = (short)(Randomizer.Next(0, 0x7FFF) * insanityScalar);
            short lValue = (short)(Randomizer.Next(0, 0x7FFF) * insanityScalar);
            byte hitsToStun = (byte)Randomizer.Next(GcxDecimalZero, scaledByteMax);
            short sleepDuration = (short)(Randomizer.Next(0, 0x7FFF) * insanityScalar);
            short stunDuration = (short)(Randomizer.Next(0, 0x7FFF) * insanityScalar);
            byte unknown1 = (byte)Randomizer.Next(GcxDecimalZero, scaledByteMax);
            byte unknown2 = (byte)Randomizer.Next(GcxDecimalZero, scaledByteMax);

            if (valueConsistency)
            {
                //TODO: implement
            }

            return new GuardValues
            {
                NormalVision = normalVision,
                AlertVision = alertVision,
                EvasionVision = evasionVision,
                HearingDistance = hearingRange,
                LValue = lValue,
                HitsToStun = hitsToStun,
                SleepDuration = sleepDuration,
                StunDuration = stunDuration,
                Unknown1 = unknown1,
                Unknown2 = unknown2
            };
        }

        private Route SelectRandomRouteFromFile(string file)
        {
            GuardStageInfo example = GuardStage.w00c;
            GuardStageInfo currentStage = GuardStage.GuardStageList.Find(stage => file.Contains(stage.AreaCode));
            if (currentStage != null)
            {
                int validRouteCount = currentStage.ValidRoutes.Count;
                KeyValuePair<int, int> randomRoute = currentStage.ValidRoutes.ElementAt(Randomizer.Next(0, validRouteCount));
                return new Route(randomRoute.Key, randomRoute.Value);
            }
            return null;
        }

        private void RandomizeGuardPatrols(RandomizationOptions.RouteRandomizationBehavior guardRouteBehavior)
        {
            //TODO: implement guard-ID tracking for chosen routes so we can enable no-route sharing. 
            //TODO: add logic for randomizing defender and attacker routes, too?
            //w21a guard just insta dies at the start if he's far enough on the route xdd
            //A7 92 65 0? 06 77 F7 F7 is the true magic, but we're able to get away with just 06 77 F7 F7
            byte[] watcherInitBytes = new byte[] { 0x06, 0x77, 0xF7, 0xF7 };
            //this will allow us to catch all of the other problematic spawns that aren't tengus
            byte[] subfunctionCallBytes = new byte[] { 0xDD, 0x6F, 0xE8, 0x0D };
            byte[] tenguACallBytes1 = new byte[] { 0x45, 0x6B, 0x8F, 0x0D };
            byte[] tenguACallBytes2 = new byte[] { 0x88, 0x94, 0x70, 0x0D };
            byte[] tenguBCallBytes = new byte[] { 0x45, 0x6B, 0x9F, 0x0D };
            byte[] paramRDesignationBytes = new byte[] { 0x52, 0x72 }; //52 72 ?? is the determination of hzx route 
            byte[] paramNDesignationBytes = new byte[] { 0x52, 0x6E }; //52 6E ?? is the determination of starting index in route
            int subfunctionRouteDesignationOffset = 8;
            int subfunctionIndexDesignationOffset = 9;
            int gcxDesignationOffset = 2;

            List<string> gcxFilesToEdit = GcxFileDirectory.FindAll(file => file.Contains("scenerio_stage_w") && !file.Contains("scenerio_stage_wp") && !file.Contains("webdemo") && !file.Contains("wmovie") && file.EndsWith(".gcx"));
            byte[] gcxContents;
            bool edited = false;

            foreach(string gcxFile in gcxFilesToEdit)
            {
                Dictionary<int, List<int>> chosenRoutes = new Dictionary<int, List<int>>();
                if (gcxFile.Contains("w11a")) // 2/3 of the guards here are attackers, which we aren't messing with atm.
                    continue;
                gcxContents = File.ReadAllBytes(gcxFile);
                if (!gcxFile.Contains("w4")) //non-tengu levels
                {
                    GuardStageInfo stageInfo = GuardStage.GuardStageList.Find(x => gcxFile.Contains(x.AreaCode));
                    if (stageInfo != null)
                    {
                        if (stageInfo.RouteDeterminedInSubfunction && stageInfo.IndexDeterminedInSubfunction)
                        {
                            List<int> subfunctionCalls = GcxEditor.FindAllSubArray(gcxContents, subfunctionCallBytes);

                            if(subfunctionCalls != null)
                            {
                                foreach(int subfunctionCall in subfunctionCalls)
                                {
                                    RandomizeNormalGuard(gcxFile, ref gcxContents, ref chosenRoutes, guardRouteBehavior, subfunctionCall + subfunctionRouteDesignationOffset, subfunctionCall + subfunctionIndexDesignationOffset);
                                }
                                edited = true;
                            }
                        }
                        else
                        {
                            List<int> watcherInitCalls = GcxEditor.FindAllSubArray(gcxContents, watcherInitBytes);
                            List<int> paramRDesignations = GcxEditor.FindAllSubArray(gcxContents, paramRDesignationBytes);
                            List<int> paramNDesignations = GcxEditor.FindAllSubArray(gcxContents, paramNDesignationBytes);
                            if (watcherInitCalls != null)
                            {
                                foreach (int watcherInitCall in watcherInitCalls)
                                {
                                    byte[] guardId = new byte[4];
                                    Array.Copy(gcxContents, watcherInitCall + 5, guardId, 0, 4);
                                    if ((guardId.SequenceEqual(new byte[] { 0xFC, 0x39, 0x65, 0x03 }) || guardId.SequenceEqual(new byte[] { 0xFC, 0x39, 0x65, 0x06})) 
                                        && gcxFile.Contains("w31d"))
                                    {
                                        //These specific guards are the only watcher that uses a varbuf for route and index assignment
                                        //As such, it will eventually need to be handled uniquely, but for now I'm just not going to mess with them
                                        continue;
                                    }
                                    
                                    int paramRDesignation = FindClosestGreaterValue(paramRDesignations, watcherInitCall);
                                    int paramNDesignation = FindClosestGreaterValue(paramNDesignations, watcherInitCall);

                                    RandomizeNormalGuard(gcxFile, ref gcxContents, ref chosenRoutes, guardRouteBehavior, paramRDesignation + gcxDesignationOffset, paramNDesignation + gcxDesignationOffset);
                                }
                                edited = true;
                            }
                        }
                    }
                }
                else
                {
                    //w41a, w42a, w44a, w45a are all tengu levels
                    List<int> tenguAInit1Calls = GcxEditor.FindAllSubArray(gcxContents, tenguACallBytes1);
                    List<int> tenguAInit2Calls = GcxEditor.FindAllSubArray(gcxContents, tenguACallBytes2);
                    List<int> tenguBInitCalls = GcxEditor.FindAllSubArray(gcxContents, tenguBCallBytes);

                    if (tenguAInit1Calls != null)
                    {
                        foreach(int tenguAInit1Call in tenguAInit1Calls)
                        {
                            RandomizeTenguCall(gcxFile, ref gcxContents, guardRouteBehavior, chosenRoutes, tenguAInit1Call);
                        }
                        edited = true;
                    }

                    if(tenguAInit2Calls != null)
                    {
                        foreach(int tenguAInit2Call in tenguAInit2Calls)
                        {
                            RandomizeTenguCall(gcxFile, ref gcxContents, guardRouteBehavior, chosenRoutes, tenguAInit2Call);
                        }
                        edited = true;
                    }

                    if (tenguBInitCalls != null)
                    {
                        foreach (int tenguBInitCall in tenguBInitCalls)
                        {
                            RandomizeTenguCall(gcxFile, ref gcxContents, guardRouteBehavior, chosenRoutes, tenguBInitCall);
                        }
                        edited = true;
                    }
                }

                if (edited)
                    File.WriteAllBytes(gcxFile, gcxContents);
                edited = false;
            }
        }

        private void RandomizeNormalGuard(string gcxFile, ref byte[] gcxContents, ref Dictionary<int, List<int>> chosenRoutes, RandomizationOptions.RouteRandomizationBehavior guardRouteBehavior, int routeDesignation, int indexDesignation)
        {
            Route randomlySelectedRoute = GetRandomNormalGuardRoute(gcxFile, chosenRoutes, guardRouteBehavior);
            gcxContents[routeDesignation] = (byte)(GcxDecimalZero + (byte)randomlySelectedRoute.Id);
            int startingIndex = GetStartingIndex(chosenRoutes, randomlySelectedRoute, guardRouteBehavior);
            gcxContents[indexDesignation] = (byte)startingIndex;

            AddChosenRouteToDict(ref chosenRoutes, randomlySelectedRoute, startingIndex);
        }

        private Route GetRandomNormalGuardRoute(string gcxFile, Dictionary<int, List<int>> chosenRoutes, RandomizationOptions.RouteRandomizationBehavior guardRouteBehavior)
        {
            Route randomlySelectedRoute = SelectRandomRouteFromFile(gcxFile);
            while ((guardRouteBehavior == RandomizationOptions.RouteRandomizationBehavior.NoRouteShare && chosenRoutes.ContainsKey(randomlySelectedRoute.Id)) ||
                (chosenRoutes.ContainsKey(randomlySelectedRoute.Id) && randomlySelectedRoute.Indices == chosenRoutes[randomlySelectedRoute.Id].Count))
            {
                randomlySelectedRoute = SelectRandomRouteFromFile(gcxFile);
            }

            return randomlySelectedRoute;
        }

        private void AddChosenRouteToDict(ref Dictionary<int, List<int>> chosenRoutes, Route randomlySelectedRoute, int startingIndex)
        {
            if (chosenRoutes.ContainsKey(randomlySelectedRoute.Id))
                chosenRoutes[randomlySelectedRoute.Id].Add(startingIndex);
            else
                chosenRoutes.Add(randomlySelectedRoute.Id, new List<int> { startingIndex });
        }

        private int GetStartingIndex(Dictionary<int, List<int>> chosenRoutes, Route randomlySelectedRoute, RandomizationOptions.RouteRandomizationBehavior guardRouteBehavior)
        {
            int startingIndex = GcxDecimalZero + Randomizer.Next(0, randomlySelectedRoute.Indices);
            if (chosenRoutes.ContainsKey(randomlySelectedRoute.Id))
            {
                while (guardRouteBehavior == RandomizationOptions.RouteRandomizationBehavior.NoNodeShare && chosenRoutes[randomlySelectedRoute.Id].Contains(startingIndex))
                {
                    startingIndex = GcxDecimalZero + Randomizer.Next(0, randomlySelectedRoute.Indices);
                }
            }

            return startingIndex;
        }

        private void RandomizeTenguCall(string gcxFile, ref byte[] gcxContents, RandomizationOptions.RouteRandomizationBehavior guardRouteBehavior, Dictionary<int, List<int>> chosenRoutes, int callOffset)
        {
            Route randomlySelectedRoute = SelectRandomRouteFromFile(gcxFile);
            while (guardRouteBehavior == RandomizationOptions.RouteRandomizationBehavior.NoRouteShare && chosenRoutes.ContainsKey(randomlySelectedRoute.Id))
            {
                randomlySelectedRoute = SelectRandomRouteFromFile(gcxFile);
            }
            if (randomlySelectedRoute != null)
            {
                gcxContents[callOffset + 8] = (byte)(GcxDecimalZero + (byte)randomlySelectedRoute.Id);
                if (guardRouteBehavior == RandomizationOptions.RouteRandomizationBehavior.NoRouteShare)
                    chosenRoutes.Add(randomlySelectedRoute.Id, new List<int> { });
            }
        }

        private bool ModifyAllParamECalls(ref byte[] gcxContents)
        {
            byte[] explicitCallBytes3ByteId = new byte[] { 0xA7, 0x92, 0x65, 0x08, 0x06, 0x07, 0x9A, 0xCC };
            byte[] explicitCallBytes4ByteId = new byte[] { 0xA7, 0x92, 0x65, 0x09, 0x06, 0x07, 0x9A, 0xCC };
            byte[] paramEDesignationBytes = new byte[] { 0x52, 0x65 }; //52 65 C? is the determination of guard type inside an explicit call
            //explicit calls are more complicated. Param e is designated in different places, based on call construction.
            //Some reinforcements are called with an ID of only 3 bytes, others with 4 byte ID
            //We always want the first param E after the explicit call, and it should be safe to look for the first [52 65] after to find it
            List<int> explicit3ByteIdCalls = GcxEditor.FindAllSubArray(gcxContents, explicitCallBytes3ByteId);
            List<int> explicit4ByteIdCalls = GcxEditor.FindAllSubArray(gcxContents, explicitCallBytes4ByteId);
            List<int> paramEDesignationCalls = GcxEditor.FindAllSubArray(gcxContents, paramEDesignationBytes);

            bool edited = false;

            if (explicit3ByteIdCalls != null)
            {
                ModifyParamE(explicit3ByteIdCalls, paramEDesignationCalls, ref gcxContents);
                edited = true;
            }
            if (explicit4ByteIdCalls != null)
            {
                ModifyParamE(explicit4ByteIdCalls, paramEDesignationCalls, ref gcxContents);
                edited = true;
            }

            return edited;
        }

        private void ModifyParamE(List<int> explicitByteIdCalls, List<int> paramEDesignationCalls, ref byte[] gcxContents)
        {
            foreach (int explicit3ByteIdCall in explicitByteIdCalls)
            {
                int paramEDesignation = FindClosestGreaterValue(paramEDesignationCalls, explicit3ByteIdCall);
                gcxContents[paramEDesignation + 2] = (byte)Randomizer.Next(GcxDecimalZero, 0xC6);
            }
        }

        private void RandomizeReinforcementGuardTypes()
        {
            byte[] subfunctionCallBytes = new byte[] { 0x7D, 0x11, 0xBA, 0xB4, 0xA0 };
            int subfunctionParamEOffset = 0x11;
            int minGuardType = GcxDecimalZero;
            int maxGuardType = 0xC5;

            List<string> gcxFilesToEdit = GcxFileDirectory.FindAll(file => file.Contains("scenerio_stage_w") && !file.Contains("scenerio_stage_wp") && !file.Contains("webdemo") && !file.Contains("wmovie") && file.EndsWith(".gcx"));
            byte[] gcxContents;
            bool edited = false;

            foreach (string gcxFile in gcxFilesToEdit)
            {
                if (gcxFile.Contains("w11a") || gcxFile.Contains("w25d")) //the normal guards in w11a are considered attackers, and w25d has no param e for attackers. Skip these files.
                    continue;
                gcxContents = File.ReadAllBytes(gcxFile);
                List<int> subFunctionCalls = GcxEditor.FindAllSubArray(gcxContents, subfunctionCallBytes);
                if (subFunctionCalls != null)
                {
                    //subfunction calls are always formatted the same way(param E is always the 4th param), so we can handle these simply
                    foreach (int subFunctionCall in subFunctionCalls)
                    {
                        gcxContents[subFunctionCall + subfunctionParamEOffset] = (byte)Randomizer.Next(minGuardType, maxGuardType + 1); //+1 to force real max value inclusion
                    }
                    edited = true;
                }
                else
                {
                    edited = ModifyAllParamECalls(ref gcxContents);
                }
                if(edited)
                    File.WriteAllBytes(gcxFile, gcxContents);
                edited = false;
            }
        }

        private int FindClosestGreaterValue(List<int> list, int target)
        {
            foreach (int value in list)
            {
                if(value <= target)
                {
                    continue;
                }
                if (value > target)
                    return value;
            }
            return -1;
        }

        private void SetNormalVision(string gcxFile, ref byte[] gcxContents, short visionRange)
        {
            List<int> normalVisionSets = GcxEditor.FindAllSubArray(gcxContents, NormalVisionSetBytes);
            foreach (int normalVisionSet in normalVisionSets)
                Array.Copy(BitConverter.GetBytes(visionRange), 0, gcxContents, normalVisionSet + NormalVisionSetBytes.Length, sizeof(short));
        }

        private void SetAlertVision(string gcxFile, ref byte[] gcxContents, short visionRange)
        {
            List<int> alertVisionSets = GcxEditor.FindAllSubArray(gcxContents, AlertVisionSetBytes);
            foreach (int alertVisionSet in alertVisionSets)
                Array.Copy(BitConverter.GetBytes(visionRange), 0, gcxContents, alertVisionSet + AlertVisionSetBytes.Length, sizeof(short));
        }

        private void SetEvasionVision(string gcxFile, ref byte[] gcxContents, short visionRange)
        {
            List<int> evasionVisionSets = GcxEditor.FindAllSubArray(gcxContents, EvasionVisionSetBytes);
            foreach (int evasionVisionSet in evasionVisionSets)
                Array.Copy(BitConverter.GetBytes(visionRange), 0, gcxContents, evasionVisionSet + EvasionVisionSetBytes.Length, sizeof(short));
        }

        private void SetHearingRange(string gcxFile, ref byte[] gcxContents, short hearingRange)
        {
            List<int> hearingRangeSets = GcxEditor.FindAllSubArray(gcxContents, HearingRangeSetBytes);
            foreach (int hearingRangeSet in hearingRangeSets)
                Array.Copy(BitConverter.GetBytes(hearingRange), 0, gcxContents, hearingRangeSet + HearingRangeSetBytes.Length, sizeof(short));
        }

        private void SetLifeValue(string gcxFile, ref byte[] gcxContents, short lifeValue)
        {
            List<int> lValueSets = GcxEditor.FindAllSubArray(gcxContents, LifeValueSetBytes);
            foreach (int lValueSet in lValueSets)
                Array.Copy(BitConverter.GetBytes(lifeValue), 0, gcxContents, lValueSet + LifeValueSetBytes.Length, sizeof(short));
        }

        private void SetHitsToStunValue(string gcxFile, ref byte[] gcxContents, byte hitsToStun)
        {
            List<int> hitsToStunSets = GcxEditor.FindAllSubArray(gcxContents, HitsToStunSetBytes);
            foreach (int hitsToStunSet in hitsToStunSets)
                Array.Copy(BitConverter.GetBytes(hitsToStun), 0, gcxContents, hitsToStunSet + HitsToStunSetBytes.Length, sizeof(byte));
        }

        private void SetSleepDuration(string gcxFile, ref byte[] gcxContents, short sleepDuration)
        {
            List<int> sleepDurationSets = GcxEditor.FindAllSubArray(gcxContents, SleepDurationSetBytes);
            foreach (int normalVisionSet in sleepDurationSets)
                Array.Copy(BitConverter.GetBytes(sleepDuration), 0, gcxContents, normalVisionSet + SleepDurationSetBytes.Length, sizeof(short));
        }

        private void SetStunDuration(string gcxFile, ref byte[] gcxContents, short stunDuration)
        {
            List<int> stunDurationSets = GcxEditor.FindAllSubArray(gcxContents, StunVisionSetBytes);
            foreach (int normalVisionSet in stunDurationSets)
                Array.Copy(BitConverter.GetBytes(stunDuration), 0, gcxContents, normalVisionSet + StunVisionSetBytes.Length, sizeof(short));
        }

        private void SetUnknown1Value(string gcxFile, ref byte[] gcxContents, byte unknown1)
        {
            List<int> unknown1Sets = GcxEditor.FindAllSubArray(gcxContents, Unknown1SetBytes);
            foreach (int unknown1Set in unknown1Sets)
                Array.Copy(BitConverter.GetBytes(unknown1), 0, gcxContents, unknown1Set + Unknown1SetBytes.Length, sizeof(byte));
        }

        private void SetUnknown2Value(string gcxFile, ref byte[] gcxContents, byte unknown2)
        {
            List<int> unknown2Sets = GcxEditor.FindAllSubArray(gcxContents, Unknown2SetBytes);
            foreach (int unknown2Set in unknown2Sets)
                Array.Copy(BitConverter.GetBytes(unknown2), 0, gcxContents, unknown2Set + Unknown2SetBytes.Length, sizeof(byte));
        }

        private void SetNormalGuardValues(string gcxFile, ref byte[] gcxContents, GuardValues guardValues)
        {
            SetNormalVision(gcxFile, ref gcxContents, guardValues.NormalVision);
            SetAlertVision(gcxFile, ref gcxContents, guardValues.AlertVision);
            SetEvasionVision(gcxFile, ref gcxContents, guardValues.EvasionVision);
            SetHearingRange(gcxFile, ref gcxContents, guardValues.HearingDistance);
            SetLifeValue(gcxFile, ref gcxContents, guardValues.LValue);
            SetHitsToStunValue(gcxFile, ref gcxContents, guardValues.HitsToStun);
            SetSleepDuration(gcxFile, ref gcxContents, guardValues.SleepDuration);
            SetStunDuration(gcxFile, ref gcxContents, guardValues.StunDuration);
            SetUnknown1Value(gcxFile, ref gcxContents, guardValues.Unknown1);
            SetUnknown2Value(gcxFile, ref gcxContents, guardValues.Unknown2);
        }

        private void SetW42aTenguValues(ref byte[] gcxContents, GuardValues guardValues)
        {
            int normalVisionOffset = 0xA;
            int alertVisionOffset = 0xD;

            //need to alter calls to both tengu spawners
            List<int> tengu1Sets = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x88, 0x94, 0x70, 0x0D });
            foreach (int tenguSet in tengu1Sets)
            {
                Array.Copy(BitConverter.GetBytes(guardValues.NormalVision), 0, gcxContents, tenguSet + normalVisionOffset, sizeof(short));
                Array.Copy(BitConverter.GetBytes(guardValues.AlertVision), 0, gcxContents, tenguSet + alertVisionOffset, sizeof(short));
            }

            List<int> tengu2Sets = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x45, 0x6B, 0x8F, 0x0D });
            foreach (int tenguSet in tengu2Sets)
            {
                Array.Copy(BitConverter.GetBytes(guardValues.NormalVision), 0, gcxContents, tenguSet + normalVisionOffset, sizeof(short));
                Array.Copy(BitConverter.GetBytes(guardValues.AlertVision), 0, gcxContents, tenguSet + alertVisionOffset, sizeof(short));
            }
        }

        private void SetW44aTenguValues(ref byte[] gcxContents, GuardValues guardValues)
        {
            //need to alter varbuf_0x9A8 (Vision) and varbuf_0x9AA (HP)
            int alertVisionOffset = 0x6;
            int hpValueOffset = 0x6;

            //Set the vision for tengus in this level
            List<int> tengu1Sets = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x39, 0x11, 0x00, 0x09, 0xA8 });
            foreach (int tenguSet in tengu1Sets)
            {
                Array.Copy(BitConverter.GetBytes(guardValues.AlertVision), 0, gcxContents, tenguSet + alertVisionOffset, sizeof(short));
            }

            //Set the HP for tengus in this level
            List<int> tengu2Sets = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x39, 0x11, 0x00, 0x09, 0xAA });
            foreach (int tenguSet in tengu2Sets)
            {
                Array.Copy(BitConverter.GetBytes(guardValues.LValue), 0, gcxContents, tenguSet + hpValueOffset, sizeof(short));
            }
        }

        private void SetW45aTenguValues(ref byte[] gcxContents, GuardValues guardValues)
        {
            //need to alter varbuf_0xA0C (Life) and varbuf_0xA0E (Hits to stun)
            int hpValueOffset = 0x6;
            int hitsToStunOffset = 0x5;

            //Set the hp for tengus in this level
            List<int> tengu1Sets = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x39, 0x11, 0x00, 0x0A, 0x0C });
            foreach (int tenguSet in tengu1Sets)
            {
                Array.Copy(BitConverter.GetBytes(guardValues.LValue), 0, gcxContents, tenguSet + hpValueOffset, sizeof(short));
            }

            //Set the hits to stun for tengus in this level
            List<int> tengu2Sets = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x37, 0x11, 0x00, 0x0A, 0x0E });
            foreach (int tenguSet in tengu2Sets)
            {
                Array.Copy(BitConverter.GetBytes(guardValues.HitsToStun), 0, gcxContents, tenguSet + hitsToStunOffset, sizeof(byte));
            }
        }

        private void RandomizeGuardValues(bool levelConsistency = true, bool valueConsistency = false, float insanityScalar = .25f)
        {
            List<string> gcxFilesToEdit = GcxFileDirectory.FindAll(file => file.Contains("scenerio_stage_w") && !file.Contains("scenerio_stage_wp") && !file.Contains("webdemo") && !file.Contains("wmovie") && file.EndsWith(".gcx"));
            byte[] gcxContents;
            GuardValues guardValues = GetRandomGuardValues(valueConsistency, insanityScalar);

            foreach (string gcxFile in gcxFilesToEdit)
            {
                gcxContents = File.ReadAllBytes(gcxFile);
                SetNormalGuardValues(gcxFile, ref gcxContents, guardValues);

                if (gcxFile.Contains("w42a"))
                {
                    SetW42aTenguValues(ref gcxContents, guardValues);
                }

                if (gcxFile.Contains("w44a"))
                {
                    SetW44aTenguValues(ref gcxContents, guardValues);
                }

                if (gcxFile.Contains("w45a"))
                {
                    SetW45aTenguValues(ref gcxContents, guardValues);
                }

                if (!levelConsistency)
                {
                    guardValues = GetRandomGuardValues(valueConsistency, insanityScalar);
                }

                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private ByteLocation WestFacingControlUnit(int chosenLocation)
        {
            ByteLocation unitLocation = new ByteLocation();

            switch (chosenLocation)
            {
                case 0:
                    unitLocation = null;
                    break;
                case 1:
                    unitLocation.X = new byte[] { 0xE4, 0xC1 };
                    unitLocation.Y = new byte[] { 0x78, 0xEC };
                    unitLocation.Z = new byte[] { 0x30, 0x87 };
                    break;
                case 2:
                    unitLocation.X = new byte[] { 0xE4, 0xC1 };
                    unitLocation.Y = new byte[] { 0x78, 0xEC };
                    unitLocation.Z = new byte[] { 0x08, 0x96 };
                    break;
                case 3:
                    unitLocation.X = new byte[] { 0xB0, 0xDE };
                    unitLocation.Y = new byte[] { 0x00, 0xFA };
                    unitLocation.Z = new byte[] { 0x37, 0xD7 };
                    break;
                case 4:
                    unitLocation.X = new byte[] { 0xB0, 0xDE };
                    unitLocation.Y = new byte[] { 0x00, 0xFA };
                    unitLocation.Z = new byte[] { 0x32, 0xA0 };
                    break;
                case 5:
                    unitLocation.X = new byte[] { 0x0F, 0xCF };
                    unitLocation.Y = new byte[] { 0x40, 0xF6 };
                    unitLocation.Z = new byte[] { 0x90, 0xB2 };
                    break;
            }

            return unitLocation;
        }

        private void ModifyControlUnitLocation(byte[] gcxContents, byte[] controlUnitBytes, byte[] brokenControlUnitBytes, ByteLocation controlUnitLocation)
        {
            int controlUnitOffset = GcxEditor.FindAllSubArray(gcxContents, controlUnitBytes).FirstOrDefault();
            int brokenControlUnitOffset = GcxEditor.FindAllSubArray(gcxContents, brokenControlUnitBytes).LastOrDefault();

            Array.Copy(controlUnitLocation.X, 0, gcxContents, controlUnitOffset + 0x7, 2);
            Array.Copy(controlUnitLocation.Y, 0, gcxContents, controlUnitOffset + 0xA, 2);
            Array.Copy(controlUnitLocation.Z, 0, gcxContents, controlUnitOffset + 0xD, 2);

            Array.Copy(controlUnitLocation.X, 0, gcxContents, brokenControlUnitOffset + 0x11, 2);
            Array.Copy(controlUnitLocation.Y, 0, gcxContents, brokenControlUnitOffset + 0x14, 2);
            Array.Copy(controlUnitLocation.Z, 0, gcxContents, brokenControlUnitOffset + 0x17, 2);
        }

        private void RandomizeTankerSemtexControlUnitLocations()
        {
            RandomizationForm._logger.Debug("Randomizing control units...");
            byte[] controlUnit1Bytes = { 0x6C, 0x55, 0xF5 };
            byte[] brokenControlUnit1Bytes = { 0xAD, 0x55, 0xD5 };
            byte[] controlUnit2Bytes = { 0x6B, 0x55, 0xF5 };
            byte[] brokenControlUnit2Bytes = { 0xAC, 0x55, 0xD5 };
            byte[] controlUnit3Bytes = { 0x6A, 0x55, 0xF5 };
            byte[] brokenControlUnit3Bytes = { 0xAB, 0x55, 0xD5 };
            string gcxFile;
            byte[] gcxContents;

            int c1Choice = Randomizer.Next(4);
            int c2Choice = Randomizer.Next(5);
            int c3Choice = c1Choice;
            while (c3Choice == c1Choice)
            {
                c3Choice = Randomizer.Next(4);
            }

            ByteLocation c1Location = SouthFacingControlUnit(c1Choice);
            ByteLocation c2Location = WestFacingControlUnit(c2Choice);
            ByteLocation c3Location = SouthFacingControlUnit(c3Choice);
            

            gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w02a"));
            gcxContents = File.ReadAllBytes(gcxFile);
            if (c1Location != null)
            {
                ModifyControlUnitLocation(gcxContents, controlUnit1Bytes, brokenControlUnit1Bytes, c1Location);
            }
            if (c2Location != null)
            {
                ModifyControlUnitLocation(gcxContents, controlUnit2Bytes, brokenControlUnit2Bytes, c2Location);
            }
            if (c3Location != null)
            {
                ModifyControlUnitLocation(gcxContents, controlUnit3Bytes, brokenControlUnit3Bytes, c3Location);
            }

            File.WriteAllBytes(gcxFile, gcxContents);
        }

        private ByteLocation SouthFacingControlUnit(int choice)
        {
            ByteLocation byteLocation = new ByteLocation();
            switch (choice)
            {
                case 0:
                    byteLocation = null;
                    break;
                case 1:
                    byteLocation.X = new byte[] { 0xBB, 0xB7 };
                    byteLocation.Y = new byte[] { 0x80, 0xF1 };
                    byteLocation.Z = new byte[] { 0x00, 0xA3 };
                    break;
                case 2:
                    byteLocation.X = new byte[] { 0xBB, 0xB7 };
                    byteLocation.Y = new byte[] { 0x40, 0xF5 };
                    byteLocation.Z = new byte[] { 0xB5, 0x9E };
                    break;
                case 3:
                    byteLocation.X = new byte[] { 0xB5, 0xC8 };
                    byteLocation.Y = new byte[] { 0x40, 0xF6 };
                    byteLocation.Z = new byte[] { 0xB5, 0x9E };
                    break;
                case 4:
                    byteLocation.X = new byte[] { 0xB7, 0xE4 };
                    byteLocation.Y = new byte[] { 0x00, 0xF3 };
                    byteLocation.Z = new byte[] { 0xBE, 0xA6 };
                    break;
            }

            return byteLocation;
        }

        private void SetC4Location(byte[] gcxContents, byte[] bytesToFind, ByteLocation location, int xOffset, int yOffset, int zOffset)
        {
            List<int> c4Locations = GcxEditor.FindAllSubArray(gcxContents, bytesToFind);

            foreach(int c4Location in c4Locations)
            {
                Array.Copy(location.X, 0, gcxContents, c4Location + xOffset, location.X.Length);
                Array.Copy(location.Y, 0, gcxContents, c4Location + yOffset, location.Y.Length);
                Array.Copy(location.Z, 0, gcxContents, c4Location + zOffset, location.Z.Length);
            }
        }

        private void RandomizeStrutARoofC4()
        {
            int roofChoice = Randomizer.Next(3);
            ByteLocation roofLocation = new ByteLocation();
            int xLocationOffset = 0xC;
            int yLocationOffset = 0xF;
            int zLocationOffset = 0x12;
            switch (roofChoice)
            {
                case 0:
                    //change nothing
                    break;
                case 1:
                    roofLocation.X = new byte[] { 0xCD, 0x0B };
                    roofLocation.Y = new byte[] { 0x6A, 0x14 };
                    roofLocation.Z = new byte[] { 0x00, 0x00 };
                    break;
                case 2:
                    roofLocation.X = new byte[] { 0x52, 0xE4 };
                    roofLocation.Y = new byte[] { 0x6A, 0x18 };
                    roofLocation.Z = new byte[] { 0x57, 0x09 };
                    break;
            }

            if (roofChoice != 0)
            {
                string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w12a"));
                byte[] gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, BulC4InitBytes, roofLocation, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);

                gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w12c"));
                gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, BulC4InitBytes, roofLocation, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private void RandomizePumpRoomC4()
        {
            int pumpRoom = Randomizer.Next(6);
            ByteLocation pumpRoomLocation = new ByteLocation();
            int xLocationOffset = 0xD;
            int yLocationOffset = 0xF;
            int zLocationOffset = 0x11;
            byte[] pumpRoomC4DeclarationBytes = new byte[] { 0x16, 0x99, 0x61, 0x59 };
            switch (pumpRoom)
            {
                case 0:
                    //change nothing
                    break;
                case 1:
                    pumpRoomLocation.X = new byte[] { 0x6F };
                    pumpRoomLocation.Y = new byte[] { 0xFF };
                    pumpRoomLocation.Z = new byte[] { 0x00, 0x01 };
                    break;
                case 2:
                    pumpRoomLocation.X = new byte[] { 0x70 };
                    pumpRoomLocation.Y = new byte[] { 0xFF };
                    pumpRoomLocation.Z = new byte[] { 0x80, 0x31 };
                    break;
                case 3:
                    pumpRoomLocation.X = new byte[] { 0x00 };
                    pumpRoomLocation.Y = new byte[] { 0xFF };
                    pumpRoomLocation.Z = new byte[] { 0x38, 0x20 };
                    break;
                case 4:
                    pumpRoomLocation.X = new byte[] { 0x00 };
                    pumpRoomLocation.Y = new byte[] { 0xFF };
                    pumpRoomLocation.Z = new byte[] { 0x40, 0x1A };
                    break;
                case 5:
                    pumpRoomLocation.X = new byte[] { 0x00 };
                    pumpRoomLocation.Y = new byte[] { 0xFF };
                    pumpRoomLocation.Z = new byte[] { 0x50, 0x10 };
                    break;
            }

            if (pumpRoom != 0)
            {
                string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w12b"));
                byte[] gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, pumpRoomC4DeclarationBytes, pumpRoomLocation, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private void RandomizeTransformerRoomC4()
        {
            int transformerRoom = Randomizer.Next(6);
            ByteLocation location = new ByteLocation();
            int xLocationOffset = 0xC;
            int yLocationOffset = 0x11;
            int zLocationOffset = 0x14;
            switch (transformerRoom)
            {
                case 0:
                    //change nothing
                    break;
                case 1:
                    location.X = new byte[] { 0x56, 0x43, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x4C, 0x04 };
                    location.Z = new byte[] { 0x90, 0x75, 0xFF, 0xFF };
                    break;
                case 2:
                    location.X = new byte[] { 0x56, 0x43, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x7A, 0x00 };
                    location.Z = new byte[] { 0x10, 0x89, 0xFF, 0xFF };
                    break;
                case 3:
                    location.X = new byte[] { 0x00, 0x20, 0xFF, 0xFF };
                    location.Y = new byte[] { 0xE3, 0x01 };
                    location.Z = new byte[] { 0x90, 0x93, 0xFF, 0xFF };
                    break;
                case 4:
                    location.X = new byte[] { 0xC6, 0x2C, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x40, 0x0D };
                    location.Z = new byte[] { 0xAC, 0x67, 0xFF, 0xFF };
                    break;
                case 5:
                    location.X = new byte[] { 0x61, 0x53, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x7A, 0x00 };
                    location.Z = new byte[] { 0xA1, 0x67, 0xFF, 0xFF };
                    break;
            }

            if (transformerRoom != 0)
            {
                string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w14a"));
                byte[] gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, BulC4InitBytes, location, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private void RandomizeMessHallC4()
        {
            int diningHall = Randomizer.Next(8);
            ByteLocation location = new ByteLocation();
            int xLocationOffset = 0xD;
            int yLocationOffset = 0x12;
            int zLocationOffset = 0x15;
            byte[] diningHallC4DeclarationBytes = new byte[] { 0x20, 0x99, 0x61, 0x59 };
            switch (diningHall)
            {
                case 0:
                    //change nothing
                    break;
                case 1:
                    location.X = new byte[] { 0x41, 0x44, 0xFF, 0xFF };
                    location.Y = new byte[] { 0xB0, 0x05 };
                    location.Z = new byte[] { 0xC3, 0xBD, 0xFE, 0xFF };
                    break;
                case 2:
                    location.X = new byte[] { 0x2E, 0x52, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x32, 0x0D };
                    location.Z = new byte[] { 0xC3, 0xBD, 0xFE, 0xFF };
                    break;
                case 3:
                    location.X = new byte[] { 0x34, 0x28, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x32, 0x0B };
                    location.Z = new byte[] { 0xAB, 0xC1, 0xFE, 0xFF };
                    break;
                case 4:
                    location.X = new byte[] { 0x61, 0x0F, 0xFF, 0xFF };
                    location.Y = new byte[] { 0xE2, 0x0C };
                    location.Z = new byte[] { 0x28, 0xAC, 0xFE, 0xFF };
                    break;
                case 5:
                    location.X = new byte[] { 0x11, 0x25, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x00, 0x0C };
                    location.Z = new byte[] { 0x33, 0xD5, 0xFE, 0xFF };
                    break;
                case 6:
                    location.X = new byte[] { 0xA9, 0x4D, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x60, 0x09 };
                    location.Z = new byte[] { 0xD8, 0x76, 0xFE, 0xFF };
                    break;
                case 7:
                    location.X = new byte[] { 0x2E, 0x11, 0xFF, 0xFF };
                    location.Y = new byte[] { 0x70, 0x01 };
                    location.Z = new byte[] { 0x9D, 0x90, 0xFE, 0xFF };
                    break;
            }

            if (diningHall != 0)
            {
                string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w16a"));
                byte[] gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, diningHallC4DeclarationBytes, location, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);

                gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w16b"));
                gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, diningHallC4DeclarationBytes, location, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private void RemoveHatchOpenedRequirement(byte[] gcxContents, List<int> hatchReferenceOffset)
        {
            byte originalByte = 0;
            int i = 0;
            while (originalByte != GcxDecimalZero)
            {
                originalByte = gcxContents[hatchReferenceOffset[i] + 7];
                if (originalByte != GcxDecimalZero)
                {
                    i++;
                }
            }

            gcxContents[hatchReferenceOffset[i] + 7] = GcxDecimalOne;
        }

        private void RandomizeSedimentPoolC4s()
        {
            int sedimentPool1 = Randomizer.Next(5);
            ByteLocation location = new ByteLocation();
            int xLocationOffset = 0xB;
            int yLocationOffset = 0xE;
            int zLocationOffset = 0x11;
            byte[] sedimentPool1C4DeclarationBytes = new byte[] { 0x06, 0x25, 0x6F, 0x3A, 0x06, 0x4D, 0x25, 0xB2 };
            switch (sedimentPool1)
            {
                default:
                    sedimentPool1 = 0;
                    break;
                case 0:
                    //change nothing
                    break;
                case 1:
                    //other liftable & sprayable hatch
                    location.X = new byte[] { 0x0B, 0xDB };
                    location.Y = new byte[] { 0x66, 0xEF };
                    location.Z = new byte[] { 0x41, 0x0C, 0xFE, 0xFF };
                    break;
                case 2:
                    //behind fence
                    location.X = new byte[] { 0x45, 0xE4 };
                    location.Y = new byte[] { 0x60, 0xF0 };
                    location.Z = new byte[] { 0x56, 0x5F, 0xFE, 0xFF };
                    break;
                case 3:
                    //left-side scaffold 
                    location.X = new byte[] { 0x9F, 0xFC };
                    location.Y = new byte[] { 0x75, 0xED };
                    location.Z = new byte[] { 0xA3, 0x06, 0xFE, 0xFF };
                    break;

                case 4:
                    //under stairs 
                    location.X = new byte[] { 0x99, 0xEA };
                    location.Y = new byte[] { 0x60, 0xF0 };
                    location.Z = new byte[] { 0x62, 0xF7, 0xFD, 0xFF };
                    break;

            }

            int sedimentPool2 = Randomizer.Next(4);
            ByteLocation location2 = new ByteLocation();
            byte[] sedimentPool2C4DeclarationBytes = new byte[] { 0x06, 0x25, 0x6F, 0x3A, 0x06, 0x4E, 0x25, 0xB2 };
            switch (sedimentPool2)
            {
                default:
                    sedimentPool2 = 0;
                    break;
                case 0:
                    //change nothing
                    break;
                case 1:
                    //center cage
                    location2.X = new byte[] { 0x77, 0x00 };
                    location2.Y = new byte[] { 0x30, 0xFC };
                    location2.Z = new byte[] { 0x6F, 0x24, 0xFE, 0xFF };
                    break;
                case 2:
                    //behind fence
                    location2.X = new byte[] { 0x5C, 0x1C };
                    location2.Y = new byte[] { 0x60, 0xF0 };
                    location2.Z = new byte[] { 0x56, 0x5F, 0xFE, 0xFF };
                    break;
                case 3:
                    //right-side scaffold
                    location2.X = new byte[] { 0x1C, 0x03 };
                    location2.Y = new byte[] { 0x75, 0xED };
                    location2.Z = new byte[] { 0xB3, 0x06, 0xFE, 0xFF };
                    break;
            }

            int sedimentPool3 = Randomizer.Next(5);
            ByteLocation location3 = new ByteLocation();
            byte[] sedimentPool3C4DeclarationBytes = new byte[] { 0x06, 0x25, 0x6F, 0x3A, 0x06, 0x4F, 0x25, 0xB2 };
            switch (sedimentPool3)
            {
                case 0:
                    //change nothing
                    break;
                case 1:
                    location3.X = new byte[] { 0xBF, 0x00 };
                    location3.Y = new byte[] { 0xC2, 0x01 };
                    location3.Z = new byte[] { 0x6A, 0xF6, 0xFD, 0xFF };
                    break;
                case 2:
                    location3.X = new byte[] { 0xB6, 0x26 };
                    location3.Y = new byte[] { 0xCE, 0xFF };
                    location3.Z = new byte[] { 0x54, 0x49, 0xFE, 0xFF };
                    break;
                case 3:
                    location3.X = new byte[] { 0xB0, 0x01 };
                    location3.Y = new byte[] { 0xB8, 0xFA };
                    location3.Z = new byte[] { 0x66, 0x02, 0xFE, 0xFF };
                    break;
                case 4:
                    location3.X = new byte[] { 0xBD, 0x1F };
                    location3.Y = new byte[] { 0xB8, 0xFA };
                    location3.Z = new byte[] { 0xF6, 0x3B, 0xFE, 0xFF };
                    break;
            }

            if (sedimentPool1 != 0 || sedimentPool2 != 0 || sedimentPool3 != 0)
            {
                string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w18a"));
                byte[] gcxContents = File.ReadAllBytes(gcxFile);
                if (sedimentPool1 != 0)
                {
                    //need to remove hatch opened requirement, otherwise it will only be defusable when standard spawn hatch is opened
                    List<int> hatch1References = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x4D, 0x25, 0xB2 });
                    RemoveHatchOpenedRequirement(gcxContents, hatch1References);
                    SetC4Location(gcxContents, sedimentPool1C4DeclarationBytes, location, xLocationOffset, yLocationOffset, zLocationOffset);
                }
                if (sedimentPool2 != 0)
                {
                    //need to remove hatch opened requirement, otherwise it will only be defusable when standard spawn hatch is opened
                    List<int> hatch2References = GcxEditor.FindAllSubArray(gcxContents, new byte[] { 0x4E, 0x25, 0xB2 });
                    RemoveHatchOpenedRequirement(gcxContents, hatch2References);
                    SetC4Location(gcxContents, sedimentPool2C4DeclarationBytes, location2, xLocationOffset, yLocationOffset, zLocationOffset);
                }
                if (sedimentPool3 != 0)
                {
                    SetC4Location(gcxContents, sedimentPool3C4DeclarationBytes, location3, xLocationOffset, yLocationOffset, zLocationOffset);
                }

                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private void RandomizeParcelRoomC4()
        {
            int parcelRoom = Randomizer.Next(4);
            ByteLocation location = new ByteLocation();
            int xLocationOffset = 0x19;
            int yLocationOffset = 0x1E;
            int zLocationOffset = 0x21;
            byte[] parcelRoomC4DeclarationBytes = new byte[] { 0x06, 0x44, 0x31, 0x41, 0x0D, 0xEA, 0x7D, 0x5C, 0x99 };
            switch (parcelRoom)
            {
                case 0:
                    //change nothing
                    break;
                case 1:
                    location.X = new byte[] { 0x27, 0xCC, 0x00, 0x00 };
                    location.Y = new byte[] { 0x2A, 0x09 };
                    location.Z = new byte[] { 0x41, 0x7A, 0xFE, 0xFF };
                    break;
                case 2:
                    location.X = new byte[] { 0xDC, 0xDC, 0x00, 0x00 };
                    location.Y = new byte[] { 0x2A, 0x10 };
                    location.Z = new byte[] { 0x10, 0x89, 0xFE, 0xFF };
                    break;
                case 3:
                    location.X = new byte[] { 0x42, 0xE5, 0x00, 0x00 };
                    location.Y = new byte[] { 0x4B, 0x06 };
                    location.Z = new byte[] { 0xC1, 0xC2, 0xFE, 0xFF };
                    break;
            }

            if (parcelRoom != 0)
            {
                string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w20a"));
                byte[] gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, parcelRoomC4DeclarationBytes, location, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private void RandomizeHeliportC4()
        {
            int helipad = Randomizer.Next(5);
            ByteLocation location = new ByteLocation();
            int xLocationOffset = 0xC;
            int yLocationOffset = 0x11;
            int zLocationOffset = 0x14;
            switch (helipad)
            {
                case 0:
                    //change nothing
                    break;
                case 1:
                    location.X = new byte[] { 0x44, 0xBB, 0x00, 0x00 };
                    location.Y = new byte[] { 0x00, 0x31 };
                    location.Z = new byte[] { 0x3B, 0xA8, 0xFE, 0xFF };
                    break;
                case 2:
                    location.X = new byte[] { 0xBF, 0xB1, 0x00, 0x00 };
                    location.Y = new byte[] { 0x00, 0x2E };
                    location.Z = new byte[] { 0x3B, 0xA8, 0xFE, 0xFF };
                    break;
                case 3:
                    location.X = new byte[] { 0x75, 0xCD, 0x00, 0x00 };
                    location.Y = new byte[] { 0x0D, 0x27 };
                    location.Z = new byte[] { 0xDD, 0xC2, 0xFE, 0xFF };
                    break;
                case 4:
                    location.X = new byte[] { 0x91, 0x9E, 0x00, 0x00 };
                    location.Y = new byte[] { 0x80, 0x11 };
                    location.Z = new byte[] { 0x88, 0xA1, 0xFE, 0xFF };
                    break;
            }

            if (helipad != 0)
            {
                string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w20b"));
                byte[] gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, BulC4InitBytes, location, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private void RandomizeArmoryC4()
        {
            int armory = Randomizer.Next(9);
            ByteLocation location = new ByteLocation();
            int xLocationOffset = 0xB;
            int yLocationOffset = 0x10;
            int zLocationOffset = 0x13;
            byte[] armoryC4DeclarationBytes = new byte[] { 0x06, 0x25, 0x6F, 0x3A, 0x06, 0x25, 0x6F, 0x3A };
            switch (armory)
            {
                case 0:
                    //change nothing
                    break;
                case 1:
                    location.X = new byte[] { 0x30, 0xC5, 0x00, 0x00 };
                    location.Y = new byte[] { 0x60, 0xFB };
                    location.Z = new byte[] { 0xDC, 0xB6 };
                    break;
                case 2:
                    location.X = new byte[] { 0xA9, 0xB3, 0x00, 0x00 };
                    location.Y = new byte[] { 0x60, 0xF0 };
                    location.Z = new byte[] { 0x9F, 0x81 };
                    break;
                case 3:
                    location.X = new byte[] { 0x45, 0x9A, 0x00, 0x00 };
                    location.Y = new byte[] { 0xE3, 0x01 };
                    location.Z = new byte[] { 0x53, 0x95 };
                    break;
                case 4:
                    location.X = new byte[] { 0x81, 0xAF, 0x00, 0x00 };
                    location.Y = new byte[] { 0x9B, 0x05 };
                    location.Z = new byte[] { 0xB5, 0xB8 };
                    break;
                case 5:
                    location.X = new byte[] { 0xFE, 0xF3, 0x00, 0x00 };
                    location.Y = new byte[] { 0xB2, 0x00 };
                    location.Z = new byte[] { 0x74, 0xAA };
                    break;
                case 6:
                    location.X = new byte[] { 0x3D, 0xC5, 0x00, 0x00 };
                    location.Y = new byte[] { 0xE2, 0x01 };
                    location.Z = new byte[] { 0x64, 0xA6 };
                    break;
                case 7:
                    location.X = new byte[] { 0x53, 0xC4, 0x00, 0x00 };
                    location.Y = new byte[] { 0x1B, 0x04 };
                    location.Z = new byte[] { 0x00, 0x8E };
                    break;
                case 8:
                    location.X = new byte[] { 0xB9, 0xDA, 0x00, 0x00 };
                    location.Y = new byte[] { 0x4B, 0x04 };
                    location.Z = new byte[] { 0xAE, 0x90 };
                    break;
            }

            if (armory != 0)
            {
                string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_w22a"));
                byte[] gcxContents = File.ReadAllBytes(gcxFile);
                SetC4Location(gcxContents, armoryC4DeclarationBytes, location, xLocationOffset, yLocationOffset, zLocationOffset);
                File.WriteAllBytes(gcxFile, gcxContents);
            }
        }

        private void RandomizeC4Locations()
        {
            RandomizationForm._logger.Debug("Randomizing C4s...");

            RandomizeStrutARoofC4();
            RandomizePumpRoomC4();
            RandomizeTransformerRoomC4();
            RandomizeMessHallC4();
            RandomizeSedimentPoolC4s();
            RandomizeParcelRoomC4();
            RandomizeHeliportC4();
            RandomizeArmoryC4();
        }

        public void Derandomize()
        {
            RandomizationForm._logger.Debug("Derandomizing files...");
            //So things are going to get EXTREMELY hairy if we try to "derandomize" things manually,
            //or once we have more options if we try to randomize on top of an already randomized gcx
            //To save myself a TON of work, instead we will copy the gcx files that will be modified into
            //a new subfolder, and push/pull from there to make this a simpler process.
            foreach (FileInfo file in OriginalGcxFilesDirectory.GetFiles())
            {
                file.CopyTo(Path.Combine(OriginalGcxFilesDirectory.Parent.FullName, file.Name), true);
            }

            SpoilerContents = "";
        }

        private void SaveOldFiles(DirectoryInfo gcxDirectory)
        {
            OriginalGcxFilesDirectory = gcxDirectory.CreateSubdirectory("originalGcxFiles");

            try
            {
                foreach (FileInfo file in gcxDirectory.GetFiles())
                {
                    file.CopyTo(Path.Combine(OriginalGcxFilesDirectory.FullName, file.Name));
                }
            }
            catch (IOException ioe)
            {
                if (ioe.Message.Contains("already exists"))
                {
                    //This error means we already have a back-up, so we're safe.
                    return;
                }
                MessageBox.Show("Something went wrong when trying to initialize the randomizer, please use Steam to Verify integrity of game files before trying again.");
            }
            catch
            {
                MessageBox.Show("Something went wrong when trying to initialize the randomizer, please use Steam to Verify integrity of game files before trying again.");
            }
        }

        private void InitializeItemAndWeaponAwardOptions()
        {
            RaidenItemAwardOptions = new List<RandomizedItem>();
            RaidenItemAwardOptions.AddRange(MasterRaidenItemAwardOptions);
            RaidenWeaponAwardOptions = new List<RandomizedItem>();
            RaidenWeaponAwardOptions.AddRange(MasterRaidenWeaponAwardOptions);
            SnakeItemAwardOptions = new List<RandomizedItem>();
            SnakeItemAwardOptions.AddRange(MasterSnakeItemAwardOptions);
            SnakeWeaponAwardOptions = new List<RandomizedItem>();
            SnakeWeaponAwardOptions.AddRange(MasterSnakeWeaponAwardOptions);
        }

        private void RemoveAutomaticRewardsFromLogic()
        {
            _vanillaItems.PlantSet3.ItemsNeededToProgress.Remove(MGS2Weapons.Socom);
            _vanillaItems.PlantSet3.ItemsNeededToProgress.Remove(MGS2Weapons.Coolant);
            _vanillaItems.PlantSet4.ItemsNeededToProgress.Remove(MGS2Weapons.Socom);
            _vanillaItems.PlantSet4.ItemsNeededToProgress.Remove(MGS2Weapons.Coolant);
            _vanillaItems.PlantSet4.ItemsNeededToProgress.Remove(MGS2Items.BDU);
            _vanillaItems.PlantSet5.ItemsNeededToProgress.Remove(MGS2Weapons.Socom);
            _vanillaItems.PlantSet5.ItemsNeededToProgress.Remove(MGS2Weapons.Coolant);
            _vanillaItems.PlantSet5.ItemsNeededToProgress.Remove(MGS2Items.BDU);
            _vanillaItems.PlantSet6.ItemsNeededToProgress.Remove(MGS2Weapons.Socom);
            _vanillaItems.PlantSet6.ItemsNeededToProgress.Remove(MGS2Weapons.Coolant);
            _vanillaItems.PlantSet6.ItemsNeededToProgress.Remove(MGS2Items.BDU);
            _vanillaItems.PlantSet7.ItemsNeededToProgress.Remove(MGS2Weapons.Socom);
            _vanillaItems.PlantSet7.ItemsNeededToProgress.Remove(MGS2Weapons.Coolant);
            _vanillaItems.PlantSet7.ItemsNeededToProgress.Remove(MGS2Items.BDU);
            _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(MGS2Weapons.Socom);
            _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(MGS2Weapons.Coolant);
            _vanillaItems.PlantSet8.ItemsNeededToProgress.Remove(MGS2Items.BDU);
            _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(MGS2Weapons.Socom);
            _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(MGS2Weapons.Coolant);
            _vanillaItems.PlantSet9.ItemsNeededToProgress.Remove(MGS2Items.BDU);
        }

        private List<Item> InitializeTankerSpawnPool(RandomizationOptions options)
        {
            List<Item> spawns = new List<Item>();
            foreach (var kvp in _vanillaItems.TankerPart3.Entities)
            {
                if (!options.IncludeRations && kvp.Value == MGS2Items.Ration)
                    continue;
                else
                    spawns.Add(kvp.Value);
            }

            return spawns;
        }

        private void AssignTankerSpawn(int itemsAssigned, Item randomChoice)
        {
            if (itemsAssigned < _vanillaItems.TankerPart1.Entities.Count)
            {
                _randomizedItems.TankerPart1.Entities.Add(_vanillaItems.TankerPart3.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.TankerPart2.Entities.Count)
            {
                _randomizedItems.TankerPart2.Entities.Add(_vanillaItems.TankerPart3.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else
            {
                _randomizedItems.TankerPart3.Entities.Add(_vanillaItems.TankerPart3.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
        }

        private void BackfillTankerEntities()
        {
            foreach (var entity in _randomizedItems.TankerPart1.Entities)
            {
                _randomizedItems.TankerPart2.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.TankerPart2.Entities)
            {
                _randomizedItems.TankerPart3.Entities.Add(entity.Key, entity.Value);
            }
        }

        private Item GetRandomSpawnPoolItem(List<Item> spawnPool)
        {
            int randomNum = Randomizer.Next();
            int modValue = randomNum % spawnPool.Count;
            return spawnPool[modValue];
        }

        private void RandomizeTankerChapter(RandomizationOptions options)
        {
            RandomizationForm._logger.Debug("Randomizing tanker items...");
            List<Item> tankerSpawnsLeft = InitializeTankerSpawnPool(options);

            //assign each spawn on the tanker a random item from the list of available spawns
            int itemsAssigned = 0;
            int retries = 1000;
            while (tankerSpawnsLeft.Count > 0)
            {
                if (!options.IncludeRations &&
                    _vanillaItems.TankerPart3.Entities.ElementAt(itemsAssigned).Value == MGS2Items.Ration)
                {
                    itemsAssigned++; //increase the assigned count, but do not randomize the item.
                    continue;
                }

                Item randomChoice = GetRandomSpawnPoolItem(tankerSpawnsLeft);

                if (options.NoHardLogicLocks &&
                    LogicRequirements.ProgressionItems.Contains(randomChoice.Name) &&
                    !_vanillaItems.TankerPart3.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn)
                {
                    retries--;
                    if (retries == 0)
                        break; //maybe throw and rethrow instead of break?
                    continue;
                }

                if (new[] { "M9" }.Contains(randomChoice.Name) && options.AllWeaponsSpawnable && _vanillaItems.TankerPart3.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn == false)
                {
                    retries--;
                    if (retries == 0)
                        break;
                    continue;
                }

                AssignTankerSpawn(itemsAssigned, randomChoice);

                tankerSpawnsLeft.Remove(randomChoice);
                itemsAssigned++;
            }

            BackfillTankerEntities();
        }

        private List<Item> InitializePlantSpawnPool(RandomizationOptions options, Dictionary<Location, Item> entitySet)
        {
            List<Item> spawnPool = new List<Item>();

            foreach (var kvp in entitySet)
            {
                if (!options.IncludeRations && kvp.Value == MGS2Items.Ration)
                    continue;
                else
                    spawnPool.Add(kvp.Value);
            }

            return spawnPool;
        }

        private void BackfillCardlessRandomizationPlantEntities()
        {
            foreach (var entity in _randomizedItems.PlantSet1.Entities)
            {
                _randomizedItems.PlantSet2.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantSet2.Entities)
            {
                _randomizedItems.PlantSet3.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantSet3.Entities)
            {
                _randomizedItems.PlantSet4.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantSet4.Entities)
            {
                _randomizedItems.PlantSet5.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantSet5.Entities)
            {
                _randomizedItems.PlantSet6.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantSet6.Entities)
            {
                _randomizedItems.PlantSet7.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantSet7.Entities)
            {
                _randomizedItems.PlantSet8.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantSet8.Entities)
            {
                _randomizedItems.PlantSet9.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantSet9.Entities)
            {
                _randomizedItems.PlantSet10.Entities.Add(entity.Key, entity.Value);
            }
        }

        private void BackfillCardRandomizationPlantEntities()
        {
            foreach (var entity in _randomizedItems.PlantCard0Set.Entities)
            {
                _randomizedItems.PlantCard1Set.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantCard1Set.Entities)
            {
                _randomizedItems.PlantCard2Set.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantCard2Set.Entities)
            {
                _randomizedItems.PlantCard3Set.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantCard3Set.Entities)
            {
                _randomizedItems.PlantCard4Set.Entities.Add(entity.Key, entity.Value);
            }
            foreach (var entity in _randomizedItems.PlantCard4Set.Entities)
            {
                _randomizedItems.PlantCard5Set.Entities.Add(entity.Key, entity.Value);
            }

            OverwritePlantSet();
        }

        private void OverwritePlantSet()
        {
            //Need to populate PlantSet10 entities as it is the one used to write the randomization to the gcx files
            foreach (var entity in _randomizedItems.PlantCard5Set.Entities)
            {
                _randomizedItems.PlantSet10.Entities[entity.Key] = entity.Value;
            }
        }

        private void BackfillPlantEntities(bool cardsRandomized)
        {
            if (!cardsRandomized)
            {
                BackfillCardlessRandomizationPlantEntities();
            }
            else
            {
                BackfillCardRandomizationPlantEntities();
            }
        }

        private void AssignCardlessRandomizationPlantSpawn(int itemsAssigned, Item randomChoice)
        {
            if (itemsAssigned < _vanillaItems.PlantSet1.Entities.Count)
            {
                _randomizedItems.PlantSet1.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.PlantSet2.Entities.Count)
            {
                _randomizedItems.PlantSet2.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.PlantSet3.Entities.Count)
            {
                _randomizedItems.PlantSet3.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.PlantSet4.Entities.Count)
            {
                _randomizedItems.PlantSet4.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.PlantSet5.Entities.Count)
            {
                _randomizedItems.PlantSet5.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.PlantSet6.Entities.Count)
            {
                _randomizedItems.PlantSet6.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.PlantSet7.Entities.Count)
            {
                _randomizedItems.PlantSet7.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.PlantSet8.Entities.Count)
            {
                _randomizedItems.PlantSet8.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else if (itemsAssigned < _vanillaItems.PlantSet9.Entities.Count)
            {
                _randomizedItems.PlantSet9.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
            else
            {
                _randomizedItems.PlantSet10.Entities.Add(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key, randomChoice);
            }
        }

        private void AssignCardedRandomizationPlantSpawn(int itemsAssigned, Item randomChoice, bool keepVanillaCardAccess)
        {
            if (!keepVanillaCardAccess)
            {
                switch (_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.CardNeededToAccess)
                {
                    case 0:
                        _randomizedItems.PlantCard0Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                        break;
                    case 1:
                        _randomizedItems.PlantCard1Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                        break;
                    case 2:
                        _randomizedItems.PlantCard2Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                        break;
                    case 3:
                        _randomizedItems.PlantCard3Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                        break;
                    case 4:
                        _randomizedItems.PlantCard4Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                        break;
                    case 5:
                        _randomizedItems.PlantCard5Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                        break;
                }
            }
            else
            {
                if (itemsAssigned < _vanillaItems.PlantCard0Set.Entities.Count)
                {
                    _randomizedItems.PlantCard0Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                }
                else if (itemsAssigned < _vanillaItems.PlantCard1Set.Entities.Count)
                {
                    _randomizedItems.PlantCard1Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                }
                else if (itemsAssigned < _vanillaItems.PlantCard2Set.Entities.Count)
                {
                    _randomizedItems.PlantCard2Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                }
                else if (itemsAssigned < _vanillaItems.PlantCard3Set.Entities.Count)
                {
                    _randomizedItems.PlantCard3Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                }
                else if (itemsAssigned < _vanillaItems.PlantCard4Set.Entities.Count)
                {
                    _randomizedItems.PlantCard4Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                }
                else
                {
                    _randomizedItems.PlantCard5Set.Entities.Add(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key, randomChoice);
                }
            }
        }

        private void RandomizePlantChapter(RandomizationOptions options)
        {
            RandomizationForm._logger.Debug("Randomizing plant items...");
            List<Item> plantSpawnPool = new List<Item>();

            int itemsAssigned = 0;
            int retries = 100;

            if (!options.RandomizeCards)
            {
                plantSpawnPool = InitializePlantSpawnPool(options, _vanillaItems.PlantSet10.Entities);

                while (plantSpawnPool.Count > 0)
                {
                    if (!options.IncludeRations &&
                    _vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Value == MGS2Items.Ration)
                    {
                        itemsAssigned++; //increase the assigned count, but do not randomize the item.
                        continue;
                    }

                    Item randomChoice = GetRandomSpawnPoolItem(plantSpawnPool);

                    //isolate rations to only non-mandatory spawns
                    if (randomChoice.Name == "Ration" &&
                        _vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn)
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if (options.NoHardLogicLocks &&
                        LogicRequirements.ProgressionItems.Contains(randomChoice.Name) &&
                        !_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn)
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if (options.RandomizeAutomaticRewards
                        && LogicRequirements.AutoAwardedProgressionItems.Contains(randomChoice.Name) &&
                        !_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn)
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if (randomChoice.Name == "Nikita")
                    {
                        if (options.NikitaShell2)
                        {
                            //currently, only the Nikita can cause a soft logic lock if the spawn is not in Shell 2
                            if (!(new[] { "w31a", "w31b" }.Contains(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key.GcxFile))
                                || ElectricalRoomSpawns.Contains(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key.Name))
                            {
                                retries--;
                                if (retries == 0)
                                    break;
                                continue;
                            }
                        }
                        else
                        {
                            if (ElectricalRoomSpawns.Contains(_vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key.Name)
                                || Location.FifthProgressionAreas.Contains(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.Name))
                            {
                                retries--;
                                if (retries == 0)
                                    break;
                                continue;
                            }
                        }
                    }

                    if (new[] { "M9", "RGB-6", "M4", "PSG1-T" }.Contains(randomChoice.Name) && options.AllWeaponsSpawnable && _vanillaItems.PlantSet10.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn == false)
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    AssignCardlessRandomizationPlantSpawn(itemsAssigned, randomChoice);

                    plantSpawnPool.Remove(randomChoice);
                    itemsAssigned++;
                }

                if (retries == 0)
                {
                    throw new RandomizerException("bad randomization seed");
                }

                BackfillPlantEntities(options.RandomizeCards);

                //if the itemset isn't logically sound, re-randomize.
                if (!VerifyItemSetLogicValidity(_randomizedItems))
                {
                    throw new RandomizerException("bad randomization seed");
                }
            }
            else
            {
                AddCardsToPools();

                plantSpawnPool = InitializePlantSpawnPool(options, _vanillaItems.PlantCard5Set.Entities);

                while (plantSpawnPool.Count > 0)
                {
                    if (!options.IncludeRations &&
                    _vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Value == MGS2Items.Ration)
                    {
                        itemsAssigned++; //increase the assigned count, but do not randomize the item.
                        continue;
                    }

                    Item randomChoice = GetRandomSpawnPoolItem(plantSpawnPool);

                    //isolate rations to only non-mandatory spawns
                    if (randomChoice.Name == "Ration" &&
                        _vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn)
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if (options.NoHardLogicLocks &&
                        LogicRequirements.ProgressionItems.Contains(randomChoice.Name) &&
                        !_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn)
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if (options.RandomizeAutomaticRewards
                        && LogicRequirements.AutoAwardedProgressionItems.Contains(randomChoice.Name) &&
                        !_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn)
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if (options.NoHardLogicLocks &&
                        _vanillaItems.CardRandomizationFirstProgressionItems.Any(progressionItem => progressionItem.Name == randomChoice.Name) &&
                        Location.FirstProgressionAreas.Contains(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.GcxFile) &&
                        !_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn
                        )
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if (options.NoHardLogicLocks &&
                        _vanillaItems.CardRandomizationSecondProgressionItems.Any(progressionItem => progressionItem.Name == randomChoice.Name) &&
                        Location.SecondProgressionAreas.Contains(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.GcxFile) &&
                        !_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn
                        )
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if (options.NoHardLogicLocks &&
                        _vanillaItems.CardRandomizationThirdProgressionItems.Any(progressionItem => progressionItem.Name == randomChoice.Name) &&
                        Location.ThirdProgressionAreas.Contains(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.GcxFile) &&
                        !_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn
                        )
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    if ((randomChoice.Name == "Nikita" || randomChoice.Name == "Card 4") && options.NikitaShell2)
                    {
                        //currently, the Nikita and Card 4 can cause a soft logic lock if the spawn is not in Shell 2
                        if (!Location.FourthProgressionAreas.Contains(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.GcxFile)
                            || ElectricalRoomSpawns.Contains(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.Name))
                        {
                            retries--;
                            if (retries == 0)
                                break;
                            continue;
                        }
                    }
                    else if (randomChoice.Name == "Nikita")
                    {
                        if (ElectricalRoomSpawns.Contains(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.Name)
                            || Location.FifthProgressionAreas.Contains(_vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.Name))
                        {
                            retries--;
                            if (retries == 0)
                                break;
                            continue;
                        }
                    }

                    if (new[] { "M9", "RGB-6", "M4", "PSG1-T" }.Contains(randomChoice.Name)
                        && options.AllWeaponsSpawnable
                        && _vanillaItems.PlantCard5Set.Entities.ElementAt(itemsAssigned).Key.MandatorySpawn == false)
                    {
                        retries--;
                        if (retries == 0)
                            break;
                        continue;
                    }

                    AssignCardedRandomizationPlantSpawn(itemsAssigned, randomChoice, options.KeepVanillaCardAccess);

                    plantSpawnPool.Remove(randomChoice);
                    itemsAssigned++;
                }

                if (retries == 0)
                {
                    throw new RandomizerException("bad randomization seed");
                }

                BackfillPlantEntities(options.RandomizeCards);

                if (!VerifyCardSetLogicValidity(_randomizedItems, options.KeepVanillaCardAccess, options.NikitaShell2))
                {
                    throw new RandomizerException("bad randomization seed");
                }
            }
        }

        public void RandomizeSpawns(RandomizationOptions options)
        {
            if (options.RandomizeStartingItems)
            {
                RandomizeStartingItems();
            }
            if (options.RandomizeAutomaticRewards)
            {
                SpoilerContents += RandomizeAutomaticRewards(options.RandomizeCards);
            }
            else
            {
                //need to remove the automatic rewards from the logic checker if we aren't randomizing automatic rewards
                RemoveAutomaticRewardsFromLogic();
            }

            try
            {
                RandomizeTankerChapter(options);
            }
            catch (Exception ex)
            {
                //TODO: need to confirm if this is safe. silently swallowing an exception is usually bad...
            }

            try
            {
                RandomizePlantChapter(options);
            }
            catch (Exception ex)
            {
                if (ex is RandomizerException)
                    throw ex;
                else
                {
                    throw new RandomizerException("bad randomization seed");
                }
            }
        }

        public int RandomizeMGS2(RandomizationOptions options)
        {
            BuildVanillaItemSet();
            Derandomize(); //return to a "base" state to make our lives easier.
            InitializeItemAndWeaponAwardOptions();
            _randomizedItems = new MGS2ItemSet();
            SpoilerContents = options.ToString();

            if (options.RandomizeSpawns)
            {
                RandomizeSpawns(options);
            }

            if (options.RandomizeClaymores)
            {
                RandomizeClaymores();
            }

            if (options.RandomizeC4)
            {
                RandomizeC4Locations();
            }

            if (options.RandomizeTankerControlUnits)
            {
                RandomizeTankerSemtexControlUnitLocations();
            }

            if (options.RandomizeGuardValues)
            {
                RandomizeGuardValues(options.KeepGuardValuesConsistentAcrossLevels, false, options.GuardRandomizationBounds); //TODO: implement support for value consistency
            }

            if (options.RandomizeReinforcementGuardTypes)
            {
                RandomizeReinforcementGuardTypes();
            }

            if (options.RandomizeGuardPatrols)
            {
                RandomizeGuardPatrols(options.GuardPatrolRandomizationBehavior);
            }

            return Seed;
        }

        private bool CheckTankerLogic(MGS2ItemSet setToCheck)
        {
            foreach (Item item in _vanillaItems.TankerPart1.ItemsNeededToProgress)
            {
                if (!setToCheck.TankerPart1.Entities.ContainsValue(item))
                    return false;
            }
            foreach (Item item in _vanillaItems.TankerPart2.ItemsNeededToProgress)
            {
                if (!setToCheck.TankerPart2.Entities.ContainsValue(item))
                    return false;
            }
            foreach (Item item in _vanillaItems.TankerPart3.ItemsNeededToProgress)
            {
                if (!setToCheck.TankerPart3.Entities.ContainsValue(item))
                    return false;
            }

            return true;
        }

        private void SwapSpawnContents(ItemSet itemSet, KeyValuePair<Location, Item> item1, KeyValuePair<Location, Item> item2)
        {
            itemSet.Entities[item1.Key] = item2.Value;
            itemSet.Entities[item2.Key] = item1.Value;
        }

        private void FixCardlessSpawn(ItemSet itemSet, List<KeyValuePair<Location,Item>> partSpawns, Item itemToFix, Item itemToSwapWith)
        {
            KeyValuePair<Location, Item> progressiveSpawn = itemSet.Entities.FirstOrDefault(spawn => spawn.Value.Name == itemToFix.Name);
            List<KeyValuePair<Location, Item>> partSpawnsForItemToSwapWith = partSpawns.Where(spawn => (spawn.Value.Name == itemToSwapWith.Name)
            && spawn.Key.MandatorySpawn
            && (spawn.Key.CardNeededToAccess <= VanillaItems.ItemAccessLevels[itemToFix])).ToList();
            KeyValuePair<Location, Item> spawnToSwap = partSpawns[Randomizer.Next(0, partSpawnsForItemToSwapWith.Count)]; //could this be just count? i think so?

            SwapSpawnContents(itemSet, spawnToSwap, progressiveSpawn);
        }

        private bool VerifyItemSetLogicValidity(MGS2ItemSet setToCheck)
        {
            if (!CheckTankerLogic(setToCheck))
                return false;

            #region Plant Checks
            if (_vanillaItems.PlantSet3.ItemsNeededToProgress.Count > 0)
            {
                List<KeyValuePair<Location, Item>> secondProgressionSpawns = setToCheck.PlantSet10.Entities.Where(spawns => setToCheck.PlantSet3.Entities.Contains(spawns)).ToList();
                foreach (Item item in _vanillaItems.PlantSet3.ItemsNeededToProgress)
                {
                    if (!secondProgressionSpawns.Any(spawn => spawn.Value.Name == item.Name))
                    {
                        if (item.Name == MGS2Weapons.Coolant.Name)
                        {
                            FixCardlessSpawn(setToCheck.PlantSet10, secondProgressionSpawns, MGS2Weapons.Coolant, MGS2Weapons.M9Ammo);
                        }
                        if (item.Name == MGS2Weapons.Socom.Name)
                        {
                            FixCardlessSpawn(setToCheck.PlantSet10, secondProgressionSpawns, MGS2Weapons.Socom, MGS2Weapons.SocomAmmo);
                        }
                        if (item.Name == MGS2Items.SensorB.Name)
                        {
                            FixCardlessSpawn(setToCheck.PlantSet10, secondProgressionSpawns, MGS2Items.SensorB, MGS2Weapons.M4Ammo);
                        }
                    }
                }
            }
            if (_vanillaItems.PlantSet4.ItemsNeededToProgress.Count > 0)
            {
                List<KeyValuePair<Location, Item>> thirdProgressionSpawns = setToCheck.PlantSet10.Entities.Where(spawns => setToCheck.PlantSet4.Entities.Contains(spawns)).ToList();
                foreach (Item item in _vanillaItems.PlantSet4.ItemsNeededToProgress)
                {
                    if (!thirdProgressionSpawns.Any(spawn => spawn.Value.Name == item.Name))
                    {
                        if (item.Name == MGS2Items.BDU.Name)
                        {
                            FixCardlessSpawn(setToCheck.PlantSet10, thirdProgressionSpawns, MGS2Items.BDU, MGS2Weapons.Rgb6Ammo);
                        }
                        if (item.Name == MGS2Weapons.Aks74u.Name)
                        {
                            FixCardlessSpawn(setToCheck.PlantSet10, thirdProgressionSpawns, MGS2Weapons.Aks74u, MGS2Weapons.Aks74uAmmo);
                        }
                    }
                }
            }
            if (_vanillaItems.PlantSet5.ItemsNeededToProgress.Count > 0)
            {
                List<KeyValuePair<Location, Item>> fourthProgressionSpawns = setToCheck.PlantSet10.Entities.Where(spawns => setToCheck.PlantSet5.Entities.Contains(spawns)).ToList();
                foreach (Item item in _vanillaItems.PlantSet5.ItemsNeededToProgress)
                {
                    if (!fourthProgressionSpawns.Any(spawn => spawn.Value.Name == item.Name))
                    {
                        if (item.Name == MGS2Weapons.Dmic1.Name)
                        {
                            FixCardlessSpawn(setToCheck.PlantSet10, fourthProgressionSpawns, MGS2Weapons.Dmic1, MGS2Weapons.Chaff);
                        }
                    }
                }
            }
            if (_vanillaItems.PlantSet6.ItemsNeededToProgress.Count > 0)
            {
                List<KeyValuePair<Location, Item>> fifthProgressionSpawns = setToCheck.PlantSet10.Entities.Where(spawns => setToCheck.PlantSet6.Entities.Contains(spawns)).ToList();
                foreach (Item item in _vanillaItems.PlantSet6.ItemsNeededToProgress)
                {
                    if (!fifthProgressionSpawns.Any(spawn => spawn.Value.Name == item.Name))
                    {
                        if (item.Name == MGS2Weapons.Psg1.Name)
                        {
                            FixCardlessSpawn(setToCheck.PlantSet10, fifthProgressionSpawns, MGS2Weapons.Psg1, MGS2Weapons.Psg1Ammo);
                        }
                    }
                }
            }
            #endregion
            return true;
        }

        private void FixCardedSpawn(ItemSet itemSet, List<KeyValuePair<Location, Item>> partSpawns, Item itemToFix, Item itemToSwapWith, bool keepCardAccessLevels)
        {
            KeyValuePair<Location, Item> socomSpawn = itemSet.Entities.FirstOrDefault(spawn => spawn.Value.Name == itemToFix.Name);
            List<KeyValuePair<Location, Item>> part1SocomAmmoSpawns = partSpawns.Where(spawn => spawn.Value.Name == itemToSwapWith.Name
            && spawn.Key.MandatorySpawn
            && (keepCardAccessLevels ? spawn.Key.CardNeededToAccess == VanillaItems.ItemAccessLevels[itemToFix] : true)).ToList();
            KeyValuePair<Location, Item> ammoSpawnToSwap = part1SocomAmmoSpawns[Randomizer.Next(0, part1SocomAmmoSpawns.Count)]; 

            SwapSpawnContents(itemSet, ammoSpawnToSwap, socomSpawn);
        }

        private void FixCardSpawn(MGS2ItemSet masterItemSet, ItemSet itemSet, List<KeyValuePair<Location, Item>> cardSpawns, Item cardToFix, int accessLevel)
        {
            KeyValuePair<Location, Item> cardSpawn = cardSpawns.Where(spawn => spawn.Value.Name == cardToFix.Name).FirstOrDefault();
            List<KeyValuePair<Location, Item>> mandatorySpawnsInAccessLevel = itemSet.Entities.Where(spawn => spawn.Key.MandatorySpawn
                && spawn.Key.CardNeededToAccess == accessLevel).ToList();
            KeyValuePair<Location, Item> spawnToSwap = mandatorySpawnsInAccessLevel[Randomizer.Next(0, mandatorySpawnsInAccessLevel.Count)];

            SwapSpawnContents(masterItemSet.PlantCard5Set, spawnToSwap, cardSpawn);
        }

        private bool VerifyCardSetLogicValidity(MGS2ItemSet setToCheck, bool keepCardAccessLevels = false, bool nikitaShell2 = true)
        {
            if (!CheckTankerLogic(setToCheck))
                return false;

            #region Plant Checks
            List<KeyValuePair<Location, Item>> cardSpawns = setToCheck.PlantCard5Set.Entities.Where(spawns => spawns.Value.Name.Contains("Card")).ToList();

            if (!setToCheck.PlantCard0Set.Entities.ContainsValue(MGS2Items.Card1) ||
                !setToCheck.PlantCard0Set.Entities.FirstOrDefault(spawn => spawn.Value.Name == MGS2Items.Card1.Name).Key.MandatorySpawn)
            {
                FixCardSpawn(setToCheck, setToCheck.PlantCard0Set, cardSpawns, MGS2Items.Card1, 0);
            }
            if (!setToCheck.PlantCard1Set.Entities.ContainsValue(MGS2Items.Card2) ||
                setToCheck.PlantCard1Set.Entities.Where(spawn => spawn.Value.Name == MGS2Items.Card2.Name).FirstOrDefault().Key.CardNeededToAccess != 1 ||
                !setToCheck.PlantCard1Set.Entities.FirstOrDefault(spawn => spawn.Value.Name == MGS2Items.Card2.Name).Key.MandatorySpawn)
            {
                FixCardSpawn(setToCheck, setToCheck.PlantCard1Set, cardSpawns, MGS2Items.Card2, 1);
            }
            if (!setToCheck.PlantCard2Set.Entities.ContainsValue(MGS2Items.Card3) ||
                setToCheck.PlantCard2Set.Entities.Where(spawn => spawn.Value.Name == MGS2Items.Card3.Name).FirstOrDefault().Key.CardNeededToAccess != 2 ||
                !setToCheck.PlantCard2Set.Entities.FirstOrDefault(spawn => spawn.Value.Name == MGS2Items.Card3.Name).Key.MandatorySpawn)
            {
                FixCardSpawn(setToCheck, setToCheck.PlantCard2Set, cardSpawns, MGS2Items.Card3, 2);
            }
            if (!setToCheck.PlantCard3Set.Entities.ContainsValue(MGS2Items.Card4) ||
                (setToCheck.PlantCard3Set.Entities.Where(spawn => spawn.Value.Name == MGS2Items.Card4.Name).FirstOrDefault().Key.CardNeededToAccess != 3 
                    && ((nikitaShell2 && Location.FourthProgressionAreas.Contains(setToCheck.PlantCard3Set.Entities.FirstOrDefault(spawn=>spawn.Value.Name == MGS2Items.Card4.Name).Key.GcxFile)) 
                    || !nikitaShell2)) ||
                !setToCheck.PlantCard3Set.Entities.FirstOrDefault(spawn => spawn.Value.Name == MGS2Items.Card4.Name).Key.MandatorySpawn)
            {
                KeyValuePair<Location, Item> cardSpawn4 = cardSpawns.Where(spawn => spawn.Value.Name == MGS2Items.Card4.Name).FirstOrDefault();
                List<KeyValuePair<Location, Item>> lvl3MandatorySpawns = setToCheck.PlantCard3Set.Entities.Where(spawn => spawn.Key.MandatorySpawn
                    && spawn.Key.CardNeededToAccess == 3
                    && ((nikitaShell2 && Location.FourthProgressionAreas.Contains(spawn.Key.GcxFile)) || !nikitaShell2)).ToList();
                KeyValuePair<Location, Item> lvl3SpawnToSwap = lvl3MandatorySpawns[Randomizer.Next(0, lvl3MandatorySpawns.Count - 1)];

                SwapSpawnContents(setToCheck.PlantCard5Set, lvl3SpawnToSwap, cardSpawn4);
            }
            if (!setToCheck.PlantCard4Set.Entities.ContainsValue(MGS2Items.Card5) ||
                setToCheck.PlantCard4Set.Entities.Where(spawn => spawn.Value.Name == MGS2Items.Card5.Name).FirstOrDefault().Key.CardNeededToAccess != 4 ||
                !setToCheck.PlantCard4Set.Entities.FirstOrDefault(spawn => spawn.Value.Name == MGS2Items.Card5.Name).Key.MandatorySpawn)
            {
                FixCardSpawn(setToCheck, setToCheck.PlantCard4Set, cardSpawns, MGS2Items.Card5, 4);
            }


            if (keepCardAccessLevels)
            {
                //this does a first pass attempt at moving one-time pickup items/weapons into the right level of access for spawns
                foreach (KeyValuePair<Item, int> uniqueItemSpawn in VanillaItems.ItemAccessLevels)
                {
                    KeyValuePair<Location, Item> randomizedUniqueSpawnToSwap = setToCheck.PlantCard5Set.Entities.FirstOrDefault(spawn => spawn.Value == uniqueItemSpawn.Key);
                    if (randomizedUniqueSpawnToSwap.Key != null && randomizedUniqueSpawnToSwap.Key.CardNeededToAccess != uniqueItemSpawn.Value)
                    {
                        List<KeyValuePair<Location, Item>> acceptableLevelSpawns = setToCheck.PlantCard5Set.Entities.Where(spawn => spawn.Key.CardNeededToAccess == uniqueItemSpawn.Value
                        && spawn.Key.MandatorySpawn
                        && !VanillaItems.ItemAccessLevels.ContainsKey(spawn.Value)
                        && !spawn.Value.Name.Contains("Card")
                        && (randomizedUniqueSpawnToSwap.Value == MGS2Weapons.Nikita ? !ElectricalRoomSpawns.Contains(spawn.Key.Name) : true)).ToList();
                        KeyValuePair<Location, Item> spawnToSwap = acceptableLevelSpawns[Randomizer.Next(0, acceptableLevelSpawns.Count - 1)];

                        SwapSpawnContents(setToCheck.PlantCard5Set, randomizedUniqueSpawnToSwap, spawnToSwap);
                    }
                }
            }
            
            List<KeyValuePair<Location, Item>> firstProgressionSpawns = setToCheck.PlantCard5Set.Entities.Where(spawns => Location.FirstProgressionAreas.Contains(spawns.Key.GcxFile)
            && new string[] { "BottomRightConveyer", "UnderTopsideConveyerBelt", "Level5DoorRoom", "PerimeterAccessRoom" }.Contains(spawns.Key.Name) == false
            && spawns.Key.CardNeededToAccess <= 1).ToList();
            foreach (Item item in _vanillaItems.CardRandomizationFirstProgressionItems)
            {
                if (!firstProgressionSpawns.Any(spawn => spawn.Value.Name == item.Name))
                {
                    if (item.Name == MGS2Weapons.Socom.Name)
                    {
                        FixCardedSpawn(setToCheck.PlantCard5Set, firstProgressionSpawns, MGS2Weapons.Socom, MGS2Weapons.SocomAmmo, keepCardAccessLevels);
                    }
                    if (item.Name == MGS2Weapons.Coolant.Name)
                    {
                        FixCardedSpawn(setToCheck.PlantCard5Set, firstProgressionSpawns, MGS2Weapons.Coolant, MGS2Weapons.M9Ammo, keepCardAccessLevels);
                    }
                    if (item.Name == MGS2Items.SensorB.Name)
                    {
                        FixCardedSpawn(setToCheck.PlantCard5Set, firstProgressionSpawns, MGS2Items.SensorB, MGS2Weapons.M4Ammo, keepCardAccessLevels);
                    }
                }
            }

            List<KeyValuePair<Location, Item>> secondProgressionSpawns = setToCheck.PlantCard5Set.Entities.Where(spawns => Location.SecondProgressionAreas.Contains(spawns.Key.GcxFile)
            && new string[] { "FrontDoor1", "FrontDoor2", "BottomRightConveyer", "UnderTopsideConveyerBelt", "Level5DoorRoom", "PerimeterAccessRoom" }.Contains(spawns.Key.Name) == false
            && spawns.Key.CardNeededToAccess <= 2).ToList();
            foreach (Item item in _vanillaItems.CardRandomizationSecondProgressionItems)
            {
                if (!secondProgressionSpawns.Any(spawn => spawn.Value.Name == item.Name))
                {
                    if (item.Name == MGS2Items.BDU.Name)
                    {
                        FixCardedSpawn(setToCheck.PlantCard5Set, secondProgressionSpawns, MGS2Items.BDU, MGS2Weapons.Rgb6Ammo, keepCardAccessLevels);
                    }
                    if (item.Name == MGS2Weapons.Aks74u.Name)
                    {
                        FixCardedSpawn(setToCheck.PlantCard5Set, secondProgressionSpawns, MGS2Weapons.Aks74u, MGS2Weapons.Aks74uAmmo, keepCardAccessLevels);
                    }
                }
            }

            List<KeyValuePair<Location, Item>> thirdProgressionSpawns = setToCheck.PlantCard5Set.Entities.Where(spawns => Location.ThirdProgressionAreas.Contains(spawns.Key.GcxFile)
            && new string[] { "FrontDoor1", "FrontDoor2" }.Contains(spawns.Key.Name) == false
            && spawns.Key.CardNeededToAccess <= 3).ToList();
            foreach (Item item in _vanillaItems.CardRandomizationThirdProgressionItems)
            {
                if (!thirdProgressionSpawns.Any(spawn => spawn.Value.Name == item.Name))
                {
                    if (item.Name == MGS2Weapons.Dmic1.Name)
                    {
                        FixCardedSpawn(setToCheck.PlantCard5Set, thirdProgressionSpawns, MGS2Weapons.Dmic1, MGS2Weapons.Chaff, keepCardAccessLevels);
                    }
                    if (item.Name == MGS2Weapons.Psg1.Name)
                    {
                        FixCardedSpawn(setToCheck.PlantCard5Set, thirdProgressionSpawns, MGS2Weapons.Psg1, MGS2Weapons.Psg1Ammo, keepCardAccessLevels);
                    }
                }
            }

            OverwritePlantSet();
            #endregion

            return true;
        }

        public static bool ContainsSpawningFunctions(DecodedProc func)
        {
            List<string> spawningFunctions = new List<string>();
            foreach (RawProc spawningFunc in KnownProc.SpawnProcs)
            {
                spawningFunctions.Add(spawningFunc.BigEndianRepresentation);
            }
            return spawningFunctions.Any(function => func.DecodedContents.Contains(function));
        }

        private OpenedFileData OpenFileForRandomization(Dictionary<string, OpenedFileData> openedFiles, string gcxFile, string stageToEdit, KeyValuePair<Location, Item> spawnToEdit)
        {
            GcxEditor gcx_Editor = new GcxEditor();
            try
            {
                gcx_Editor.CallDecompiler(gcxFile);
            }
            catch (Exception e)
            {
                throw new RandomizerException($"gcx decompilation failed for stage {stageToEdit}: {e}");
            }
            try
            {
                List<DecodedProc> allFileFunctions = gcx_Editor.BuildContentTree();
                List<DecodedProc> spawns = new List<DecodedProc>();
                foreach (DecodedProc entry in allFileFunctions)
                {
                    if (ContainsSpawningFunctions(entry))
                        spawns.Add(entry);
                }
                AddAllProcs(gcx_Editor);
                ProcEditor procEditor = new ProcEditor(spawns, true);
                openedFiles.Add(stageToEdit, new OpenedFileData { GcxEditor = gcx_Editor, DecodedProcs = spawns, ProcEditor = procEditor });

                return new OpenedFileData() { DecodedProcs = spawns, ProcEditor = procEditor, GcxEditor = gcx_Editor };
            }
            catch (Exception e)
            {
                throw new RandomizerException($"decompiled gcx for stage {stageToEdit} threw an unexpected error: {e}");
            }
        }

        private string ModifySpawnInMemory(string gcxFile, KeyValuePair<Location, Item> spawnToEdit, ProcEditor procEditor, string cheatSheet)
        {
            cheatSheet += $"{gcxFile}({MGS2Levels.MainGameStages.PlayableStageList.FirstOrDefault(x => x.AreaCode == spawnToEdit.Key.GcxFile).Name}): {spawnToEdit.Key.Name} now has a {spawnToEdit.Value.Name}\n";
            /*if (_vanillaItems.TankerPart3.Entities[spawnToEdit.Key].Name != spawnToEdit.Value.Name)
            {

            }*/
            procEditor.ModifySpawnProc(spawnToEdit.Key.SpawnId, spawnToEdit.Value.ProcId);
            procEditor.SaveAutomatedChangesToMemory();

            return cheatSheet;
        }

        private void FixPlantReferencesForTanker(byte[] newGcxBytes)
        {
            //this is here to allow any custom weapon spawns made for Raiden to work for Snake on Tanker levels.
            List<int> plantWeaponReferences = GcxEditor.FindAllSubArray(newGcxBytes, new byte[] { 0x39, 0x21, 0x80, 0x02, 0xAC });
            foreach (int index in plantWeaponReferences)
            {
                Array.Copy(new byte[] { 0x39, 0x21, 0x80, 0x01, 0x5C }, 0, newGcxBytes, index, 5);
            }
            //this is here to allow any custom item spawns made for Raiden to work for Snake on Tanker levels.
            List<int> plantItemReferences = GcxEditor.FindAllSubArray(newGcxBytes, new byte[] { 0x39, 0x21, 0x80, 0x03, 0x3C });
            foreach (int index in plantItemReferences)
            {
                Array.Copy(new byte[] { 0x39, 0x21, 0x80, 0x01, 0xEC }, 0, newGcxBytes, index, 5);
            }
        }

        private void FixTankerReferencesForPlant(byte[] newGcxBytes)
        {
            //this is here to allow any custom weapon spawns made for Snake to work for Raiden on Plant levels.
            List<int> tankerWeaponReferences = GcxEditor.FindAllSubArray(newGcxBytes, new byte[] { 0x39, 0x21, 0x80, 0x01, 0x5C });
            foreach (int index in tankerWeaponReferences)
            {
                Array.Copy(new byte[] { 0x39, 0x21, 0x80, 0x02, 0xAC }, 0, newGcxBytes, index, 5);
            }
            //this is here to allow any custom item spawns made for Snake to work for Raiden on Plant levels.
            List<int> tankerItemReferences = GcxEditor.FindAllSubArray(newGcxBytes, new byte[] { 0x39, 0x21, 0x80, 0x01, 0xEC });
            foreach (int index in tankerItemReferences)
            {
                Array.Copy(new byte[] { 0x39, 0x21, 0x80, 0x03, 0x3C }, 0, newGcxBytes, index, 5);
            }
        }

        private void FixBuggedSpawns(GcxEditor gcxEditor)
        {
            Dictionary<RawProc, string> procsToFix = new Dictionary<RawProc, string> {
                { KnownProc.AwardBox1, "proc_0x97D665.proc" },
                { KnownProc.AwardBox2, "proc_0x3E97CF.proc" },
                { KnownProc.AwardBox3, "proc_0x5E97CF.proc" },
                { KnownProc.AwardBox4, "proc_0x7E97CF.proc" },
                { KnownProc.AwardBox5, "proc_0x9E97CF.proc" },
                { KnownProc.AwardWetBox, "proc_0xCAF11B.proc" } };
            

            foreach(KeyValuePair<RawProc,string> proc in procsToFix)
            {
                byte[] modifiedContents = File.ReadAllBytes(Path.Combine("MGS2 Known Procs", proc.Value));
                gcxEditor.ModifyProc(proc.Key, modifiedContents);
            }
        }

        private string ProcessSpawnToEdit(KeyValuePair<Location, Item> spawnToEdit, Dictionary<string, OpenedFileData> openedFiles, string cheatSheet)
        {
            string gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_{spawnToEdit.Key.GcxFile}"));
            List<DecodedProc> spawns = null;
            ProcEditor procEditor = null;

            if (!openedFiles.ContainsKey(spawnToEdit.Key.GcxFile))
            {
                OpenedFileData openedFileData = OpenFileForRandomization(openedFiles, gcxFile, spawnToEdit.Key.GcxFile, spawnToEdit);
                spawns = openedFileData.DecodedProcs;
                procEditor = openedFileData.ProcEditor;
                FixBuggedSpawns(openedFileData.GcxEditor);
            }
            else
            {
                OpenedFileData openedFileData = openedFiles[spawnToEdit.Key.GcxFile];
                spawns = openedFileData.DecodedProcs;
                procEditor = openedFileData.ProcEditor;
            }

            cheatSheet = ModifySpawnInMemory(spawnToEdit.Key.GcxFile, spawnToEdit, procEditor, cheatSheet);

            if (spawnToEdit.Key.SisterSpawn != null)
            {
                gcxFile = GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_{spawnToEdit.Key.SisterSpawn}"));
                if (!openedFiles.ContainsKey(spawnToEdit.Key.SisterSpawn))
                {
                    OpenedFileData openedFileData = OpenFileForRandomization(openedFiles, gcxFile, spawnToEdit.Key.SisterSpawn, spawnToEdit);
                    spawns = openedFileData.DecodedProcs;
                    procEditor = openedFileData.ProcEditor;
                    FixBuggedSpawns(openedFileData.GcxEditor);
                }
                else
                {
                    OpenedFileData openedFileData = openedFiles[spawnToEdit.Key.SisterSpawn];
                    spawns = openedFileData.DecodedProcs;
                    procEditor = openedFileData.ProcEditor;
                }

                cheatSheet = ModifySpawnInMemory(spawnToEdit.Key.SisterSpawn, spawnToEdit, procEditor, cheatSheet);
            }

            return cheatSheet;
        }

        private void SaveFileToDisk(KeyValuePair<string, OpenedFileData> kvp, bool customDirectory, DirectoryInfo createdDirectory)
        {
            OpenedFileData openedFileData = kvp.Value;
            byte[] newGcxBytes = openedFileData.GcxEditor.BuildGcxFile();
            if (kvp.Key.Contains("w0"))
            {
                FixPlantReferencesForTanker(newGcxBytes);
            }
            string date = $"{createdDirectory.Name}/scenerio_stage_{kvp.Key}.gcx";
            if (customDirectory)
                File.WriteAllBytes(date, newGcxBytes);
            else
                File.WriteAllBytes(GcxFileDirectory.Find(file => file.Contains($"scenerio_stage_{kvp.Key}")), newGcxBytes);
        }

        public bool SaveRandomizationToDisk(bool makeSpoilerFile = true, bool customDirectory = true)
        {
            AddAllResources();

            //since some levels are part of multiple different logic sets,
            //we iterate spawn by spawn and modify in memory before saving to disk level by level
            Dictionary<string, OpenedFileData> openedFiles = new Dictionary<string, OpenedFileData>();
            string cheatSheet = SpoilerContents;
            RandomizationForm._logger.Debug("Saving tanker randomization to memory...");
            foreach (KeyValuePair<Location, Item> spawnToEdit in _randomizedItems.TankerPart3.Entities)
            {
                cheatSheet = ProcessSpawnToEdit(spawnToEdit, openedFiles, cheatSheet);
            }

            RandomizationForm._logger.Debug("Saving plant randomization to memory...");
            foreach (KeyValuePair<Location, Item> spawnToEdit in _randomizedItems.PlantSet10.Entities)
            {
                cheatSheet = ProcessSpawnToEdit(spawnToEdit, openedFiles, cheatSheet);
            }

            DirectoryInfo createdDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            if (customDirectory)
                createdDirectory = Directory.CreateDirectory($"{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}_randomizedGcxFiles");

            RandomizationForm._logger.Debug("Saving randomization to disk from memory...");
            foreach (KeyValuePair<string, OpenedFileData> kvp in openedFiles)
            {
                SaveFileToDisk(kvp, customDirectory, createdDirectory);
            }

            if (makeSpoilerFile)
                File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/spoiler_seed-{Seed}.txt", cheatSheet);

            return true;
        }

        private void AddAllResources()
        {
            RandomizationForm._logger.Debug("Adding all resources to resource files...");
            List<string> itemResources = new List<string>();
            foreach (BasicResource value in Resource.ItemResourcesList)
            {
                itemResources.Add(value.Name);
            }
            List<string> allStages = new List<string> { "w00a", "w00b", "w00c", "w01a", "w01b", "w01c", "w01d", "w01e", "w01f",
            "w02a", "w03a", "w03b", "w04a", "w04b", "w04c", "w11a", "w11b", "w11c", "w12a", "w12b", "w12c", "w13a", "w13b",
            "w14a", "w15a", "w15b", "w16a", "w16b", "w17a", "w18a", "w19a", "w20a", "w20b", "w20c", "w20d", "w21a", "w21b",
            "w22a", "w23a", "w23b", "w24a", "w24b", "w24c", "w24d", "w24e", "w25a", "w25b", "w25c", "w25d", "w28a", "w31a",
            "w31b", "w31c", "w31d", "w31f", "w32a", "w32b", "w41a", "w42a", "w43a", "w44a", "w45a", "w46a", "w51a", "w61a"};
            foreach (string stage in allStages)
                ResourceEditor.AddResources(stage, ResourceSuperDirectory.FullName, itemResources);

            RandomizationForm._logger.Debug("Adding guard resources to applicable files...");
            List<string> reinforcementResources = new List<string>();
            foreach (BasicResource value in Resource.GuardResourceList)
            {
                reinforcementResources.Add(value.Name);
            }
            List<string> stagesWithReinforcements = new List<string>
            {
                "w00a", "w00b", "w00c", "w01a", "w01b", "w01c", "w01d", "w01e", "w01f",
                "w02a", "w03a", "w03b", "w04a", "w04b", "w04c", "w11a", "w11b", "w11c", "w12a", "w12b", "w12c", "w13a", "w13b",
                "w14a", "w15a", "w15b", "w16a", "w16b", "w17a", "w18a", "w19a", "w20a", "w20b", "w20c", "w20d", "w21a", "w21b",
                "w22a", "w23a", "w23b", "w24a", "w24b", "w24c", "w24d", "w24e", "w25a", "w25b", "w25c", "w25d", "w28a", "w31a",
                "w31b", "w31c", "w31d", "w31f", "w32a", "w32b"
            };            
            foreach (string stage in stagesWithReinforcements)
                ResourceEditor.AddResources(stage, ResourceSuperDirectory.FullName, reinforcementResources);

            FixTenguResourceBug();
        }

        private void FixTenguResourceBug()
        {
            //Fixing a bug I accidentally created in 1.2.0.0. anyone that used that version will have bugged resources for arsenal tengu. 
            List<string> tenguStages = new List<string> { "w41a", "w42a", "w44a", "w45a" };
            foreach (string stage in tenguStages)
            {
                //w41a & w42a use a41a. w44a & w45a use a45a
                string manifestPath = Path.Combine(ResourceSuperDirectory.FullName, stage, "manifest.txt");
                string resources = File.ReadAllText(manifestPath);

                if (new[] { "w41a", "w42a" }.Contains(stage))
                    resources = resources.Replace("gbs_stage_a02a", "gbs_stage_a41a");
                else
                    resources = resources.Replace("gbs_stage_a02a", "gbs_stage_a45a");

                File.WriteAllText(manifestPath, resources);
            }
        }

        private void AddAllProcs(GcxEditor gcx_Editor)
        {
            ProcSelector.GetAllProcs();

            foreach (DecodedProc proc in ProcSelector.ProcsToAdd)
            {
                gcx_Editor.InsertNewProcedureToFile(proc);
            }
        }
    }
}
