using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    JumpManager jumpManager; 

    public void Constructor(JumpManager j)
    {
        jumpManager = j;
    }

    public bool ISGrounded()
    {
        if (jumpManager.distance == 0)
        {
            return true;
        }
        else
            return false;
    }
}
