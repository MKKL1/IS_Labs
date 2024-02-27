"""
serialize json
"""
import json
class SerializeJson:
    #metoda statyczna
    @staticmethod
    def run(deserializeddata, filelocation):
        print("let's serialize something")
        with open(filelocation, 'w',encoding='utf-8') as f:
            json.dump(SerializeJson.get_data(deserializeddata), f, ensure_ascii=False)
    @staticmethod
    def get_data(deserializeddata):
        lst = []
        etykiety = ['Kod_TERYT', 'Województwo','Powiat','typ_JST','nazwa_urzędu_JST','miejscowość']
        #TODO – do modyfikacji
        for dep in deserializeddata.data:
            tmp_dep = {}
            for e in etykiety:
                tmp_dep[e] = dep.get(e)
            tmp_dep['telefon_z_numerem_kierunkowym'] = str(dep.get('telefon kierunkowy')) + " " + str(dep.get('telefon'))
            lst.append(tmp_dep)
        return {"departaments":lst}