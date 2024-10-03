using TMPro;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public InventoryController inventoryController;
    public TextMeshProUGUI tomatoText;
    public TextMeshProUGUI pepperText;
    public TextMeshProUGUI selectedItemText;
    public FirstPersonController firstPersonController;

    public int tomatoCount;
    public int pepperCount;

    private string selectedItem;
    public GameObject inventoryPanel;

    void Start()
    {
        SelectPepper();
        inventoryController = FindObjectOfType<InventoryController>();

        if (inventoryController == null)
        {
            Debug.LogError("No InventoryController found in the scene!");
        }

        UpdateItemCounts();
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            if (inventoryPanel.activeSelf)
            {
                firstPersonController.lockCursor = false;
            }else{
                 firstPersonController.lockCursor = true;
            }
        }

        UpdateItemCounts();
        UpdateUI();
    }

    void UpdateItemCounts()
    {
        if (inventoryController.newInventoryDict.ContainsKey("ID1"))
        {
            pepperCount = inventoryController.newInventoryDict["ID1"].num;
        }

        if (inventoryController.newInventoryDict.ContainsKey("ID2"))
        {
            tomatoCount = inventoryController.newInventoryDict["ID2"].num;
        }
    }

    void UpdateUI()
    {
        tomatoText.text = tomatoCount.ToString();
        pepperText.text = pepperCount.ToString();
        selectedItemText.text = "Selected: " + selectedItem;
    }

    public void SelectPepper()
    {
        //succulent pepper
        selectedItem = "PEPPER";
        inventoryController.selectedIndex = 1;  
        Debug.Log("Pepper selected.");
    }

    public void SelectTomato()
    {
        //succulent el tomates
        selectedItem = "TOMATO";
        inventoryController.selectedIndex = 2; 
        Debug.Log("Tomato selected.");
    }
}
