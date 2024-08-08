using Cairo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;

namespace ChelseasFieldJournal
{
    public class GuiDialogToolJournal : GuiDialogGeneric
    {
        public InventoryBase Inventory { get; set; }
        
        private int leftPageNumber { get; set; }
        private int rightPageNumber { get; set; }
        private Item ItemBook { get; set; }

        public GuiDialogToolJournal(string DialogTitle, EntityPlayer playerIn, ICoreClientAPI capi) : base(DialogTitle, capi)
        {
            this.leftPageNumber = 1;
            this.rightPageNumber = 2;
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
            double size4 = GuiElementPassiveItemSlot.unscaledSlotSize + GuiElementItemSlotGridBase.unscaledSlotPadding;
            ElementBounds BoundsMainBG = ElementBounds.Fixed(0.0, 0.0, 700.0, 400.0);
            ElementBounds bgBounds = ElementBounds.Fill.WithFixedPadding(0.0);
            bgBounds.BothSizing = ElementSizing.FitToChildren;
            bgBounds.WithChildren(new ElementBounds[]
            {
                BoundsMainBG
            });
            ElementBounds dialogBounds = ElementStdBounds.AutosizedMainDialog.WithAlignment(EnumDialogArea.CenterMiddle).WithFixedAlignmentOffset(0.0, 20.0);
            int offsetx = 78;
            ElementBounds SpellbookImageBounds = ElementBounds.Fixed(0.0, 32.0, 700.0, 400.0);
            ElementBounds LeftPageBounds = ElementBounds.Fixed((double)(158 + offsetx), 360.0, 32.0, 16.0);
            ElementBounds RightPageBounds = ElementBounds.Fixed((double)(158 + offsetx + 217), 360.0, 32.0, 16.0);
            IGuiAPI gui = this.capi.Gui;
            string str = "america";
            this.Composers[str] = gui.CreateCompo(str, dialogBounds).AddShadedDialogBG(bgBounds.WithFixedSize(700.0, 20.0), true, 5.0, 0.75f).
                AddStaticImage(new AssetLocation("fieldjournal", "dialogs/test.png"), SpellbookImageBounds, Operator.Over).EndIf().EndChildElements().Compose(true);
            this.lastRedrawMs = this.capi.ElapsedMilliseconds;
        }

        // Token: 0x06000BFB RID: 3067 RVA: 0x000B9FF1 File Offset: 0x000B81F1
        private void onDrawIconPrev(Context ctx, ImageSurface surface, ElementBounds currentBounds)
        {
            this.capi.Gui.Icons.Drawleft_svg(ctx, 0, 0, 42f, 42f, GuiStyle.DialogDefaultTextColor);
        }

        // Token: 0x06000BFC RID: 3068 RVA: 0x000BA01C File Offset: 0x000B821C
        private void onDrawIconNext(Context ctx, ImageSurface surface, ElementBounds currentBounds)
        {
            this.capi.Gui.Icons.Drawright_svg(ctx, 0, 0, 42f, 42f, GuiStyle.DialogDefaultTextColor);
        }


        // Token: 0x06000C0E RID: 3086 RVA: 0x000BA696 File Offset: 0x000B8896
        public override void OnGuiOpened()
        {
            base.OnGuiOpened();
            this.RunAllSetupDialogs();
        }

        // Token: 0x06000C0F RID: 3087 RVA: 0x000BA6A7 File Offset: 0x000B88A7
        public override void OnGuiClosed()
        {
            base.OnGuiClosed();
        }

        // Token: 0x06000C10 RID: 3088 RVA: 0x000BA6B4 File Offset: 0x000B88B4
        public override bool TryClose()
        {
            return base.TryClose();
        }

        // Token: 0x06000C11 RID: 3089 RVA: 0x000BA6CC File Offset: 0x000B88CC
        public override bool TryOpen()
        {
            return base.TryOpen();
        }

        // Token: 0x06000C12 RID: 3090 RVA: 0x000BA6E4 File Offset: 0x000B88E4
        private void OnTitleBarClose()
        {
            this.TryClose();
        }

        // Token: 0x170002CE RID: 718
        // (get) Token: 0x06000C13 RID: 3091 RVA: 0x000BA6F0 File Offset: 0x000B88F0

        // Token: 0x06000C14 RID: 3092 RVA: 0x000BA703 File Offset: 0x000B8903
        public override void OnRenderGUI(float deltaTime)
        {
            base.OnRenderGUI(deltaTime);
        }

        // Token: 0x04000F43 RID: 3907
        private long lastRedrawMs;
    }
}
