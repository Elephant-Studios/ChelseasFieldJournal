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

        private object currentLeftPage;
        private object currentRightPage;

        public GuiDialogToolJournal(string DialogTitle, EntityPlayer playerIn, ICoreClientAPI capi) : base(DialogTitle, capi)
        {
            this.SetupDialogJournal();
            if (leftPageNumber < 1) { leftPageNumber = 1; }
            if (rightPageNumber < 1) { rightPageNumber = 1; }
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

            //TitlePageEntry currentChapterPage = JournalTitleEntries[Chapter];
            Console.WriteLine("title Entries:" + JournalTitleEntries.Count);
            Console.WriteLine("page Entries:" + JournalPageEntries.Count);
            Console.WriteLine("Fauna Entries:" + JournalFaunaEntries.Count);
            Console.WriteLine("Flora Entries:" + JournalFloraEntries.Count);
            Console.WriteLine("Cooking Entries:" + JournalCookingEntries.Count);
            Console.WriteLine("Construct Entries:" + JournalConstructEntries.Count);

                // Array of lists containing all your journal entries
                var journalChapters = new List<object>[] {
                JournalPageEntries.Cast<object>().ToList(),
                JournalOreEntries.Cast<object>().ToList(),
                JournalFaunaEntries.Cast<object>().ToList(),
                JournalFloraEntries.Cast<object>().ToList(),
                JournalCookingEntries.Cast<object>().ToList(),
                JournalConstructEntries.Cast<object>().ToList()
            };

                if (Chapter >= 0 && Chapter < journalChapters.Length)
                {
                    var Entry = journalChapters[Chapter];
                    if (ChapterLeftPage < Entry.Count)
                    {
                        currentLeftPage = Entry[ChapterLeftPage];
                        currentRightPage = (ChapterLeftPage + 1 < Entry.Count) ? Entry[ChapterLeftPage + 1] : null;
                    }
                    else if (Chapter + 1 < journalChapters.Length)
                    {
                        Chapter++;
                        ChapterLeftPage = 0;
                        currentLeftPage = Entry[ChapterLeftPage];
                        currentRightPage = (ChapterLeftPage + 1 < Entry.Count) ? Entry[ChapterLeftPage + 1] : null;
                    }
                }

            RichTextComponentBase[] richStack = new RichTextComponentBase[] { new ItemstackTextComponent(capi, capi.World.Player.Entity.LeftHandItemSlot.Itemstack, 128.0) };

            base.SingleComposer = gui.CreateCompo(dialogId, dialogBounds).BeginChildElements(childBounds).
                AddStaticImage(new AssetLocation(MOD_ID + ":" + "textures/dialogs/test.png"), JournalBlankBounds, Operator.Over).
                AddStaticImage(new AssetLocation(MOD_ID + ":" + "textures/dialogs/1.png"), TestIconBounds, Operator.Atop).
                AddRichtext(richStack, ItemStackIconBounds).//AddIf(leftPageNumber == 0).
                AddButton("", new ActionConsumable(this.OnLeftPage), ElementBounds.Fixed(0.0, 0.0, 105.0, 700), EnumButtonStyle.None).
                AddButton("", new ActionConsumable(this.OnRightPage), ElementBounds.Fixed(986, 0.0, 105.0, 700), EnumButtonStyle.None).

                AddIf(leftPageNumber > 0).
                AddStaticText(this.leftPageNumber.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Normal).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(60.0, 50.0, 50.0, 50.0), null).
                EndIf().
                AddStaticText(this.rightPageNumber.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Normal).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(1000.0, 50.0, 50.0, 50.0), null).

                //Chapter Titles
                AddIf(Chapter < JournalTitleEntries.Count && ChapterLeftPage == 0).
                AddStaticTextAutoFontSize(JournalTitleEntries[Chapter].MainTitle, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(1000.0, 50.0, 300.0, 300.0)).
                EndIf().

                //Left Page
                AddIf(ChapterLeftPage > 0).
                
                //Page Entry
                AddIf(currentLeftPage is PageEntry).
                //AddIf(((PageEntry)currentLeftPage).Title != null && ((PageEntry)currentLeftPage).MainText != null).
                AddStaticTextAutoFontSize(((PageEntry)currentLeftPage).Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((PageEntry)currentLeftPage).MainText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0)).
                AddIf(((PageEntry)currentLeftPage).ImageSpecialText != null).
                AddStaticTextAutoFontSize(((PageEntry)currentLeftPage).ImageSpecialText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0)).
                AddIf(((CookingEntry)currentLeftPage).Step2 != null).
                AddStaticImage(new AssetLocation(ASSETDOMAIN + ((PageEntry)currentLeftPage).ImagePath), TestIconBounds, Operator.Atop).
                EndIf().EndIf().EndIf().
                /*
                //Ore Entry
                AddIf(currentLeftPage is OreEntry).AddIf(((OreEntry)currentLeftPage).Title != null && ((OreEntry)currentLeftPage).Uses != null).
                AddStaticTextAutoFontSize(((OreEntry)currentLeftPage).Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((OreEntry)currentLeftPage).Uses, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((OreEntry)currentLeftPage).Depth, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                //also do Arrays for a Composer Helper soon?
                AddIf(((OreEntry)currentLeftPage).Formula != null).
                AddStaticTextAutoFontSize(((OreEntry)currentLeftPage).Formula, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0)).
                AddIf(((CookingEntry)currentLeftPage).Step2 != null).
                AddStaticImage(new AssetLocation(ASSETDOMAIN + ((OreEntry)currentLeftPage).ImagePath), TestIconBounds, Operator.Atop).
                EndIf().EndIf().EndIf().EndIf().

                //Fauna Entry
                AddIf(currentLeftPage is FaunaEntry).AddIf(((FaunaEntry)currentLeftPage).Title != null && ((FaunaEntry)currentLeftPage).LatinName != null).
                AddStaticTextAutoFontSize(((FaunaEntry)currentLeftPage).Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((FaunaEntry)currentLeftPage).LatinName, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((FaunaEntry)currentLeftPage).Habitat, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                AddIf(((CookingEntry)currentLeftPage).Step2 != null).
                AddStaticImage(new AssetLocation(ASSETDOMAIN + ((FaunaEntry)currentLeftPage).ImagePath), TestIconBounds, Operator.Atop).
                EndIf().EndIf().EndIf().

                //Flora Entry
                AddIf(currentLeftPage is FloraEntry).AddIf(((FloraEntry)currentLeftPage).Title != null && ((FloraEntry)currentLeftPage).Uses != null).
                AddStaticTextAutoFontSize(((FloraEntry)currentLeftPage).Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((FloraEntry)currentLeftPage).LatinName, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((FloraEntry)currentLeftPage).Uses, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((FloraEntry)currentLeftPage).Notes, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                AddIf(((FloraEntry)currentLeftPage).SpecialNote != null).
                AddStaticTextAutoFontSize(((FloraEntry)currentLeftPage).SpecialNote, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0)).
                AddIf(((CookingEntry)currentLeftPage).Step2 != null).
                AddStaticImage(new AssetLocation(ASSETDOMAIN + ((FloraEntry)currentLeftPage).ImagePath), TestIconBounds, Operator.Atop).
                EndIf().EndIf().EndIf().EndIf().

                //Cooking Entry
                AddIf(currentLeftPage is CookingEntry).AddIf(((CookingEntry)currentLeftPage).Title != null && ((CookingEntry)currentLeftPage).Step1 != null).
                AddStaticTextAutoFontSize(((CookingEntry)currentLeftPage).Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((CookingEntry)currentLeftPage).PrepTime.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((CookingEntry)currentLeftPage).Yield, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((CookingEntry)currentLeftPage).Step1, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((CookingEntry)currentLeftPage).Step1Body, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                //Optional Second Step
                AddIf(((CookingEntry)currentLeftPage).Step2 != null).
                AddStaticTextAutoFontSize(((CookingEntry)currentLeftPage).Step2, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((CookingEntry)currentLeftPage).Step2Body, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                AddIf(((CookingEntry)currentLeftPage).Step2 != null).
                AddStaticImage(new AssetLocation(ASSETDOMAIN + ((CookingEntry)currentLeftPage).ImagePath), TestIconBounds, Operator.Atop).
                EndIf().EndIf().EndIf().EndIf().

                //Construct Entry
                AddIf(currentLeftPage is ConstructEntry).AddIf(((ConstructEntry)currentLeftPage).Title != null && ((ConstructEntry)currentLeftPage).MainText != null).
                AddStaticTextAutoFontSize(((ConstructEntry)currentLeftPage).Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((ConstructEntry)currentLeftPage).MainText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0)).
                AddStaticTextAutoFontSize(((ConstructEntry)currentLeftPage).Materials, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0)).
                AddIf(((CookingEntry)currentLeftPage).Step2 != null).
                AddStaticImage(new AssetLocation(ASSETDOMAIN + ((ConstructEntry)currentLeftPage).ImagePath), TestIconBounds, Operator.Atop).
                EndIf().
                */
                EndIf().
                EndChildElements();

            base.SingleComposer.Compose(true);
        }

        private bool OnRightPage()
        {
            Console.WriteLine(1);
            leftPageNumber++;
            rightPageNumber = leftPageNumber + 1;
            this.SetupDialogJournal();
            return true;
        }

        private bool OnLeftPage()
        {
            if (this.rightPageNumber > 0)
            {
                Console.WriteLine(2);
                leftPageNumber--;
                rightPageNumber = leftPageNumber + 1;
                this.SetupDialogJournal();
            }
            return true;
        }
    }
}
