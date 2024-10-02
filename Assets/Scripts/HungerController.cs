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
    public RawImage healthBarFill;
    [SerializeField]private PlayerDamageController playerDamageController;
    public float seconds;
    public float hungerDecrement = 5f;
    public float timeInterval = 5f;

    private float originalWidth;
    private float originalWidthHealth;

    void Start()
    {
        hungerPercentage = maxHunger;
        originalWidth = hungerBarFill.rectTransform.sizeDelta.x;
        originalWidthHealth = healthBarFill.rectTransform.sizeDelta.x;
        hungerBarFill.rectTransform.pivot = new Vector2(0f, 0.5f);
        healthBarFill.rectTransform.pivot = new Vector2(0,0.5f);
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

    // Ensure health percentage is calculated properly
    float healthPercentage = (float)playerDamageController.curPlayerHealth / playerDamageController.maxPlayerHealth;
    healthPercentage = Mathf.Clamp(healthPercentage, 0f, 1f);  // Clamp to prevent negative values

    // Update health bar size based on percentage
    healthBarFill.rectTransform.sizeDelta = new Vector2(healthPercentage * originalWidthHealth, healthBarFill.rectTransform.sizeDelta.y);
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
