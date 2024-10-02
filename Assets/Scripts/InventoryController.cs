using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Use Character as the type instead of dynamic
    public Dictionary<string, Character> newInventoryDict = new Dictionary<string, Character>();

    public class Character
    {
        public string name;
        public int num;
        public string ID;

        public Character(string i, string n, int nu)
        {
            name = n;
            num = nu;
            ID = i;
        }
    }

    public void CreateNewCharacter(string ID, string n, int nu)
    {
        Character newCharacter = new Character(ID, n, nu);
        newInventoryDict.Add(ID, newCharacter);
    }

    void Start()
    {
        CreateNewCharacter("IDPEPPER", "PEPPER", 4);
        CreateNewCharacter("IDTOMATO", "TOMATO", 3);

        foreach (Character newChar in newInventoryDict.Values)
        {
            Debug.Log("Character: " + newChar.name + ", ID: " + newChar.ID + ", Num: " + newChar.num);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
