using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
	public class ComboBox : System.Windows.Controls.ComboBox
	{
        /*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
		new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

        public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(BorderBrush), "#FFACACAC".ToBrush());
        new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

        public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(Foreground), "#00000000".ToBrush());
		new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

		public static readonly DependencyProperty StaticGlyphProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticGlyph), "#FF606060".ToBrush());
		public Brush StaticGlyph { get => (Brush)GetValue(StaticGlyphProperty); set => SetValue(StaticGlyphProperty, value); }

		public static readonly DependencyProperty StaticEditableBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticEditableBackground), "#FFFFFFFF".ToBrush());
		public Brush StaticEditableBackground { get => (Brush)GetValue(StaticEditableBackgroundProperty); set => SetValue(StaticEditableBackgroundProperty, value); }

		public static readonly DependencyProperty StaticEditableBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticEditableBorderBrush), "#FFABADB3".ToBrush());
		public Brush StaticEditableBorderBrush { get => (Brush)GetValue(StaticEditableBorderBrushProperty); set => SetValue(StaticEditableBorderBrushProperty, value); }

		public static readonly DependencyProperty StaticEditableButtonBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticEditableButtonBackground), "Transparent".ToBrush());
		public Brush StaticEditableButtonBackground { get => (Brush)GetValue(StaticEditableButtonBackgroundProperty); set => SetValue(StaticEditableButtonBackgroundProperty, value); }

		public static readonly DependencyProperty StaticEditableButtonBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(StaticEditableButtonBorderBrush), "Transparent".ToBrush());
		public Brush StaticEditableButtonBorderBrush { get => (Brush)GetValue(StaticEditableButtonBorderBrushProperty); set => SetValue(StaticEditableButtonBorderBrushProperty, value); }

		public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverBorderBrush), "#FF7EB4EA".ToBrush());
		public Brush MouseOverBorderBrush { get => (Brush)GetValue(MouseOverBorderBrushProperty); set => SetValue(MouseOverBorderBrushProperty, value); }

		public static readonly DependencyProperty MouseOverGlyphProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverGlyph), "#FF000000".ToBrush());
		public Brush MouseOverGlyph { get => (Brush)GetValue(MouseOverGlyphProperty); set => SetValue(MouseOverGlyphProperty, value); }

		public static readonly DependencyProperty MouseOverEditableBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverEditableBackground), "#FFFFFFFF".ToBrush());
		public Brush MouseOverEditableBackground { get => (Brush)GetValue(MouseOverEditableBackgroundProperty); set => SetValue(MouseOverEditableBackgroundProperty, value); }

		public static readonly DependencyProperty MouseOverEditableBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverEditableBorderBrush), "#FF7EB4EA".ToBrush());
		public Brush MouseOverEditableBorderBrush { get => (Brush)GetValue(MouseOverEditableBorderBrushProperty); set => SetValue(MouseOverEditableBorderBrushProperty, value); }

		public static readonly DependencyProperty MouseOverEditableButtonBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverEditableButtonBorderBrush), "#FF7EB4EA".ToBrush());
		public Brush MouseOverEditableButtonBorderBrush { get => (Brush)GetValue(MouseOverEditableButtonBorderBrushProperty); set => SetValue(MouseOverEditableButtonBorderBrushProperty, value); }

		public static readonly DependencyProperty PressedBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedBorderBrush), "#FF569DE5".ToBrush());
		public Brush PressedBorderBrush { get => (Brush)GetValue(PressedBorderBrushProperty); set => SetValue(PressedBorderBrushProperty, value); }

		public static readonly DependencyProperty PressedGlyphProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedGlyph), "#FF000000".ToBrush());
		public Brush PressedGlyph { get => (Brush)GetValue(PressedGlyphProperty); set => SetValue(PressedGlyphProperty, value); }

		public static readonly DependencyProperty PressedEditableBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedEditableBackground), "#FFFFFFFF".ToBrush());
		public Brush PressedEditableBackground { get => (Brush)GetValue(PressedEditableBackgroundProperty); set => SetValue(PressedEditableBackgroundProperty, value); }

		public static readonly DependencyProperty PressedEditableBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedEditableBorderBrush), "#FF569DE5".ToBrush());
		public Brush PressedEditableBorderBrush { get => (Brush)GetValue(PressedEditableBorderBrushProperty); set => SetValue(PressedEditableBorderBrushProperty, value); }

		public static readonly DependencyProperty PressedEditableButtonBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedEditableButtonBorderBrush), "#FF569DE5".ToBrush());
		public Brush PressedEditableButtonBorderBrush { get => (Brush)GetValue(PressedEditableButtonBorderBrushProperty); set => SetValue(PressedEditableButtonBorderBrushProperty, value); }

		public static readonly DependencyProperty DisabledBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledBackground), "#FFF0F0F0".ToBrush());
		public Brush DisabledBackground { get => (Brush)GetValue(DisabledBackgroundProperty); set => SetValue(DisabledBackgroundProperty, value); }

		public static readonly DependencyProperty DisabledBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledBorderBrush), "#FFD9D9D9".ToBrush());
		public Brush DisabledBorderBrush { get => (Brush)GetValue(DisabledBorderBrushProperty); set => SetValue(DisabledBorderBrushProperty, value); }

		public static readonly DependencyProperty DisabledGlyphProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledGlyph), "#FFBFBFBF".ToBrush());
		public Brush DisabledGlyph { get => (Brush)GetValue(DisabledGlyphProperty); set => SetValue(DisabledGlyphProperty, value); }

		public static readonly DependencyProperty DisabledEditableBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledEditableBackground), "#FFFFFFFF".ToBrush());
		public Brush DisabledEditableBackground { get => (Brush)GetValue(DisabledEditableBackgroundProperty); set => SetValue(DisabledEditableBackgroundProperty, value); }

		public static readonly DependencyProperty DisabledEditableBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledEditableBorderBrush), "#FFBFBFBF".ToBrush());
		public Brush DisabledEditableBorderBrush { get => (Brush)GetValue(DisabledEditableBorderBrushProperty); set => SetValue(DisabledEditableBorderBrushProperty, value); }

		public static readonly DependencyProperty DisabledEditableButtonBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledEditableButtonBackground), "Transparent".ToBrush());
		public Brush DisabledEditableButtonBackground { get => (Brush)GetValue(DisabledEditableButtonBackgroundProperty); set => SetValue(DisabledEditableButtonBackgroundProperty, value); }

		public static readonly DependencyProperty DisabledEditableButtonBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(DisabledEditableButtonBorderBrush), "Transparent".ToBrush());
		public Brush DisabledEditableButtonBorderBrush { get => (Brush)GetValue(DisabledEditableButtonBorderBrushProperty); set => SetValue(DisabledEditableButtonBorderBrushProperty, value); }
        
		public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverBackground), new LinearGradientBrush("#FFECF4FC".ToColor(), "#FFDCECFC".ToColor(), new(0, 1), new(1, 0) /*MANUAL*/));
		public Brush MouseOverBackground { get => (Brush)GetValue(MouseOverBackgroundProperty); set => SetValue(MouseOverBackgroundProperty, value); }

		public static readonly DependencyProperty MouseOverEditableButtonBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(MouseOverEditableButtonBackground), new LinearGradientBrush("#FFEBF4FC".ToColor(), "#FFDCECFC".ToColor(), new(0, 1), new(1, 0) /*MANUAL*/) /*MANUAL*/);
		public Brush MouseOverEditableButtonBackground { get => (Brush)GetValue(MouseOverEditableButtonBackgroundProperty); set => SetValue(MouseOverEditableButtonBackgroundProperty, value); }

		public static readonly DependencyProperty PressedBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedBackground), new LinearGradientBrush("#FFF0F0F0".ToColor(), "#FFE5E5E5".ToColor(), new(0, 1), new(1, 0) /*MANUAL*/) /*MANUAL*/);
		public Brush PressedBackground { get => (Brush)GetValue(PressedBackgroundProperty); set => SetValue(PressedBackgroundProperty, value); }

		public static readonly DependencyProperty PressedEditableButtonBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(PressedEditableButtonBackground), new LinearGradientBrush("#FFDAECFC".ToColor(), "#FFC4E0FC".ToColor(), new(0, 1), new(1, 0) /*MANUAL*/) /*MANUAL*/);
		public Brush PressedEditableButtonBackground { get => (Brush)GetValue(PressedEditableButtonBackgroundProperty); set => SetValue(PressedEditableButtonBackgroundProperty, value); }

        public static readonly DependencyProperty GlyphProperty = DependencyExt.RegisterDependencyProperty<ComboBox, Brush>(nameof(Glyph), "#FF606060".ToBrush());
		public Brush Glyph { get => (Brush)GetValue(GlyphProperty); set => SetValue(GlyphProperty, value); }

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
