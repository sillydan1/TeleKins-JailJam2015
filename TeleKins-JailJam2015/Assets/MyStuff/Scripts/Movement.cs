using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10;
    private CharacterMotor motor;
    private CharacterController controller;
    private bool isJumping;

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
        controller.Move(moveDir);
        //motor.inputMoveDirection = moveDir;
        
    }
}
