using System;
using System.Linq;
using System.Text;
using Vintagestory.API.Client;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace ChelseasFieldJournal
{
    class ItemJournal : Item
    {
        public GuiDialogToolJournal dlg;
        private ICoreClientAPI capi { get; set; }

        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            this.capi = (api as ICoreClientAPI);
        }
        public override void OnHeldIdle(ItemSlot slot, EntityAgent byEntity)
        {
            base.OnHeldIdle(slot, byEntity);
            if (this.api.Side == EnumAppSide.Client)
            {
                this.dlg = new GuiDialogToolJournal("gui-dialogs-journal", (EntityPlayer)byEntity, capi);
                this.dlg.TryOpen();
                this.dlg.OnClosed += delegate ()
                {
                    byEntity = null;
                };
            }
        }
        public override bool OnHeldInteractCancel(float secondsUsed, ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, EnumItemUseCancelReason cancelReason)
        {   
            return true;
        }
        public override void GetHeldItemInfo(ItemSlot inSlot, StringBuilder dsc, IWorldAccessor world, bool withDebugInfo)
        {
            base.GetHeldItemInfo(inSlot, dsc, world, withDebugInfo);
            dsc.AppendLine("Snakes... Why'd it have to be snakes!");
            dsc.AppendLine("*Requires Rope in Hotbar for Use*");
        }
    }
}
