using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GemPopup : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject prompt;
    private bool inHitbox;
    void Start()
    {
        playerTransform = GameObject.Find("FirstPersonController").transform;
    }

    // Update is called once per frame
    void Update()
    {
        FacePromptToPlayer();
    }
    void OnTriggerEnter(Collider hit){
        if (hit.gameObject.CompareTag("Player"))
        {
            inHitbox = true;
            prompt.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inHitbox = false;
            prompt.SetActive(false);
        }
    }
     void FacePromptToPlayer()
    {
        Vector3 directionToPlayer = playerTransform.position - prompt.transform.position;
        directionToPlayer.y = 0;

        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-directionToPlayer);
            prompt.transform.rotation = Quaternion.Slerp(
                prompt.transform.rotation,
                Quaternion.Euler(0, targetRotation.eulerAngles.y, 0),
                Time.deltaTime * 5f
            );
        }
    }
}
