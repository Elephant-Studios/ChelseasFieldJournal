using Cairo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace ChelseasFieldJournal.src.GUI
{
    public static class GuiComposerHelpers
    {
        public static GuiComposer AddStaticImage(
          this GuiComposer composer,
          AssetLocation imageAsset,
          ElementBounds bounds,
          Operator blendMode = 2)
        {
            if (!composer.Composed)
                composer.AddStaticElement((GuiElement)new GuiElementImage(composer.Api, bounds, imageAsset, blendMode), (string)null);
            return composer;
        }

        public static GuiComposer AddSkillItemRMGrid(
          this GuiComposer composer,
          List<SkillItemRM> skillItems,
          int columns,
          int rows,
          Action<int> OnSlotClick,
          ElementBounds bounds,
          double paddingforXYIn,
          double selectedelementsizeIn,
          int skilloffsetIn,
          string key = null)
        {
            if (!composer.Composed)
                composer.AddInteractiveElement((GuiElement)new GuiElementSkillItemGridRM(composer.Api, skillItems, columns, rows, OnSlotClick, bounds, paddingforXYIn, selectedelementsizeIn, skilloffsetIn), key);
            return composer;
        }
    }
}
