using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformSpawner spawner;
    private GameManager gameManager;
    private bool uniqueTouch = false;

    public void SetSpawner(PlatformSpawner spawner) //asignar al spawner.. 
    {
        this.spawner = spawner;
    }
    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !uniqueTouch)
        {
            uniqueTouch = true;
            gameManager.AddScore(10); //cantidad score
            spawner.SpawnPlatforms(); 
        }
    }
}
