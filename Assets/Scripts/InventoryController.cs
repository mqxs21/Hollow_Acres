using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Dictionary<string, Character> newInventoryDict = new Dictionary<string, Character>();
    public int selectedIndex = 1;
    public bool inHitbox = false;
    public float searchRadius = 10f; // Radius within which to search for GrowthController

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

    // Create properties for Tomato and Pepper amounts to be accessed publicly
    public int PepperAmount
    {
        get { return GetCharacterAmount("PEPPER"); }
        set { UpdateCharacterAmount("PEPPER", value); }
    }

    public int TomatoAmount
    {
        get { return GetCharacterAmount("TOMATO"); }
        set { UpdateCharacterAmount("TOMATO", value); }
    }

    // Method to create a new character and add to dictionary
    public void CreateNewCharacter(string ID, string n, int nu)
    {
        Character newCharacter = new Character(ID, n, nu);
        newInventoryDict.Add(ID, newCharacter);
    }

    // Method to get the amount of a character by name
    private int GetCharacterAmount(string characterName)
    {
        foreach (Character character in newInventoryDict.Values)
        {
            if (character.name == characterName)
            {
                return character.num;
            }
        }
        return 0;
    }

    // mathod to update the amount of a character by name
    private void UpdateCharacterAmount(string characterName, int newAmount)
    {
        foreach (Character character in newInventoryDict.Values)
        {
            if (character.name == characterName)
            {
                character.num = newAmount;
                Debug.Log($"{characterName} amount updated to {newAmount}");
                return;
            }
        }
    }

    void Start()
    {
        CreateNewCharacter("ID1", "PEPPER", 4);
        CreateNewCharacter("ID2", "TOMATO", 3);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hitbox")
        {
            inHitbox = true;
            Debug.Log("Collision with Hitbox!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            inHitbox = false;
            Debug.Log("Left Hitbox!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && inHitbox)
        {
            string currentClick = "ID" + selectedIndex;

            foreach (Character newChar in newInventoryDict.Values)
            {
                if (newChar.ID == currentClick)
                {
                    if (newChar.num >= 1)
                    {
                        Debug.Log("Planting");

                        newChar.num -= 1;

                        // Find the closest GrowthController
                        GrowthController closestGrowthController = FindClosestGrowthController();
                        if (closestGrowthController != null)
                        {
                            closestGrowthController.PlantSeed(newChar.name);
                            Debug.Log("planting " + newChar.name);
                        }
                        else
                        {
                            Debug.LogWarning("No GrowthController found nearby.");
                        }
                    }
                    else
                    {
                        Debug.Log("Not Enough");
                    }
                }
            }
        }
    }

    // Find the closest GrowthController within a certain radius
    GrowthController FindClosestGrowthController()
    {
        GrowthController[] allGrowthControllers = FindObjectsByType<GrowthController>(FindObjectsSortMode.None);
        GrowthController closestController = null;
        float closestDistance = Mathf.Infinity;

        foreach (GrowthController controller in allGrowthControllers)
        {
            float distanceToController = Vector3.Distance(transform.position, controller.transform.position);
            if (distanceToController < closestDistance)
            {
                closestController = controller;
                closestDistance = distanceToController;
            }
        }

        if (closestController != null)
        {
            // Debug.Log("Found closest GrowthController at distance: " + closestDistance);
        }
        else
        {
            // Debug.LogWarning("No GrowthController found nearby.");
        }

        return closestController;
    }
}
