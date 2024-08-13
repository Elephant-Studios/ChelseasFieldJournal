using Cairo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

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
    }
}
    