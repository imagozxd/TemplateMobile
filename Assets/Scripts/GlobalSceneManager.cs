using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSceneManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        //aditiva inicial
        LoadSceneAdditive("Menu");
    }

    public void LoadGameScene()
    {
        LoadSceneAdditive("GameScene");
    }

    // Cargar una escena de manera aditiva (manteniendo la actual "Loader Scene")
    public void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        Debug.Log("Se cargó con éxito la escena " + sceneName + " de manera aditiva");
    }

    // Descargar una escena (que haya sido cargada de manera aditiva)
    public void UnloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        else
        {
            Debug.LogWarning("La escena " + sceneName + " no está cargada.");
        }
    }
}
