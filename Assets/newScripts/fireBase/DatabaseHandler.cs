using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;


public class DatabaseHandler : MonoBehaviour
{
    public static DatabaseHandler Instance { get; private set; }

    public string PlayerName { get; private set; }
    public int HighScore { get; private set; }
    [SerializeField] private string userID;
    private DatabaseReference reference;

    private void Awake()
    {
        userID = SystemInfo.deviceUniqueIdentifier;

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public void SetHighScore(int score)
    {
        HighScore = score;
    }
    public void CreateUserPlayer()
    {
        UserPlayer newUserPlayer = new UserPlayer(PlayerName, HighScore);
        string json = JsonUtility.ToJson(newUserPlayer);

        reference.Child("Scores").Child(userID).SetRawJsonValueAsync(json);
        Debug.Log("nombre: " + PlayerName + " y el score: " + HighScore);
    }

    public void GetUserCount(Action<int> onCallback) //para usarlo como ID 
    {
        reference.Child("Scores").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                int userCount = (int)snapshot.ChildrenCount;
                onCallback(userCount);
            }
            else
            {
                Debug.LogError("Error al obtener el número de usuarios: " + task.Exception);
                onCallback(0);
            }

        });    
    }



}

[System.Serializable]
public class UserPlayer
{
    public string namePlayer;    
    public int scorePlayer;

    public UserPlayer(string namePlayer, int scorePlayer)
    {
        this.namePlayer = namePlayer;        
        this.scorePlayer = scorePlayer;
    }
}