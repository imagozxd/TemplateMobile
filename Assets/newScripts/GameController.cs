using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private int score = 0;
    private bool gameOver = false;
    [SerializeField] private PlayerController playerController;

    void Start()
    {
        //playerController.OnGameOver += GameOver;
        playerController.OnRestart += RestartGame;
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Mostrar score/pisos: " + score);
    }

    public void RestartGame()
    {
        Debug.Log("Reiniciando el juego");
        gameOver = false;
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        gameOver = true;

        Time.timeScale = 0f;
    }
}
