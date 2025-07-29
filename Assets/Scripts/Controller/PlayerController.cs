using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public float smoothedSpeed = 0.01f;
    Vector3 offset = new Vector3(0, 0, 1);

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 desiredPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothedSpeed);
        transform.position = smoothedPosition;
    }
}
