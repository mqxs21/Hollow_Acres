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
    public AudioSource dayMusic;
    public AudioSource nightMusic;
    public bool dayNightCycleWork;
    public float musicTransitionSmoothness = 1; // Speed for music transitions

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
        
       
        if (isNight)
        {
            nightMusic.volume = 0.5f;
            dayMusic.volume = 0;
        }
        else
        {
            dayMusic.volume = 0.5f;
            nightMusic.volume = 0;
        }

       
        dayMusic.Play();
        nightMusic.Play();
    }

    void Update()
    {
        StatController.GameManager.IncrementDay(dayNumber);
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
                transitionProgress = 0; 
            }
        }

        UpdateCameraBackground();
        UpdateMusicVolume();
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

    void UpdateMusicVolume()
    {
        if (isNight)
        {

            if (nightMusic.volume < 0.5)
            {
                nightMusic.volume = Mathf.Lerp(nightMusic.volume, 0.5f, Time.deltaTime * musicTransitionSmoothness);
            }
            if (dayMusic.volume > 0)
            {
                dayMusic.volume = Mathf.Lerp(dayMusic.volume, 0, Time.deltaTime * musicTransitionSmoothness);
            }
        }
        else
        {
            if (dayMusic.volume < 0.5)
            {
                dayMusic.volume = Mathf.Lerp(dayMusic.volume, 0.5f, Time.deltaTime * musicTransitionSmoothness);
            }
            if (nightMusic.volume > 0)
            {
                nightMusic.volume = Mathf.Lerp(nightMusic.volume, 0, Time.deltaTime * musicTransitionSmoothness);
            }
        }
    }
}
