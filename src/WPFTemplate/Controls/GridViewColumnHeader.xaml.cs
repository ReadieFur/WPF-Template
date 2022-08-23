using System.Windows;
using WPFTemplate.Extensions;

namespace WPFTemplate.Controls
{
    public class GridViewColumnHeader : System.Windows.Controls.GridViewColumnHeader
    {
        #region I wish multi-inheritance was a thing.
        //...And no I don't mean interfaces.
        #region Resources
        public static readonly ResourceDictionary RESOURCES = ResourceDictionaryExt.LoadControlResourceDictionary<GridViewColumnHeader>();
        public static readonly Style BASE_STYLE = RESOURCES.GetResource<Style>(nameof(GridViewColumnHeader));

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
        #endregion

        static GridViewColumnHeader() => BASE_STYLE.Seal();

        public GridViewColumnHeader() => Loaded += OnLoaded;
        #endregion
    }
}
