﻿using RarityLib.Utils;
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
    class TrollCard : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            statModifiers.health = 0.1f;
            statModifiers.movementSpeed = 0.1f;
            statModifiers.jump = 0.1f;
            statModifiers.lifeSteal = 0;
            statModifiers.sizeMultiplier = 3f;
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            gun.damage /= 10f;
            gun.projectileSpeed /= 10f;
            gun.attackSpeed *= 10f;
            gun.reloadTime *= 10f;
            gun.gravity *= 10f;
            gun.slow *= 10f;
            gun.reflects -= 100;
            block.cooldown *= 10f;
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }


        protected override string GetTitle()
        {
            return "Trololo";
        }
        protected override string GetDescription()
        {
            return "You've been trolled!";
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
                    stat = "Block CD",
                    amount = "-1000%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Attack SPD",
                    amount = "-1000%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Reload SPD",
                    amount = "-1000%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bounces",
                    amount = "+100",
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
