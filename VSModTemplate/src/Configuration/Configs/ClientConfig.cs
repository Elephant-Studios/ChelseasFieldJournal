using static Ele.VSModTemplate.ModConstants;
using Newtonsoft.Json;
using Ele.Configuration;


namespace Ele.VSModTemplate
{
    public class ClientConfig : IModConfig
    {
        [JsonIgnore]
        public ConfigArgs Info { get; set; }

        public bool Example_Bool { get; set; } = true;

        /*----------------
         * 
         * Add config fields here
         * 
         -----------------*/


        public ClientConfig(ConfigArgs args)
        {
            Info = args;

            //Initialize all required defaults here
            Example_Bool = true;
        }
        public ClientConfig(ConfigArgs args, ClientConfig previousConfig = null) : this(args)
        {
            if (previousConfig == null) return;

            //Update all fields from the previousConfig here
            Info = previousConfig.Info;
            Example_Bool = previousConfig.Example_Bool;
        }
    }
}