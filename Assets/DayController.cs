using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    public int nightNumber = 1;
    public bool isNight = false;
    private float seconds = 0;
    public float secondsPerCycle = 5;

    public Camera mainCamera; 
    public Color dayColor;
    public Color nightColor = Color.black;
    public GrowthController growthController;

    void Start()
    {
        
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        dayColor = mainCamera.backgroundColor;
        UpdateCameraBackground();
    }

    void Update()
    {
       
        seconds += Time.deltaTime;
        if (seconds >= secondsPerCycle)
        {
            
            seconds = 0;
            isNight = !isNight; 
            UpdateCameraBackground(); 
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
