using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public Animator tutAnim;
    public void LoadGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void OpenTutPanel(){
        tutAnim.SetBool("Up",true);
    }
    public void CloseTutPanel(){
        tutAnim.SetBool("Up",false);
    }
}
