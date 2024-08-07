using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using ChelseasFieldJournal.src.GUI;

namespace ChelseasFieldJournal.src
{
    class ItemJournal : Item
    {
        public GuiDialogToolJournal dlg;
        public override void OnHeldInteractStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            
            ICoreClientAPI capi = byEntity.World.Api as ICoreClientAPI;
            GuiDialogToolJournal guiDialogToolJournal = this.dlg;
            bool flag7 = guiDialogToolJournal == null || !guiDialogToolJournal.IsOpened();
            if (flag7)
            {
                this.dlg = new GuiDialogToolJournal("america", (EntityPlayer)byEntity, capi);
                this.dlg.TryOpen();
                this.dlg.OnClosed += delegate ()
                {
                    byEntity = null;
                };
                handling = EnumHandHandling.NotHandled;
                return;
            }
                        handling = EnumHandHandling.NotHandled;
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
