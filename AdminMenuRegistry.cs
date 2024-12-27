using System.Collections.Generic;

namespace AdminPanelPlugin
{
    public static class AdminMenuRegistry
    {
        private static readonly Dictionary<string, IAdminMenu> Menus = new();

        public static void RegisterMenu(IAdminMenu menu)
        {
            Menus[menu.MenuContext] = menu;
        }

        public static IAdminMenu? GetMenu(string context)
        {
            return Menus.TryGetValue(context, out var menu) ? menu : null;
        }
    }
}
