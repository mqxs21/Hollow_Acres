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
        if (Input.GetKey(KeyCode.F)) // USED FOR TEESTING PERPOSES ONLY TAKE OUT LATOR
        {
            isNight = !isNight;
        }
        seconds += Time.deltaTime;
        if (seconds >= secondsPerCycle)
        {
            
            seconds = 0;
            isNight = !isNight; 
            UpdateCameraBackground(); 
        }

        if (isNight)
        {
            Debug.Log("It is night time.");
        }
        else
        {
            Debug.Log("It is daytime.");
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
