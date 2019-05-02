using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Spotify.Themes
{
    public class ThemeManager
    {
        public enum Theme
        {
            Light,
            Dark
        }

        public static void ChangeTheme(Theme theme)
        {
            var mergeDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergeDictionaries != null)
            {
                mergeDictionaries.Clear();
                switch (theme)
                {
                    case Theme.Light:
                        mergeDictionaries.Add(new LightTheme());
                        break;
                    case Theme.Dark:
                        mergeDictionaries.Add(new DarkTheme());
                        break;
                    default:
                        mergeDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }

        public static void LoadTheme()
        {
            Theme currentTheme = CurrentTheme();
            ChangeTheme(currentTheme);
        }

        private static Theme CurrentTheme()
        {
            return default(Theme);
        }
    }
}
