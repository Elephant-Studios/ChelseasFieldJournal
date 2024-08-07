using static Ele.ChelseasFieldJournal.ModConstants;
using Newtonsoft.Json;
using Ele.Configuration;


namespace Ele.ChelseasFieldJournal
{
    public class ServerProperty : IModConfig
    {
        [JsonIgnore]
        public ConfigArgs Info { get; set; }
        public bool Example_Bool { get; set; } = true;

        /*----------------
         * 
         * Add config fields here
         * 
         -----------------*/


        public ServerProperty(ConfigArgs args)
        {
            Info = args;

            //Initialize all required defaults here
            Example_Bool = true;
        }
        public ServerProperty(ConfigArgs args, ServerProperty previousProp = null) : this(args)
        {
            if (previousProp == null) return;

            //Update all fields from the previousProp here
            Info = previousProp.Info;
            Example_Bool = previousProp.Example_Bool;
        }
    }
}