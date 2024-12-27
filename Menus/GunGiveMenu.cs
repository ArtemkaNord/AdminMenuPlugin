using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Menu;
using System;
using System.Collections.Generic;

namespace AdminPanelPlugin.Menus
{
    public class GunGiveMenu : IAdminMenu
    {
        private readonly AdminPanelPlugin _plugin;
        private readonly List<Weapon> weapons;
        private int currentPage;

        public GunGiveMenu(AdminPanelPlugin plugin)
        {
            _plugin = plugin;
            this.weapons = LoadAllWeapons();
            this.currentPage = 0;
        }

        public string MenuContext => "GunGiveMenu";

        public ChatMenu GetChatMenu(CCSPlayerController player)
        {
            return CreateGunMenu(player, currentPage);
        }

        public void HandleOption(CCSPlayerController player, int choice, AdminPanelPlugin plugin)
        {
            if (choice == 8 && (currentPage + 1) * 7 < weapons.Count)
            {
                currentPage++;
            }
            else if (choice == 9 && currentPage > 0)
            {
                currentPage--;
            }
            else if (choice >= 1 && choice <= 7)
            {
                int weaponIndex = (currentPage * 7) + (choice - 1);
                if (weaponIndex < weapons.Count)
                {
                    GiveGun(player, weapons[weaponIndex]);
                }
            }
        }

        private ChatMenu CreateGunMenu(CCSPlayerController player, int page)
        {
            var chatMenu = new ChatMenu($"Guns Menu (Page {page + 1})");

            int startIndex = page * 7;
            int endIndex = Math.Min(startIndex + 7, weapons.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                int index = i;
                chatMenu.AddMenuOption(
                    $"{i - startIndex + 1}. {weapons[i].Name}",
                    (playerController, menuOption) => GiveGun(playerController, weapons[index]));
            }

            if (endIndex < weapons.Count)
            {
                chatMenu.AddMenuOption("8. Next Page", (p, option) => HandleOption(player, 8, _plugin));
            }

            if (page > 0)
            {
                chatMenu.AddMenuOption("9. Previous Page", (p, option) => HandleOption(player, 9, _plugin));
            }

            return chatMenu;
        }

        private void GiveGun(CCSPlayerController player, Weapon weapon)
        {
            if (player == null || !player.IsValid || player.IsBot || player.PlayerPawn?.Value?.WeaponServices?.MyWeapons == null)
            {
                player?.PrintToChat("Cannot give gun. Invalid player.");
                return;
            }

            RemoveCurrentWeapon(player, weapon.Type);
            player.GiveNamedItem(weapon.GiveName);
            player.PrintToChat($"You have been given: {weapon.Name}");
        }

        private void RemoveCurrentWeapon(CCSPlayerController player, WeaponType type)
        {
            foreach (var weapon in player.PlayerPawn!.Value!.WeaponServices!.MyWeapons)
            {
                if (weapon.Value != null && !string.IsNullOrWhiteSpace(weapon.Value.DesignerName))
                {
                    weapon.Value.Remove();
                }
            }
        }

        private List<Weapon> LoadAllWeapons()
        {
            return new List<Weapon>
            {
                new Weapon("AK-47", "weapon_ak47", WeaponType.Primary),
                new Weapon("M4A4", "weapon_m4a1", WeaponType.Primary),
                new Weapon("M4A1-S", "weapon_m4a1_silencer", WeaponType.Primary),
                new Weapon("AWP", "weapon_awp", WeaponType.Primary),
                new Weapon("SSG 08", "weapon_ssg08", WeaponType.Primary),
                new Weapon("Galil AR", "weapon_galilar", WeaponType.Primary),
                new Weapon("FAMAS", "weapon_famas", WeaponType.Primary),
                new Weapon("SG 553", "weapon_sg553", WeaponType.Primary),
                new Weapon("AUG", "weapon_aug", WeaponType.Primary),
                new Weapon("Negev", "weapon_negev", WeaponType.Primary),
                new Weapon("M249", "weapon_m249", WeaponType.Primary),
                new Weapon("Glock-18", "weapon_glock", WeaponType.Secondary),
                new Weapon("P2000", "weapon_hkp2000", WeaponType.Secondary),
                new Weapon("USP-S", "weapon_usp_silencer", WeaponType.Secondary),
                new Weapon("Tec-9", "weapon_tec9", WeaponType.Secondary),
                new Weapon("P250", "weapon_p250", WeaponType.Secondary),
                new Weapon("CZ75-Auto", "weapon_cz75a", WeaponType.Secondary),
                new Weapon("Dual Berettas", "weapon_elite", WeaponType.Secondary),
                new Weapon("Five-SeveN", "weapon_fiveseven", WeaponType.Secondary),
                new Weapon("R8 Revolver", "weapon_revolver", WeaponType.Secondary),
                new Weapon("MP5-SD", "weapon_mp5sd", WeaponType.Primary),
                new Weapon("PP-Bizon", "weapon_bizon", WeaponType.Primary),
                new Weapon("UMP-45", "weapon_ump45", WeaponType.Primary),
                new Weapon("MP9", "weapon_mp9", WeaponType.Primary),
                new Weapon("P90", "weapon_p90", WeaponType.Primary),
                new Weapon("MP7", "weapon_mp7", WeaponType.Primary),
                new Weapon("MAC-10", "weapon_mac10", WeaponType.Primary),
                new Weapon("G3SG1", "weapon_g3sg1", WeaponType.Primary),
                new Weapon("SCAR-20", "weapon_scar20", WeaponType.Primary),
                new Weapon("XM1014", "weapon_xm1014", WeaponType.Primary),
                new Weapon("MAG-7", "weapon_mag7", WeaponType.Primary),
                new Weapon("Sawed-Off", "weapon_sawedoff", WeaponType.Primary),
                new Weapon("Nova", "weapon_nova", WeaponType.Primary)
            };
        }
    }

    public class Weapon
    {
        public string Name { get; }
        public string GiveName { get; }
        public WeaponType Type { get; }

        public Weapon(string name, string giveName, WeaponType type)
        {
            Name = name;
            GiveName = giveName;
            Type = type;
        }
    }

    public enum WeaponType
    {
        Primary,
        Secondary
    }
}
