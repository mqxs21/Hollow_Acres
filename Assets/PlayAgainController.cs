using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainController : MonoBehaviour
{
    void Start(){
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayAgain(){
        SceneManager.LoadScene(0);
    }
}
