using Spotify.Utils;
using Xamarin.Forms;

namespace Spotify.Themes
{
    public static class ThemeManager
    {
        public static readonly IStore Store = new Store();

        public static void ChangeTheme(string theme)
        {
            var mergeDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergeDictionaries != null)
            {
                mergeDictionaries.Clear();
                SaveTheme(theme);
                switch (theme)
                {
                    case "Light":
                        mergeDictionaries.Add(new Light());
                        break;
                    case "Dark":
                        mergeDictionaries.Add(new Dark());
                        break;
                    default:
                        mergeDictionaries.Add(new Light());
                        break;
                }
            }
        }

        public static void LoadTheme()
        {            
            ChangeTheme(GetThemeSaved());
        }

        public static string GetThemeSaved()
        {
            string defaultTheme = "Light";
            Store.GetValue("Theme");
            return defaultTheme;
        }

        public static void SaveTheme(string theme)
        {
            Store.SetValue("Theme", theme);
        }
    }
}
