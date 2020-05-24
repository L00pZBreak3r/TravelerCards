using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerCards
{
  class TravelerCard
  {
    public readonly string Start;
    public readonly string Finish;

    public TravelerCard Pred;
    public TravelerCard Next;

    public TravelerCard(string start, string finish)
    {
      Start = start;
      Finish = finish;
    }

    #region ToString

    public override string ToString()
    {
      return string.Format("\"{0}\" \"{1}\"", Start, Finish);
    }

    #endregion
  }
}
