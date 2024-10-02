using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerController : MonoBehaviour
{
    public float hungerPercentage = 100f;
    public float maxHunger = 100f;
    public GameObject hungerBarUI;
    public RawImage hungerBarFill;

    public float seconds;
    public float hungerDecrement = 5f;
    public float timeInterval = 5f;

    private float originalWidth;

    void Start()
    {
        hungerPercentage = maxHunger;
        originalWidth = hungerBarFill.rectTransform.sizeDelta.x;
        hungerBarFill.rectTransform.pivot = new Vector2(0f, 0.5f);
    }

    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= timeInterval)
        {
            seconds = 0;
            DecreaseHunger();
        }

        UpdateHungerUI();
    }



    void DecreaseHunger()
    {
        hungerPercentage -= hungerDecrement;
        hungerPercentage = Mathf.Clamp(hungerPercentage, 0, maxHunger);
    }

    void UpdateHungerUI()
    {
        hungerBarFill.rectTransform.sizeDelta = new Vector2((hungerPercentage / maxHunger) * originalWidth, hungerBarFill.rectTransform.sizeDelta.y);
    }
}
