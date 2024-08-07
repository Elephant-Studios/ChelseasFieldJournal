using Cairo;
using Ele.ChelseasFieldJournal;
using Ele.Utility;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace ChelseasFieldJournal.src.GUI
{
    public class GuiElementImage : GuiElementTextBase
    {
        private readonly AssetLocation _imageAsset;
        private readonly Operator _blendMode;

        public GuiElementImage(
          ICoreClientAPI capi,
          ElementBounds bounds,
          AssetLocation imageAsset,
          Operator blendMode)
          : base(capi, "", (CairoFont)null, bounds)
        {
            this._imageAsset = imageAsset;
            this._blendMode = blendMode;
            ((GuiElement)this).RenderAsPremultipliedAlpha = true;
        }

        public virtual void ComposeElements(Context context, ImageSurface originalSurface)
        {
            context.Save();
            Operator @operator = context.Operator;
            context.Operator = this._blendMode;
            ImageSurface surfaceFromAsset = GuiElement.getImageSurfaceFromAsset(this.api, this._imageAsset, (int)byte.MaxValue);
            double num1 = ((GuiElement)this).Bounds.OuterWidth / (double)surfaceFromAsset.Width;
            double num2 = ((GuiElement)this).Bounds.OuterHeight / (double)surfaceFromAsset.Height;
            context.SetSourceRGBA(0.0, 0.0, 0.0, 0.0);
            context.SetSource((Surface)surfaceFromAsset);
            context.Scale(num1, num2);
            ((Surface)surfaceFromAsset).Show(context, ((GuiElement)this).Bounds.drawX / num1, ((GuiElement)this).Bounds.drawY / num2);
            context.Operator = @operator;
            context.Restore();
        }
    }
}
