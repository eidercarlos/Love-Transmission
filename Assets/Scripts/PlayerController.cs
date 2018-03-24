using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    Animator anim;
    int moveForward = Animator.StringToHash("MoveForward");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {   
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if(moveDirection.z > 0.0f)
            {   
                anim.Play("Armed-Run-Forward");
            }
            else if(moveDirection.z < 0.0f)
            {   
                anim.Play("Armed-Run-Backward");
            }
            else
            {
                anim.Play("Armed-Idle-Pistol-R");
            }

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            //if (Input.GetButton("Jump"))
            //    moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

}
