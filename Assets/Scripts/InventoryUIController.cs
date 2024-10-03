using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    public InventoryController inventoryController; // Reference to the InventoryController script
    public GameObject inventoryPanel; // Panel that will display the inventory
    public GameObject itemPrefab; // Prefab for individual inventory items (Text + Button)

    
    void Start()
{
    // Automatically find the InventoryController in the scene
    inventoryController = FindObjectOfType<InventoryController>();

    if (inventoryController == null)
    {
        Debug.LogError("No InventoryController found in the scene!");
    }

    // Ensure the inventory panel is initially hidden
    inventoryPanel.SetActive(false);
}


    void Update()
    {
        // Toggle the inventory panel visibility when pressing the 'I' key
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(false);
            }
            else
            {
                inventoryPanel.SetActive(true);
                UpdateInventoryUI();
            }
        }
    }

    // Update the inventory display in the UI
    public void UpdateInventoryUI()
    {
        // Debugging: Log the number of items in the inventory
        Debug.Log("Inventory contains " + inventoryController.newInventoryDict.Count + " items.");

        // Clear any existing items in the panel
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Populate the UI with items from the inventory dictionary
        foreach (KeyValuePair<string, InventoryController.Character> entry in inventoryController.newInventoryDict)
        {
            InventoryController.Character character = entry.Value;

            // Debugging: Log each character as we iterate over them
            Debug.Log("Creating UI for item: " + character.name);

            // Instantiate a new UI element for each inventory item
            GameObject item = Instantiate(itemPrefab, inventoryPanel.transform);

            // Verify that the prefab has Text and Button components
            Text itemText = item.GetComponentInChildren<Text>();
            Button itemButton = item.GetComponentInChildren<Button>();

            if (itemText == null || itemButton == null)
            {
                Debug.LogError("Item prefab is missing Text or Button component.");
                continue; // Skip this item if something is wrong
            }

            // Set the text to display the character's name and number of items
            itemText.text = character.name + " (x" + character.num + ")";

            // Create a local copy of the character variable for the button listener
            InventoryController.Character localCharacter = character;

            // Optionally, add a button click event (e.g., to select the item)
            itemButton.onClick.RemoveAllListeners(); // Clear previous listeners
            itemButton.onClick.AddListener(() => SelectItem(localCharacter));
        }
    }



    // Method to handle when an item is selected
    public void SelectItem(InventoryController.Character character)
    {
        Debug.Log("Selected " + character.name);
        // Implement further actions here (e.g., equip item, use item, etc.)
    }
}
