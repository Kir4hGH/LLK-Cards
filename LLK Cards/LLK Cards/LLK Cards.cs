using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using LLKCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;


namespace LLKCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class LLKCards : BaseUnityPlugin
    {
        private const string ModId = "com.LLK.rounds.LLKCards";
        private const string ModName = "LLK Cards";
        public const string Version = "0.1.1"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "LLK";
        public static LLKCards instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<Rat>();
            CustomCard.BuildCard<BounceInfinite>();
            CustomCard.BuildCard<KingKong>();
            CustomCard.BuildCard<NoWay>();
            CustomCard.BuildCard<OnePunchMan>();
            CustomCard.BuildCard<TrollCard>();
            CustomCard.BuildCard<SniperCard>();
        }
    }
}
