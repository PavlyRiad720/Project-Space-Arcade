using Unity.VisualScripting;
using UnityEngine;

public class SpaceFlyCam : MonoBehaviour
{
    [Header("Movement Speeds")]
    public float mainSpeed = 15.0f;
    public float shiftSpeed = 45.0f;
    public float climbSpeed = 10.0f;

    [Header("Mouse Look Sensitivity")]
    public float mouseSensitivity = 0.25f;

    private Vector3 lastMouse = new Vector3(255, 255, 255);
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 currentRotation = transform.localRotation.eulerAngles;
        rotationX = currentRotation.y;
        rotationY = -currentRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity * 10f;
        rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity * 10f;
        rotationY = Mathf.Clamp(rotationY, -85f, 85f);

        transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0);

        Vector3 p = GetBaseInput();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            p = p * shiftSpeed;
        }
        else
        {
            p = p * mainSpeed;
        }

        p = p * Time.deltaTime;
        transform.Translate(p);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();

        if (Input.GetKey(KeyCode.W)) p_Velocity += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) p_Velocity += Vector3.back;

        if (Input.GetKey(KeyCode.A)) p_Velocity += Vector3.left;
        if (Input.GetKey(KeyCode.D)) p_Velocity += Vector3.right;

        if (Input.GetKey(KeyCode.E)) p_Velocity += Vector3.up;
        if (Input.GetKey(KeyCode.Q)) p_Velocity += Vector3.down;

        return p_Velocity;
    }
}
