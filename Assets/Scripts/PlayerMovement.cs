using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement Settings")]
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 15f;
    public float sprintSpeed = 10f;
    
    [Header ("Camera Settings")]
    public float mouseSensv = 100f;
    public Transform playerCamera;

    [Header ("Jumping")]
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundDistance= 0.4f;
    public LayerMask groundMask;

    [Header ("FOV")]
    public float normalFOV = 60f;
    public float sprintFOV = 75f;
    public float fovTransform = 5f;
    
    private Rigidbody rb;
    private Vector3 movement; 
    private float xRotation = 0f;
    private bool isSprinting;
    private Camera cam;
    private bool onGround;


    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        rb.freezeRotation = true; 

        cam = playerCamera.GetComponent<Camera>();
        if (cam != null) cam.fieldOfView = normalFOV;
    }

    void Update()
    {
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // --- Movement Input ---
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

       
        movement = (transform.right * moveX + transform.forward * moveZ).normalized;
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        if(Input.GetKeyDown(KeyCode.Space) && onGround){
            rb.linearVelocity = new Vector3(rb.linearVelocity.x , 0f, rb.linearVelocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        if (cam != null){
            bool isActuallySprinting = isSprinting && movement.magnitude > 0;
            float targetFOV = isActuallySprinting ? sprintFOV : normalFOV;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, fovTransform * Time.deltaTime);
        }
        
        // --- Camera ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensv * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensv * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        float currentTargetSpeed = isSprinting ? sprintSpeed : moveSpeed;
        Vector3 targetVelocity = movement * currentTargetSpeed;
        Vector3 currentHorizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        float smoothRate = (movement.magnitude > 0) ? acceleration : deceleration;
        Vector3 smoothedVelocity = Vector3.Lerp(currentHorizontalVelocity, targetVelocity, smoothRate * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(smoothedVelocity.x, rb.linearVelocity.y, smoothedVelocity.z);
    }
}