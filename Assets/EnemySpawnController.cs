using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public DayController dayController;
    private bool lastNight;
    public GameObject enemy;
        void Start()
    {
        
        dayController = GameObject.Find("DayNightManager").GetComponent<DayController>();
        lastNight = dayController.isNight;
    }

    void Update()
    {
        if (dayController.isNight != lastNight)
        {
            if (dayController.isNight)
            {
                int times = 5+(dayController.dayNumber-1);
                for (int i = 0; i < times; i++)
                {
                    int spawnNum = UnityEngine.Random.Range(1,16);
                    Instantiate(enemy,GameObject.Find("Spawn ("+spawnNum+")").transform.position,Quaternion.identity);
                }
            }
            lastNight = dayController.isNight;
        }
    }
}
