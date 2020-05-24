using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerCards
{
  static class TravelerCardSorter
  {
    public static List<TravelerCard> Sort(List<TravelerCard> list)
    {
      List<TravelerCard> res = null;
      if ((list != null) && (list.Count > 0))
      {
        ParallelLoopResult result = Parallel.ForEach(list,
                                                     (cur) => {
                                                       if (cur.Pred == null)
                                                       {
                                                         var cd1 = list.Find(m => m.Finish.Equals(cur.Start, StringComparison.CurrentCultureIgnoreCase));
                                                         if (cd1 != null)
                                                         {
                                                           cur.Pred = cd1;
                                                           cd1.Next = cur;
                                                         }
                                                       }
                                                       if (cur.Next == null)
                                                       {
                                                         var cd2 = list.Find(m => m.Start.Equals(cur.Finish, StringComparison.CurrentCultureIgnoreCase));
                                                         if (cd2 != null)
                                                         {
                                                           cur.Next = cd2;
                                                           cd2.Pred = cur;
                                                         }
                                                       }
                                                     });

        var cd = list.Find(m => m.Pred == null);
        if (cd != null)
        {
          List<TravelerCard> t0 = new List<TravelerCard>(list);
          List<TravelerCard> t = new List<TravelerCard>(t0.Count);
          t.Add(cd);
          t0.Remove(cd);
          cd = cd.Next;
          while ((t0.Count > 0) && (cd != null) && !t.Contains(cd))
          {
            t.Add(cd);
            t0.Remove(cd);
            cd = cd.Next;
          }
          if ((t.Count == list.Count) && (t[0].Pred == null) && (t.Last().Next == null))
          {
            res = t;
          }
        }
      }
      return res;
    }
  }
}
