import xml.etree.ElementTree as ET
import xml.dom.minidom as minidom
import json


def xml2json(xmlpath, jsonpath):
    lst = []

    with open(xmlpath, 'r', encoding="utf-8") as f:
        root = ET.fromstring(f.read())
        for child in root:
            urz = {}
            for c2 in child:
                if c2.text is not None:
                    urz[c2.tag] = c2.text
            lst.append(urz)
        json.dump(lst, open(jsonpath, 'w', encoding="utf-8"), ensure_ascii=False, indent=2)


def json2xml(jsonpath, xmlpath):
    with open(jsonpath, 'r', encoding="utf-8") as f:
        js = json.load(f)
        root = ET.Element("root")
        for row in js:
            record = ET.SubElement(root, "urzad")
            for key, value in row.items():
                field = ET.SubElement(record, key)
                field.text = value
        xml_str = ET.tostring(root, encoding='utf-8')
        dom = minidom.parseString(xml_str)
        with open(xmlpath, 'w', encoding='utf-8') as xmlfile:
            xmlfile.write(dom.toprettyxml(indent="  "))


xml2json('Assets\\data.xml', 'Assets\\data2.json')
json2xml('Assets\\data.json', 'Assets\\data2.xml')
