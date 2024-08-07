using static Ele.VSModTemplate.ModConstants;
using Vintagestory.API.Common;
using System.IO;

namespace Ele.Configuration
{
    public enum ConfigType
    {
        Core,
        Client,
        Server
    }

    public class ConfigArgs
    {
        public ConfigType Type { get; set; }
        public string Name { get; set; }
        public string Folder { get; set; }
        public string JsonPath { get; set; }

        /// <summary>
        ///   Multi-option constructor for initializing any kind of config
        /// </summary>
        /// <param name="type">Determines config type. Only leave empty if generating a singular default config.</param>
        /// <param name="name">Optional config file name to be used instead of a default</param>
        /// <param name="folder">Optional config folder name to be used instead of a default</param>
        public ConfigArgs(ICoreAPI api, ConfigType? type = null, string name = null, string folder = null)
        {
            Type = type ?? ConfigType.Core;
            Name = GetConfigName(type, name);
            Folder = folder ?? $"{MOD_NAME}";
            JsonPath = Name == MOD_NAME ?
                $"{Name}.json" :
                Path.Combine(api.GetOrCreateDataPath(JsonPath), $"{Name}.json");
        }

        /// <summary>
        ///   Returns the default name of a config depending on its type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name">Optional name to be used instead of a default</param>
        public static string GetConfigName(ConfigType? type = null, string name = null)
        {
            switch (type)
            {
                case ConfigType.Core:
                    return name == null ? Main_Config_Name : name;
                case ConfigType.Client:
                    return name == null ? Client_Config_Name : name;
                case ConfigType.Server:
                    return name == null ? Default_Server_Config : $"{Default_Server_Config}.{name}";
                default:
                    return MOD_NAME;
            }
        }
    }
}