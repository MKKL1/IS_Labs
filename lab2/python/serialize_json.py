"""
serialize json
"""
import json


class SerializeJson:
    @staticmethod
    def runToFile(deserialized_data, destination_file_locaiton):
        with open(destination_file_locaiton, 'w', encoding='utf-8') as f:
            json.dump(SerializeJson.get_data(deserialized_data), f, ensure_ascii=False)

    @staticmethod
    def run(deserialized_data):
        return json.dump(SerializeJson.get_data(deserialized_data))

    @staticmethod
    def get_data(deserialized_data):
        lst = []
        etykiety = ['Kod_TERYT', 'Województwo', 'Powiat', 'typ_JST', 'nazwa_urzędu_JST', 'miejscowość']
        for dep in deserialized_data.data:
            tmp_dep = {}
            for e in etykiety:
                tmp_dep[e] = dep.get(e)
            tmp_dep['telefon_z_numerem_kierunkowym'] = str(dep.get('telefon kierunkowy')) + " " + str(
                dep.get('telefon'))
            lst.append(tmp_dep)
        return {"departaments": lst}
