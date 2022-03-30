using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] Vector3 rayStartingPoint;

    [SerializeField] [Range(0.0f, 3f)] float rayLength = 2f;
    [SerializeField] [Range(0.0f, 0.5f)] float startingPoint_offset = 0.01f;

    private RaycastHit hitInfo;
    private int layerMask = 1 << 6;
    public float distance;
    public float newDistance;

    //private float startingDistanceFromGround = 0;

    GroundCheck groundCheck;
    FallingCheck fallingCheck;

    // Start is called before the first frame update
    void Start()
    {

        groundCheck = gameObject.AddComponent<GroundCheck>();
        fallingCheck = gameObject.AddComponent<FallingCheck>();
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

    void RayCasting ()
    {
        if (capsuleCollider)
        {
            rayStartingPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + startingPoint_offset, capsuleCollider.bounds.center.z);
            if (Physics.Raycast(rayStartingPoint, Vector3.down, out hitInfo, rayLength, layerMask))
            {
                //float newDistance = DistanceFromGround(hitInfo);
                newDistance = DistanceFromGround(hitInfo);
                /*
                if (distance == 0 || newDistance > distance)
                {
                    //Debug.Log("We are not falling");
                }
                else if (newDistance < distance)
                {
                    //Debug.Log("We are falling");
                }*/
                distance = newDistance;
                
            }
            /*
            else if (player.IsOnGround() == false && player.IsJumping() == false)
            {
                Debug.Log("We are falling");
            }*/
        }
        Debug.Log("Error: Capsule not detected");
    }
    private float DistanceFromGround(RaycastHit hitInfo)
    {
        return Mathf.Round(hitInfo.distance * 10) / 10;
        /*
        //float distanceFromGround = startingPoint - hitInfo;
        float distance = Vector3.Distance(startingPoint, hitInfo);
        //Debug.Log(distance);
        return distance;
        */
    }
}