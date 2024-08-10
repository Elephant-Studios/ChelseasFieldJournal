using Cairo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace ChelseasFieldJournal
{
    public static class GuiComposerHelpers
    {

        public static GuiElementColorListPicker GetColorListPicker(this GuiComposer composer, string key)
        {
            return (GuiElementColorListPicker)composer.GetElement(key);
        }

        public static void ColorListPickerSetValue(this GuiComposer composer, string key, int selectedIndex)
        {
            int i = 0;
            GuiElementColorListPicker btn;
            while ((btn = composer.GetColorListPicker(key + "-" + i.ToString())) != null)
            {
                btn.SetValue(i == selectedIndex);
                i++;
            }
        }
        public static GuiComposer AddStaticImage(this GuiComposer composer, AssetLocation imageAsset, ElementBounds bounds, Operator blendMode = Operator.Over)
        {
            bool flag = !composer.Composed;
            //if (flag)
            
                composer.AddStaticElement(new GuiElementImage(composer.Api, bounds, imageAsset, blendMode), null);
            
            return composer;
        }

        public static GuiComposer AddColorListPicker(this GuiComposer composer, int[] colors, Action<int> onToggle, ElementBounds startBounds, int maxLineWidth, string key = null)
        {
            return composer.AddElementListPicker(typeof(GuiElementColorListPicker), colors, onToggle, startBounds, maxLineWidth, key);
        }

        public static GuiComposer AddCompactVerticalScrollbar(this GuiComposer composer, Action<float> onNewScrollbarValue, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementCompactScrollbar(composer.Api, onNewScrollbarValue, bounds), key);
            }
            return composer;
        }

        public static GuiElementCompactScrollbar GetCompactScrollbar(this GuiComposer composer, string key)
        {
            return (GuiElementCompactScrollbar)composer.GetElement(key);
        }

        public static GuiComposer AddMultiSelectDropDown(this GuiComposer composer, string[] values, string[] names, int selectedIndex, SelectionChangedDelegate onSelectionChanged, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementDropDown(composer.Api, values, names, selectedIndex, onSelectionChanged, bounds, CairoFont.WhiteSmallText(), true), key);
            }
            return composer;
        }

        public static GuiComposer AddDropDown(this GuiComposer composer, string[] values, string[] names, int selectedIndex, SelectionChangedDelegate onSelectionChanged, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementDropDown(composer.Api, values, names, selectedIndex, onSelectionChanged, bounds, CairoFont.WhiteSmallText(), false), key);
            }
            return composer;
        }

        public static GuiComposer AddDropDown(this GuiComposer composer, string[] values, string[] names, int selectedIndex, SelectionChangedDelegate onSelectionChanged, ElementBounds bounds, CairoFont font, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementDropDown(composer.Api, values, names, selectedIndex, onSelectionChanged, bounds, font, false), key);
            }
            return composer;
        }

        public static GuiElementDropDown GetDropDown(this GuiComposer composer, string key)
        {
            return (GuiElementDropDown)composer.GetElement(key);
        }

        public static GuiComposer AddElementListPicker<T>(this GuiComposer composer, Type pickertype, T[] elems, Action<int> onToggle, ElementBounds startBounds, int maxLineWidth, string key)
        {
            if (!composer.Composed)
            {
                if (key == null)
                {
                    key = "elementlistpicker";
                }
                int quantityButtons = elems.Length;
                double lineWidth = 0.0;
                for (int i = 0; i < elems.Length; i++)
                {
                    int index = i;
                    if (lineWidth > (double)maxLineWidth)
                    {
                        startBounds.fixedX -= lineWidth;
                        startBounds.fixedY += startBounds.fixedHeight + 5.0;
                        lineWidth = 0.0;
                    }
                    GuiElement elem = Activator.CreateInstance(pickertype, new object[]
                    {
                        composer.Api,
                        elems[i],
                        startBounds.FlatCopy()
                    }) as GuiElement;
                    composer.AddInteractiveElement(elem, key + "-" + i.ToString());
                    (composer[key + "-" + i.ToString()] as GuiElementElementListPickerBase<T>).handler = delegate (bool on)
                    {
                        if (on)
                        {
                            onToggle(index);
                            for (int j = 0; j < quantityButtons; j++)
                            {
                                if (j != index)
                                {
                                    (composer[key + "-" + j.ToString()] as GuiElementElementListPickerBase<T>).SetValue(false);
                                }
                            }
                            return;
                        }
                        (composer[key + "-" + index.ToString()] as GuiElementElementListPickerBase<T>).SetValue(true);
                    };
                    startBounds.fixedX += startBounds.fixedWidth + 5.0;
                    lineWidth += startBounds.fixedWidth + 5.0;
                }
            }
            return composer;
        }

        public static GuiComposer AddHorizontalTabs(this GuiComposer composer, GuiTab[] tabs, ElementBounds bounds, Action<int> onTabClicked, CairoFont font, CairoFont selectedFont, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementHorizontalTabs(composer.Api, tabs, font, selectedFont, bounds, onTabClicked), key);
            }
            return composer;
        }

        public static GuiElementHorizontalTabs GetHorizontalTabs(this GuiComposer composer, string key)
        {
            return (GuiElementHorizontalTabs)composer.GetElement(key);
        }

        public static GuiElementIconListPicker GetIconListPicker(this GuiComposer composer, string key)
        {
            return (GuiElementIconListPicker)composer.GetElement(key);
        }

        public static void IconListPickerSetValue(this GuiComposer composer, string key, int selectedIndex)
        {
            int i = 0;
            GuiElementIconListPicker btn;
            while ((btn = composer.GetIconListPicker(key + "-" + i.ToString())) != null)
            {
                btn.SetValue(i == selectedIndex);
                i++;
            }
        }

        public static GuiComposer AddIconListPicker(this GuiComposer composer, string[] icons, Action<int> onToggle, ElementBounds startBounds, int maxLineWidth, string key = null)
        {
            return composer.AddElementListPicker(typeof(GuiElementIconListPicker), icons, onToggle, startBounds, maxLineWidth, key);
        }

        public static GuiComposer AddVerticalScrollbar(this GuiComposer composer, Action<float> onNewScrollbarValue, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementScrollbar(composer.Api, onNewScrollbarValue, bounds), key);
            }
            return composer;
        }

        public static GuiElementScrollbar GetScrollbar(this GuiComposer composer, string key)
        {
            return (GuiElementScrollbar)composer.GetElement(key);
        }

        public static GuiComposer AddSlider(this GuiComposer composer, ActionConsumable<int> onNewSliderValue, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementSlider(composer.Api, onNewSliderValue, bounds), key);
            }
            return composer;
        }

        public static GuiElementSlider GetSlider(this GuiComposer composer, string key)
        {
            return (GuiElementSlider)composer.GetElement(key);
        }

        public static GuiComposer AddSwitch(this GuiComposer composer, Action<bool> onToggle, ElementBounds bounds, string key = null, double size = 30.0, double padding = 4.0)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementSwitch(composer.Api, onToggle, bounds, size, padding), key);
            }
            return composer;
        }

        public static GuiElementSwitch GetSwitch(this GuiComposer composer, string key)
        {
            return (GuiElementSwitch)composer.GetElement(key);
        }

        [Obsolete("Use Method without orientation argument")]
        public static GuiComposer AddButton(this GuiComposer composer, string text, ActionConsumable onClick, ElementBounds bounds, CairoFont buttonFont, EnumButtonStyle style, EnumTextOrientation orientation, string key = null)
        {
            return composer.AddButton(text, onClick, bounds, buttonFont, style, key);
        }

        [Obsolete("Use Method without orientation argument")]
        public static GuiComposer AddButton(this GuiComposer composer, string text, ActionConsumable onClick, ElementBounds bounds, EnumButtonStyle style, EnumTextOrientation orientation, string key = null)
        {
            return composer.AddButton(text, onClick, bounds, style, key);
        }

        [Obsolete("Use Method without orientation argument")]
        public static GuiComposer AddSmallButton(this GuiComposer composer, string text, ActionConsumable onClick, ElementBounds bounds, EnumButtonStyle style, EnumTextOrientation orientation, string key = null)
        {
            return composer.AddSmallButton(text, onClick, bounds, style, key);
        }

        public static GuiComposer AddButton(this GuiComposer composer, string text, ActionConsumable onClick, ElementBounds bounds, CairoFont buttonFont, EnumButtonStyle style = EnumButtonStyle.Normal, string key = null)
        {
            if (!composer.Composed)
            {
                CairoFont hoverFont = buttonFont.Clone().WithColor(GuiStyle.ActiveButtonTextColor);
                GuiElementTextButton elem = new GuiElementTextButton(composer.Api, text, buttonFont, hoverFont, onClick, bounds, style);
                elem.SetOrientation(buttonFont.Orientation);
                composer.AddInteractiveElement(elem, key);
            }
            return composer;
        }

        public static GuiComposer AddButton(this GuiComposer composer, string text, ActionConsumable onClick, ElementBounds bounds, EnumButtonStyle style = EnumButtonStyle.Normal, string key = null)
        {
            if (!composer.Composed)
            {
                GuiElementTextButton elem = new GuiElementTextButton(composer.Api, text, CairoFont.ButtonText(), CairoFont.ButtonPressedText(), onClick, bounds, style);
                elem.SetOrientation(CairoFont.ButtonText().Orientation);
                composer.AddInteractiveElement(elem, key);
            }
            return composer;
        }


        public static GuiComposer AddSmallButton(this GuiComposer composer, string text, ActionConsumable onClick, ElementBounds bounds, EnumButtonStyle style = EnumButtonStyle.Normal, string key = null)
        {
            if (!composer.Composed)
            {
                CairoFont font = CairoFont.ButtonText();
                CairoFont font2 = CairoFont.ButtonPressedText();
                font.Fontname = GuiStyle.StandardFontName;
                font2.Fontname = GuiStyle.StandardFontName;
                if (style != EnumButtonStyle.Small)
                {
                    font.FontWeight = FontWeight.Bold;
                    font2.FontWeight = FontWeight.Bold;
                }
                else
                {
                    font.FontWeight = 0;
                    font2.FontWeight = 0;
                }
                font.UnscaledFontsize = GuiStyle.SmallFontSize;
                font2.UnscaledFontsize = GuiStyle.SmallFontSize;
                GuiElementTextButton elem = new GuiElementTextButton(composer.Api, text, font, font2, onClick, bounds, style);
                elem.SetOrientation(font.Orientation);
                composer.AddInteractiveElement(elem, key);
            }
            return composer;
        }

        public static GuiElementTextButton GetButton(this GuiComposer composer, string key)
        {
            return (GuiElementTextButton)composer.GetElement(key);
        }

        public static GuiElementToggleButton GetToggleButton(this GuiComposer composer, string key)
        {
            return (GuiElementToggleButton)composer.GetElement(key);
        }

        public static GuiComposer AddToggleButton(this GuiComposer composer, string text, CairoFont font, Action<bool> onToggle, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementToggleButton(composer.Api, "", text, font, onToggle, bounds, true), key);
            }
            return composer;
        }

        public static GuiComposer AddIconButton(this GuiComposer composer, string icon, Action<bool> onToggle, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementToggleButton(composer.Api, icon, "", CairoFont.WhiteDetailText(), onToggle, bounds, false), key);
            }
            return composer;
        }
        public static void ToggleButtonsSetValue(this GuiComposer composer, string key, int selectedIndex)
        {
            int i = 0;
            GuiElementToggleButton btn;
            while ((btn = composer.GetToggleButton(key + "-" + i.ToString())) != null)
            {
                btn.SetValue(i == selectedIndex);
                i++;
            }
        }
        public static GuiComposer AddIconToggleButtons(this GuiComposer composer, string[] icons, CairoFont font, Action<int> onToggle, ElementBounds[] bounds, string key = null)
        {
            if (!composer.Composed)
            {
                int quantityButtons = icons.Length;
                for (int i = 0; i < icons.Length; i++)
                {
                    int index = i;
                    composer.AddInteractiveElement(new GuiElementToggleButton(composer.Api, icons[i], "", font, delegate (bool on)
                    {
                        if (on)
                        {
                            onToggle(index);
                            for (int j = 0; j < quantityButtons; j++)
                            {
                                if (j != index)
                                {
                                    composer.GetToggleButton(key + "-" + j.ToString()).SetValue(false);
                                }
                            }
                            return;
                        }
                        composer.GetToggleButton(key + "-" + index.ToString()).SetValue(true);
                    }, bounds[i], true), key + "-" + i.ToString());
                }
            }
            return composer;
        }

        public static GuiComposer AddTextToggleButtons(this GuiComposer composer, string[] texts, CairoFont font, Action<int> onToggle, ElementBounds[] bounds, string key = null)
        {
            if (!composer.Composed)
            {
                int quantityButtons = texts.Length;
                for (int i = 0; i < texts.Length; i++)
                {
                    int index = i;
                    composer.AddInteractiveElement(new GuiElementToggleButton(composer.Api, "", texts[i], font, delegate (bool on)
                    {
                        if (on)
                        {
                            onToggle(index);
                            for (int j = 0; j < quantityButtons; j++)
                            {
                                if (j != index)
                                {
                                    composer.GetToggleButton(key + "-" + j.ToString()).SetValue(false);
                                }
                            }
                            return;
                        }
                        composer.GetToggleButton(key + "-" + index.ToString()).SetValue(true);
                    }, bounds[i], true), key + "-" + i.ToString());
                }
            }
            return composer;
        }

        public static GuiComposer AddVerticalToggleTabs(this GuiComposer composer, GuiTab[] tabs, ElementBounds bounds, Action<int, GuiTab> onTabClicked, string key = null)
        {
            if (!composer.Composed)
            {
                CairoFont font = CairoFont.WhiteDetailText().WithFontSize(17f);
                CairoFont selectedFont = CairoFont.WhiteDetailText().WithFontSize(17f).WithColor(GuiStyle.ActiveButtonTextColor);
                composer.AddInteractiveElement(new GuiElementVerticalTabs(composer.Api, tabs, font, selectedFont, bounds, onTabClicked)
                {
                    ToggleTabs = true
                }, key);
            }
            return composer;
        }
        public static GuiComposer AddVerticalTabs(this GuiComposer composer, GuiTab[] tabs, ElementBounds bounds, Action<int, GuiTab> onTabClicked, string key = null)
        {
            if (!composer.Composed)
            {
                CairoFont font = CairoFont.WhiteDetailText().WithFontSize(17f);
                CairoFont selectedFont = CairoFont.WhiteDetailText().WithFontSize(17f).WithColor(GuiStyle.ActiveButtonTextColor);
                composer.AddInteractiveElement(new GuiElementVerticalTabs(composer.Api, tabs, font, selectedFont, bounds, onTabClicked), key);
            }
            return composer;
        }
        public static GuiElementVerticalTabs GetVerticalTab(this GuiComposer composer, string key)
        {
            return (GuiElementVerticalTabs)composer.GetElement(key);
        }
        public static GuiComposer AddCellList<T>(this GuiComposer composer, ElementBounds bounds, OnRequireCell<T> cellCreator, List<T> cells = null, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementCellList<T>(composer.Api, bounds, cellCreator, cells), key);
            }
            return composer;
        }

        public static GuiElementCellList<T> GetCellList<T>(this GuiComposer composer, string key)
        {
            return (GuiElementCellList<T>)composer.GetElement(key);
        }

        public static GuiComposer AddChatInput(this GuiComposer composer, ElementBounds bounds, Action<string> onTextChanged, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementChatInput(composer.Api, bounds, onTextChanged), key);
            }
            return composer;
        }

        public static GuiElementChatInput GetChatInput(this GuiComposer composer, string key)
        {
            return (GuiElementChatInput)composer.GetElement(key);
        }

        public static GuiComposer AddConfigList(this GuiComposer composer, List<ConfigItem> items, ConfigItemClickDelegate onItemClick, CairoFont font, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                GuiElementConfigList element = new GuiElementConfigList(composer.Api, items, onItemClick, font, bounds);
                composer.AddInteractiveElement(element, key);
            }
            return composer;
        }

        public static GuiElementConfigList GetConfigList(this GuiComposer composer, string key)
        {
            return (GuiElementConfigList)composer.GetElement(key);
        }

        public static GuiComposer AddContainer(this GuiComposer composer, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementContainer(composer.Api, bounds), key);
            }
            return composer;
        }

        public static GuiElementContainer GetContainer(this GuiComposer composer, string key)
        {
            return (GuiElementContainer)composer.GetElement(key);
        }

        public static GuiComposer AddDialogTitleBar(this GuiComposer composer, string text, Action onClose = null, CairoFont font = null, ElementBounds bounds = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementDialogTitleBar(composer.Api, text, composer, onClose, font, bounds), null);
            }
            return composer;
        }

        public static GuiComposer AddDialogTitleBarWithBg(this GuiComposer composer, string text, Action onClose = null, CairoFont font = null, ElementBounds bounds = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementDialogTitleBar(composer.Api, text, composer, onClose, font, bounds)
                {
                    drawBg = true
                }, null);
            }
            return composer;
        }

        public static GuiElementDialogTitleBar GetTitleBar(this GuiComposer composer, string key)
        {
            return (GuiElementDialogTitleBar)composer.GetElement(key);
        }

        public static GuiComposer AddNumberInput(this GuiComposer composer, ElementBounds bounds, Action<string> onTextChanged, CairoFont font = null, string key = null)
        {
            if (font == null)
            {
                font = CairoFont.TextInput();
            }
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementNumberInput(composer.Api, bounds, onTextChanged, font), key);
            }
            return composer;
        }

        public static GuiElementNumberInput GetNumberInput(this GuiComposer composer, string key)
        {
            return (GuiElementNumberInput)composer.GetElement(key);
        }

        public static GuiComposer AddStatbar(this GuiComposer composer, ElementBounds bounds, double[] color, bool hideable, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementStatbar(composer.Api, bounds, color, false, hideable), key);
            }
            return composer;
        }

        public static GuiComposer AddStatbar(this GuiComposer composer, ElementBounds bounds, double[] color, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementStatbar(composer.Api, bounds, color, false, false), key);
            }
            return composer;
        }
        public static GuiComposer AddInvStatbar(this GuiComposer composer, ElementBounds bounds, double[] color, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementStatbar(composer.Api, bounds, color, true, false), key);
            }
            return composer;
        }

        public static GuiElementStatbar GetStatbar(this GuiComposer composer, string key)
        {
            return (GuiElementStatbar)composer.GetElement(key);
        }

        public static GuiComposer AddTextArea(this GuiComposer composer, ElementBounds bounds, Action<string> onTextChanged, CairoFont font = null, string key = null)
        {
            if (font == null)
            {
                font = CairoFont.SmallTextInput();
            }
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementTextArea(composer.Api, bounds, onTextChanged, font), key);
            }
            return composer;
        }

        public static GuiElementTextArea GetTextArea(this GuiComposer composer, string key)
        {
            return (GuiElementTextArea)composer.GetElement(key);
        }

        public static GuiComposer AddTextInput(this GuiComposer composer, ElementBounds bounds, Action<string> onTextChanged, CairoFont font = null, string key = null)
        {
            if (font == null)
            {
                font = CairoFont.TextInput();
            }
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementTextInput(composer.Api, bounds, onTextChanged, font), key);
            }
            return composer;
        }

        public static GuiElementTextInput GetTextInput(this GuiComposer composer, string key)
        {
            return (GuiElementTextInput)composer.GetElement(key);
        }
        /*
        public static GuiComposer AddItemSlotGrid(this GuiComposer composer, IInventory inventory, Action<object> sendPacket, int columns, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementItemSlotGrid(composer.Api, inventory, sendPacket, columns, null, bounds), key);
                GuiElementItemSlotGridBase.UpdateLastSlotGridFlag(composer);
            }
            return composer;
        }

        public static GuiComposer AddItemSlotGrid(this GuiComposer composer, IInventory inventory, Action<object> sendPacket, int columns, int[] selectiveSlots, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementItemSlotGrid(composer.Api, inventory, sendPacket, columns, selectiveSlots, bounds), key);
                GuiElementItemSlotGridBase.UpdateLastSlotGridFlag(composer);
            }
            return composer;
        }

        public static GuiElementItemSlotGrid GetSlotGrid(this GuiComposer composer, string key)
        {
            return (GuiElementItemSlotGrid)composer.GetElement(key);
        }

        public static GuiComposer AddItemSlotGridExcl(this GuiComposer composer, IInventory inventory, Action<object> sendPacket, int columns, int[] excludingSlots, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementItemSlotGridExcl(composer.Api, inventory, sendPacket, columns, excludingSlots, bounds), key);
                GuiElementItemSlotGridBase.UpdateLastSlotGridFlag(composer);
            }
            return composer;
        }*/

        public static GuiElementItemSlotGridExcl GetSlotGridExcl(this GuiComposer composer, string key)
        {
            return (GuiElementItemSlotGridExcl)composer.GetElement(key);
        }

        public static GuiComposer AddPassiveItemSlot(this GuiComposer composer, ElementBounds bounds, IInventory inventory, ItemSlot slot, bool drawBackground = true)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementPassiveItemSlot(composer.Api, bounds, inventory, slot, drawBackground), null);
            }
            return composer;
        }

        public static GuiComposer AddSkillItemGrid(this GuiComposer composer, List<SkillItem> skillItems, int columns, int rows, Action<int> onSlotClick, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementSkillItemGrid(composer.Api, skillItems, columns, rows, onSlotClick, bounds), key);
            }
            return composer;
        }

        public static GuiElementSkillItemGrid GetSkillItemGrid(this GuiComposer composer, string key)
        {
            return (GuiElementSkillItemGrid)composer.GetElement(key);
        }

        public static GuiComposer AddEmbossedText(this GuiComposer composer, string text, CairoFont font, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementEmbossedText(composer.Api, text, font, bounds), key);
            }
            return composer;
        }

        public static GuiElementEmbossedText GetEmbossedText(this GuiComposer composer, string key)
        {
            return (GuiElementEmbossedText)composer.GetElement(key);
        }

        public static GuiComposer AddHoverText(this GuiComposer composer, string text, CairoFont font, int width, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                GuiElementHoverText elem = new GuiElementHoverText(composer.Api, text, font, width, bounds, null);
                composer.AddInteractiveElement(elem, key);
            }
            return composer;
        }

        public static GuiComposer AddAutoSizeHoverText(this GuiComposer composer, string text, CairoFont font, int width, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                GuiElementHoverText elem = new GuiElementHoverText(composer.Api, text, font, width, bounds, null);
                elem.SetAutoWidth(true);
                composer.AddInteractiveElement(elem, key);
            }
            return composer;
        }

        public static GuiComposer AddTranspHoverText(this GuiComposer composer, string text, CairoFont font, int width, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                GuiElementHoverText elem = new GuiElementHoverText(composer.Api, text, font, width, bounds, new TextBackground());
                composer.AddInteractiveElement(elem, key);
            }
            return composer;
        }

        public static GuiComposer AddHoverText(this GuiComposer composer, string text, CairoFont font, int width, ElementBounds bounds, TextBackground background, string key = null)
        {
            if (!composer.Composed)
            {
                GuiElementHoverText elem = new GuiElementHoverText(composer.Api, text, font, width, bounds, background);
                composer.AddInteractiveElement(elem, key);
            }
            return composer;
        }

        public static GuiElementHoverText GetHoverText(this GuiComposer composer, string key)
        {
            return (GuiElementHoverText)composer.GetElement(key);
        }

        public static GuiComposer AddRichtext(this GuiComposer composer, string vtmlCode, CairoFont baseFont, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementRichtext(composer.Api, VtmlUtil.Richtextify(composer.Api, vtmlCode, baseFont, null), bounds), key);
            }
            return composer;
        }

        public static GuiComposer AddRichtext(this GuiComposer composer, string vtmlCode, CairoFont baseFont, ElementBounds bounds, Action<LinkTextComponent> didClickLink, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementRichtext(composer.Api, VtmlUtil.Richtextify(composer.Api, vtmlCode, baseFont, didClickLink), bounds), key);
            }
            return composer;
        }

        public static GuiComposer AddRichtext(this GuiComposer composer, RichTextComponentBase[] components, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementRichtext(composer.Api, components, bounds), key);
            }
            return composer;
        }

        public static GuiElementRichtext GetRichtext(this GuiComposer composer, string key)
        {
            return (GuiElementRichtext)composer.GetElement(key);
        }

        public static GuiComposer AddCustomRender(this GuiComposer composer, ElementBounds bounds, RenderDelegateWithBounds onRender)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementCustomRender(composer.Api, bounds, onRender), null);
            }
            return composer;
        }

        public static GuiElementCustomRender GetCustomRender(this GuiComposer composer, string key)
        {
            return (GuiElementCustomRender)composer.GetElement(key);
        }

        public static GuiComposer AddStaticCustomDraw(this GuiComposer composer, ElementBounds bounds, DrawDelegateWithBounds onDraw)
        {
            if (!composer.Composed)
            {
                composer.AddStaticElement(new GuiElementCustomDraw(composer.Api, bounds, onDraw, false), null);
            }
            return composer;
        }

        public static GuiComposer AddDynamicCustomDraw(this GuiComposer composer, ElementBounds bounds, DrawDelegateWithBounds onDraw, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddInteractiveElement(new GuiElementCustomDraw(composer.Api, bounds, onDraw, true), key);
            }
            return composer;
        }

        public static GuiElementCustomDraw GetCustomDraw(this GuiComposer composer, string key)
        {
            return (GuiElementCustomDraw)composer.GetElement(key);
        }

        public static GuiComposer AddShadedDialogBG(this GuiComposer composer, ElementBounds bounds, bool withTitleBar = true, double strokeWidth = 5.0, float alpha = 0.75f)
        {
            if (!composer.Composed)
            {
                composer.AddStaticElement(new GuiElementDialogBackground(composer.Api, bounds, withTitleBar, strokeWidth, alpha), null);
            }
            return composer;
        }

       
        public static GuiComposer AddDialogBG(this GuiComposer composer, ElementBounds bounds, bool withTitleBar = true, float alpha = 1f)
        {
            if (!composer.Composed)
            {
                composer.AddStaticElement(new GuiElementDialogBackground(composer.Api, bounds, withTitleBar, 0.0, alpha)
                {
                    Shade = false
                }, null);
            }
            return composer;
        }

        public static GuiComposer AddStaticText(this GuiComposer composer, string text, CairoFont font, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddStaticElement(new GuiElementStaticText(composer.Api, text, font.Orientation, bounds, font), key);
            }
            return composer;
        }

        public static GuiComposer AddStaticText(this GuiComposer composer, string text, CairoFont font, EnumTextOrientation orientation, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                composer.AddStaticElement(new GuiElementStaticText(composer.Api, text, orientation, bounds, font), key);
            }
            return composer;
        }

        public static GuiComposer AddStaticTextAutoBoxSize(this GuiComposer composer, string text, CairoFont font, EnumTextOrientation orientation, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                GuiElementStaticText elem = new GuiElementStaticText(composer.Api, text, orientation, bounds, font);
                composer.AddStaticElement(elem, key);
                elem.AutoBoxSize(false);
            }
            return composer;
        }

        public static GuiComposer AddStaticTextAutoFontSize(this GuiComposer composer, string text, CairoFont font, ElementBounds bounds, string key = null)
        {
            if (!composer.Composed)
            {
                GuiElementStaticText elem = new GuiElementStaticText(composer.Api, text, font.Orientation, bounds, font);
                composer.AddStaticElement(elem, key);
                elem.AutoFontSize(true);
            }
            return composer;
        }

        public static GuiElementStaticText GetStaticText(this GuiComposer composer, string key)
        {
            return (GuiElementStaticText)composer.GetElement(key);
        }
    }
}
    