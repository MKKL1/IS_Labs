"""
json to yaml converter
"""
import yaml
from deserialize_json import DeserializeJson
class ConvertJsonToYaml:
    @staticmethod
    def run(deserializeddata , destinationfilelocaiton):
        print("let's convert something")
        with open(destinationfilelocaiton, 'w', encoding='utf-8') as f:
            yaml.dump(deserializeddata, f, allow_unicode=True)
        print("it is done")

    @staticmethod
    def convert(jsonPath, destinationfilelocaiton):
        print("let's convert something")

        newDeserializator = DeserializeJson(jsonPath)
        with open(destinationfilelocaiton, 'w', encoding='utf-8') as f:
            yaml.dump(newDeserializator.data, f, allow_unicode=True)
        print("it is done")