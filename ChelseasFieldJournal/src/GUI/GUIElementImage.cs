using Cairo;
using Ele.ChelseasFieldJournal;
using Ele.Utility;
using SkiaSharp;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace ChelseasFieldJournal
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

        public override void ComposeElements(Context context, ImageSurface originalSurface)
        {
            //base.ComposeElements(context, originalSurface);
            //Font.SetupContext(context);
            Bounds.CalcWorldBounds();
            ComposeTextElements(context, originalSurface);
            context.Save();
            Operator @operator = context.Operator;
            context.Operator = this._blendMode;
            using ImageSurface surfaceFromAsset = GuiElement.getImageSurfaceFromAsset(this.api, this._imageAsset, (int)byte.MaxValue);
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
