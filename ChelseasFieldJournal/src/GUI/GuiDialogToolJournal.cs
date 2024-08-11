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
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;

namespace ChelseasFieldJournal
{
    public class GuiDialogToolJournal : GuiDialogGeneric, IDisposable
    {
        public InventoryBase Inventory { get; set; }
        
        private int leftPageNumber { get; set; }
        private int rightPageNumber { get; set; }
        private Item ItemBook { get; set; }

        public GuiDialogToolJournal(string DialogTitle, EntityPlayer playerIn, ICoreClientAPI capi) : base(DialogTitle, capi)
        {
            this.SetupDialogJournal();
            this.RunAllSetupDialogs();
            this.lastRedrawMs = this.capi.ElapsedMilliseconds;
        }

        private void RunAllSetupDialogs()
        {
            //this.SetupDialogDiscoveredEntries();
            
        }

        private void SetupDialogJournal()
        {
            ElementBounds dialogBounds = ElementStdBounds.AutosizedMainDialog.WithAlignment(EnumDialogArea.CenterMiddle);//.WithFixedAlignmentOffset(0.0, 20.0);
            ElementBounds JournalBlankBounds = ElementBounds.Fixed(0.0, 0.0, 1091, 700);
            ElementBounds TestIconBounds = ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0);
            ElementBounds ItemStackIconBounds = ElementBounds.Fixed(200.0, 200.0, 256.0, 256.0);
            ElementBounds childBounds = new ElementBounds().WithSizing(ElementSizing.FitToChildren);
            IGuiAPI gui = this.capi.Gui;
            string str = "gui-dialog-journal";
            AssetLocation test = new AssetLocation("fieldjournal", "textures/dialogs/test.png");
            RichTextComponentBase[] richStack = new RichTextComponentBase[] { new ItemstackTextComponent(capi, capi.World.Player.Entity.LeftHandItemSlot.Itemstack, 128.0) };
            this.Composers[str] = gui.CreateCompo(str, dialogBounds).BeginChildElements(childBounds).
                AddStaticImage(new AssetLocation("fieldjournal", "dialogs/test.png"), JournalBlankBounds, Operator.Over).
                AddStaticImage(new AssetLocation("fieldjournal", "dialogs/1.png"), TestIconBounds, Operator.Atop).
                AddRichtext(richStack, ItemStackIconBounds).
                EndChildElements().
                Compose(true);
            this.lastRedrawMs = this.capi.ElapsedMilliseconds;
        }
        private void onDrawIconPrev(Context ctx, ImageSurface surface, ElementBounds currentBounds)
        {
            this.capi.Gui.Icons.Drawleft_svg(ctx, 0, 0, 42f, 42f, GuiStyle.DialogDefaultTextColor);
        }

        private void onDrawIconNext(Context ctx, ImageSurface surface, ElementBounds currentBounds)
        {
            this.capi.Gui.Icons.Drawright_svg(ctx, 0, 0, 42f, 42f, GuiStyle.DialogDefaultTextColor);
        }

        public override void OnGuiOpened()
        {
            base.OnGuiOpened();
            this.RunAllSetupDialogs();
        }

        public override void OnGuiClosed()
        {
            base.OnGuiClosed();
        }

        public override bool TryClose()
        {
            return base.TryClose();
        }

        public override bool TryOpen()
        {
            return base.TryOpen();
        }

        private void OnTitleBarClose()
        {
            this.TryClose();
        }

        public override void OnRenderGUI(float deltaTime)
        {
            base.OnRenderGUI(deltaTime);
        }

        private long lastRedrawMs;
    }
}
