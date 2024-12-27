using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Entities;
using System.Collections.Generic;
using CounterStrikeSharp.API.Modules.Commands;
using AdminPanelPlugin.Menus;

namespace AdminPanelPlugin
{
    public class AdminPanelPlugin : BasePlugin
    {
        public override string ModuleName => "AdminPanel";
        public override string ModuleVersion => "1.0";
        public override string ModuleAuthor => "ArtemkaNord";
        public override string ModuleDescription => "Multifunctional Admin menu";

        private readonly Dictionary<CCSPlayerController, ChatMenu> activeMenus = new();
        private readonly Dictionary<CCSPlayerController, string> activeMenuContexts = new();

        public override void Load(bool hotReload)
        {
        }

        [ConsoleCommand("panel")]
        [ConsoleCommand("ap")]
        [ConsoleCommand("adminpanel")]
        public void OpenAdminPanel(CCSPlayerController player, CommandInfo info)
        {
            if (!ValidatePlayer(player)) return;

            OpenMenu(player, new AdminMainMenu(this));
        }

        public void OpenMenu(CCSPlayerController player, IAdminMenu menu)
        {
            if (activeMenus.ContainsKey(player))
            {
                activeMenus.Remove(player);
            }

            activeMenus[player] = menu.GetChatMenu(player);
            activeMenuContexts[player] = menu.MenuContext;
            ChatMenus.OpenMenu(player, activeMenus[player]);
        }

        public void ExitAdminMenu(CCSPlayerController player)
        {
            if (activeMenus.ContainsKey(player))
            {
                activeMenus.Remove(player);
                activeMenuContexts.Remove(player);
            }
            player.PrintToChat("Exited Admin Panel.");
        }

        public void HandleChatCommand(CCSPlayerController player, string command)
        {
            if (!activeMenus.ContainsKey(player)) return;

            if (int.TryParse(command.Replace("!", ""), out int choice))
            {
                var context = activeMenuContexts[player];
                AdminMenuRegistry.GetMenu(context)?.HandleOption(player, choice, this);
            }
        }

        private bool ValidatePlayer(CCSPlayerController player)
        {
            if (player == null || !player.IsValid || player.IsBot || !player.PawnIsAlive)
            {
                player?.PrintToChat("You must be alive to access the Admin Panel.");
                return false;
            }
            return true;
        }

        public override void Unload(bool hotReload)
        {
            activeMenus.Clear();
            activeMenuContexts.Clear();
        }
    }
}
