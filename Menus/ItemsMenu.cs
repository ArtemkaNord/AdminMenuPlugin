using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace AdminPanelPlugin.Menus
{
    public class ItemsMenu : IAdminMenu
    {
        private readonly AdminPanelPlugin _plugin;

        public ItemsMenu(AdminPanelPlugin plugin)
        {
            _plugin = plugin;
        }

        public string MenuContext => "ItemsMenu";

        public ChatMenu GetChatMenu(CCSPlayerController player)
        {
            var chatMenu = new ChatMenu("Items Menu");

            chatMenu.AddMenuOption("1. Guns", (playerController, menuOption) =>
            {
                _plugin.OpenMenu(playerController, new GunGiveMenu(_plugin));
            });

            chatMenu.AddMenuOption("2. Other Items (Not Implemented)", (playerController, menuOption) =>
            {
                playerController.PrintToChat("Other items menu is not implemented yet.");
            });

            chatMenu.AddMenuOption("3. Exit", (playerController, menuOption) =>
            {
                _plugin.ExitAdminMenu(playerController);
            });

            return chatMenu;
        }

        public void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin)
        {
            switch (choice)
            {
                case 1:
                    plugin.OpenMenu(player, new GunGiveMenu(plugin));
                    break;
                case 2:
                    player.PrintToChat("Other items menu is not implemented yet.");
                    break;
                case 3:
                    plugin.ExitAdminMenu(player);
                    break;
                default:
                    player.PrintToChat("Invalid option.");
                    break;
            }
        }
    }
}
