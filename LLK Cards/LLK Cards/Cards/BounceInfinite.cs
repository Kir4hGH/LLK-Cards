using ModdingUtils.Extensions;
using RarityLib.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Utils;
using UnityEngine;


namespace LLKCards.Cards
{
    class BounceInfinite : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            List<CardInfo> activecards = ((ObservableCollection<CardInfo>)typeof(CardManager).GetField("activeCards", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null)).ToList();
            List<CardInfo> inactivecards = (List<CardInfo>)typeof(CardManager).GetField("inactiveCards", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            List<CardInfo> allcards = activecards.Concat(inactivecards).ToList();

            CardInfo targetBounceCard = allcards.Where(card => card.gameObject.name == "TargetBounce").ToList()[0];
            Gun targetBounceGun = targetBounceCard.GetComponent<Gun>();
            ObjectsToSpawn screenEdgeToSpawn = (new List<ObjectsToSpawn>(targetBounceGun.objectsToSpawn)).Where(objectToSpawn => objectToSpawn.AddToProjectile.GetComponent<ScreenEdgeBounce>() != null).ToList()[0];


            List<ObjectsToSpawn> objectsToSpawn = gun.objectsToSpawn.ToList();
            objectsToSpawn.Add(screenEdgeToSpawn);
            gun.objectsToSpawn = objectsToSpawn.ToArray();

            gun.reflects += 10000;
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            //UnityEngine.Debug.Log($"[{LLKCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }


        protected override string GetTitle()
        {
            return "Infinite Bounce";
        }
        protected override string GetDescription()
        {
            return "Almost endless bounces";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
            //return RarityUtils.GetRarity("Legendary");
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bounces",
                    amount = "Infinite",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.PoisonGreen;
        }
        public override string GetModName()
        {
            return LLKCards.ModInitials;
        }
    }
}
