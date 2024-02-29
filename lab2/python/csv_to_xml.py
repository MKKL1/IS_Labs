import csv
import xml.etree.ElementTree as ET
import xml.dom.minidom as minidom

def csv_to_xml(csv_file, xml_file):
    with open(csv_file, encoding="utf-8") as f:
        reader = csv.DictReader(f)

        root = ET.Element("root")
        for row in reader:
            record = ET.SubElement(root, "urzad")
            for key, value in row.items():
                field = ET.SubElement(record, key.replace(' ', '_').replace('/', '_'))
                field.text = value

    xml_str = ET.tostring(root, encoding='utf-8')
    dom = minidom.parseString(xml_str)
    with open(xml_file, 'w', encoding='utf-8') as xmlfile:
        xmlfile.write(dom.toprettyxml(indent="  "))


# Example usage
csv_to_xml('Assets\\data.csv', 'Assets\\data.xml')
