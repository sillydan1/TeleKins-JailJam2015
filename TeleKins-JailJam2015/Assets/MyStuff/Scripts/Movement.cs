using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10;
    private CharacterMotor motor;
    private CharacterController controller;
    private bool isJumping, isLaunching;
    private float timer, launchDuration, oldJumpHeight;
    private Vector3 launchVel;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        motor = GetComponent<CharacterMotor>();
    }
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.forward * verti;
        moveDir += transform.right * hori;
        moveDir *= Time.deltaTime * moveSpeed;

        motor.inputJump = Input.GetButton("Jump");
        

        if(Input.GetKeyDown(KeyCode.E))
        {
            isLaunching = true;
            Debug.Log("Yes");
        }
        //motor.inputMoveDirection = moveDir;
        if(isLaunching)
        {
            if(timer < launchDuration)
            {
                timer += Time.deltaTime;
                //controller.Move(launchVel * Time.deltaTime);
                moveDir += launchVel * Time.deltaTime;
                moveDir += new Vector3(0, -0.2f, 0);
                launchVel /= 1.03f;
                motor.jumping.baseHeight = oldJumpHeight;
            }
            else
            {
                timer = 0;
                isLaunching = false;
            }
        }
        controller.Move(moveDir);
    }
    public void Launch(Vector3 LaunchVelocity, float duration)
    {
        launchVel = LaunchVelocity;
        isLaunching = true;
        launchDuration = duration;
        oldJumpHeight = motor.jumping.baseHeight;
        motor.jumping.baseHeight = 0.1f;
        motor.inputJump = true;
    }
}
