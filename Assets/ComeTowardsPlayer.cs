using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class ComeTowardsPlayer : MonoBehaviour
{
    [SerializeField] private int LerpSpeed;
    [SerializeField] private FirstPersonController firstPersonController;

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position,firstPersonController.transform.position)<=3)
        {
            transform.position = Vector3.Lerp(transform.position,firstPersonController.transform.position,LerpSpeed*Time.deltaTime);
        }
        
    }
}
