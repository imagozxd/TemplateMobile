using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    private GameObject platformPrefab;

    private static GameObject[] pool;
    private static int poolSize = 20;

    void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(platformPrefab, transform); //sobrecarga para hacer padre
            pool[i].SetActive(false); 
        }
    }

    public static GameObject GetPlatform()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        return null; // Si todas las plataformas están activas, no devuelve ninguna sugerenciagpt
    }

    public static void ReturnPlatform(GameObject platform)
    {
        platform.SetActive(false); //retornar el gameobject, desactivandolo
    }
}
