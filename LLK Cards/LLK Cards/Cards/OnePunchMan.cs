using RarityLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace LLKCards.Cards
{
    class OnePunchMan : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            gun.reloadTime = 5;
            statModifiers.movementSpeed = 1.5f;
            statModifiers.jump = 1.3f;
            cardInfo.allowMultiple = false;
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            gun.damage *= 10f;
            gunAmmo.maxAmmo = 1;
            gun.knockback = +10;
            ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(characterStats).punch = true;
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }


        protected override string GetTitle()
        {
            return "One-Punch Man";
        }
        protected override string GetDescription()
        {
            return "Saitama, is that you?";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            //return CardInfo.Rarity.Rare;
            return RarityUtils.GetRarity("Legendary");
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "DMG",
                    amount = "+1000%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Movement SPD",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Knockback",
                    amount = "+10",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Jump Height",
                    amount = "+30%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Ammo",
                    amount = "1 max",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload SPD",
                    amount = "*5",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.FirepowerYellow;
        }
        public override string GetModName()
        {
            return LLKCards.ModInitials;
        }
    }
}
