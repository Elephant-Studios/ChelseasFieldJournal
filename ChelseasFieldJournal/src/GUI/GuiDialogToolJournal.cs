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
        private int ChapterLeftPage { get; set; }

        private int Chapter { get; set; }
        private int ChapterCount = 6;

        private object currentLeftPage;
        private object currentRightPage;

        public GuiDialogToolJournal(string DialogTitle, EntityPlayer playerIn, ICoreClientAPI capi) : base(DialogTitle, capi)
        {
            //if (leftPageNumber < 1) { leftPageNumber = 1; }
            leftPageNumber = 0;
            rightPageNumber = 1;
            //if (rightPageNumber < 1) { rightPageNumber = 1; }
            this.SetupDialogJournal();
            //InitializeJournalEntries();
            //if (ChapterPage < 1) { ChapterPage = 1; }
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
            var journalChapters = new List<object>[] {
                JournalTextEntries.Cast<object>().ToList(),
                JournalOreEntries.Cast<object>().ToList(),
                JournalFaunaEntries.Cast<object>().ToList(),
                JournalFloraEntries.Cast<object>().ToList(),
                JournalCookingEntries.Cast<object>().ToList(),
                JournalConstructEntries.Cast<object>().ToList()
            };
            
            if (ChapterLeftPage > journalChapters[Chapter].Count && Chapter + 1 < journalChapters.Length) //next Chapter
            {
                Chapter++;
                ChapterLeftPage = 0;
            }
            
            if (ChapterLeftPage < 0 && Chapter - 1 >= 0) //previous Chapter
            {
                Chapter--;
                ChapterLeftPage = journalChapters[Chapter].Count % 2 == 0
                    ? journalChapters[Chapter].Count - 2
                    : journalChapters[Chapter].Count - 1;
            }

            if (Chapter >= 0 && Chapter < journalChapters.Length) //If chapter is valid
            {
                var Entry = journalChapters[Chapter];
                if (ChapterLeftPage - 1 < Entry.Count) //If Chapter Left Page is valid
                {
                    currentLeftPage = (ChapterLeftPage != 0) ? Entry[ChapterLeftPage - 1] : null;
                    currentRightPage = (ChapterLeftPage + 1 < Entry.Count) ? Entry[ChapterLeftPage] : null;
                }
                /*
                else if (Chapter + 1 < journalChapters.Length) //If 
                {
                    Chapter++;
                    ChapterLeftPage = 0;
                    currentLeftPage = null; //Entry[ChapterLeftPage];
                    currentRightPage = (ChapterLeftPage + 1 < Entry.Count) ? Entry[ChapterLeftPage + 1] : null;
                }*/ 
            }
            
            RichTextComponentBase[] richStack = new RichTextComponentBase[] { new ItemstackTextComponent(capi, capi.World.Player.Entity.LeftHandItemSlot.Itemstack, 128.0) };

            base.SingleComposer = gui.CreateCompo(dialogId, dialogBounds).BeginChildElements(childBounds).
                AddStaticImage(new AssetLocation(MOD_ID + ":" + "textures/dialogs/test.png"), JournalBlankBounds, Operator.Over).
                //AddStaticImage(new AssetLocation(MOD_ID + ":" + "textures/dialogs/1.png"), TestIconBounds, Operator.Atop).
                AddRichtext(richStack, ItemStackIconBounds).//AddIf(leftPageNumber == 0).
                AddButton("", new ActionConsumable(this.OnLeftPage), ElementBounds.Fixed(0.0, 0.0, 105.0, 700), EnumButtonStyle.None).
                AddButton("", new ActionConsumable(this.OnRightPage), ElementBounds.Fixed(986, 0.0, 105.0, 700), EnumButtonStyle.None).
                AddStaticText(this.ChapterLeftPage.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Normal).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(1000.0, 800.0, 50.0, 50.0), null).
                AddIf(leftPageNumber > 0).
                    AddStaticText(this.leftPageNumber.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Normal).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(60.0, 50.0, 50.0, 50.0), null).
                EndIf().
                AddStaticText(this.rightPageNumber.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Normal).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(1000.0, 50.0, 50.0, 50.0), null).
                
                //Chapter Titles
                AddIf(Chapter < JournalTitleEntries.Count && ChapterLeftPage == 0).
                    AddStaticText(JournalTitleEntries[Chapter].MainTitle, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300, 50.0, 300.0, 300.0)).

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
            if (!(Chapter == 5 && ChapterLeftPage + 1 < JournalConstructEntries.Count))
            {
                Console.WriteLine("right");
                leftPageNumber += 2;
                rightPageNumber += 2;
                ChapterLeftPage += 2;
                this.SetupDialogJournal();
            }
            return true;
        }

        private bool OnLeftPage()
        {
            if (this.leftPageNumber != 0)
            {
                Console.WriteLine("left");
                leftPageNumber -= 2;
                rightPageNumber -= 2;
                ChapterLeftPage -= 2;
                this.SetupDialogJournal();
            }
            else if (this.Chapter != 0 )
            {
                Chapter--;
            }
            return true;
        }
    }
}
