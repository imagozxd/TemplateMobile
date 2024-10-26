using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //private GlobalSceneManager globalSceneManager;
    [SerializeField] private TMP_InputField fieldAttribute;
    //[SerializeField] private DatabaseHandler databaseHandler;

    public void JugarBtn()
    {
        GetAttributeInformation();
        
        if (GlobalSceneManager.Instance != null)
        {
            //globalSceneManager.LoadGameScene();
            GlobalSceneManager.Instance.LoadGameScene();
            //globalSceneManager.LoadGameScene();
        }
    }

    public void GetAttributeInformation()
    {
        string playerName = fieldAttribute.text;
        //playerName = playerName.Remove(playerName.Length - 1);
        Debug.Log("nombre ingresado:"+playerName);
        //StartCoroutine(databaseHandler.GetCustomAttribute(playerName, UpdateCustomText));
        if (DatabaseHandler.Instance != null)
        {
            DatabaseHandler.Instance.SetPlayerName(playerName);
            Debug.Log("ENTRO AQUI 1");
        }
    }
    public void PuntajesBtn()
{
    if (GlobalSceneManager.Instance != null)
    {
        GlobalSceneManager.Instance.LoadPuntajes();
    }
}

    public void SalirBtn()
    {
        Debug.Log("deberia cerrar");
        Application.Quit();
    }


}
