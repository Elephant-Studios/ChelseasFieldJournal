using System;
using System.Linq;
using System.Text;
using Vintagestory.API.Client;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace Ele.ChelseasFieldJournal
{
    class ItemJournal : Item
    {
        public GuiDialogToolJournal dlg;

        private ICoreClientAPI capi { get; set; }

        private string JournalString = "gui-dialogs-journal";

        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            this.capi = (api as ICoreClientAPI);
        }

        public override void OnHeldIdle(ItemSlot slot, EntityAgent byEntity)
        {
            if (this.api.Side == EnumAppSide.Client)
            {
                this.dlg = new GuiDialogToolJournal(JournalString, (EntityPlayer)byEntity, capi);
                this.dlg.TryOpen();
            }
            base.OnHeldIdle(slot, byEntity);
        }

        public override bool OnHeldInteractCancel(float secondsUsed, ItemSlot slot,
            EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel,
            EnumItemUseCancelReason cancelReason) => true;
    }
}
