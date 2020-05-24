using System;
using System.Collections.Generic;

namespace TravelerCards
{
  static class TravelerCardTester
  {
    public static List<TravelerCard> CreateTest(int count)
    {
      if (count > 0)
      {
        List<TravelerCard> t = new List<TravelerCard>(count);
        for (int i = 0; i < count; i++)
          t.Add(new TravelerCard((i + 1).ToString(), (i + 2).ToString()));
        List<TravelerCard> t2 = new List<TravelerCard>(count);
        var rnd = new Random();
        while (t.Count > 0)
        {
          int i = rnd.Next(t.Count);
          t2.Add(t[i]);
          t.RemoveAt(i);
        }
        return t2;
      }
      return null;
    }
  }
}
