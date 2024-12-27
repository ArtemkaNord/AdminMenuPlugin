using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace AdminPanelPlugin.Menus
{
    public class ItemsMenu : IAdminMenu
    {
        private readonly AdminPanelPlugin _plugin;

        public string MenuContext => "ItemsMenu";

        public ItemsMenu(AdminPanelPlugin plugin)
        {
            _plugin = plugin;
        }

        public ChatMenu GetChatMenu(CCSPlayerController player)
        {
            var chatMenu = new ChatMenu("*** Items Menu ***");
            chatMenu.AddMenuOption("1. Guns", (p, option) => p.PrintToChat("Guns selected (not implemented yet)."));
            chatMenu.AddMenuOption("2. Other", (p, option) => p.PrintToChat("Other selected (not implemented yet)."));
            chatMenu.AddMenuOption("3. Back", (p, option) => _plugin.OpenMenu(p, new AdminMainMenu(_plugin)));

            return chatMenu;
        }

        public void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin)
        {
            switch (choice)
            {
                case 1:
                    player.PrintToChat("Guns selected.");
                    break;
                case 2:
                    player.PrintToChat("Other selected.");
                    break;
                case 3:
                    plugin.OpenMenu(player, new AdminMainMenu(plugin));
                    break;
                default:
                    player.PrintToChat("Invalid option.");
                    break;
            }
        }
    }
}
