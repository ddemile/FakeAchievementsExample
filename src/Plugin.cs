using BepInEx;
using FakeAchievements;
using UnityEngine;

namespace FakeAchievementsExample
{
    [BepInPlugin(MOD_ID, "Fake Achievements Example", "0.1.0")]
    class Plugin : BaseUnityPlugin
    {
        internal const string MOD_ID = "ddemile.fake_achievements_example";

        // Add hooks
        public void OnEnable()
        {
            On.RainWorld.OnModsInit += Extras.WrapInit(LoadResources);

            // Put your custom hooks here!
            On.Player.Die += Player_Die;
        }
        
        // Load any resources, such as sprites or sounds
        private void LoadResources(RainWorld rainWorld)
        {
        }

        private void Player_Die(On.Player.orig_Die orig, Player self)
        {
            orig(self);

            AchievementsManager.ShowAchievement(Achievements.Die);
        }
    }
}