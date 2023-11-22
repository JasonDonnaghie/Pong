using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Pressed : MonoBehaviour
{
    
    // public function to be called on button press
    public void play_pressed()
    {   
        Debug.Log("Playing");
        SceneManager.LoadSceneAsync("Game");
    }

    public void quit_pressed(){
        Debug.Log("Quitting");
        Application.Quit();
    }

    
}
