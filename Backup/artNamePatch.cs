// Decompiled with JetBrains decompiler
// Type: MonsterMash.artNamePatch
// Assembly: MonsterMash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A94756C7-C0E1-42C5-80F4-CD7841A4CCB0
// Assembly location: C:\Users\Sebastian\Desktop\ManBearPig.dll

using Harmony;
using RimWorld;
using System;
using Verse;

namespace MonsterMash
{
  [HarmonyPatch(typeof (CompArt), "JustCreatedBy", new Type[] {typeof (Pawn)})]
  internal static class artNamePatch
  {
    public static bool checkNamePrefix(ref Pawn pawn)
    {
      Log.Message("Checking for Pawn Name");
      bool flag;
      if (pawn.get_Name() == null)
      {
        Log.Message("No Pawn Name Found");
        Traverse.Create<CompArt>().Property("authorNameInt", (object[]) null).SetValue((object) "None");
        flag = false;
      }
      else
      {
        Log.Message("Pawn Name Found");
        flag = true;
      }
      return flag;
    }
  }
}
