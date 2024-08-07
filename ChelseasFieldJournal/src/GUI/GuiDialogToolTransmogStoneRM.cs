using Cairo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;

namespace ChelseasFieldJournal.src.GUI
{
    public class GuiDialogToolTransmogStoneRM : GuiDialogGeneric
    {
        private EntityPlayer Player;
        private ItemStack NameChanger;
        private int curTab = 0;
        private int dlgHeight = 224;
        private string defaultselectedchange;

        private string selectedchange { get; set; }

        private string[] values { get; set; }

        private string[] codes { get; set; }

        public GuiDialogToolTransmogStoneRM(
          EntityPlayer playerIn,
          ItemStack itemIn,
          ICoreClientAPI capi,
          int rows = 4,
          int cols = 4)
          : base("Transmog Stone", capi)
        {
            this.NameChanger = itemIn;
            this.Player = playerIn;
            ((IEventAPI)capi.Event).RegisterGameTickListener(new Action<float>(this.UpdateMachineInfo), 500, 0);
            if (((RegistryObject)itemIn.Collectible).Code.Path.Contains("staffshape"))
            {
                this.values = new string[8]
                {
          "Crude staff",
          "Conjuror staff",
          "Elvish staff",
          "Clubbed staff",
          "Scholar staff",
          "Druid staff",
          "Nebula staff",
          "Reaper staff"
                };
                this.codes = new string[8]
                {
          "staffcrude",
          "staffconjuror",
          "staffelvish",
          "staffclubbed",
          "staffscholar",
          "staffdruid",
          "staffnebula",
          "staffreaper"
                };
                this.selectedchange = "staffcrude";
            }
            if (!((RegistryObject)itemIn.Collectible).Code.Path.Contains("staffcolor") && !((RegistryObject)itemIn.Collectible).Code.Path.Contains("magearmorcolor"))
                return;
            this.values = new string[12]
            {
        "Plain",
        "Orange",
        "Black",
        "Red",
        "Blue",
        "Purple",
        "Pink",
        "White",
        "Yellow",
        "Gray",
        "Green",
        "Teal"
            };
            this.codes = new string[12]
            {
        "plain",
        "orange",
        "black",
        "red",
        "blue",
        "purple",
        "pink",
        "white",
        "yellow",
        "gray",
        "green",
        "teal"
            };
            this.selectedchange = "plain";
        }

        public virtual double DrawOrder => 0.2;

        protected void UpdateMachineInfo(float dt)
        {
            if (!((GuiDialog)this).IsOpened())
                return;
            this.ComposeGuisData();
        }

        protected void ComposeGuisData()
        {
            double unscaledSlotPadding = GuiElementItemSlotGridBase.unscaledSlotPadding;
            ElementBounds elementBounds1 = ElementBounds.FixedSize(318.0, (double)this.dlgHeight).WithFixedPadding(GuiStyle.ElementToDialogPadding);
            ElementBounds elementBounds2 = ElementBounds.FixedSize(517.0, (double)(this.dlgHeight + 40)).WithAlignment((EnumDialogArea)6).WithFixedAlignmentOffset(GuiStyle.DialogToScreenPadding, 0.0);
            ElementBounds.Fixed(-4.0, 38.0, 482.0, 181.0);
            ElementBounds.Fixed(32.0, 110.0, 464.0, 440.0);
            ElementBounds.Fixed(32.0, 130.0, 464.0, 440.0);
            ((GuiDialog)this).Composers["guidialog-namechange-main-overlay_rm"] = ((GuiDialog)this).capi.Gui.CreateCompo("guidialog-namechange-main-overlay_rm", elementBounds2).BeginChildElements(elementBounds1);
            if (!((EntityAgent)this.Player).RightHandItemSlot.Empty)
            {
                if (((EntityAgent)this.Player).RightHandItemSlot.Itemstack.Item != this.NameChanger.Item)
                    ((GuiDialog)this).TryClose();
            }
            else
                ((GuiDialog)this).TryClose();
            if (this.curTab != 0)
                ;
            if (((GuiDialog)this).Composers["guidialog-namechange-main_rm"].Bounds != ((GuiDialog)this).Composers["guidialog-namechange-main-overlay_rm"].Bounds)
                ((GuiDialog)this).Composers["guidialog-namechange-main-overlay_rm"].Bounds.WithParent(((GuiDialog)this).Composers["guidialog-namechange-main_rm"].Bounds);
            ((GuiDialog)this).Composers["guidialog-namechange-main-overlay_rm"].Compose(true);
        }

