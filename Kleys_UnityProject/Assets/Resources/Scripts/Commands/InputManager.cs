using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Commands translate;
    private Commands rotate;
    private Commands jump;
    private float verticalInput;
    private float horizontalInput;
    private Animator animator;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        translate = new Translate();
        rotate = new Rotate();
        jump = new Jump();
        if(gameObject.GetComponent<Player>())
        {
            player = gameObject.GetComponent<Player>();
        }
    }
     
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && player.Get_IsOnGround())
        {
            animator.SetBool("isJumping", true);
            player.Set_IsJumping(true);
            jump.Jumping(player.transform);
        }
        else if (Input.GetKeyDown(KeyCode.F) && player.Get_CanGrabObject())
        {
            animator.SetTrigger("grab");
            player.Set_IsGrabbing(true);
        }
    }

    private void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (verticalInput != 0)
        {
            HandleVerticalInputs(verticalInput);
            if (horizontalInput != 0)
            {
                HandleHorizontalInputs(horizontalInput);
            }
        }
        else if (horizontalInput != 0)
        {
            HandleHorizontalInputs(horizontalInput);
        }
    }
    private void HandleVerticalInputs(float verticalInput)
    {
        translate.Move(this.transform, new Vector2(0, verticalInput));
    }
    private void HandleHorizontalInputs(float horizontalInput)
    {
        rotate.Turn(this.transform, horizontalInput);
    }

    public void SetAnimator (Animator anim)
    {
        animator = anim;
    }

    public void UpdateAnimations()
    {
        animator.SetFloat("speed", Input.GetAxis("Vertical"));
        animator.SetFloat("rotationSpeed", Input.GetAxis("Horizontal"));
    }
}
