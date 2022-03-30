using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    /*
    private CapsuleCollider capsuleCollider;
    private Vector3 rayStartingPoint;
    private RaycastHit hitInfo;
    private int layerMask = 1 << 6;
    [SerializeField] [Range(0.0f, 3f)] float rayLength = 2f;
    [SerializeField] [Range(0.0f, 0.5f)] float startingPoint_offset = 0.01f;
    private float distance;
    Player player;
    */
    private Player player;
    private CapsuleCollider capsuleCollider;
    private JumpManager jumpManager;

    void Start()
    {
        
        if (gameObject.GetComponent<CapsuleCollider>())
        {
            capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
            if(gameObject.GetComponent<Player>())
            {
                player = gameObject.GetComponent<Player>();
            }
        }
        else
        {
            Debug.Log("Error: No capsule Collider found");
        }
        jumpManager = gameObject.AddComponent<JumpManager>();
    }
    public bool IsFalling()
    {
        /*
        if (capsuleCollider)
        {
            if (player.IsOnGround() == false && player.IsJumping() == true)
            {
                Debug.Log("Let's Check if it is falling");
                rayStartingPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + startingPoint_offset, capsuleCollider.bounds.center.z);
                if (Physics.Raycast(rayStartingPoint, Vector3.down, out hitInfo, rayLength, layerMask))
                {
                    float newDistance = DistanceFromGround(hitInfo);
                    if (distance == 0 || newDistance > distance)
                    {
                        Debug.Log("We are not falling");
                        //return false;
                    }
                    else if (newDistance < distance)
                    {
                        Debug.Log("We are falling");
                        //return true;
                    }
                    distance = newDistance;
                }
            }
            else if(player.IsOnGround() == false && player.IsJumping() == false)
            {
                Debug.Log("We are falling");
                return true;
            }
            return false;
        }
        Debug.Log("Error: Capsule not detected");
        return false;
        */
        if (player.IsOnGround() == false && player.IsJumping() == true)
        {
            if (jumpManager.distance == 0 || jumpManager.newDistance > jumpManager.distance)
            {
                Debug.Log("We are not falling");
                //return false;
            }
            else if (jumpManager.newDistance < jumpManager.distance)
            {
                Debug.Log("We are falling");
                //return true;
            }
        }
        else if (player.IsOnGround() == false && player.IsJumping() == false)
        {
            Debug.Log("We are falling");
            //return true;
        }
        return false;
    }
    /*
    private float DistanceFromGround(RaycastHit hitInfo)
    {
        return Mathf.Round(hitInfo.distance * 10) / 10;
        /*
        //float distanceFromGround = startingPoint - hitInfo;
        float distance = Vector3.Distance(startingPoint, hitInfo);
        //Debug.Log(distance);
        return distance;
        
    }*/
}
