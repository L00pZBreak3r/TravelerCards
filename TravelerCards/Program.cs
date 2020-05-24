using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TravelerCards
{
  class Program
  {
    private static List<TravelerCard> ParseInputFile(string fileName)
    {
      List<TravelerCard> res = null;
      if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName))
      {
        res = new List<TravelerCard>();
        using (var sr = File.OpenText(fileName))
        {
          string s = "";
          while ((s = sr.ReadLine()) != null)
          {
            if (!string.IsNullOrWhiteSpace(s))
            {
              char sep = ' ';
              int i = s.IndexOf('"');
              if (i >= 0)
              {
                sep = '"';
                s = s.Replace("\" ", "\"").Replace(" \"", "\"");
              }
              var a = s.Trim().Split(new char[] { sep }, StringSplitOptions.RemoveEmptyEntries);
              if (a.Length > 1)
                res.Add(new TravelerCard(a[0].Trim(), a[1].Trim()));
            }
          }
        }
      }
      return res;
    }

    static void Main(string[] args)
    {
      string inpfile = "input.txt";
      string outfile = "output.txt";
      bool mt = false;
      if (args.Length > 0)
      {
        mt = "maketest".Equals(args[0], StringComparison.OrdinalIgnoreCase);
        if (mt)
        {
          int c = 10000;
          string fn = "input.txt";
          if (args.Length > 1)
          {
            if (!int.TryParse(args[1], out c))
              c = 10000;
            if (args.Length > 2)
              fn = args[2];
          }
          var t = TravelerCardTester.CreateTest(c);
          File.WriteAllLines(fn, t.Select(m => m.ToString()));
          Console.WriteLine("Test file \"{0}\" created.", fn);
        }
        else
        {
          inpfile = args[0];
          if (args.Length > 1)
            outfile = args[1];
        }
      }
      if (!mt && File.Exists(inpfile))
      {
        var lst = ParseInputFile(inpfile);
        var t = TravelerCardSorter.Sort(lst);
        if (t != null)
        {
          File.WriteAllLines(outfile, t.Select(m => m.ToString()));
          Console.WriteLine("The input list was successfully sorted. Result was saved to \"{0}\".", outfile);
        }
        else
          Console.WriteLine("Cannot sort the traveler card list.");
      }
    }
  }
}
