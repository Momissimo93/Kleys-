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
            capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
            groundCheck = gameObject.AddComponent<GroundCheck>();
            groundCheck.Constructor(this);
            fallingCheck = gameObject.AddComponent<FallingCheck>();
            if (gameObject.GetComponent<Player>())
            {
                player = gameObject.GetComponent<Player>();
            }
            fallingCheck.Constructor(this);
        }
        else
        {
            Debug.Log("Error: No capsule Collider found");
        }
    }

    public void UpdateManger()
    {
        if(player)
        {
            RayCasting();
            player.Set_IsOnGround(IsGrounded());
            if (player.Get_IsOnGround() == true)
            {
                player.Set_IsFalling(false);
                player.Set_IsJumping(false);
                player.GetAnimator().SetBool("isFalling", false);
                player.GetAnimator().SetBool("isGrounded", true);
                player.GetAnimator().SetBool("isJumping", false);
            }
            else if (player.Get_IsOnGround() == false)
            {
                player.GetAnimator().SetBool("isGrounded", false);
                player.Set_IsFalling(IsFalling());

                if (player.Get_IsFalling() == true)
                {
                    player.GetAnimator().SetBool("isFalling", true);
                }
            }
            else if (player.Get_IsJumping() == false && player.Get_IsFalling() == false && player.Get_IsOnGround() == true)
            {
                Debug.Log("Reached the ground"); 
            }

        }
    }

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
    public float DistanceFromGround(RaycastHit hitInfo)
    {
        Debug.Log(Mathf.Round(hitInfo.distance * 10) / 10);
        return Mathf.Round(hitInfo.distance * 10) / 10;
    }
    void DrawRay(RaycastHit hitInfo)
    {
        Debug.DrawRay(transform.position, Vector3.down * hitInfo.distance, Color.red);
    }
    public void SetAnimator(Animator anim)
    {
        animator = anim;
    }
}