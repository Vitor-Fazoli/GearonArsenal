using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TritonsHydrants.Content.Projectiles;

namespace TritonsHydrants.Content.Items.Weapons.Hoses
{
    public class RubberHose : ModItem
    {
        // You can use a vanilla texture for your item by using the format: "Terraria/Item_<Item ID>".
        public override string Texture => "Terraria/Images/Item_" + ItemID.LastPrism;
        public static Color OverrideColor = new(122, 173, 255);

        public override void SetDefaults()
        {
            // Start by using CloneDefaults to clone all the basic item properties from the vanilla Last Prism.
            // For example, this copies sprite size, use style, sell price, and the item being a magic weapon.
            Item.CloneDefaults(ItemID.LastPrism);
            Item.mana = 4;
            Item.damage = 42;
            Item.shoot = ModContent.ProjectileType<AquaBurst>();
            Item.shootSpeed = 30f;

            // Change the item's draw color so that it is visually distinct from the vanilla Last Prism.
            Item.color = OverrideColor;
        }

        // Because this weapon fires a holdout projectile, it needs to block usage if its projectile already exists.
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<AquaBurst>()] <= 0;
        }
    }
}