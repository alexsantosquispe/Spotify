using Spotify.Utils;
using Xamarin.Forms;

namespace Spotify.Themes
{
    public static class ThemeManager
    {
        public static readonly IStore Store = new Store();

        /// <summary>
        /// Changes the current theme
        /// </summary>
        /// <param name="theme"></param>
        public static void ChangeTheme(string theme)
        {
            var mergeDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergeDictionaries != null)
            {
                mergeDictionaries.Clear();
                Store.SetValue("Theme", theme);
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

        /// <summary>
        /// Loads the initial theme
        /// </summary>
        public static void LoadTheme()
        {
            string theme = "Light";
            if (Store.Exist("Theme"))
            {
                theme = Store.GetValue("Theme");
            }
            ChangeTheme(theme);
        }
    }
}
