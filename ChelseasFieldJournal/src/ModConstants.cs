using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace Ele.ChelseasFieldJournal
{
    public static class ModConstants
    {
        internal const string MOD_NAME = "ChelseasFieldJournal"; //<--Cannot contain spaces
        internal const string ORG_ID = "elephantstudios"; //<--Cannot contain spaces
        internal static string MOD_ID = "fieldjournal";
        internal static string ASSETDOMAIN = "fieldjournal:textures/dialogs/";
        internal static string Display_Name;
        internal static string Harmony_ID;

        internal static string Main_Channel;
        internal static string Config_Channel;

        internal const string Main_Config_Name = "Core-Settings";
        internal const string Client_Config_Name = "Client-Settings";
        internal const string Default_Server_Config = "Server-Properties";

        public static List<TitlePageEntry> JournalTitleEntries = new List<TitlePageEntry>();
        public static List<PageEntry> JournalPageEntries = new List<PageEntry>();
        public static List<OreEntry> JournalOreEntries = new List<OreEntry>();
        public static List<FaunaEntry> JournalFaunaEntries = new List<FaunaEntry>();
        public static List<FloraEntry> JournalFloraEntries = new List<FloraEntry>();
        public static List<CookingEntry> JournalCookingEntries = new List<CookingEntry>();
        public static List<ConstructEntry> JournalConstructEntries = new List<ConstructEntry>();

        internal static void Init(ModInfo modInfo)
        {
            MOD_ID = modInfo.ModID;
            Display_Name = modInfo.Name;
            Harmony_ID = $"com.{ORG_ID}.{MOD_ID}";

            Main_Channel = $"{MOD_ID}:main";
            Config_Channel = $"{MOD_ID}:config";
            InitializeJournalEntries();
        }

        public class EventIDs
        {
            internal static string Config_Reloaded = $"{MOD_ID}:configreloaded";
            internal static string Admin_Send_Config = $"{MOD_ID}:adminsendconfig";
        }

        // Place any public enums down here
        public struct TitlePageEntry
        {
            public string MainTitle;
            public string Subtitle;
            public string Category;
        }

        public struct PageEntry
        {
            public string Title;
            public string MainText;
            public string ImageSpecialText;
            public string[] Tags;
            public string ImagePath;
        }
        
        public struct OreEntry
        {
            public string Title;
            public string Formula;
            public string Uses;
            public string Depth;
            public string[] Properties;
            public string[] Tags;
            public string ImagePath;
        }

        public struct FaunaEntry
        {
            public string Title;
            public string LatinName;
            public string Habitat;
            public string[] Harvestables;
            public string[] Tags;
            public string ImagePath;
        }

        public struct FloraEntry
        {
            public string Title;
            public string LatinName;
            public string Uses;
            public string Notes;
            public string SpecialNote;
            public string[] Properties;
            public string[] Tags;
            public string ImagePath;
        }

        public struct CookingEntry
        {
            public string Title;
            public int PrepTime;
            public string[] MachineList;
            public string[] Ingredients;
            public string Yield;
            public string Step1;
            public string Step1Body;
            public string Step2;
            public string Step2Body;
            public string[] Tags;
            public string ImagePath;
        }

        public struct ConstructEntry
        {
            public string Title;
            public string MainText;
            public string Materials;
            public string[] Tags;
            public string ImagePath;
        }

        public static void InitializeJournalEntries()
        {
            Console.WriteLine("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBEEEEEEEEEEEEEEEEEEEEP");
            //TITLES
            JournalTitleEntries.Add(new TitlePageEntry() {
                MainTitle = "Title",
                Subtitle = "Subtitle",
                Category = "CategoryTest",
            });
            //ADVICE
            JournalPageEntries.Add(new PageEntry() {
                Title = "Title",
                MainText = "MainText",
                ImageSpecialText = "ImageSpecialText",
                Tags = new string[] { "Advice"},
                ImagePath = "1"
            });
            //ORES
            JournalOreEntries.Add(new OreEntry() { 
                Title = "OreTest", 
                Formula = "OreFormula", 
                Uses = "OreUses", 
                Depth = "DepthRange", 
                Properties = new string[] { "SmeltingPoint", "RockType", "VeinShape", "Special1", "Special2", "Special3" }, 
                Tags = new string[] { "Ore", "AlphabeticalName", "RockType", "MetalStrength" }, 
                ImagePath = "1"
            });
            //FAUNA
            JournalFaunaEntries.Add(new FaunaEntry() {
                Title = "FaunaTest",
                LatinName = "LatinName",
                Habitat = "Habitat",
                Harvestables = new string[] { "Harvestables", "Harvestables", "Harvestables" },
                Tags = new string[] { "Fauna", "AlphabeticalName", "Habitat", "Size" },
                ImagePath = "1"
            });
            //FLORA
            JournalFloraEntries.Add(new FloraEntry() {
                Title = "FloraTest",
                LatinName = "LatinName",
                Uses = "Uses",
                Notes = "NoteTest",
                SpecialNote = "SpecialNote",
                Properties = new string[] { "Habitat", "GrowthCycleLength", "Nutrient", "SunExposure", "Perennial Type", "Temp Range", "Satiety Quality Low" },
                Tags = new string[] { "Flora", "Habitat", "Type" },
                ImagePath = "1"
            });
            //COOKING
            JournalCookingEntries.Add(new CookingEntry() {
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
            //CONSTRUCT
            JournalConstructEntries.Add(new ConstructEntry()
            {
                Title = "ConstructTest",
                MainText = "MainTextTest",
                Materials = "MaterialsTest",
                Tags = new string[] { "Construct", "Type" },
                ImagePath = "1"
            });
        }
    }
}
