using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    private Player player;
    private CapsuleCollider capsuleCollider;
    private JumpManager jumpManager;
    float distance;
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
    }

    public void Constructor(JumpManager j)
    {
        jumpManager = j;
    }

    public bool IsFalling()
    {
        if (player.Get_IsOnGround() == false && player.Get_IsJumping() == true)
        {
            float newDistance = jumpManager.distance;

            if (distance == 0 || newDistance > distance)
            {
                distance = newDistance;
                return false;
            }
            else if (newDistance < distance)
            {
                distance = newDistance;
                return true;
            }
            distance = newDistance;
        }
        else if (player.Get_IsOnGround() == false && player.Get_IsJumping() == false)
        {
            return true;
        }
        return false;
    }
}
