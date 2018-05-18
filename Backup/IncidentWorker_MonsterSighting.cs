// Decompiled with JetBrains decompiler
// Type: MonsterMash.IncidentWorker_MonsterSighting
// Assembly: MonsterMash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A94756C7-C0E1-42C5-80F4-CD7841A4CCB0
// Assembly location: C:\Users\Sebastian\Desktop\ManBearPig.dll

using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using Verse.AI;

namespace MonsterMash
{
  public class IncidentWorker_MonsterSighting : IncidentWorker
  {
    protected virtual bool CanFireNowSub(IIncidentTarget target)
    {
      return !((GameConditionManager) ((Map) target).gameConditionManager).ConditionIsActive((GameConditionDef) GameConditionDefOf.ToxicFallout);
    }

    protected virtual bool TryExecuteWorker(IncidentParms parms)
    {
      Map target = (Map) parms.target;
      IntVec3 intVec3_1;
      if (!RCellFinder.TryFindRandomPawnEntryCell(ref intVec3_1, target, (float) (CellFinder.EdgeRoadChance_Animal + 0.200000002980232), (Predicate<IntVec3>) null))
        return false;
      PawnKindDef pawnKindDef = IncidentWorker_MonsterSighting.selectMonster();
      int num1 = Mathf.Clamp(GenMath.RoundRandom((float) StorytellerUtility.DefaultParmsNow((StorytellerDef) Find.get_Storyteller().def, (IncidentCategory) 3, (IIncidentTarget) target).points / (float) pawnKindDef.combatPower), 1, Rand.RangeInclusive(2, 4));
      int num2 = Rand.RangeInclusive(90000, 150000);
      IntVec3 invalid = IntVec3.get_Invalid();
      if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(intVec3_1, target, 10f, ref invalid))
        invalid = IntVec3.get_Invalid();
      Pawn pawn = (Pawn) null;
      for (int index = 0; index < num1; ++index)
      {
        IntVec3 intVec3_2 = CellFinder.RandomClosewalkCellNear(intVec3_1, target, 10, (Predicate<IntVec3>) null);
        pawn = PawnGenerator.GeneratePawn(pawnKindDef, (Faction) null);
        GenSpawn.Spawn((Thing) pawn, intVec3_2, target, Rot4.get_Random(), false);
        ((Pawn_MindState) pawn.mindState).exitMapAfterTick = (__Null) (Find.get_TickManager().get_TicksGame() + num2);
        // ISSUE: explicit reference operation
        if (((IntVec3) @invalid).get_IsValid())
          ((Pawn_MindState) pawn.mindState).forcedGotoPosition = (__Null) CellFinder.RandomClosewalkCellNear(invalid, target, 10, (Predicate<IntVec3>) null);
      }
      Find.get_LetterStack().ReceiveLetter(GenText.CapitalizeFirst(Translator.Translate("LetterLabelMonsterSighting", new object[1]
      {
        (object) ((Def) pawnKindDef).label
      })), Translator.Translate("LetterMonsterSighting", new object[1]
      {
        (object) ((Def) pawnKindDef).label
      }), (LetterDef) LetterDefOf.PositiveEvent, GlobalTargetInfo.op_Implicit((Thing) pawn), (string) null);
      return true;
    }

    public static PawnKindDef selectMonster()
    {
      return (PawnKindDef) GenCollection.RandomElement<PawnKindDef>((IEnumerable<M0>) DefDatabase<PawnKindDef>.get_AllDefs().Where<PawnKindDef>((Func<PawnKindDef, bool>) (defs => ((string) ((Def) defs).defName).Equals("CarrionCrawler") | ((string) ((Def) defs).defName).Equals("InfernoBeetle") | ((string) ((Def) defs).defName).Equals("LandKraken") | ((string) ((Def) defs).defName).Equals("PolarColossus") | ((string) ((Def) defs).defName).Equals("SanguineDrake"))));
    }

    public IncidentWorker_MonsterSighting()
    {
      base.\u002Ector();
    }
  }
}
