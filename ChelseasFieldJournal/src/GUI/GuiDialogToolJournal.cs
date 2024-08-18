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
using Vintagestory.GameContent;
using static Ele.ChelseasFieldJournal.JournalEntryManager;
using static Ele.ChelseasFieldJournal.ModConstants;

namespace Ele.ChelseasFieldJournal
{
    public class GuiDialogToolJournal : GuiDialogGeneric
    {
        private Item ItemBook { get; set; }
        private int ChapterLeftPage { get; set; }

        private int ChapterIndex { get; set; }
        private int ChapterCount = 6;
        private int LeftPageNumber = 0;

        private IPageEntry? currentLeftPage;
        private IPageEntry? currentRightPage;

        public GuiDialogToolJournal(string DialogTitle, EntityPlayer playerIn, ICoreClientAPI capi) : base(DialogTitle, capi)
        {
            this.SetupDialogJournal();
            InitializeJournalEntries();
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

            // Array of lists containing all your journal entries
            var journalChapters = new List<IPageEntry>[] {
                JournalTextEntries.Cast<IPageEntry>().ToList(),
                JournalOreEntries.Cast<IPageEntry>().ToList(),
                JournalFaunaEntries.Cast<IPageEntry>().ToList(),
                JournalFloraEntries.Cast<IPageEntry>().ToList(),
                JournalCookingEntries.Cast<IPageEntry>().ToList(),
                JournalConstructEntries.Cast<IPageEntry>().ToList()
            };
            
            if (ChapterLeftPage > journalChapters[ChapterIndex].Count && ChapterIndex + 1 < journalChapters.Length) //next ChapterIndex
            {
                ChapterIndex++;
                ChapterLeftPage = 0;
            }
            
            if (ChapterLeftPage < 0 && ChapterIndex - 1 >= 0) //previous ChapterIndex
            {
                ChapterIndex--;
                ChapterLeftPage = journalChapters[ChapterIndex].Count % 2 == 0
                    ? journalChapters[ChapterIndex].Count - 2
                    : journalChapters[ChapterIndex].Count - 1;
            }

            if (ChapterIndex >= 0 && ChapterIndex < journalChapters.Length) //If chapter is valid
            {
                var Entry = journalChapters[ChapterIndex];
                if (ChapterLeftPage - 1 < Entry.Count) //If ChapterIndex Left Page is valid
                {
                    currentLeftPage = (ChapterLeftPage != 0) ? Entry[ChapterLeftPage - 1] : null;
                    currentRightPage = (ChapterLeftPage + 1 < Entry.Count) ? Entry[ChapterLeftPage] : null;
                }
            }

            LeftPageNumber = ChapterLeftPage;
            for (int i = 0; i < ChapterIndex; i++)
            {
                LeftPageNumber += journalChapters[i].Count;
            }


            RichTextComponentBase[] richStack = new RichTextComponentBase[] { new ItemstackTextComponent(capi, capi.World.Player.Entity.LeftHandItemSlot.Itemstack, 128.0) };

            base.SingleComposer = gui.CreateCompo(dialogId, dialogBounds).BeginChildElements(childBounds).
                AddStaticImage(new AssetLocation(MOD_ID + ":" + "textures/dialogs/test.png"), JournalBlankBounds, Operator.Over).
                AddRichtext(richStack, ItemStackIconBounds).//AddIf(leftPageNumber == 0).
                AddButton("", new ActionConsumable(this.OnLeftPage), ElementBounds.Fixed(0.0, 0.0, 105.0, 700), EnumButtonStyle.None).
                AddButton("", new ActionConsumable(this.OnRightPage), ElementBounds.Fixed(986, 0.0, 105.0, 700), EnumButtonStyle.None).
                AddStaticText(this.ChapterLeftPage.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Normal).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(1000.0, 800.0, 50.0, 50.0), null).
                AddIf(LeftPageNumber > 0).
                    AddStaticText(this.LeftPageNumber.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Normal).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(60.0, 50.0, 50.0, 50.0), null).
                EndIf().
                AddStaticText((this.LeftPageNumber + 1).ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Normal).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(1000.0, 50.0, 50.0, 50.0), null).
                
                //ChapterIndex Titles
                AddIf(ChapterIndex < JournalTitleEntries.Count && ChapterLeftPage == 0).
                    AddStaticText(JournalTitleEntries[ChapterIndex].Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300, 50.0, 300.0, 300.0)).

                    AddRightPage(currentRightPage).
                EndIf().
                
                //Left Page
                AddIf(ChapterLeftPage > 0).
                    AddLeftPage(currentLeftPage).
                    AddRightPage(currentRightPage).
                EndIf().
                
                EndChildElements();

            base.SingleComposer.Compose(true);
        }

        private bool OnRightPage()
        {
            if (!(ChapterIndex == ChapterCount && ChapterLeftPage + 1 < JournalConstructEntries.Count))
            {
                ChapterLeftPage += 2;
                this.SetupDialogJournal();
            }
            return true;
        }

        private bool OnLeftPage()
        {
            if (this.LeftPageNumber != 0)
            {
                ChapterLeftPage -= 2;
                this.SetupDialogJournal();
            }
            else if (this.ChapterIndex != 0 )
            {
                ChapterIndex--;
            }
            return true;
        }
    }
}
