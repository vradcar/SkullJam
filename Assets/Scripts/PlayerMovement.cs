using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 30f;
    bool jump = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Run", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("JumpTrigger", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("JumpTrigger", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
