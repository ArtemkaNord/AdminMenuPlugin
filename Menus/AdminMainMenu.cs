using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace AdminPanelPlugin.Menus
{
    public class AdminMainMenu : IAdminMenu
    {
        private readonly AdminPanelPlugin _plugin;

        public string MenuContext => "AdminMainMenu";

        public AdminMainMenu(AdminPanelPlugin plugin)
        {
            _plugin = plugin;
        }

        public ChatMenu GetChatMenu(CCSPlayerController player)
        {
            var chatMenu = new ChatMenu("*** Admin Panel ***");

            chatMenu.AddMenuOption("1. Punish", (p, option) => _plugin.OpenMenu(p, new PunishMenu(_plugin)));
            chatMenu.AddMenuOption("2. Roles", (p, option) => _plugin.OpenMenu(p, new RolesMenu(_plugin)));
            chatMenu.AddMenuOption("3. Map Settings", (p, option) => _plugin.OpenMenu(p, new MapSettingsMenu(_plugin)));
            chatMenu.AddMenuOption("4. Items", (p, option) => _plugin.OpenMenu(p, new ItemsMenu(_plugin)));
            chatMenu.AddMenuOption("5. Features", (p, option) => _plugin.OpenMenu(p, new FeaturesMenu(_plugin)));
            chatMenu.AddMenuOption("6. Exit", (p, option) => _plugin.ExitAdminMenu(p));

            return chatMenu;
        }

        public void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin)
        {
        }
    }
}
