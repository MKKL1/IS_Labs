"""
json to yaml converter
"""
import yaml
from deserialize_json import DeserializeJson


class ConvertJsonToYaml:
    @staticmethod
    def run(deserialized_data, destination_file_location):
        print("let's convert something")
        with open(destination_file_location, 'w', encoding='utf-8') as f:
            yaml.dump(deserialized_data, f, allow_unicode=True)
        print("it is done")

    @staticmethod
    def convertFile(json_path, destination_file_location):
        print("let's convert something")

        deserializator = DeserializeJson.create_from_file(json_path)
        with open(destination_file_location, 'w', encoding='utf-8') as f:
            yaml.dump(deserializator.data, f, allow_unicode=True)
        print("it is done")
