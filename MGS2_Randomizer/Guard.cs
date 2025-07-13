namespace MGS2_Randomizer
{
    public interface IGuard
    {
        int Id { get; set; }
        int Route { get; set; }
        int? StartingIndex { get; set; }
        byte[] CallingBytes { get; set; }
        bool SubfunctionCreation { get; set; }
    }

    public class Watcher : IGuard
    {
        public int Id { get; set; }
        public int Route { get; set; }
        public int? StartingIndex { get; set; }
        public byte[] CallingBytes { get; set; }
        public bool SubfunctionCreation { get; set; }
        public int RouteOffset { get; set; }
        public int[] StartingIndexOffset { get; set; } //[1] is just direct offset, [2] is nested offset
    }

    public class Defender : IGuard
    {
        public int Id { get; set; }
        public int Route { get; set; }
        public int? StartingIndex { get; set; }
        public byte[] CallingBytes { get; set; }
        public bool SubfunctionCreation { get; set; }
        public int RouteOffset { get; set; }
        public int StartingIndexOffset { get; set; }
    }

    public class Attacker : IGuard
    {
        public int Id { get; set; }
        public int Route { get; set; }
        public int? StartingIndex { get; set; }
        public ReinforcementType ReinforcementType { get; set; }
        public byte[] CallingBytes { get; set; }
        public bool SubfunctionCreation { get; set; }
        public int ReinforcementTypeOffset { get; set; }
    }

    public class TenguA : IGuard
    {
        public int Id { get; set; }
        public int Route { get; set; }
        public int? StartingIndex { get; set; }
        public byte[] CallingBytes { get; set; }
        public bool SubfunctionCreation { get; set; }
    }

    public class TenguB : IGuard
    {
        public int Id { get; set; }
        public int Route { get; set; }
        public int? StartingIndex { get; set; }
        public byte[] CallingBytes { get; set; }
        public bool SubfunctionCreation { get; set; }
    }

    public enum ReinforcementType
    {
        Normal = 0,
        ShieldNoLight = 1,
        ShieldWithLight = 2,
        Shotgun = 3,
        HiTech = 4
    }
}
