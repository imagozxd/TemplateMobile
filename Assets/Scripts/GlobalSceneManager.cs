using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSceneManager : MonoBehaviour
{
    public static GlobalSceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {        
        StartCoroutine(LoadSceneAdditive("Menu"));
    }

    public void LoadGameScene()
    {
        StartCoroutine(SwitchToScene("Menu", "GameScene"));
    }
    public void LoadPuntajes()
    {

        StartCoroutine(LoadSceneAdditive("Puntajes"));
    }
    public void UnloadPuntajes()
    {

        StartCoroutine(UnloadScene("Puntajes"));
    }

    private IEnumerator SwitchToScene(string unloadSceneName, string loadSceneName)
    {
        yield return StartCoroutine(UnloadScene(unloadSceneName));//se va
        yield return StartCoroutine(LoadSceneAdditive(loadSceneName));//nueva
    }

    public IEnumerator LoadSceneAdditive(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return new WaitUntil(() => asyncLoad.isDone);
            Debug.Log("escena aditiva: " + sceneName);
        }
    }

    public IEnumerator UnloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
            yield return new WaitUntil(() => asyncUnload.isDone);
            Debug.Log("se descargo: " + sceneName);
        }        
    }
}
