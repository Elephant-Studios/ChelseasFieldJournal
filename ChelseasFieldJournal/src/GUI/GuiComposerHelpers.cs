using Cairo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using static Ele.ChelseasFieldJournal.ModConstants;
using static Ele.ChelseasFieldJournal.JournalEntryManager;

namespace Ele.ChelseasFieldJournal
{
    public static class GuiComposerHelpers
    {

        public static GuiComposer AddStaticImage(this GuiComposer composer, AssetLocation imageAsset, ElementBounds bounds, Operator blendMode = Operator.Over)
        {
            if (!composer.Composed)
            {
                composer.AddStaticElement(new GuiElementImage(composer.Api, bounds, imageAsset, blendMode), null);
            }
            return composer;
        }

        public static GuiComposer AddLeftPage(this GuiComposer composer, Object leftPage)
        {
            if (!composer.Composed && leftPage != null && leftPage is IPageEntry)
            {
                if (leftPage is TextEntry leftTextEntry && leftTextEntry.Title != null && leftTextEntry.MainText != null)
                {
                    Console.WriteLine(leftTextEntry.Title);
                    composer.AddStaticText(leftTextEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(leftTextEntry.MainText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0));
                    if (leftTextEntry.ImageSpecialText != null)
                    {
                        composer.AddStaticText(leftTextEntry.ImageSpecialText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0));
                    }
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftTextEntry.ImagePath + ".png"), ElementBounds.Fixed(300.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (leftPage is OreEntry leftOreEntry)
                {
                    composer.AddStaticText(leftOreEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(leftOreEntry.Uses, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftOreEntry.Depth, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    if (leftOreEntry.Formula != null)
                    {
                        composer.AddStaticText(leftOreEntry.Formula, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0));
                    }
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftOreEntry.ImagePath + ".png"), ElementBounds.Fixed(300.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (leftPage is FaunaEntry leftFaunaEntry)
                {
                    composer.AddStaticText(leftFaunaEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(leftFaunaEntry.LatinName, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftFaunaEntry.Habitat, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftFaunaEntry.ImagePath + ".png"), ElementBounds.Fixed(300.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (leftPage is FloraEntry leftFloraEntry)
                {
                    composer.AddStaticText(leftFloraEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(leftFloraEntry.LatinName, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftFloraEntry.Uses, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftFloraEntry.Notes, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    if (leftFloraEntry.SpecialNote != null)
                    {
                        composer.AddStaticText(leftFloraEntry.SpecialNote, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0));
                    }
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftFloraEntry.ImagePath + ".png"), ElementBounds.Fixed(300.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (leftPage is CookingEntry leftCookingEntry)
                {
                    composer.AddStaticText(leftCookingEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(leftCookingEntry.PrepTime.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftCookingEntry.Yield, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftCookingEntry.Step1, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftCookingEntry.Step1Body, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    if (leftCookingEntry.Step2 != null)
                    {
                        composer.AddStaticText(leftCookingEntry.Step2, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0));
                        composer.AddStaticText(leftCookingEntry.Step2Body, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    }
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftCookingEntry.ImagePath + ".png"), ElementBounds.Fixed(300.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (leftPage is ConstructEntry leftConstructEntry)
                {
                    composer.AddStaticText(leftConstructEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(leftConstructEntry.MainText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftConstructEntry.Materials, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftConstructEntry.ImagePath + ".png"), ElementBounds.Fixed(300.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
            }
            return composer;
        }

        public static GuiComposer AddRightPage(this GuiComposer composer, Object rightPage)
        {
            if (!composer.Composed && rightPage != null && rightPage is IPageEntry)
            {
                if (rightPage is TextEntry rightTextEntry && rightTextEntry.Title != null && rightTextEntry.MainText != null)
                {
                    Console.WriteLine(rightTextEntry.Title);
                    composer.AddStaticText(rightTextEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(rightTextEntry.MainText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(700.0, 400.0, 300.0, 300.0));
                    if (rightTextEntry.ImageSpecialText != null)
                    {
                        composer.AddStaticText(rightTextEntry.ImageSpecialText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 50.0, 300.0, 300.0));
                    }
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + rightTextEntry.ImagePath + ".png"), ElementBounds.Fixed(900.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (rightPage is OreEntry rightOreEntry)
                {
                    composer.AddStaticText(rightOreEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(rightOreEntry.Uses, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(700.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(rightOreEntry.Depth, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(800.0, 400.0, 300.0, 300.0));
                    if (rightOreEntry.Formula != null)
                    {
                        composer.AddStaticText(rightOreEntry.Formula, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(800.0, 50.0, 300.0, 300.0));
                    }
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + rightOreEntry.ImagePath + ".png"), ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (rightPage is FaunaEntry rightFaunaEntry)
                {
                    composer.AddStaticText(rightFaunaEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(rightFaunaEntry.LatinName, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(rightFaunaEntry.Habitat, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 400.0, 300.0, 300.0));
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + rightFaunaEntry.ImagePath + ".png"), ElementBounds.Fixed(900.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (rightPage is FloraEntry rightFloraEntry)
                {
                    composer.AddStaticText(rightFloraEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(rightFloraEntry.LatinName, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(rightFloraEntry.Uses, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(rightFloraEntry.Notes, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(700.0, 400.0, 300.0, 300.0));
                    if (rightFloraEntry.SpecialNote != null)
                    {
                        composer.AddStaticText(rightFloraEntry.SpecialNote, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(900.0, 50.0, 300.0, 300.0));
                    }
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + rightFloraEntry.ImagePath + ".png"), ElementBounds.Fixed(900.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (rightPage is CookingEntry rightCookingEntry)
                {
                    composer.AddStaticText(rightCookingEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(rightCookingEntry.PrepTime.ToString(), CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(rightCookingEntry.Yield, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(rightCookingEntry.Step1, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(rightCookingEntry.Step1Body, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 400.0, 300.0, 300.0));
                    if (rightCookingEntry.Step2 != null)
                    {
                        composer.AddStaticText(rightCookingEntry.Step2, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(700.0, 50.0, 300.0, 300.0));
                        composer.AddStaticText(rightCookingEntry.Step2Body, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 400.0, 300.0, 300.0));
                    }
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + rightCookingEntry.ImagePath + ".png"), ElementBounds.Fixed(900.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (rightPage is ConstructEntry rightConstructEntry)
                {
                    composer.AddStaticText(rightConstructEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(rightConstructEntry.MainText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(500.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(rightConstructEntry.Materials, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(600.0, 400.0, 300.0, 300.0));
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + rightConstructEntry.ImagePath + ".png"), ElementBounds.Fixed(900.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
            }
            return composer;
        }
    }
}
    