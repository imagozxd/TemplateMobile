using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private float spawnY = -2.25f;
    private float yPlatformSpace = 2.25f;

    void Start()
    {
        InstantiatePlatform();
    }

    public void SpawnPlatforms()
    {
        InstantiatePlatform();
        
    }

    private void InstantiatePlatform()
    {
        float randomX = Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        GameObject platform = PlatformPool.GetPlatform();
        if (platform != null)
        {
            platform.transform.position = spawnPosition;
            //platform.GetComponent<Platform>().SetSpawner(this); 

            Platform platformScript = platform.GetComponent<Platform>();
            if (platformScript != null)
            {
                platformScript.SetSpawner(this);
                platformScript.SetGameManager(FindObjectOfType<GameManager>());
            }
        }
        //calcula la siguiete 
        spawnY += yPlatformSpace;
    }


}
