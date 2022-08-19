namespace WPFTemplate.Styles
{
    public class XAML
    {
        public string backgroundColour { get; set; } = Styles.background.ToString();
        public string hoverBackgroundColour { get; set; } = Styles.backgroundAlt.ToString();
        public string clickBackgroundColour { get; set; } = Styles.backgroundAlt.ToString();
        public string disabledBackgroundColour { get; set; } = "#FFF4F4F4";

        public string foregroundColour { get; set; } = Styles.foreground.ToString();
        public string disabledForegroundColour { get; set; } = "#FF838383";

        public string hoverColour { get; set; } = Styles.backgroundAlt.ToString();

        public string borderColour { get; set; } = Styles.foreground.ToString();
        public string hoverBorderColour { get; set; } = Styles.foreground.ToString();
        public string clickBorderColour { get; set; } = Styles.foreground.ToString();
        public string disabledBorderColour { get; set; } = "#FFF4F4F4";

        public string accentColour { get; set; } = Styles.accent.ToString();

        public XAML()
        {
            //This update here dosen't seem to work so I will do it externally.
            /*Styles.onChange += () => Helpers.InvokeDispatcher(() => {...});*/
        }
    }
}
