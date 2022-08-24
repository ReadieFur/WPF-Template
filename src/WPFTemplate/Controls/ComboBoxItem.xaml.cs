using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
	public class ComboBoxItem : System.Windows.Controls.ComboBoxItem
	{
		/*public static readonly DependencyProperty BackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
		new public Brush Background { get => (Brush)GetValue(BackgroundProperty); set => SetValue(BackgroundProperty, value); }

		public static readonly DependencyProperty BorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(BorderBrush), "#FFACACAC".ToBrush());
		new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushProperty); set => SetValue(BorderBrushProperty, value); }

		public static readonly DependencyProperty ForegroundProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(Foreground), "#00000000".ToBrush());
		new public Brush Foreground { get => (Brush)GetValue(ForegroundProperty); set => SetValue(ForegroundProperty, value); }*/

		public static readonly DependencyProperty ItemsviewHoverBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewHoverBackground), "#1F26A0DA".ToBrush());
		public Brush ItemsviewHoverBackground { get => (Brush)GetValue(ItemsviewHoverBackgroundProperty); set => SetValue(ItemsviewHoverBackgroundProperty, value); }

		public static readonly DependencyProperty ItemsviewHoverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewHoverBorderBrush), "#A826A0DA".ToBrush());
		public Brush ItemsviewHoverBorderBrush { get => (Brush)GetValue(ItemsviewHoverBorderBrushProperty); set => SetValue(ItemsviewHoverBorderBrushProperty, value); }

		public static readonly DependencyProperty ItemsviewSelectedBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedBackground), "#3D26A0DA".ToBrush());
		public Brush ItemsviewSelectedBackground { get => (Brush)GetValue(ItemsviewSelectedBackgroundProperty); set => SetValue(ItemsviewSelectedBackgroundProperty, value); }

		public static readonly DependencyProperty ItemsviewSelectedBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedBorderBrush), "#FF26A0DA".ToBrush());
		public Brush ItemsviewSelectedBorderBrush { get => (Brush)GetValue(ItemsviewSelectedBorderBrushProperty); set => SetValue(ItemsviewSelectedBorderBrushProperty, value); }

		public static readonly DependencyProperty ItemsviewSelectedHoverBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedHoverBackground), "#2E0080FF".ToBrush());
		public Brush ItemsviewSelectedHoverBackground { get => (Brush)GetValue(ItemsviewSelectedHoverBackgroundProperty); set => SetValue(ItemsviewSelectedHoverBackgroundProperty, value); }

		public static readonly DependencyProperty ItemsviewSelectedHoverBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedHoverBorderBrush), "#99006CD9".ToBrush());
		public Brush ItemsviewSelectedHoverBorderBrush { get => (Brush)GetValue(ItemsviewSelectedHoverBorderBrushProperty); set => SetValue(ItemsviewSelectedHoverBorderBrushProperty, value); }

		public static readonly DependencyProperty ItemsviewSelectedNoFocusBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedNoFocusBackground), "#3DDADADA".ToBrush());
		public Brush ItemsviewSelectedNoFocusBackground { get => (Brush)GetValue(ItemsviewSelectedNoFocusBackgroundProperty); set => SetValue(ItemsviewSelectedNoFocusBackgroundProperty, value); }

		public static readonly DependencyProperty ItemsviewSelectedNoFocusBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedNoFocusBorderBrush), "#FFDADADA".ToBrush());
		public Brush ItemsviewSelectedNoFocusBorderBrush { get => (Brush)GetValue(ItemsviewSelectedNoFocusBorderBrushProperty); set => SetValue(ItemsviewSelectedNoFocusBorderBrushProperty, value); }

		public static readonly DependencyProperty ItemsviewFocusBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewFocusBorderBrush), "#FF26A0DA".ToBrush());
		public Brush ItemsviewFocusBorderBrush { get => (Brush)GetValue(ItemsviewFocusBorderBrushProperty); set => SetValue(ItemsviewFocusBorderBrushProperty, value); }

		public static readonly DependencyProperty ItemsviewHoverFocusBackgroundProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewHoverFocusBackground), "#5426A0DA".ToBrush());
		public Brush ItemsviewHoverFocusBackground { get => (Brush)GetValue(ItemsviewHoverFocusBackgroundProperty); set => SetValue(ItemsviewHoverFocusBackgroundProperty, value); }

		public static readonly DependencyProperty ItemsviewHoverFocusBorderBrushProperty = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewHoverFocusBorderBrush), "#FF26A0DA".ToBrush());
		public Brush ItemsviewHoverFocusBorderBrush { get => (Brush)GetValue(ItemsviewHoverFocusBorderBrushProperty); set => SetValue(ItemsviewHoverFocusBorderBrushProperty, value); }

		public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<ComboBoxItem>();
		public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(ComboBoxItem));

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

		static ComboBoxItem() => BASE_STYLE.Seal();

		public ComboBoxItem() => Loaded += OnLoaded;
	}
}
