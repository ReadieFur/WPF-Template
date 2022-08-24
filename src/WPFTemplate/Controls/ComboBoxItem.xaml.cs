using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
	public class ComboBoxItem : System.Windows.Controls.ComboBoxItem
	{
		/*public static readonly DependencyProperty BackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(Background), "#FFFFFFFF".ToBrush());
		new public Brush Background { get => (Brush)GetValue(BackgroundDP); set => SetValue(BackgroundDP, value); }

		public static readonly DependencyProperty BorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(BorderBrush), "#FFACACAC".ToBrush());
		new public Brush BorderBrush { get => (Brush)GetValue(BorderBrushDP); set => SetValue(BorderBrushDP, value); }

		public static readonly DependencyProperty ForegroundDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(Foreground), "#00000000".ToBrush());
		new public Brush Foreground { get => (Brush)GetValue(ForegroundDP); set => SetValue(ForegroundDP, value); }*/

		public static readonly DependencyProperty ItemsviewHoverBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewHoverBackground), "#1F26A0DA".ToBrush());
		public Brush ItemsviewHoverBackground { get => (Brush)GetValue(ItemsviewHoverBackgroundDP); set => SetValue(ItemsviewHoverBackgroundDP, value); }

		public static readonly DependencyProperty ItemsviewHoverBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewHoverBorderBrush), "#A826A0DA".ToBrush());
		public Brush ItemsviewHoverBorderBrush { get => (Brush)GetValue(ItemsviewHoverBorderBrushDP); set => SetValue(ItemsviewHoverBorderBrushDP, value); }

		public static readonly DependencyProperty ItemsviewSelectedBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedBackground), "#3D26A0DA".ToBrush());
		public Brush ItemsviewSelectedBackground { get => (Brush)GetValue(ItemsviewSelectedBackgroundDP); set => SetValue(ItemsviewSelectedBackgroundDP, value); }

		public static readonly DependencyProperty ItemsviewSelectedBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedBorderBrush), "#FF26A0DA".ToBrush());
		public Brush ItemsviewSelectedBorderBrush { get => (Brush)GetValue(ItemsviewSelectedBorderBrushDP); set => SetValue(ItemsviewSelectedBorderBrushDP, value); }

		public static readonly DependencyProperty ItemsviewSelectedHoverBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedHoverBackground), "#2E0080FF".ToBrush());
		public Brush ItemsviewSelectedHoverBackground { get => (Brush)GetValue(ItemsviewSelectedHoverBackgroundDP); set => SetValue(ItemsviewSelectedHoverBackgroundDP, value); }

		public static readonly DependencyProperty ItemsviewSelectedHoverBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedHoverBorderBrush), "#99006CD9".ToBrush());
		public Brush ItemsviewSelectedHoverBorderBrush { get => (Brush)GetValue(ItemsviewSelectedHoverBorderBrushDP); set => SetValue(ItemsviewSelectedHoverBorderBrushDP, value); }

		public static readonly DependencyProperty ItemsviewSelectedNoFocusBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedNoFocusBackground), "#3DDADADA".ToBrush());
		public Brush ItemsviewSelectedNoFocusBackground { get => (Brush)GetValue(ItemsviewSelectedNoFocusBackgroundDP); set => SetValue(ItemsviewSelectedNoFocusBackgroundDP, value); }

		public static readonly DependencyProperty ItemsviewSelectedNoFocusBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewSelectedNoFocusBorderBrush), "#FFDADADA".ToBrush());
		public Brush ItemsviewSelectedNoFocusBorderBrush { get => (Brush)GetValue(ItemsviewSelectedNoFocusBorderBrushDP); set => SetValue(ItemsviewSelectedNoFocusBorderBrushDP, value); }

		public static readonly DependencyProperty ItemsviewFocusBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewFocusBorderBrush), "#FF26A0DA".ToBrush());
		public Brush ItemsviewFocusBorderBrush { get => (Brush)GetValue(ItemsviewFocusBorderBrushDP); set => SetValue(ItemsviewFocusBorderBrushDP, value); }

		public static readonly DependencyProperty ItemsviewHoverFocusBackgroundDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewHoverFocusBackground), "#5426A0DA".ToBrush());
		public Brush ItemsviewHoverFocusBackground { get => (Brush)GetValue(ItemsviewHoverFocusBackgroundDP); set => SetValue(ItemsviewHoverFocusBackgroundDP, value); }

		public static readonly DependencyProperty ItemsviewHoverFocusBorderBrushDP = DependencyExt.RegisterDependencyProperty<ComboBoxItem, Brush>(nameof(ItemsviewHoverFocusBorderBrush), "#FF26A0DA".ToBrush());
		public Brush ItemsviewHoverFocusBorderBrush { get => (Brush)GetValue(ItemsviewHoverFocusBorderBrushDP); set => SetValue(ItemsviewHoverFocusBorderBrushDP, value); }

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
