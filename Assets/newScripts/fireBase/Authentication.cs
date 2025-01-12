using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using System.Threading.Tasks;
using UnityEngine.Events;
using TMPro;

public class Authentication : MonoBehaviour
{
    //[SerializeField] private string email;
    //[SerializeField] private string password;
    [SerializeField] private TMP_InputField inputId;
    [SerializeField] private TMP_InputField inputPass;
    [SerializeField] private AuthMenu authMenu;

    //[Header("Bool Actions")]
    //[SerializeField] private bool signUp = false;
    //[SerializeField] private bool signIn = false;

    private FirebaseAuth _authReference;
    public UnityEvent OnSignInSuccesful = new UnityEvent();
    public UnityEvent OnLogInSuccesful = new UnityEvent();

    private void Awake()
    {
        _authReference = FirebaseAuth.GetAuth(FirebaseApp.DefaultInstance);
    }

    private void Start()
    {
        //if (signUp)
        //{
        //    Debug.Log("Start Register");
        //    StartCoroutine(RegisterUser(email, password));
        //}

        //if (signIn)
        //{
        //    Debug.Log("Start Login");
        //    StartCoroutine(SignInWithEmail(email, password));
        //}
    }

    private void Update()
    {
        
    }
    public void RegisterUserFromInput()
    {
        string email = inputId.text;
        string password = inputPass.text;
        StartCoroutine(RegisterUser(email, password));
    }
    public void SignInUserFromInput()
    {
        string email = inputId.text;
        string password = inputPass.text;
        StartCoroutine(SignInWithEmail(email, password));
    }

    private IEnumerator RegisterUser(string email, string password)
    {
        Debug.Log("Registering");
        var registerTask = _authReference.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        if (registerTask.Exception != null)
        {
            Debug.LogWarning($"Failed to register task with {registerTask.Exception}");
        }
        else
        {
            Debug.Log($"Succesfully registered user {registerTask.Result.User.Email}");
            authMenu.EnterOnGameBtn();
        }
    }

    private IEnumerator SignInWithEmail(string email, string password)
    {
        Debug.Log("Loggin In");

        var loginTask = _authReference.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            Debug.LogWarning($"Login failed with {loginTask.Exception}");
        }
        else
        {
            Debug.Log($"Login succeeded with {loginTask.Result.User.Email}");
            //OnLogInSuccesful?.Invoke();
            authMenu.EnterOnGameBtn();
        }
    }

    public void LogOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
