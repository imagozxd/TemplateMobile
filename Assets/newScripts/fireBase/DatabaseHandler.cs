using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
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
        string uniqueID = GenerateUniqueID();

        UserPlayer newUserPlayer = new UserPlayer(PlayerName, HighScore);
        string json = JsonUtility.ToJson(newUserPlayer);

        reference.Child("Scores").Child(uniqueID).SetRawJsonValueAsync(json);//aqui es como se guarda en la bd
        Debug.Log("nombre: " + PlayerName + " y el score: " + HighScore + "// ID: "+ uniqueID);
    }

    private string GenerateUniqueID()//para usarlo como ID 
    {
        return userID + "_" + DateTime.UtcNow.Ticks;
    }

    public IEnumerator GetUserPlayer(string uniqueID, Action<UserPlayer> onCallBack)
    {
        var userDataTask = reference.Child("Scores").Child(uniqueID).GetValueAsync();

        yield return new WaitUntil(predicate: () => userDataTask.IsCompleted);

        if (userDataTask.Result.Value != null)
        {
            string json = userDataTask.Result.GetRawJsonValue();
            UserPlayer userPlayer = JsonUtility.FromJson<UserPlayer>(json);
            onCallBack?.Invoke(userPlayer);
        }
        else
        {
            onCallBack?.Invoke(null); // O puedes devolver un UserPlayer vacío o con valores predeterminados
        }
    }
    public IEnumerator GetTopScores(Action<List<UserPlayer>> onCallBack)
    {
        var scoresDataTask = reference.Child("Scores").GetValueAsync();

        yield return new WaitUntil(predicate: () => scoresDataTask.IsCompleted);

        if (scoresDataTask.Result.Value != null)
        {
            List<UserPlayer> userPlayers = new List<UserPlayer>();

            foreach (var child in scoresDataTask.Result.Children)
            {
                string json = child.GetRawJsonValue();
                UserPlayer userPlayer = JsonUtility.FromJson<UserPlayer>(json);
                userPlayers.Add(userPlayer);
            }

            userPlayers.Sort((x, y) => y.scorePlayer.CompareTo(x.scorePlayer));

            // Devuelve los 5 más altos
            onCallBack?.Invoke(userPlayers.GetRange(0, Mathf.Min(5, userPlayers.Count)));
        }
        else
        {
            onCallBack?.Invoke(new List<UserPlayer>()); // Devuelve una lista vacía si no hay datos
        }
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