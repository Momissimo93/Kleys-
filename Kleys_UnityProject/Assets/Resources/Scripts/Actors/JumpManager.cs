using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] Vector3 rayStartingPoint;

    [SerializeField] [Range(0.0f, 10f)] float rayLength = 10f;
    [SerializeField] [Range(0.0f, 0.5f)] float startingPoint_offset = 0.01f;

    private RaycastHit hitInfo;
    private int layerMask = 1 << 6;
    public float distance;
    public float newDistance;

    GroundCheck groundCheck;
    FallingCheck fallingCheck;
    Player player;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<CapsuleCollider>())
        {
            //The capsule is needed in order to cast a ray
            capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
            /*
             * The two GroundCheck and FallingCheck functions like component of the class JumpManager
             * Both have a method called Constructor that takes a reference to the JumpManager that is used by the Player class 
            */
            groundCheck = gameObject.AddComponent<GroundCheck>();
            groundCheck.Constructor(this);
            fallingCheck = gameObject.AddComponent<FallingCheck>();
            fallingCheck.Constructor(this);

            //The class needs a reference to the Player class to communicate with it 
            if (gameObject.GetComponent<Player>())
            {
                player = gameObject.GetComponent<Player>();
            }
        }
        else
        {
            Debug.Log("Error: No capsule Collider found");
        }
    }

    //The UpdateManager is called from the Update method of the class Player 
    public void UpdateManger()
    {
        if(player)
        {
            //The first action to be performed is that of cast a Ray checking our distance from the ground
            RayCasting();
            //The method ask: are we on ground or not?
            player.Set_IsOnGround(IsGrounded());
            if (player.Get_IsOnGround() == true)
            {
                //If the player is on the ground that means that we are not falling and not jumping 
                player.Set_IsFalling(false);
                player.Set_IsJumping(false);
                //After updating the variables we update the animations 
                player.GetAnimator().SetBool("isFalling", false);
                player.GetAnimator().SetBool("isGrounded", true);
                player.GetAnimator().SetBool("isJumping", false);
            }
            else if (player.Get_IsOnGround() == false)
            {
                //If the player is not on the ground we update the animation 
                player.GetAnimator().SetBool("isGrounded", false);
                //Then it is checked if the player is falling or not; and this depends upon the player distance from the ground 
                player.Set_IsFalling(IsFalling());

                if (player.Get_IsFalling() == true)
                {
                    //If the player is falling then the animation changes accordingly 
                    player.GetAnimator().SetBool("isFalling", true);
                }
            }
            else if (player.Get_IsJumping() == false && player.Get_IsFalling() == false && player.Get_IsOnGround() == true)
            {
                //This is just to monitor if we are on the ground or not; the actual animation is chenged elsewhere 
                Debug.Log("Reached the ground"); 
            }
        }
    }

    //The two methods ask the classes GroundCheck and FallingCheck to see whatever the player is on the ground or if it is falling 
    public bool IsGrounded()
    {
        if(groundCheck)
        {
            return groundCheck.ISGrounded();
        }
        return false;
    }
    public bool IsFalling()
    {
        if (fallingCheck)
        {
            return fallingCheck.IsFalling();
        }
        return false;
    }
    public void RayCasting ()
    {
        if (capsuleCollider)
        {
            rayStartingPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + startingPoint_offset, capsuleCollider.bounds.center.z);
            if (Physics.Raycast(rayStartingPoint, Vector3.down, out hitInfo, rayLength, layerMask))
            {
                DrawRay(hitInfo);
                newDistance = DistanceFromGround(hitInfo);
                distance = newDistance;
            }
        }
        else
        {
            Debug.Log("Error: Capsule not detected");
        }
    }

    //The distance from the ground is here calculated and rounded 
    public float DistanceFromGround(RaycastHit hitInfo)
    {
        return Mathf.Round(hitInfo.distance * 10) / 10;
    }
    void DrawRay(RaycastHit hitInfo)
    {
        Debug.DrawRay(transform.position, Vector3.down * hitInfo.distance, Color.red);
    }
    //The methods takes the animation an animation and stores it into a variable 
    public void SetAnimator(Animator anim)
    {
        animator = anim;
    }
}