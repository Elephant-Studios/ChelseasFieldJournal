using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ele.ChelseasFieldJournal
{
    public class IPageEntry
    {
        public string Title = string.Empty;
        public string[] Tags = Array.Empty<string>();
        public string ImagePath = string.Empty;
    }
    public class TitlePageEntry : IPageEntry
    {
        public string Subtitle = string.Empty;
    }

    public class TextEntry : IPageEntry
    {
        public string MainText = string.Empty;
        public string ImageSpecialText = string.Empty;
    }

    public class OreEntry : IPageEntry
    {
        public string Formula = string.Empty;
        public string Uses = string.Empty;
        public string Depth = string.Empty;
        public string[] Properties = Array.Empty<string>();
    }

    public class FaunaEntry : IPageEntry
    {
        public string LatinName = string.Empty;
        public string Habitat = string.Empty;
        public string[] Harvestables = Array.Empty<string>();
    }

    public class FloraEntry : IPageEntry
    {
        public string LatinName = string.Empty;
        public string Uses = string.Empty;
        public string Notes = string.Empty;
        public string SpecialNote = string.Empty;
        public string[] Properties = Array.Empty<string>();
    }

    public class CookingEntry : IPageEntry
    {
        public int PrepTime;
        public string[] MachineList = Array.Empty<string>();
        public string[] Ingredients = Array.Empty<string>();
        public string Yield = string.Empty;
        public string Step1 = string.Empty;
        public string Step1Body = string.Empty;
        public string Step2 = string.Empty;
        public string Step2Body = string.Empty;
    }

    public class ConstructEntry : IPageEntry
    {
        public string MainText = string.Empty;
        public string Materials = string.Empty;
    }
    public static class JournalEntryManager
    {
        public static List<TitlePageEntry> JournalTitleEntries = new List<TitlePageEntry>();
        public static List<TextEntry> JournalTextEntries = new List<TextEntry>();
        public static List<OreEntry> JournalOreEntries = new List<OreEntry>();
        public static List<FaunaEntry> JournalFaunaEntries = new List<FaunaEntry>();
        public static List<FloraEntry> JournalFloraEntries = new List<FloraEntry>();
        public static List<CookingEntry> JournalCookingEntries = new List<CookingEntry>();
        public static List<ConstructEntry> JournalConstructEntries = new List<ConstructEntry>();


        public static void InitializeJournalEntries()
        {
            Console.WriteLine("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBEEEEEEEEEEEEEEEEEEEEP");
            //TITLES
            JournalTitleEntries.Add(new TitlePageEntry()
            {
                Title = "Advice",
                Subtitle = "Subtitle",
                Tags = new string[] { "CategoryTest" },
            });
            JournalTitleEntries.Add(new TitlePageEntry()
            {
                Title = "Ores",
                Subtitle = "Subtitle",
                Tags = new string[] { "CategoryTest" },
            });
            JournalTitleEntries.Add(new TitlePageEntry()
            {
                Title = "Fauna",
                Subtitle = "Subtitle",
                Tags = new string[] { "CategoryTest" },
            });
            JournalTitleEntries.Add(new TitlePageEntry()
            {
                Title = "Flora",
                Subtitle = "Subtitle",
                Tags = new string[] { "CategoryTest" },
            });
            JournalTitleEntries.Add(new TitlePageEntry()
            {
                Title = "Cooking",
                Subtitle = "Subtitle",
                Tags = new string[] { "CategoryTest" },
            });
            JournalTitleEntries.Add(new TitlePageEntry()
            {
                Title = "Constructs",
                Subtitle = "Subtitle",
                Tags = new string[] { "CategoryTest" },
            });

            //ADVICE
            JournalTextEntries.Add(new TextEntry()
            {
                Title = "TextTitle",
                MainText = "MainText",
                ImageSpecialText = "ImageSpecialText",
                Tags = new string[] { "Advice" },
                ImagePath = "1"
            });
            JournalTextEntries.Add(new TextEntry()
            {
                Title = "TextTitle2",
                MainText = "MainText",
                ImageSpecialText = "ImageSpecialText",
                Tags = new string[] { "Advice" },
                ImagePath = "1"
            });

            //ORES
            JournalOreEntries.Add(new OreEntry()
            {
                Title = "OreTest",
                Formula = "OreFormula",
                Uses = "OreUses",
                Depth = "DepthRange",
                Properties = new string[] { "SmeltingPoint", "RockType", "VeinShape", "Special1", "Special2", "Special3" },
                Tags = new string[] { "Ore", "AlphabeticalName", "RockType", "MetalStrength" },
                ImagePath = "1"
            });
            JournalOreEntries.Add(new OreEntry()
            {
                Title = "OreTest2",
                Formula = "OreFormula",
                Uses = "OreUses",
                Depth = "DepthRange",
                Properties = new string[] { "SmeltingPoint", "RockType", "VeinShape", "Special1", "Special2", "Special3" },
                Tags = new string[] { "Ore", "AlphabeticalName", "RockType", "MetalStrength" },
                ImagePath = "1"
            });

            //FAUNA
            JournalFaunaEntries.Add(new FaunaEntry()
            {
                Title = "FaunaTest",
                LatinName = "LatinName",
                Habitat = "Habitat",
                Harvestables = new string[] { "Harvestables", "Harvestables", "Harvestables" },
                Tags = new string[] { "Fauna", "AlphabeticalName", "Habitat", "Size" },
                ImagePath = "1"
            });
            JournalFaunaEntries.Add(new FaunaEntry()
            {
                Title = "FaunaTest2",
                LatinName = "LatinName",
                Habitat = "Habitat",
                Harvestables = new string[] { "Harvestables", "Harvestables", "Harvestables" },
                Tags = new string[] { "Fauna", "AlphabeticalName", "Habitat", "Size" },
                ImagePath = "1"
            });

            //FLORA
            JournalFloraEntries.Add(new FloraEntry()
            {
                Title = "FloraTest",
                LatinName = "LatinName",
                Uses = "Uses",
                Notes = "NoteTest",
                SpecialNote = "SpecialNote",
                Properties = new string[] { "Habitat", "GrowthCycleLength", "Nutrient", "SunExposure", "Perennial Type", "Temp Range", "Satiety Quality Low" },
                Tags = new string[] { "Flora", "Habitat", "Type" },
                ImagePath = "1"
            });
            JournalFloraEntries.Add(new FloraEntry()
            {
                Title = "FloraTest2",
                LatinName = "LatinName",
                Uses = "Uses",
                Notes = "NoteTest",
                SpecialNote = "SpecialNote",
                Properties = new string[] { "Habitat", "GrowthCycleLength", "Nutrient", "SunExposure", "Perennial Type", "Temp Range", "Satiety Quality Low" },
                Tags = new string[] { "Flora", "Habitat", "Type" },
                ImagePath = "1"
            });

            //COOKING
            JournalCookingEntries.Add(new CookingEntry()
            {
                Title = "CookingTest",
                PrepTime = 20,
                MachineList = new string[] { "Machine", "Machine", "Machine" },
                Ingredients = new string[] { "Ingredient", "Ingredient" },
                Yield = "-2 Pieces",
                Step1 = "Preparation",
                Step1Body = "Chop Finely",
                Step2 = "Baking",
                Step2Body = "Cook for 30 minutes",
                Tags = new string[] { "Cooking", "DishType", "Time", "Strength" },
                ImagePath = "1"
            });
            JournalCookingEntries.Add(new CookingEntry()
            {
                Title = "CookingTest2",
                PrepTime = 20,
                MachineList = new string[] { "Machine", "Machine", "Machine" },
                Ingredients = new string[] { "Ingredient", "Ingredient" },
                Yield = "-2 Pieces",
                Step1 = "Preparation",
                Step1Body = "Chop Finely",
                Step2 = "Baking",
                Step2Body = "Cook for 30 minutes",
                Tags = new string[] { "Cooking", "DishType", "Time", "Strength" },
                ImagePath = "1"
            });

            //CONSTRUCT
            JournalConstructEntries.Add(new ConstructEntry()
            {
                Title = "ConstructTest",
                MainText = "MainTextTest",
                Materials = "MaterialsTest",
                Tags = new string[] { "Construct", "Type" },
                ImagePath = "1"
            });
            JournalConstructEntries.Add(new ConstructEntry()
            {
                Title = "ConstructTest2",
                MainText = "MainTextTest",
                Materials = "MaterialsTest",
                Tags = new string[] { "Construct", "Type" },
                ImagePath = "1"
            });
        }
    }
}
