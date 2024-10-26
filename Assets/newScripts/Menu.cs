using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //private GlobalSceneManager globalSceneManager;
    [SerializeField] private TMP_InputField fieldAttribute;
    //[SerializeField] private DatabaseHandler databaseHandler;

    public void JugarBtn()
    {
        GetAttributeInformation();
        GlobalSceneManager globalSceneManager = FindObjectOfType<GlobalSceneManager>();
        if (globalSceneManager != null)
        {
            //globalSceneManager.LoadGameScene();
            globalSceneManager.UnloadScene("Menu");
            globalSceneManager.LoadSceneAdditive("GameScene");

        }
    }

    public void GetAttributeInformation()
    {
        string playerName = fieldAttribute.text;
        //playerName = playerName.Remove(playerName.Length - 1);
        Debug.Log("nombre ingresado:"+playerName);
        //StartCoroutine(databaseHandler.GetCustomAttribute(playerName, UpdateCustomText));
        DatabaseHandler databaseHandler = FindObjectOfType<DatabaseHandler>();
        if (databaseHandler != null)
        {
            databaseHandler.SetPlayerName(playerName);

        }
    }
    
}
