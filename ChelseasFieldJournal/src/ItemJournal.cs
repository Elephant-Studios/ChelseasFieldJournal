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
        public override void OnHeldInteractStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
        {
            if (this.api.Side == EnumAppSide.Client)
            {
                this.dlg = new GuiDialogToolJournal(JournalString, (EntityPlayer)byEntity, capi);
                this.dlg.TryOpen();
            }
            base.OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling);
        }

        public override bool OnHeldInteractCancel(float secondsUsed, ItemSlot slot,
            EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel,
            EnumItemUseCancelReason cancelReason) => true;
    }
}
