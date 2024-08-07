using static Ele.ChelseasFieldJournal.ModConstants;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;
using System.IO.Compression;
using System.IO;
using System.Text;
using System;

namespace Ele.Utility;

/* Courtesy of several lovely mod authors:
 *      https://github.com/Craluminum-Mods/ 
*/
public static class LogHelper
{
    internal static ILogger Logger;

    /// <summary>
    ///     Prints a notification prefixed with the mod name to the game logs if an api is provided.
    ///     Otherwise simply prints to the console
    /// </summary>
    public static void Log(string message, ICoreAPI api = null)
    {
        if (api != null)
            Logger.Notification($"[{MOD_NAME}] {message}");
        else
            Console.WriteLine(message);
    }
}