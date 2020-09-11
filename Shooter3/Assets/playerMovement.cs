using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 6;
    public float runSpeed = 10;
    public float jumpSpeed = 8;
    public float gravity = 20;

    private Vector3 moveDirection;
    private CharacterController cc;

    public bool ClimbStair;
    public bool onGround;

    public Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        onGround = cc.isGrounded;
        float oldY = moveDirection.y;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (ClimbStair)
        {
            moveDirection = new Vector3(-h, v, 0);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {

            moveDirection = new Vector3(h, 0, v);
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0;

            if (cc.isGrounded)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveDirection *= runSpeed;
                }
                else
                {
                    moveDirection *= speed;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpSpeed;
                    anim.SetTrigger("jump");
                }
            }
            else
            {
                moveDirection *= speed;
                moveDirection.y = oldY;
            }



        }
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);

        Vector3 temp = moveDirection;
        temp.y = 0;
        anim.SetBool("onGround", cc.isGrounded);
        anim.SetFloat("speed", temp.magnitude);

    }
}

