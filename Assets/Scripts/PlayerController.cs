using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float lookSensitivity = 5.0f;
    [SerializeField]
    private float jumpForce = 100f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //player movement
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveH = transform.right * xMov;
        Vector3 moveV = transform.forward * zMov;

        Vector3 velocity;
        if (Input.GetKey(KeyCode.LeftShift))
        { 
            //run
            velocity = (moveV + moveH).normalized * speed * 1.5f;
        }
        else
        {
            //walk
            velocity = (moveV + moveH).normalized * speed;
        }

        motor.Move(velocity);

        //player rotate
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, yRot, 0) * lookSensitivity;

        motor.Rotate(rotation);

        //camera rotate
        float xRot = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRot * lookSensitivity;

        motor.RotateCamera(cameraRotationX);

        //jump
        Vector3 jumpForce = Vector3.zero;
        if (Input.GetButton("Jump")) 
        {
            jumpForce = Vector3.up * this.jumpForce;
        }

        motor.ApplyJump(jumpForce);
    }

}
