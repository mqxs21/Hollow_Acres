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
    public float dayNightTransitionSmoothness = 2;

    public Camera mainCamera; 
    public Color dayColor;
    public Color nightColor = Color.black;
    public GrowthController growthController;
    public bool dayNightCycleWork;

    private float transitionProgress = 0;

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
                isNight = !isNight;
                if (!isNight)
                {
                    dayNumber++;
                }
                transitionProgress = 0; // resets transition progress
            }
        }

        UpdateCameraBackground();
    }

    void UpdateCameraBackground()
    {
        if (mainCamera != null)
        {
            Color targetColor = isNight ? nightColor : dayColor;

            if (transitionProgress < 1)
            {
                mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, targetColor, Time.deltaTime * dayNightTransitionSmoothness);
                transitionProgress += Time.deltaTime * dayNightTransitionSmoothness;
            }
            else
            {
                mainCamera.backgroundColor = targetColor;
            }
        }
    }
}
