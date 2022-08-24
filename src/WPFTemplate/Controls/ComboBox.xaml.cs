using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
	public class ComboBox : System.Windows.Controls.ComboBox
	{
        /*public static readonly DependencyProperty BackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
		new public Brush Background { get => (Brush)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

        public static readonly DependencyProperty BorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(BorderBrush), "#FFACACAC".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

        public static readonly DependencyProperty ForegroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(Foreground), "#00000000".ToBrush());
		new public Brush Foreground { get => (Brush)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }*/

		public static readonly DependencyProperty StaticGlyphDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticGlyph), "#FF606060".ToBrush());
		public Brush StaticGlyph { get => (Brush)GetValue(StaticGlyphDP); set => SetValue(StaticGlyphDP, value); }

		public static readonly DependencyProperty StaticEditableBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticEditableBackground), "#FFFFFFFF".ToBrush());
		public Brush StaticEditableBackground { get => (Brush)GetValue(StaticEditableBackgroundDP); set => SetValue(StaticEditableBackgroundDP, value); }

		public static readonly DependencyProperty StaticEditableBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticEditableBorderBrush), "#FFABADB3".ToBrush());
		public Brush StaticEditableBorderBrush { get => (Brush)GetValue(StaticEditableBorderBrushDP); set => SetValue(StaticEditableBorderBrushDP, value); }

		public static readonly DependencyProperty StaticEditableButtonBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticEditableButtonBackground), "Transparent".ToBrush());
		public Brush StaticEditableButtonBackground { get => (Brush)GetValue(StaticEditableButtonBackgroundDP); set => SetValue(StaticEditableButtonBackgroundDP, value); }

		public static readonly DependencyProperty StaticEditableButtonBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticEditableButtonBorderBrush), "Transparent".ToBrush());
		public Brush StaticEditableButtonBorderBrush { get => (Brush)GetValue(StaticEditableButtonBorderBrushDP); set => SetValue(StaticEditableButtonBorderBrushDP, value); }

		public static readonly DependencyProperty MouseOverBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverBorderBrush), "#FF7EB4EA".ToBrush());
		public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushDP); set => SetValue(MouseOverBorderBrushDP, value); }

		public static readonly DependencyProperty MouseOverGlyphDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverGlyph), "#FF000000".ToBrush());
		public Brush MouseOverGlyph { get => (Brush)GetValue(MouseOverGlyphDP); set => SetValue(MouseOverGlyphDP, value); }

		public static readonly DependencyProperty MouseOverEditableBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverEditableBackground), "#FFFFFFFF".ToBrush());
		public Brush MouseOverEditableBackground { get => (Brush)GetValue(MouseOverEditableBackgroundDP); set => SetValue(MouseOverEditableBackgroundDP, value); }

		public static readonly DependencyProperty MouseOverEditableBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverEditableBorderBrush), "#FF7EB4EA".ToBrush());
		public Brush MouseOverEditableBorderBrush { get => (Brush)GetValue(MouseOverEditableBorderBrushDP); set => SetValue(MouseOverEditableBorderBrushDP, value); }

		public static readonly DependencyProperty MouseOverEditableButtonBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverEditableButtonBorderBrush), "#FF7EB4EA".ToBrush());
		public Brush MouseOverEditableButtonBorderBrush { get => (Brush)GetValue(MouseOverEditableButtonBorderBrushDP); set => SetValue(MouseOverEditableButtonBorderBrushDP, value); }

		public static readonly DependencyProperty PressedBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedBorderBrush), "#FF569DE5".ToBrush());
		public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushDP); set => SetValue(PressedBorderBrushDP, value); }

		public static readonly DependencyProperty PressedGlyphDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedGlyph), "#FF000000".ToBrush());
		public Brush PressedGlyph { get => (Brush)GetValue(PressedGlyphDP); set => SetValue(PressedGlyphDP, value); }

		public static readonly DependencyProperty PressedEditableBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedEditableBackground), "#FFFFFFFF".ToBrush());
		public Brush PressedEditableBackground { get => (Brush)GetValue(PressedEditableBackgroundDP); set => SetValue(PressedEditableBackgroundDP, value); }

		public static readonly DependencyProperty PressedEditableBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedEditableBorderBrush), "#FF569DE5".ToBrush());
		public Brush PressedEditableBorderBrush { get => (Brush)GetValue(PressedEditableBorderBrushDP); set => SetValue(PressedEditableBorderBrushDP, value); }

		public static readonly DependencyProperty PressedEditableButtonBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedEditableButtonBorderBrush), "#FF569DE5".ToBrush());
		public Brush PressedEditableButtonBorderBrush { get => (Brush)GetValue(PressedEditableButtonBorderBrushDP); set => SetValue(PressedEditableButtonBorderBrushDP, value); }

		public static readonly DependencyProperty DisabledBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledBackground), "#FFF0F0F0".ToBrush());
		public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundDP); set => SetValue(DisabledBackgroundDP, value); }

		public static readonly DependencyProperty DisabledBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledBorderBrush), "#FFD9D9D9".ToBrush());
		public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushDP); set => SetValue(DisabledBorderBrushDP, value); }

		public static readonly DependencyProperty DisabledGlyphDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledGlyph), "#FFBFBFBF".ToBrush());
		public Brush DisabledGlyph { get => (Brush)GetValue(DisabledGlyphDP); set => SetValue(DisabledGlyphDP, value); }

		public static readonly DependencyProperty DisabledEditableBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledEditableBackground), "#FFFFFFFF".ToBrush());
		public Brush DisabledEditableBackground { get => (Brush)GetValue(DisabledEditableBackgroundDP); set => SetValue(DisabledEditableBackgroundDP, value); }

		public static readonly DependencyProperty DisabledEditableBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledEditableBorderBrush), "#FFBFBFBF".ToBrush());
		public Brush DisabledEditableBorderBrush { get => (Brush)GetValue(DisabledEditableBorderBrushDP); set => SetValue(DisabledEditableBorderBrushDP, value); }

		public static readonly DependencyProperty DisabledEditableButtonBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledEditableButtonBackground), "Transparent".ToBrush());
		public Brush DisabledEditableButtonBackground { get => (Brush)GetValue(DisabledEditableButtonBackgroundDP); set => SetValue(DisabledEditableButtonBackgroundDP, value); }

		public static readonly DependencyProperty DisabledEditableButtonBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledEditableButtonBorderBrush), "Transparent".ToBrush());
		public Brush DisabledEditableButtonBorderBrush { get => (Brush)GetValue(DisabledEditableButtonBorderBrushDP); set => SetValue(DisabledEditableButtonBorderBrushDP, value); }
        
		public static readonly DependencyProperty MouseOverBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverBackground), new LinearGradientBrush("#FFECF4FC".ToColor(), "#FFDCECFC".ToColor(), new(0, 1), new(1, 0) /*MANUAL*/));
		public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundDP); set => SetValue(MouseOverBackgroundDP, value); }

		public static readonly DependencyProperty MouseOverEditableButtonBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverEditableButtonBackground), new LinearGradientBrush("#FFEBF4FC".ToColor(), "#FFDCECFC".ToColor(), new(0, 1), new(1, 0) /*MANUAL*/) /*MANUAL*/);
		public Brush MouseOverEditableButtonBackground { get => (Brush)GetValue(MouseOverEditableButtonBackgroundDP); set => SetValue(MouseOverEditableButtonBackgroundDP, value); }

		public static readonly DependencyProperty PressedBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedBackground), new LinearGradientBrush("#FFF0F0F0".ToColor(), "#FFE5E5E5".ToColor(), new(0, 1), new(1, 0) /*MANUAL*/) /*MANUAL*/);
		public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundDP); set => SetValue(PressedBackgroundDP, value); }

		public static readonly DependencyProperty PressedEditableButtonBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedEditableButtonBackground), new LinearGradientBrush("#FFDAECFC".ToColor(), "#FFC4E0FC".ToColor(), new(0, 1), new(1, 0) /*MANUAL*/) /*MANUAL*/);
		public Brush PressedEditableButtonBackground { get => (Brush)GetValue(PressedEditableButtonBackgroundDP); set => SetValue(PressedEditableButtonBackgroundDP, value); }

        public static readonly DependencyProperty GlyphDP = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(Glyph), "#FF606060".ToBrush());
		public Brush Glyph { get => (Brush)GetValue(GlyphDP); set => SetValue(GlyphDP, value); }

		public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<ComboBox>();
		public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(ComboBox));

		protected bool styleHasChanged = false;

		protected virtual void OnLoaded(object sender, RoutedEventArgs e)
		{
			if (!styleHasChanged) Style = BASE_STYLE;
		}

		protected override void OnStyleChanged(Style? oldStyle, Style? newStyle)
		{
			styleHasChanged = true;
			base.OnStyleChanged(oldStyle, newStyle);
		}

		static ComboBox() => BASE_STYLE.Seal();

		public ComboBox() => Loaded += OnLoaded;
	}
}
