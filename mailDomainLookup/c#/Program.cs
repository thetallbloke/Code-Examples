using DnsClient;

class Program
{
    static void Main()
    {
        string resultsFile = "results.txt";
        string domainList = "lookupDomains.txt";

        if (File.Exists(resultsFile))
        {
            File.Delete(resultsFile);
        }

        var domains = new List<string>();

        if (File.Exists(domainList))
        {
            domains.AddRange(File.ReadAllLines(domainList));
            Console.WriteLine($"Reading domains from {domainList} - {domains.Count} domains found");
        }

        foreach (var domain in domains)
        {
            //var mxRecords = Dns.GetHostEntry(domain).HostName;

            LookupClient client = new LookupClient();
            var result = client.Query(domain, QueryType.MX);
            string mxRecords = string.Join(",", result.Answers.MxRecords().Select(record => record.Exchange.Value));

            //IPHostEntry hostEntry = Dns.GetHostEntry(domain);

            var paddedDomain = domain.PadRight(22, ' ');
            string provider = "";

            if (result.Answers.MxRecords().Any(record => record.Exchange.Value.Contains("google.com")))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                provider = "Google";
            }
            else if (result.Answers.MxRecords().Any(record => record.Exchange.Value.Contains("outlook.com")) ||
                     result.Answers.MxRecords().Any(record => record.Exchange.Value.Contains("hotmail.com")) ||
                     result.Answers.MxRecords().Any(record => record.Exchange.Value.Contains("live.com")) ||
                     result.Answers.MxRecords().Any(record => record.Exchange.Value.Contains(".mail.protection.outlook.com")))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                provider = "Microsoft";
            }
            else if (result.Answers.MxRecords().Any(record => record.Exchange.Value.Contains("mxrecord.io")))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                provider = "??????????";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                provider = "Other";
            }

            var paddedProvider = provider.PadRight(12, ' ');

            using (StreamWriter sw = File.AppendText(resultsFile))
            {
                sw.WriteLine($"{paddedDomain} -- {paddedProvider} {mxRecords}");
                Console.WriteLine($"{paddedDomain} -- {paddedProvider} {mxRecords}");
            }
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Done. Results saved to {resultsFile}");
        Console.ResetColor();
    }
}