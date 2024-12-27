using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace AdminPanelPlugin.Menus
{
    public class RolesMenu : IAdminMenu
    {
        private readonly AdminPanelPlugin _plugin;

        public string MenuContext => "RolesMenu";

        public RolesMenu(AdminPanelPlugin plugin)
        {
            _plugin = plugin;
        }

        public ChatMenu GetChatMenu(CCSPlayerController player)
        {
            var chatMenu = new ChatMenu("*** Roles Menu ***");
            chatMenu.AddMenuOption("1. Add VIP", (p, option) => p.PrintToChat("Add VIP selected (not implemented yet)."));
            chatMenu.AddMenuOption("2. Add MOD", (p, option) => p.PrintToChat("Add MOD selected (not implemented yet)."));
            chatMenu.AddMenuOption("3. Add Admin", (p, option) => p.PrintToChat("Add Admin selected (not implemented yet)."));
            chatMenu.AddMenuOption("4. Status", (p, option) => p.PrintToChat("Status selected (not implemented yet)."));
            chatMenu.AddMenuOption("5. List", (p, option) => p.PrintToChat("List selected (not implemented yet)."));
            chatMenu.AddMenuOption("6. Back", (p, option) => _plugin.OpenMenu(p, new AdminMainMenu(_plugin)));

            return chatMenu;
        }

        public void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin)
        {
            switch (choice)
            {
                case 1:
                    player.PrintToChat("Add VIP selected.");
                    break;
                case 2:
                    player.PrintToChat("Add MOD selected.");
                    break;
                case 3:
                    player.PrintToChat("Add Admin selected.");
                    break;
                case 4:
                    player.PrintToChat("Status selected.");
                    break;
                case 5:
                    player.PrintToChat("List selected.");
                    break;
                case 6:
                    plugin.OpenMenu(player, new AdminMainMenu(plugin));
                    break;
                default:
                    player.PrintToChat("Invalid option.");
                    break;
            }
        }
    }
}
