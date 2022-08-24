using System.Windows;
using System.Windows.Media;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
	public class Expander : System.Windows.Controls.Expander
	{
		public static readonly DependencyProperty StaticCircleStrokeProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(StaticCircleStroke), "#FF333333".ToBrush());
		public Brush StaticCircleStroke { get => (Brush)GetValue(StaticCircleStrokeProperty); set => SetValue(StaticCircleStrokeProperty, value); }

		public static readonly DependencyProperty StaticCircleFillProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(StaticCircleFill), "#FFFFFFFF".ToBrush());
		public Brush StaticCircleFill { get => (Brush)GetValue(StaticCircleFillProperty); set => SetValue(StaticCircleFillProperty, value); }

		public static readonly DependencyProperty StaticArrowStrokeProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(StaticArrowStroke), "#FF333333".ToBrush());
		public Brush StaticArrowStroke { get => (Brush)GetValue(StaticArrowStrokeProperty); set => SetValue(StaticArrowStrokeProperty, value); }

		public static readonly DependencyProperty MouseOverCircleStrokeProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(MouseOverCircleStroke), "#FF5593FF".ToBrush());
		public Brush MouseOverCircleStroke { get => (Brush)GetValue(MouseOverCircleStrokeProperty); set => SetValue(MouseOverCircleStrokeProperty, value); }

		public static readonly DependencyProperty MouseOverCircleFillProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(MouseOverCircleFill), "#FFF3F9FF".ToBrush());
		public Brush MouseOverCircleFill { get => (Brush)GetValue(MouseOverCircleFillProperty); set => SetValue(MouseOverCircleFillProperty, value); }

		public static readonly DependencyProperty MouseOverArrowStrokeProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(MouseOverArrowStroke), "#FF000000".ToBrush());
		public Brush MouseOverArrowStroke { get => (Brush)GetValue(MouseOverArrowStrokeProperty); set => SetValue(MouseOverArrowStrokeProperty, value); }

		public static readonly DependencyProperty PressedCircleStrokeProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(PressedCircleStroke), "#FF3C77DD".ToBrush());
		public Brush PressedCircleStroke { get => (Brush)GetValue(PressedCircleStrokeProperty); set => SetValue(PressedCircleStrokeProperty, value); }

		public static readonly DependencyProperty PressedCircleFillProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(PressedCircleFill), "#FFD9ECFF".ToBrush());
		public Brush PressedCircleFill { get => (Brush)GetValue(PressedCircleFillProperty); set => SetValue(PressedCircleFillProperty, value); }

		public static readonly DependencyProperty PressedArrowStrokeProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(PressedArrowStroke), "#FF000000".ToBrush());
		public Brush PressedArrowStroke { get => (Brush)GetValue(PressedArrowStrokeProperty); set => SetValue(PressedArrowStrokeProperty, value); }

		public static readonly DependencyProperty DisabledCircleStrokeProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(DisabledCircleStroke), "#FFBCBCBC".ToBrush());
		public Brush DisabledCircleStroke { get => (Brush)GetValue(DisabledCircleStrokeProperty); set => SetValue(DisabledCircleStrokeProperty, value); }

		public static readonly DependencyProperty DisabledCircleFillProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(DisabledCircleFill), "#FFE6E6E6".ToBrush());
		public Brush DisabledCircleFill { get => (Brush)GetValue(DisabledCircleFillProperty); set => SetValue(DisabledCircleFillProperty, value); }

		public static readonly DependencyProperty DisabledArrowStrokeProperty = DependencyExt.RegisterDependencyProperty<Expander, Brush>(nameof(DisabledArrowStroke), "#FF707070".ToBrush());
		public Brush DisabledArrowStroke { get => (Brush)GetValue(DisabledArrowStrokeProperty); set => SetValue(DisabledArrowStrokeProperty, value); }

		public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<Expander>();
		public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(Expander));

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

		static Expander() => BASE_STYLE.Seal();

		public Expander() => Loaded += OnLoaded;
	}
}
