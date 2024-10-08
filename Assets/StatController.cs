using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public TextMeshProUGUI EnemyKilledText;
    public TextMeshProUGUI SeedsPlantedText;
    public TextMeshProUGUI DayNumberTexted;
    
    public class GameManager : MonoBehaviour
{
    public static int DayNumber { get; private set; }
    public static int PlantedSeeds { get; private set; }
    public static int KilledEnemies { get; private set; }

    // Call this function to reset or initialize the game
    public static void StartNewGame()
    {
        DayNumber = 1;
        PlantedSeeds = 0;
        KilledEnemies = 0;
    }

    // Function to increase the day count
    public static void IncrementDay(int dayNum)
    {
        DayNumber = dayNum;
    }

    // Function to update planted seeds
    public static void AddPlantedSeed(int amount)
    {
        PlantedSeeds += amount;
    }

    // Function to update killed enemies
    public static void AddKilledEnemy(int amount)
    {
        KilledEnemies += amount;
    }

    // Call this at the end of the game
    public static void GameOver()
    {
        // Display the stats on Game Over
        Debug.Log("Game Over! Stats:");
        Debug.Log("Day Number: " + DayNumber);
        Debug.Log("Planted Seeds: " + PlantedSeeds);
        Debug.Log("Killed Enemies: " + KilledEnemies);
    }
}
void Start(){
        EnemyKilledText.text = "Enemies Killed: " + StatController.GameManager.KilledEnemies.ToString();
        SeedsPlantedText.text = "Seeds Planted: " + StatController.GameManager.PlantedSeeds.ToString();
        DayNumberTexted.text = "Days Survived: " + StatController.GameManager.DayNumber.ToString();
    }

}
