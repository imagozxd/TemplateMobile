using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //private GlobalSceneManager globalSceneManager;
    public void JugarBtn()
    {
        GlobalSceneManager globalSceneManager = FindObjectOfType<GlobalSceneManager>();
        if (globalSceneManager != null)
        {
            globalSceneManager.LoadGameScene();
        }
    }
}
