using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 12f;
    private float moveSpeed;

    public Camera playerCamera; 
    public float normalFOV = 60f;
    public float sprintFOV = 70f;
    public float fovSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, sprintFOV, Time.deltaTime * fovSpeed);
        }
        else
        {
            moveSpeed = walkSpeed;
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, normalFOV, Time.deltaTime * fovSpeed);
        }

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        if (move.magnitude > 0.1f)
        {
            float wave = Mathf.Sin(Time.time * (moveSpeed == sprintSpeed ? 14f : 10f));
            playerCamera.transform.localPosition = new Vector3(0, 0.6f + (wave * 0.05f), 0);
        }
    }
}
