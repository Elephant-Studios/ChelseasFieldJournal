using static Ele.ChelseasFieldJournal.ModConstants;
using ProtoBuf;
using Newtonsoft.Json;
using Ele.Configuration;


namespace Ele.ChelseasFieldJournal
{
    [ProtoContract]
    public class CoreConfig : IModConfig
    {
        [JsonIgnore]
        [ProtoMember(1)]
        public ConfigArgs Info { get; set; }

        // Tag Proto Booleans with IsRequired = true to prevent false values not being sent
        [ProtoMember(2, IsRequired = true)]
        public bool Example_Bool { get; set; }

        /*----------------
         * 
         * Add more synced fields here
         * 
         -----------------*/


        public CoreConfig(ConfigArgs args)
        {
            Info = args;
            
            //Initialize all required defaults here
            Example_Bool = true;
        }
        public CoreConfig(ConfigArgs args, CoreConfig previousConfig = null) : this(args)
        {
            if (previousConfig == null) return;

            //Update all fields from the previousConfig here
            Info = previousConfig.Info;
            Example_Bool = previousConfig.Example_Bool;
        }
    }
}