using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using RaceSimulationWPF.Model;

namespace RaceSimulationWPF.Helpers
{
    public class Helper
    {  
        public static List<Person> GetPersonsFromXML(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            List<Person> persons = new List<Person>();

            XmlNodeList elemList = doc.GetElementsByTagName("Person");
            for (int i = 0; i < elemList.Count; i++)
            {
                var p = new Person();
                var node = elemList[i];
                p.Id = int.Parse(node.Attributes["id"].Value);
                p.Country = node.Attributes["country"].Value;
                p.Name = node.FirstChild.InnerText;
                persons.Add(p);
            }

            return persons;

        }

        public static IList<Person> SortPersonList(IList<Person> persons)
        {
            IList<Person> sortedList = persons.OrderBy(person => person.Id).ToList();
            return sortedList;
        }

        public static IList<RaceResult> SortResultsAndAssignRanks(IList<RaceResult> raceResults)
        {
            int rank = 1;
            int completedCount = raceResults.Where(rr => rr.NetTime.HasValue).Count();
            int dnfRank = completedCount;
            int dsqRank = completedCount;
            int dnsRank = completedCount;
           
            if (raceResults.Where(rr => rr.Irm != null && rr.Irm.ToLower() == "dnf").Count() > 0)
                dnfRank = dnfRank + 1;
            if (raceResults.Where(rr => rr.Irm != null && rr.Irm.ToLower() == "dsq").Count() > 0)
                dsqRank = dnfRank + 1;
            if (raceResults.Where(rr => rr.Irm != null && rr.Irm.ToLower() == "dns").Count() > 0)
                dnsRank = dsqRank + 1;

            IList<RaceResult> sortedList = raceResults.OrderByDescending(rr => rr.NetTime.HasValue).OrderBy(rr => rr.NetTime).ToList();

            foreach(RaceResult rr in sortedList)
            {
                if (rr.NetTime.HasValue)
                    rr.Rank = rank++;   // first assign rank to those who completed the race
                else
                {
                    if(rr.Irm.ToUpper() == "DNF")
                        rr.Rank = dnfRank;   //first rank after all competitors who completed the race
                    else if (rr.Irm.ToUpper() == "DSQ")
                        rr.Rank = dsqRank;
                    else if (rr.Irm.ToUpper() == "DNS")
                        rr.Rank = dnsRank;
                }
            }

            sortedList = raceResults.OrderBy(rr => rr.Rank).ToList();

            return sortedList;
        }

        public static XmlDocument SerializeToXmlDocument(ExportFormat input)
        {
            XmlSerializer ser = new XmlSerializer(input.GetType());
            XmlDocument xd = null;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, input);
                memStm.Position = 0;
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                using (var xtr = XmlReader.Create(memStm, settings))
                {
                    xd = new XmlDocument();
                    xd.Load(xtr);
                }
            }

            return xd;
        }
    }
}