        protected void ComposeGuis()
        {
            double unscaledSlotPadding = GuiElementItemSlotGridBase.unscaledSlotPadding;
            double num = 20.0 + unscaledSlotPadding;
            ElementBounds elementBounds1 = ElementBounds.Fixed(0.0, 0.0, 316.0, 141.0);
            ElementBounds elementBounds2 = ElementBounds.Fill.WithFixedPadding(0.0);
            elementBounds2.BothSizing = (ElementSizing)2;
            elementBounds2.WithChildren(new ElementBounds[1]
            {
        elementBounds1
            });
            ElementBounds elementBounds3 = ElementStdBounds.AutosizedMainDialog.WithAlignment((EnumDialogArea)6);
            ElementBounds elementBounds4 = ElementBounds.Fixed(34.0, 80.0, 196.0, 26.0);
            ((GuiDialog)this).Composers["guidialog-namechange-main_rm"] = GuiComposerHelpers.AddDialogTitleBar(GuiComposerHelpers.AddShadedDialogBG(((GuiDialog)this).capi.Gui.CreateCompo("guidialog-namechange-main_rm", elementBounds3), elementBounds2, true, 5.0, 0.75f), "Transmog Stone", new Action(this.OnTitleBarClose), CairoFont.WhiteSmallText().WithWeight((FontWeight)1), (ElementBounds)null).BeginChildElements(elementBounds2);
            if (this.curTab == 0)
            {
                ElementBounds elementBounds5 = ElementBounds.Fixed(0.0, num, 204.0, (double)(this.dlgHeight - 76)).FixedGrow(2.0 * unscaledSlotPadding, 2.0 * unscaledSlotPadding);
                ElementBounds elementBounds6 = ElementBounds.Fixed(2.0, num + 15.0, 304.0, 98.0).FixedRightOf(elementBounds5, -203.0);
                ElementBounds elementBounds7 = ElementBounds.Fixed(32.0, num + 65.0 - 10.0, 201.0, 30.0);
                string str = "model";
                if (((RegistryObject)this.NameChanger.Collectible).Code.Path.Contains("staffshape"))
                    str = "model";
                if (((RegistryObject)this.NameChanger.Collectible).Code.Path.Contains("staffcolor") || ((RegistryObject)this.NameChanger.Collectible).Code.Path.Contains("magearmorcolor"))
                    str = "color";
                // ISSUE: method pointer
                // ISSUE: method pointer
                // ISSUE: method pointer
                GuiComposerHelpers.AddDropDown(GuiComposerHelpers.AddAutoSizeHoverText(GuiComposerHelpers.AddDynamicCustomDraw(GuiComposerHelpers.AddSmallButton(GuiComposerHelpers.AddStaticText(GuiElementInsetHelper.AddInset(GuiElementInsetHelper.AddInset(((GuiDialog)this).Composers["guidialog-namechange-main_rm"], elementBounds6, 2, 0.5f), elementBounds7, 1, 0.1f), Lang.Get("rustboundmagic:gui-select-" + str, Array.Empty<object>()), CairoFont.WhiteDetailText().WithWeight((FontWeight)1), ElementBounds.Fixed(80.0 + unscaledSlotPadding, 58.0 + unscaledSlotPadding - 10.0, 200.0, 25.0), (string)null), Lang.Get("     ", Array.Empty<object>()), new ActionConsumable((object)this, __methodptr(OnConfirmNameUpdate)), ElementBounds.Fixed(246.0, 76.0, 41.0, 38.0), (EnumButtonStyle)3, (string)null), ElementBounds.Fixed(256.0, 82.0, 41.0, 38.0), new DrawDelegateWithBounds((object)this, __methodptr(onDrawIconConverToItem)), (string)null), "Save to stone.", CairoFont.WhiteDetailText().WithWeight((FontWeight)1), 150, ElementBounds.Fixed(246.0, 76.0, 41.0, 38.0), (string)null), this.codes, this.values, 0, new SelectionChangedDelegate((object)this, __methodptr(onDurationChanged)), elementBounds4, CairoFont.WhiteSmallText(), "duration");
            }
            if (this.selectedchange.Length <= 0)
                ;
            ((GuiDialog)this).Composers["guidialog-namechange-main_rm"].Compose(true);
        }

        private void onDurationChanged(string code, bool selected) => this.selectedchange = code;

        private void onDrawIconConverToItem(
          Context ctx,
          ImageSurface surface,
          ElementBounds currentBounds)
        {
            ((GuiDialog)this).capi.Gui.Icons.Drawimport_svg(ctx, 0, 0, 25f, 25f, GuiStyle.DialogDefaultTextColor);
        }

        private void OnTextChanged(string text) => this.selectedchange = text;

        private void OnTitleBarClose() => ((GuiDialog)this).TryClose();

        public virtual void OnGuiOpened()
        {
            ((GuiDialog)this).OnGuiOpened();
            this.ComposeGuis();
            this.ComposeGuisData();
        }

        public virtual void OnGuiClosed() => ((GuiDialog)this).OnGuiClosed();

        private bool OnConfirmNameUpdate()
        {
            if (!((EntityAgent)this.Player).RightHandItemSlot.Empty && ((EntityAgent)this.Player).RightHandItemSlot.Itemstack.Item == this.NameChanger.Item)
            {
                NetworkHandlerRM.clientChannel.SendPacket<PCItemTransmogStone>(new PCItemTransmogStone()
                {
                    inputMessage = this.selectedchange
                });
                this.NameChanger.Attributes.SetString("itementity-watchedattribute-transmogstone-changetype_rm", this.selectedchange);
                this.defaultselectedchange = this.selectedchange;
                ((GuiDialog)this).TryClose();
            }
            return true;
        }
    }
}
