using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Animator anim;
    private Vector2 moveInput;

    private void Update() {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        //Get the inputs from player (WASD, arrow keys, joystick, etc...)

        moveInput.Normalize(); //This is so diagonal movement isnt faster.

        //Check  for movement and apply the proper animations.
        if (moveInput.x != 0)
        {
            ClearWalkCycle();
            anim.SetBool("IsSide", true); //Left/Right
        }
        else if (moveInput.y > 0)
        {
            ClearWalkCycle();
            anim.SetBool("IsDown", true); //Down
        }
        else if (moveInput.y < 0)
        {
            ClearWalkCycle();
            anim.SetBool("IsUp", true); //Up
        }
        else if (moveInput == new Vector2(0,0))
        {
            ClearWalkCycle();
            anim.SetBool("IsIdle", true); //Idle
        }

        if (moveInput.x < 0) {
            renderer.flipX = true; //Left
        } else if (moveInput.x > 0)
            renderer.flipX = false; //Right
    } 

    private void FixedUpdate()
    {
        rb2d.velocity = moveInput * moveSpeed; //The actual movement of the player.
    }

    //Simple function to make sure anim bools get reset.
    public void ClearWalkCycle()
    {
        anim.SetBool("IsDown", false);
        anim.SetBool("IsUp", false);
        anim.SetBool("IsSide", false);
        anim.SetBool("IsIdle", false);
    }
}
