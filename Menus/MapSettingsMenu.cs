using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace AdminPanelPlugin.Menus
{
    public class MapSettingsMenu : IAdminMenu
    {
        private readonly AdminPanelPlugin _plugin;

        public string MenuContext => "MapSettingsMenu";

        public MapSettingsMenu(AdminPanelPlugin plugin)
        {
            _plugin = plugin;
        }

        public ChatMenu GetChatMenu(CCSPlayerController player)
        {
            var chatMenu = new ChatMenu("*** Map Settings Menu ***");
            chatMenu.AddMenuOption("1. Change Map", (p, option) => p.PrintToChat("Change Map selected (not implemented yet)."));
            chatMenu.AddMenuOption("2. End Round", (p, option) => p.PrintToChat("End Round selected (not implemented yet)."));
            chatMenu.AddMenuOption("3. Extend Round", (p, option) => p.PrintToChat("Extend Round selected (not implemented yet)."));
            chatMenu.AddMenuOption("4. Back", (p, option) => _plugin.OpenMenu(p, new AdminMainMenu(_plugin)));

            return chatMenu;
        }

        public void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin)
        {
            switch (choice)
            {
                case 1:
                    player.PrintToChat("Change Map selected.");
                    break;
                case 2:
                    player.PrintToChat("End Round selected.");
                    break;
                case 3:
                    player.PrintToChat("Extend Round selected.");
                    break;
                case 4:
                    plugin.OpenMenu(player, new AdminMainMenu(plugin));
                    break;
                default:
                    player.PrintToChat("Invalid option.");
                    break;
            }
        }
    }
}
