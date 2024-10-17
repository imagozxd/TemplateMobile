using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSceneManager : MonoBehaviour
{
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        //cargar la escena inicial (aditiva)
        LoadSceneAdditive("SceneTest1");
        

    }

    // cargar una escena de manera normal (reemplazando la actual)
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
        

    // cargar una escena de manera aditiva (manteniendo la actual "Loader Scene")
    public void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        Debug.Log("Se cargo con exito la escena " + sceneName+ " de manera aditiva");
    }


    // descargar una escena (que haya sido cargada de manera aditiva)
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

    // Comentario sobre Fade In / Fade Out:
    // Para realizar un fade in/fade out puedes usar un Canvas con una imagen negra que cubra toda la pantalla.
    // Luego puedes hacer que la opacidad de esa imagen se incremente o disminuya usando un Coroutine.
    // Aquí tienes un ejemplo básico de cómo lo podrías implementar:

    //public IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
    //{
    //    float elapsedTime = 0f;
    //    while (elapsedTime < duration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        canvasGroup.alpha = Mathf.Clamp01(elapsedTime / duration); // Incrementa el alfa (Fade In)
    //        yield return null;
    //    }
    //}

    //public IEnumerator FadeOut(CanvasGroup canvasGroup, float duration)
    //{
    //    float elapsedTime = 0f;
    //    while (elapsedTime < duration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        canvasGroup.alpha = 1 - Mathf.Clamp01(elapsedTime / duration); // Decrementa el alfa (Fade Out)
    //        yield return null;
    //    }
    //}

    // Para utilizar el fade in/out:
    // 1. Crea un GameObject con un Canvas y una imagen negra encima que cubra la pantalla.
    // 2. Asigna un CanvasGroup al objeto y referencia el CanvasGroup en este script.
    // 3. Llama a FadeIn/FadeOut antes o después de cargar la escena para hacer transiciones suaves.
}
