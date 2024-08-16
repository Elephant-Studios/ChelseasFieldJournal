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
            if (!composer.Composed && leftPage != null)
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
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftTextEntry.ImagePath + ".png"), ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0), Operator.Atop);
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
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftOreEntry.ImagePath + ".png"), ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (leftPage is FaunaEntry leftFaunaEntry)
                {
                    composer.AddStaticText(leftFaunaEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(leftFaunaEntry.LatinName, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftFaunaEntry.Habitat, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftFaunaEntry.ImagePath + ".png"), ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0), Operator.Atop);
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
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftFloraEntry.ImagePath + ".png"), ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0), Operator.Atop);
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
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftCookingEntry.ImagePath + ".png"), ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
                else if (leftPage is ConstructEntry leftConstructEntry)
                {
                    composer.AddStaticText(leftConstructEntry.Title, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 50.0, 300.0, 300.0));
                    composer.AddStaticText(leftConstructEntry.MainText, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(100.0, 400.0, 300.0, 300.0));
                    composer.AddStaticText(leftConstructEntry.Materials, CairoFont.WhiteMediumText().WithWeight(FontWeight.Bold).WithColor(ColorUtil.BlackArgbDouble), ElementBounds.Fixed(300.0, 400.0, 300.0, 300.0));
                    composer.AddStaticImage(new AssetLocation(ASSETDOMAIN + leftConstructEntry.ImagePath + ".png"), ElementBounds.Fixed(650.0, 100.0, 256.0, 196.0), Operator.Atop);
                }
            }
            return composer;
        }
    }
}
    