using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    [SerializeField] private int score = 0;
    private bool gameOver = false;
    [SerializeField] private PlayerController playerController;
    //[SerializeField] private DatabaseHandler databaseHandler;

    private int highScore;

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
    private void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            Debug.Log("Nuevo puntaje más alto: " + highScore);
            if (DatabaseHandler.Instance != null)
            {
                DatabaseHandler.Instance.SetHighScore(highScore);
            }
        }
    }

    public void RestartGame()
    {
        UpdateHighScore();

        Debug.Log("Reiniciando el juego");
        gameOver = false;
        score = 0;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetHighScore()
    {
        return highScore;
    }


    private void GameOver()
    {
        Debug.Log("Game Over");
        gameOver = true;

        Time.timeScale = 0f;
    }

    
}
