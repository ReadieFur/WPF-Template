using System;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using WPFTemplate.Extensions;

namespace WPFTemplate.Styles
{
    public static class StylesManager
    {
        private static Timer updateTimer = new Timer();
        private static SolidColorBrush _darkThemeBackground = "#0d1117".ToBrush();
        private static SolidColorBrush _darkThemeBackgroundAlt = "#161b22".ToBrush();
        private static SolidColorBrush _darkThemeForeground = "#ffffff".ToBrush();
        private static SolidColorBrush _lightThemeBackground = "#ffffff".ToBrush();
        private static SolidColorBrush _lightThemeBackgroundAlt = "#e1e1e1".ToBrush();
        private static SolidColorBrush _lightThemeForeground = "#000000".ToBrush();
        private static Brush _accent = "#00adef".ToBrush(); //Windows blue.
        private static bool _darkTheme = true;
        private static bool _useSystemTheme = true;

        public static SolidColorBrush darkThemeBackground
        {
            get => _darkThemeBackground;
            set
            {
                if (value == darkThemeBackground) return;
                _darkThemeBackground = value;
                UpdateThemes();
            }
        }
        public static SolidColorBrush darkThemeBackgroundAlt
        {
            get => _darkThemeBackgroundAlt;
            set
            {
                if (value == darkThemeBackgroundAlt) return;
                _darkThemeBackgroundAlt = value;
                UpdateThemes();
            }
        }
        public static SolidColorBrush darkThemeForeground
        {
            get => _darkThemeForeground;
            set
            {
                if (value == darkThemeForeground) return;
                _darkThemeForeground = value;
                UpdateThemes();
            }
        }
        public static SolidColorBrush lightThemeBackground
        {
            get => _lightThemeBackground;
            set
            {
                if (value == lightThemeBackground) return;
                _lightThemeBackground = value;
                UpdateThemes();
            }
        }
        public static SolidColorBrush lightThemeBackgroundAlt
        {
            get => _lightThemeBackgroundAlt;
            set
            {
                if (value == lightThemeBackgroundAlt) return;
                _lightThemeBackgroundAlt = value;
                UpdateThemes();
            }
        }
        public static SolidColorBrush lightThemeForeground
        {
            get => _lightThemeForeground;
            set
            {
                if (value == lightThemeForeground) return;
                _lightThemeForeground = value;
                UpdateThemes();
            }
        }

        public static SolidColorBrush background { get; private set; } = darkThemeBackground;
        public static SolidColorBrush backgroundAlt { get; private set; } = darkThemeBackgroundAlt;
        public static SolidColorBrush foreground { get; private set; } = darkThemeBackgroundAlt;
        /// <summary>
        /// Only settable when 'useSystemTheme' is 'false'.
        /// </summary>
        public static Brush accent
        {
            get => _accent;
            set
            {
                if (useSystemTheme) return;
                _accent = value;
                UpdateThemes();
            }
        }
        /// <summary>
        /// Only settable when 'useSystemTheme' is 'false'.
        /// </summary>
        public static bool darkTheme
        {
            get => _darkTheme;
            set
            {
                if (useSystemTheme) return;
                _darkTheme = value;
                UpdateThemes();
            }
        }
        public static bool useSystemTheme
        {
            get => _useSystemTheme;
            set
            {
                if (value == useSystemTheme) return;
                _useSystemTheme = value;
                UpdateThemes();

                if (value) updateTimer.Start();
                else updateTimer.Stop();
            }
        }
        public static event Action? onChange;

        static StylesManager()
        {
            updateTimer.Interval = 5000;
            updateTimer.Elapsed += (_, _) => UpdateThemes();
            if (useSystemTheme) updateTimer.Start();

            UpdateThemes();
        }

        private static void UpdateThemes()
        {
            bool changeDetected = false;

            if (useSystemTheme)
            {
                //Check if the app accent is not the same as the system accent.
                if (accent != SystemParameters.WindowGlassBrush)
                {
                    _accent = SystemParameters.WindowGlassBrush;
                    changeDetected |= true;
                }

                try
                {
                    //Check if the current user theme is set to dark mode.
#pragma warning disable CA1416 // Validate platform compatibility
                    bool appsUseLightTheme = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize")?
                        .GetValue("AppsUseLightTheme")?.ToString() == "1";
#pragma warning restore CA1416 // Validate platform compatibility

                    //Check if apps should use light theme and the current application is using dark mode.
                    changeDetected |= appsUseLightTheme && background != lightThemeBackground;

                    _darkTheme = !appsUseLightTheme;

                    if (appsUseLightTheme)
                    {
                        background = lightThemeBackground;
                        backgroundAlt = lightThemeBackgroundAlt;
                        foreground = lightThemeForeground;
                    }
                    else
                    {
                        background = darkThemeBackground;
                        backgroundAlt = darkThemeBackgroundAlt;
                        foreground = darkThemeForeground;
                    }
                }
                catch {}
            }
            else changeDetected = true;

            if (changeDetected) onChange?.Invoke();
        }
    }
}
