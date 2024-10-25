using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private bool canMove = false;

    void Update()
    {
        if (canMove)
        {
            Vector3 newPosition = transform.position + Vector3.up * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }

    public void StartContainerMovement()
    {
        canMove = true;
    }
}
