using HarmonyLib;
using Verse;
using UnityEngine;
using RimWorld;
using RimWorld.QuestGen;

namespace LimitQuestPawns {
    [StaticConstructorOnStartup]
    public class Main {
        static Main() {
            var harmony = new Harmony(Strings.ID);
            harmony.PatchAll();
        }
    }
}
