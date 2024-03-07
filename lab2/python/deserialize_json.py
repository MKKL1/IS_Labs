# -*- coding: utf-8 -*-
"""
deserialize json
"""
import json


class DeserializeJson:
    def __init__(self, data):
        self.data = json.load(data)

    @staticmethod
    def create_from_file(filename):
        tempdata = open(filename, encoding="utf-8-sig")
        return DeserializeJson(tempdata)

    @staticmethod
    def create_from_data(data):
        return DeserializeJson(data)

    def somestats(self):
        example_stat = 0
        for dep in self.data:
            if (dep.get('typ_JST') and
                    dep.get('Województwo') and
                    dep['typ_JST'] == 'GM' and
                    dep['Województwo'] == 'dolnośląskie'):
                example_stat += 1
        print('liczba urzędów miejskich w województwie dolnośląskim: ' + str(example_stat))

    def count_woj(self):
        wojewodztwa = {}
        for dep in self.data:
            if dep.get('Województwo'):
                woj = dep['Województwo']
                typ = dep['typ_JST']
                if not wojewodztwa.get(woj):
                    wojewodztwa[woj] = {}

                if not wojewodztwa[woj].get(typ):
                    wojewodztwa[woj][typ] = 1
                else:
                    wojewodztwa[woj][typ] += 1
        print(wojewodztwa)
