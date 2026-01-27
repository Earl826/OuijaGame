using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float walkSpeed = 5f;
    [SerializeField] public float sprintSpeed = 12f;
    private float moveSpeed;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
            Debug.Log("Sprinting");
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}
