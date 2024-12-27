using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace AdminPanelPlugin.Menus
{
    public class PunishMenu : IAdminMenu
    {
        private readonly AdminPanelPlugin _plugin;

        public string MenuContext => "PunishMenu";

        public PunishMenu(AdminPanelPlugin plugin)
        {
            _plugin = plugin;
        }

        public ChatMenu GetChatMenu(CCSPlayerController player)
        {
            var chatMenu = new ChatMenu("*** Punish Menu ***");
            chatMenu.AddMenuOption("1. Ban", (p, option) => p.PrintToChat("Ban selected (not implemented yet)."));
            chatMenu.AddMenuOption("2. Kick", (p, option) => p.PrintToChat("Kick selected (not implemented yet)."));
            chatMenu.AddMenuOption("3. Freeze", (p, option) => p.PrintToChat("Freeze selected (not implemented yet)."));
            chatMenu.AddMenuOption("4. Slay", (p, option) => p.PrintToChat("Slay selected (not implemented yet)."));
            chatMenu.AddMenuOption("5. Back", (p, option) => _plugin.OpenMenu(p, new AdminMainMenu(_plugin)));

            return chatMenu;
        }

        public void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin)
        {
            switch (choice)
            {
                case 1:
                    player.PrintToChat("Ban selected.");
                    break;
                case 2:
                    player.PrintToChat("Kick selected.");
                    break;
                case 3:
                    player.PrintToChat("Freeze selected.");
                    break;
                case 4:
                    player.PrintToChat("Slay selected.");
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
