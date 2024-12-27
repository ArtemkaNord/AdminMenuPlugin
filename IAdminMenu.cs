using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;

namespace AdminPanelPlugin
{
    public interface IAdminMenu
    {
        string MenuContext { get; }
        ChatMenu GetChatMenu(CCSPlayerController player);
        void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin);
    }
}
