using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public string currentStage = "Stage0";
    public GameObject stageOne;
    public GameObject stageTwo;
    public GameObject foodToSpawn;
    public DayController dayController;
    public GameObject storeLoc;
    public bool isPlanted;

    private GameObject cur;
    private bool lastNight;

    void Start()
    {
        isPlanted = false;
        dayController = GameObject.Find("DayNightManager").GetComponent<DayController>();
        lastNight = dayController.isNight;
    }

    void Update()
    {
        if (isPlanted)
        {
            if (currentStage == "Stage0")
            {
                NextStage();
            }
            if (dayController.isNight != lastNight)
        {
            NextStage();
            lastNight = dayController.isNight;
        }
    }
        }
        
    public void PlantSeed(){
        isPlanted = true;
    }
    public void NextStage()
    {
        int random = UnityEngine.Random.Range(1, 3);
        if (random == 1)
        {
            if (currentStage == "Stage0" && cur == null)
            {
                cur = Instantiate(stageOne, storeLoc.transform.position, Quaternion.identity);
                cur.transform.parent = storeLoc.transform;
                currentStage = "Stage1";
            }
            else if (currentStage == "Stage1")
            {
                Destroy(cur);
                cur = Instantiate(stageTwo, storeLoc.transform.position, Quaternion.identity);
                cur.transform.parent = storeLoc.transform;
                currentStage = "Stage2";
            }
            else if (currentStage == "Stage2")
            {
                Destroy(cur);
                Vector3 spawnFoodLoc = storeLoc.transform.position;
                spawnFoodLoc.y += 1;

                cur = Instantiate(foodToSpawn,spawnFoodLoc, Quaternion.identity);
                cur.transform.parent = storeLoc.transform;
                currentStage = "Stage0";
            }
        }
    }
}
