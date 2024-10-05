using System.Collections;
using TMPro;
using UnityEngine;

public class TriggerPrompt : MonoBehaviour
{
    public GameObject prompt;
    public InventoryController inventoryController;
    public bool inHitbox;
    public Transform playerTransform;
    public GameObject panel1HaveSeed;
    public GameObject panel2NoSeed;

    void Start()
    {
        playerTransform = GameObject.Find("FirstPersonController").transform;
        inventoryController = FindFirstObjectByType<InventoryController>();
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            inHitbox = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inHitbox = false;
            prompt.SetActive(false);
            panel1HaveSeed.SetActive(false);
            panel2NoSeed.SetActive(false);
        }
    }

    void Update()
    {
        if (inHitbox && !GetComponentInParent<GrowthController>().isPlanted)
        {

            string currentSelectedID = "ID" + inventoryController.selectedIndex;
            InventoryController.Character selectedCharacter = null;

            foreach (var character in inventoryController.newInventoryDict.Values)
            {
                if (character.ID == currentSelectedID)
                {
                    selectedCharacter = character;
                    break;
                }
            }

         
            if (selectedCharacter != null && selectedCharacter.num > 0)
            {
                panel1HaveSeed.SetActive(true);
                panel2NoSeed.SetActive(false);
            }
            else
            {
                panel1HaveSeed.SetActive(false);
                panel2NoSeed.SetActive(true);
            }

            prompt.SetActive(true);
            FacePromptToPlayer();
        }
        else
        {
            prompt.SetActive(false);
            panel1HaveSeed.SetActive(false);
            panel2NoSeed.SetActive(false);
        }
    }

    void FacePromptToPlayer()
    {
        Vector3 directionToPlayer = playerTransform.position - prompt.transform.position;
        directionToPlayer.y = 0;

        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            prompt.transform.rotation = Quaternion.Slerp(
                prompt.transform.rotation,
                Quaternion.Euler(0, targetRotation.eulerAngles.y, 0),
                Time.deltaTime * 5f
            );
        }
    }
}
