// Decompiled with JetBrains decompiler
// Type: MonsterMash.bleedRatePatch
// Assembly: MonsterMash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A94756C7-C0E1-42C5-80F4-CD7841A4CCB0
// Assembly location: C:\Users\Sebastian\Desktop\ManBearPig.dll

using Harmony;
using RimWorld;
using Verse;

namespace MonsterMash
{
  [HarmonyPatch(typeof (HediffSet), "CalculateBleedRate", null)]
  internal static class bleedRatePatch
  {
    public static void bleedRatePostfix(ref float __result, HediffSet __instance)
    {
      __result *= StatExtension.GetStatValue((Thing) __instance.pawn, StatDef.Named("BleedRate"), true);
    }
  }
}
