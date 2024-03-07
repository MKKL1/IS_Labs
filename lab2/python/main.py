from deserialize_json import DeserializeJson
from serialize_json import SerializeJson
from convert_json_to_yaml import ConvertJsonToYaml

import yaml

tempconffile = open('Assets/basic_config.yaml', encoding="utf8")
confdata = yaml.load(tempconffile, Loader=yaml.FullLoader)

deserializator = DeserializeJson.create_from_file(
    confdata['paths']['source_folder'] + confdata['paths']['json_source_file'])
datamodjsonpath = confdata['paths']['source_folder'] + confdata['paths']['json_destination_file']
datamodyamlpath = confdata['paths']['source_folder'] + confdata['paths']['yaml_destination_file']


def serialize():
    print('serializacja')
    SerializeJson.runToFile(deserializator, datamodjsonpath)


def convert():
    print('konwersja')
    # wybór czy plik, czy obiekt. Jeżeli scieżka 'conversion_source_file' jest podana to zostanie wybrany plik,
    # jeżeli nie jest podana zostaną wybrane dane z obiektu deserializator
    if 'conversion_source_file' in confdata['paths']:
        print('czytam plik')
        ConvertJsonToYaml.convertFile(confdata['paths']['source_folder'] + confdata['paths']['conversion_source_file'],datamodyamlpath)
    else:
        print('czytam z obiektu')
        ConvertJsonToYaml.run(SerializeJson.get_data(deserializator), datamodyamlpath)


def stats():
    deserializator.somestats()


def count():
    deserializator.count_woj()


print('Operacje do wykonania: ', confdata['operations'])

operations = {'serialize': serialize, 'convert': convert, 'stats': stats, 'count': count}
for op in confdata['operations']:
    if op not in operations.keys():
        print('Nieznana operacja ', op)
    else:
        operations[op]()
