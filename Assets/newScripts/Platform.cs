using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformSpawner spawner;
    private GameController gameController;
    private bool uniqueTouch = false;

    public void SetSpawner(PlatformSpawner spawner) //asignar al spawner.. 
    {
        this.spawner = spawner;
    }
    public void SetGameManager(GameController gameController)
    {
        this.gameController = gameController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !uniqueTouch)
        {
            uniqueTouch = true;
            gameController.AddScore(10); //cantidad score
            spawner.SpawnPlatforms(); 
        }
    }
}
