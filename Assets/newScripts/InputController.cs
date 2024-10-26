using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private bool tapDetected = false;
    [SerializeField] private Vector3 tapWorldPosition;

    public bool IsTapDetected()
    {
        DetectTap();
        return tapDetected;
    }

    public Vector3 GetTapWorldPosition()
    {
        return tapWorldPosition;
    }

    private void DetectTap()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            tapWorldPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            tapWorldPosition.z = 0;
            tapDetected = true;
            //Debug.Log("Tap en: " + tapWorldPosition);
        }
        else
        {
            tapDetected = false;
        }
    }
}
