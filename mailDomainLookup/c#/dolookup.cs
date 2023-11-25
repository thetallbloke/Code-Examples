//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;

//class Program
//{
//    static void Main()
//    {
//        string resultsFile = "results.txt";
//        string domainList = "lookupDomains.txt";

//        if (File.Exists(resultsFile))
//        {
//            File.Delete(resultsFile);
//        }

//        var domains = new List<string>();

//        if (File.Exists(domainList))
//        {
//            domains.AddRange(File.ReadAllLines(domainList));
//            Console.WriteLine($"Reading domains from {domainList} - {domains.Count} domains found");
//        }

//        foreach (var domain in domains)
//        {
//            var mxRecords = Dns.GetHostEntry(domain).HostName;

//            var paddedDomain = domain.PadRight(22, ' ');
//            string provider = "";

//            if (mxRecords.Contains("google.com"))
//            {
//                provider = "Google";
//            }
//            else if (mxRecords.Contains("outlook.com") || mxRecords.Contains("hotmail.com") || mxRecords.Contains("live.com") || mxRecords.Contains(".mail.protection.outlook.com"))
//            {
//                provider = "Microsoft";
//            }
//            else if (mxRecords.Contains("mxrecord.io"))
//            {
//                provider = "??????????";
//            }
//            else
//            {
//                provider = "Other";
//            }

//            var paddedProvider = provider.PadRight(12, ' ');

//            using (StreamWriter sw = File.AppendText(resultsFile))
//            {
//                sw.WriteLine($"{paddedDomain} -- {paddedProvider} {mxRecords}");
//                Console.WriteLine($"{paddedDomain} -- {paddedProvider} {mxRecords}");
//            }
//        }

//        Console.WriteLine($"Done. Results saved to {resultsFile}");
//    }
//}