using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement Settings")]
    public float moveSpeed = 5f;

    [Header ("Camera Settings")]
    public float mouseSensv = 100f;
    public Transform playerCamera;

    private Rigidbody rb;
    private Vector3 movement;
    private float xRotation = 0f;

    void Start() {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        movement = (transform.right * moveX + transform.forward * moveZ).normalized;
        //
        //Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensv * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensv * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    void FixedUpdate(){
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);
    }
}
