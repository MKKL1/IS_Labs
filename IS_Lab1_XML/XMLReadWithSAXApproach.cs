using System.Xml;

namespace IS_Lab1_XML
{
    internal class XMLReadWithSAXApproach
    {
        internal static void Read(string xmlpath)
        {
            // konfiguracja początkowa dla XmlReadera
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;
            // odczyt zawartości dokumentu
            XmlReader reader = XmlReader.Create(xmlpath, settings);
            // zmienne pomocnicze
            int count = 0;
            string postac = "";
            string sc = "";
            reader.MoveToContent();
            Dictionary<string, string> nazwy = new();
            // analiza każdego z węzłów dokumentu
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "produktLeczniczy")
                {
                    postac = reader.GetAttribute("nazwaPostaciFarmaceutycznej");
                    sc = reader.GetAttribute("nazwaPowszechnieStosowana");
                    if (nazwy.ContainsKey(sc))
                    {
                        if(nazwy[sc] != postac) //Jezeli postac inna niz juz sprawdzona
                            count++;
                    } else nazwy.Add(sc, postac);
                }
            }
            Console.WriteLine("Liczba produktów leczniczych w o takiej samej nazwie powszechnej, ale o różnych postaciach {0}", count);
        }
    }
}