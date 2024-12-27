using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace AdminPanelPlugin.Menus
{
    public class FeaturesMenu : IAdminMenu
    {
        private readonly AdminPanelPlugin _plugin;

        public string MenuContext => "FeaturesMenu";

        public FeaturesMenu(AdminPanelPlugin plugin)
        {
            _plugin = plugin;
        }

        public ChatMenu GetChatMenu(CCSPlayerController player)
        {
            var chatMenu = new ChatMenu("*** Features Menu ***");
            chatMenu.AddMenuOption("1. Bhop", (p, option) => p.PrintToChat("Bhop selected (not implemented yet)."));
            chatMenu.AddMenuOption("2. Double Jump", (p, option) => p.PrintToChat("Double Jump selected (not implemented yet)."));
            chatMenu.AddMenuOption("3. Noclip", (p, option) => p.PrintToChat("Noclip selected (not implemented yet)."));
            chatMenu.AddMenuOption("4. SpyMode", (p, option) => p.PrintToChat("SpyMode selected (not implemented yet)."));
            chatMenu.AddMenuOption("5. Back", (p, option) => _plugin.OpenMenu(p, new AdminMainMenu(_plugin)));

            return chatMenu;
        }

        public void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin)
        {
            switch (choice)
            {
                case 1:
                    player.PrintToChat("Bhop selected.");
                    break;
                case 2:
                    player.PrintToChat("Double Jump selected.");
                    break;
                case 3:
                    player.PrintToChat("Noclip selected.");
                    break;
                case 4:
                    player.PrintToChat("SpyMode selected.");
                    break;
                case 5:
                    plugin.OpenMenu(player, new AdminMainMenu(plugin));
                    break;
                default:
                    player.PrintToChat("Invalid option.");
                    break;
            }
        }
    }
}
