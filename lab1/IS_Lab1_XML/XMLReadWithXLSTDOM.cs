using System.Xml;
using System.Xml.XPath;

namespace IS_Lab1_XML;

internal class XMLReadWithXLSTDOM
{
    public static void Read(string xmlpath)
    {
        XPathDocument document = new XPathDocument(xmlpath);
        XPathNavigator navigator = document.CreateNavigator();
        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("x", "http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danych-v1.0");
        XPathExpression query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@nazwaPostaciFarmaceutycznej='Krem' and @nazwaPowszechnieStosowana='Mometasoni furoas']");
        query.SetContext(manager);
        int count = navigator.Select(query).Count;
        Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas {0}", count );
    }
}