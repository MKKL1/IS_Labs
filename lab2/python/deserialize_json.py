# -*- coding: utf-8 -*-
"""
deserialize json
"""
import json


class DeserializeJson:
    def __init__(self, filename):
        print("let's deserialize something")
        tempdata = open(filename, encoding="utf-8-sig")
        self.data = json.load(tempdata)

    def somestats(self):
        example_stat = 0
        for dep in self.data:
            if (dep.get('typ_JST') and dep.get('Województwo') and dep['typ_JST'] == 'GM' and dep['Województwo'] == 'dolnośląskie'):
                example_stat += 1
        print('liczba urzędów miejskich w województwie dolnośląskim: ' + ' ' + str(example_stat))

    def countWoj(self):
        wojewodztwa = {}
        for dep in self.data:
            if dep.get('Województwo'):
                woj = dep['Województwo']
                if not wojewodztwa.get(woj):
                    wojewodztwa[woj] = 1
                else:
                    wojewodztwa[woj] += 1
        print(wojewodztwa)
