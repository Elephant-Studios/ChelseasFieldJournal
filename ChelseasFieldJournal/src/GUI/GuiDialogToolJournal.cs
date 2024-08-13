using Cairo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using static Ele.ChelseasFieldJournal.ModConstants;

namespace Ele.ChelseasFieldJournal
{
    public class GuiDialogToolJournal : GuiDialogGeneric
    {
        
        private int leftPageNumber { get; set; }
        private int rightPageNumber { get; set; }
        private Item ItemBook { get; set; }

        public GuiDialogToolJournal(string DialogTitle, EntityPlayer playerIn, ICoreClientAPI capi) : base(DialogTitle, capi)
        {
            this.SetupDialogJournal();
        }

        private void SetupDialogJournal()
        {
            IGuiAPI gui = this.capi.Gui;
            string dialogId = "gui-dialog-journal";
            ElementBounds dialogBounds = ElementStdBounds.AutosizedMainDialog.WithAlignment(EnumDialogArea.CenterMiddle);
            ElementBounds JournalBlankBounds = ElementBounds.Fixed(0.0, 0.0, 1091, 700);
            ElementBounds TestIconBounds = ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0);
            ElementBounds ItemStackIconBounds = ElementBounds.Fixed(200.0, 200.0, 256.0, 256.0);
            ElementBounds childBounds = new ElementBounds().WithSizing(ElementSizing.FitToChildren);
            
            RichTextComponentBase[] richStack = new RichTextComponentBase[] { new ItemstackTextComponent(capi, capi.World.Player.Entity.LeftHandItemSlot.Itemstack, 128.0) };

            //change to singlecomposer
            base.SingleComposer = gui.CreateCompo(dialogId, dialogBounds).BeginChildElements(childBounds).
                AddStaticImage(new AssetLocation(MOD_ID + ":" + "textures/dialogs/test.png"), JournalBlankBounds, Operator.Over).
                AddStaticImage(new AssetLocation(MOD_ID + ":" + "textures/dialogs/1.png"), TestIconBounds, Operator.Atop).
                AddRichtext(richStack, ItemStackIconBounds).
                EndChildElements();

            base.SingleComposer.Compose(true);
        }
    }
}
