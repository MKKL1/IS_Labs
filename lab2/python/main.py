print("hey, it's me - Python!")
from deserialize_json import DeserializeJson
import yaml
tempconffile = open('Assets/basic_config.yaml',encoding="utf8")
confdata = yaml.load(tempconffile, Loader=yaml.FullLoader)

deserializator = DeserializeJson.create_from_file(confdata['paths']['source_folder'] + confdata['paths']['json_source_file'])
deserializator.somestats()
deserializator.count_woj()

from serialize_json import SerializeJson
datamodjsonpath = confdata['paths']['source_folder'] + confdata['paths']['json_destination_file']
datamodyamlpath = confdata['paths']['source_folder'] + confdata['paths']['yaml_destination_file']
SerializeJson.runToFile(deserializator, datamodjsonpath)

from convert_json_to_yaml import ConvertJsonToYaml
ConvertJsonToYaml.run(SerializeJson.get_data(deserializator), datamodyamlpath)
ConvertJsonToYaml.convertFile(datamodjsonpath, datamodyamlpath)
