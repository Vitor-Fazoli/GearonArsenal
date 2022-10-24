using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace DevilsWarehouse.Content.Items.Weapons.Throwing
{
    public class Yon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Victus and Yon");
        }
        public override void SetDefaults()
        {
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.damage = 10;
            Item.crit = 6;
            Item.rare = ItemRarityID.Red;
            Item.shoot = ModContent.ProjectileType<Victus>();
            Item.shootSpeed = 6;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Throwing;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 30;
                Item.useAnimation = 30;
                Item.damage = 50;
                Item.crit = 6;
                Item.rare = ItemRarityID.Red;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.DamageType = DamageClass.Throwing;
                Item.noUseGraphic = false;
                Item.noMelee = false;
                Item.shoot = ProjectileID.None;
            }
            else
            {
                Item.useTime = 15;
                Item.useAnimation = 15;
                Item.damage = 10;
                Item.crit = 6;
                Item.rare = ItemRarityID.Red;
                Item.shoot = ModContent.ProjectileType<Victus>();
                Item.shootSpeed = 8;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.noUseGraphic = true;
                Item.DamageType = DamageClass.Throwing;
            }
            return base.CanUseItem(player);
        }
    }
    internal class Victus : ModProjectile
    {
        public int distance = 50;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Victus");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 24;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 120;
            Projectile.velocity *= 3;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player p = Main.player[Projectile.owner];

        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Vector2 speed = Main.rand.NextVector2Circular(0.5f, 0.5f);
                Dust.NewDustPerfect(Projectile.Center, DustID.Gold, speed * 2);
            }
        }
    }
}