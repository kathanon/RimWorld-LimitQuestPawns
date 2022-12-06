using HarmonyLib;
using RimWorld.QuestGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace LimitQuestPawns {
    [HarmonyPatch]
    public static class Patches {
        private const string MethodName = "DoesPawnCountAsAvailableForFight";

        [HarmonyTargetMethods]
        public static IEnumerable<MethodBase> Methods() {
            var baseType = typeof(QuestNode_Root_Mission);
            yield return AccessTools.Method(baseType, MethodName);
            foreach (var type in baseType.AllSubclasses()) {
                var method = type.GetMethod(MethodName, AccessTools.allDeclared);
                if (method != null) yield return method;
            }
        }

        [HarmonyPostfix]
        public static bool PawnCountAsAvailable(bool res, Pawn p)
            => res && p.ageTracker.Adult;
    }
}
