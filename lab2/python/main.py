print("hey, it's me - Python!")
from deserialize_json import DeserializeJson
from serialize_json import SerializeJson
newDeserializator = DeserializeJson('Assets/data.json')
newDeserializator.somestats()
newDeserializator.countWoj()

from serialize_json import SerializeJson
SerializeJson.run(newDeserializator, 'Assets/data_mod.json')

from convert_json_to_yaml import ConvertJsonToYaml
ConvertJsonToYaml.run(SerializeJson.get_data(newDeserializator), 'Assets/data_mod.yaml')
ConvertJsonToYaml.convert('Assets/data_mod.json', 'Assets/data_mod.yaml')
