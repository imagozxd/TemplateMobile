using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSceneManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadSceneAdditive("Menu"));
    }

    public void LoadGameScene()
    {
        UnloadScene("Menu");

        SceneManager.LoadScene("GameScene");
    }
    public void LoadPuntajes()
    {

        StartCoroutine(LoadSceneAdditive("Puntajes"));
    }
    public void UnloadPuntajes()
    {

        UnloadScene("Puntajes");
    }

    public IEnumerator LoadSceneAdditive(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return new WaitUntil(() => asyncLoad.isDone);
            Debug.Log("carga escena aditiva: " + sceneName);
        }        
    }
    public void UnloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
            Debug.Log("se descarga: " + sceneName);
        }        
    }
}
