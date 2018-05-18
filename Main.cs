// Decompiled with JetBrains decompiler
// Type: ManBearPig.Main
// Assembly: ManBearPig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A94756C7-C0E1-42C5-80F4-CD7841A4CCB0
// Assembly location: C:\Users\Sebastian\Desktop\ManBearPig.dll

using Harmony;
using System.Reflection;
using Verse;

namespace ManBearPig
{
  [StaticConstructorOnStartup]
  internal class Main
  {
    static Main()
    {
      HarmonyInstance.Create("com.mash.monster").PatchAll(Assembly.GetExecutingAssembly());
    }
  }
}
