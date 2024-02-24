using System.Xml;

namespace IS_Lab1_XML
{
    internal class XMLReadWithDOMApproach
    {
        internal static void Read(string xmlpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);
            string postac;
            string sc;
            int count = 0;
            var drugs = doc.GetElementsByTagName("produktLeczniczy");
            Dictionary<string, string> nazwy = new();
            foreach (XmlNode d in drugs)
            {
                postac = d.Attributes.GetNamedItem("nazwaPostaciFarmaceutycznej").Value;
                sc = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
                if (nazwy.ContainsKey(sc))
                {
                    if(nazwy[sc] != postac) //Jezeli postac inna niz juz sprawdzona
                        count++;
                } else nazwy.Add(sc, postac);
            }
            Console.WriteLine("Liczba produktów leczniczych w o takiej samej nazwie powszechnej, ale o różnych postaciach {0}", count);
        }
    }
}