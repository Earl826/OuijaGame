using UnityEngine;

public class Look : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody; 

    private float xRotation = 0f;
    private bool isLocked = true;

    void Start()
    {
        SetCursorState(true);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isLocked = !isLocked;
            SetCursorState(isLocked);
        }
    }

    void SetCursorState(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}