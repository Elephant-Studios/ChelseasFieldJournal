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


        internal static void Init(ModInfo modInfo)
        {
            MOD_ID = modInfo.ModID;
            Display_Name = modInfo.Name;
            Harmony_ID = $"com.{ORG_ID}.{MOD_ID}";

            Main_Channel = $"{MOD_ID}:main";
            Config_Channel = $"{MOD_ID}:config";
        }

        public class EventIDs
        {
            internal static string Config_Reloaded = $"{MOD_ID}:configreloaded";
            internal static string Admin_Send_Config = $"{MOD_ID}:adminsendconfig";
        }
    }
}
