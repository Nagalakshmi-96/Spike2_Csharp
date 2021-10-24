//using System;
//using System.Linq;
//using System.Data;
//using System.Collections.Generic;

//public class Program
//{
//    public class Dates
//    {
//        public DateTime ActiveDate;
//        public DateTime ExpireDate;
//        public string Name;
//    }

//    public static void Main()
//    {
//        original code.
//        List<Dates> datesList = new List<Dates>();
//        datesList.Add(new Dates { Name = "A", ActiveDate = new DateTime(2017, 8, 20), ExpireDate = new DateTime(2017, 8, 23) }); //Aug 20 - Aug 23
//        datesList.Add(new Dates { Name = "B", ActiveDate = new DateTime(2017, 8, 20), ExpireDate = new DateTime(2017, 8, 22) }); //Aug 20 - Aug 22
//        datesList.Add(new Dates { Name = "C", ActiveDate = new DateTime(2017, 8, 22, 23, 0, 0), ExpireDate = new DateTime(2017, 8, 26) }); //Aug 22 11pm - Aug 26
//        datesList.Add(new Dates { Name = "D", ActiveDate = new DateTime(2017, 8, 20), ExpireDate = new DateTime(2017, 8, 23) }); //Aug 20 - Aug23


//        extrapolate the actual arrays of days that belong to each "Dates" object
//       var compareRanges = datesList.Select(d => GetDateRange(d)).ToList();

//        foreach (var o in compareRanges)
//        {
//            Console.WriteLine(o);
//        }

//        do a bit of LINQ here...
//        var result = CompareDates(compareRanges, 3);

//        output the results.
//       Console.WriteLine("Overlaps");
//        foreach (var dt in result)
//        {
//            Console.WriteLine(dt.ToString("M/d/yyyy"));
//        }

//        var maxOverlap = GetLongestOverlap(compareRanges);

//        Console.WriteLine();
//        Console.WriteLine("Most overlaps: " + maxOverlap.Item2);
//        foreach (var dt in maxOverlap.Item1)
//        {
//            Console.WriteLine(dt.ToString("M/d/yyyy"));
//        }

//        Console.Read();
//    }


//    private static DateTime[] GetDateRange(Dates dt)
//    {

//        var start = dt.ActiveDate.Date;
//        var end = dt.ExpireDate.Date;


//        return Enumerable.Range(0, Convert.ToInt32((end.Date - start.Date).TotalDays) + 1)
//            .Select(e => start.Date.AddDays(e)).ToArray();
//    }

//    set the threshold to filter the overlapped dates...
//    private static List<DateTime> CompareDates(List<DateTime[]> compareRanges, int overlapThreshold = 1)
//    {
//        merge all the days into a grouped listing
//        var grouped = compareRanges.SelectMany(r => r).GroupBy(d => d.Date);

//        filter the grouped list based on the overlap threshold, and pick out the appropriate dates
//       var thresholdMatch = grouped.Where(g => g.Count() >= overlapThreshold)
//           .Select(g => g.Key)
//           .OrderBy(d => d)
//           .ToList();

//        return thresholdMatch;
//    }


//    which date in the ranges list has the most overlaps
//    private static Tuple<List<DateTime>, int> GetLongestOverlap(List<DateTime[]> compareRanges)
//    {
//        var grouped = compareRanges.SelectMany(r => r).GroupBy(d => d.Date);
//        var max = grouped.Max(g => g.Count());
//        var maxMatch = grouped.Where(g => g.Count() == max)
//            .Select(g => g.Key)
//            .OrderBy(d => d)
//            .ToList();

//        return new Tuple<List<DateTime>, int>(maxMatch, max);
//    }
//}