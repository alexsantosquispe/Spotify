using Xamarin.Forms;

namespace Spotify.Themes
{
    public class ThemeManager
    {
        public static void ChangeTheme(string theme)
        {
            var mergeDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergeDictionaries != null)
            {
                mergeDictionaries.Clear();
                _SaveTheme(theme);
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
            ChangeTheme(_GetThemeSaved());
        }

        private static string _GetThemeSaved()
        {
            string defaultTheme = "Dark";
            if (Application.Current.Properties.ContainsKey("Theme"))
            {
                defaultTheme = Application.Current.Properties["Theme"].ToString();
            }
            return defaultTheme;
        }

        private static void _SaveTheme(string theme)
        {
            Application.Current.Properties["Theme"] = theme;
        } 
    }
}
