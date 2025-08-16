using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS2_Randomizer
{
    public class RandomizationOptions
    {
        public enum RouteRandomizationBehavior
        {
            Full,
            NoNodeShare,
            NoRouteShare
        }

        public bool RandomizeSpawns { get; set; }
        public bool NoHardLogicLocks { get; set; }
        public bool NikitaShell2 { get; set; }
        public bool RandomizeStartingItems { get; set; }
        public bool RandomizeAutomaticRewards { get; set; }
        public bool RandomizeClaymores { get; set; }
        public bool RandomizeC4 { get; set; }
        public bool IncludeRations { get; set; }
        public bool AllWeaponsSpawnable { get; set; }
        public bool RandomizeTankerControlUnits { get; set; }
        public bool RandomizeCards { get; set; }
        public bool KeepVanillaCardAccess { get; set; }
        public bool RandomizeGuardValues { get; set; }
        public float GuardRandomizationBounds { get; set; }
        public bool KeepGuardValuesConsistentAcrossLevels { get; set; }
        public bool RandomizeGuardPatrols { get; set; }
        public RouteRandomizationBehavior GuardPatrolRandomizationBehavior { get; set; }
        public bool RandomizeReinforcementGuardTypes { get; set; }

        public override string ToString()
        {
            return $"RandomizeSpawns = {RandomizeSpawns};\n" +
                $"NoHardLogicLocks = {NoHardLogicLocks};\n" +
                $"NikitaShell2 = {NikitaShell2};\n" +
                $"AllWeaponsSpawnable = {AllWeaponsSpawnable};\n" +
                $"IncludeRations = {IncludeRations};\n" +
                $"RandomizeStartingItems = {RandomizeStartingItems};\n" +
                $"RandomizeAutomaticRewards = {RandomizeAutomaticRewards};\n" +
                $"RandomizeCards = {RandomizeCards};\n" +
                $"KeepVanillaCardAccess = {KeepVanillaCardAccess};\n" +
                $"RandomizeC4 = {RandomizeC4};\n" +
                $"RandomizeClaymores = {RandomizeClaymores};\n" +
                $"RandomizeGuardValues = {RandomizeGuardValues};\n" +
                $"KeepGuardValuesConsistent = {KeepGuardValuesConsistentAcrossLevels};\n" +
                $"GuardRandomizationBounds = {GuardRandomizationBounds};\n" +
                $"RandomizeGuardPatrols = {RandomizeGuardPatrols};\n" +
                $"GuardPatrolRandomizationBehavior = {GuardPatrolRandomizationBehavior};\n" +
                $"RandomizeReinforcementGuardTypes = {RandomizeReinforcementGuardTypes};\n" +
                $"RandomizeTankerControlUnits = {RandomizeTankerControlUnits};\n\n\n\n\n\n";
        }
    }
}
