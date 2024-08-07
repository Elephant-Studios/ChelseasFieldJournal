using ChelseasFieldJournal.src;
using Ele.Utility;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace Ele.ChelseasFieldJournal
{
    public class ModMain : ModSystem
    {
        private static ICoreAPI _api = null!;
        private static ICoreServerAPI _sapi = null!;
        private static ICoreClientAPI _capi = null!;

        public override double ExecuteOrder() => 0.01;
        public override void StartPre(ICoreAPI api)
        {
            base.StartPre(api);
            InitHelpers(this);
        }

        public override void Start(ICoreAPI api)
        {
            _api = api;
            base.Start(api);
            RegisterClasses(api);
            LogHelper.Log($"Starting up {Mod.Info.Name}...");
            api.RegisterItemClass("ItemJournal", typeof(ItemJournal));
        }

        public override void AssetsFinalize(ICoreAPI api)
        {
            base.AssetsFinalize(api);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        #region Server
        public override void StartServerSide(ICoreServerAPI sapi)
        {
            base.StartServerSide(sapi);
            _sapi = sapi;

        }
        #endregion

        #region Client
        public override void StartClientSide(ICoreClientAPI capi)
        {
            base.StartClientSide(capi);
            _capi = capi;

        }
        #endregion

        #region Helpers
        public static void RegisterClasses(ICoreAPI api)
        {
            //api.Register...
        }

        internal static void InitHelpers(ModSystem modMain)
        {
            ModConstants.Init(modMain.Mod.Info);
            //LogHelper.Logger = modMain.Mod.Logger;
        }
        #endregion
    }
}
