using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayController : MonoBehaviour
{
    public int dayNumber = 1;
    public TextMeshProUGUI dayText;
    public bool isNight = false;
    private float seconds = 0;
    public float secondsPerCycle = 5;

    public Camera mainCamera; 
    public Color dayColor;
    public Color nightColor = Color.black;
    public GrowthController growthController;
    public bool dayNightCycleWork;

    void Start()
    {
        dayNightCycleWork = true;
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        dayColor = mainCamera.backgroundColor;
        UpdateCameraBackground();
    }

    void Update()
    {
        dayText.text = dayNumber.ToString();
        if (dayNightCycleWork)
        {
             seconds += Time.deltaTime;
        if (seconds >= secondsPerCycle)
        {
            
            seconds = 0;
            if (isNight)
            {
                dayNumber++;
            }
            isNight = !isNight; 
            UpdateCameraBackground(); 
        }
        }
       
       

        
    }
    void UpdateCameraBackground()
    {
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = isNight ? nightColor : dayColor;
        }
    }
}
