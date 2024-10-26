using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public event Action OnGameOver;
    public event Action OnRestart;

    [SerializeField] private Hud hud; //raro, si no lo serializo no funca ..es porque no inicia._,
    private InputController inputController;
    private Rigidbody rb;

    [SerializeField] private float yForce = 10f;//7-8 funca mejor
    [SerializeField] private float xForceMultiplier = 1f;

    private int jumpCount = 2;
    private const int maxJumpCount = 2;

    void Start()
    {
        inputController = FindObjectOfType<InputController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (inputController.IsTapDetected() && jumpCount > 0)
        {
            Vector3 tapPosition = inputController.GetTapWorldPosition();
            ApplyForce(tapPosition);
            jumpCount--;
            Debug.Log("tienes "+jumpCount+ "saltos restantes");
        }
    }

    private void ApplyForce(Vector3 tapPosition)
    {
        Vector3 force = Vector3.up * yForce;
        float xDifference = tapPosition.x - transform.position.x;
        force.x = xDifference * xForceMultiplier;

        rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            jumpCount = maxJumpCount;
            
            if (hud != null)
            {
                hud.StartContainerMovement();
            }
        }

        if (collision.gameObject.CompareTag("floor") && jumpCount == 0)
        {
            //OnGameOver?.Invoke();
            OnRestart?.Invoke();
            DatabaseHandler.Instance.CreateUserPlayer();
        }
    }

    //public int GetJumpCount() 
    //{
    //    return jumpCount;
    //}

}
