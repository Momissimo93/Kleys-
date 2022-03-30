using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    /*
    private Vector3 rayStartingPoint;
    private RaycastHit hitInfo;
    private int layerMask = 1 << 6;
    [SerializeField] [Range(0.0f, 3f)] float rayLength = 2f;
    [SerializeField] [Range(0.0f, 0.5f)] float startingPoint_offset = 0.01f;
    */
    JumpManager jumpManager; 

    void Start()
    {
        /*
        if (gameObject.GetComponent<CapsuleCollider>())
        {
            capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        }
        else
        {
            Debug.Log("Error: No capsule Collider found");
        }*/
        jumpManager = gameObject.AddComponent<JumpManager>();
    }
    public bool ISGrounded()
    {
        /*
        if (capsuleCollider)
            rayStartingPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + startingPoint_offset, capsuleCollider.bounds.center.z);

        //If the ground is detected 
        if (Physics.Raycast(rayStartingPoint, Vector3.down, out hitInfo, rayLength, layerMask))
        {
            DrawRay(hitInfo);

            if (DistanceFromGround(hitInfo) == 0)
            {
                return true;
            }
            else
            return false;
        }
        //If the ground is not detected 
        else
        {
            return false;
        }*/
        if (jumpManager.distance == 0)
        {
            return true;
        }
        else
            return false;
    }

    private float DistanceFromGround(RaycastHit hitInfo)
    {
        //Debug.Log(Mathf.Round(hitInfo.distance * 10) / 10);
        return Mathf.Round(hitInfo.distance * 10) / 10;
    }

    void DrawRay(RaycastHit hitInfo)
    {
        //Debug.DrawRay(transform.position, Vector3.down * hitInfo.distance, Color.red);
        //Debug.DrawRay(rayStartingPoint, Vector2.down * rayLength, Color.blue);
    }
}
