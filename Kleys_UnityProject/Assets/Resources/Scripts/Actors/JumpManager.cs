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
    private float distance;

    private float startingDistanceFromGround = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<CapsuleCollider>())
        {
            capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        }
        else
        {
            Debug.Log("No capsule Collider found");
        }
    }

    public bool ISGrounded()
    {
        if (capsuleCollider)
            rayStartingPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + startingPoint_offset, capsuleCollider.bounds.center.z);

        //If the ground is detected 
        if (Physics.Raycast(rayStartingPoint, Vector3.down, out hitInfo, rayLength, layerMask))
        {
            Debug.DrawRay(transform.position, Vector3.down * hitInfo.distance, Color.red);
            Debug.Log(Mathf.Round(hitInfo.distance * 10) / 10);
            if (Mathf.Round(hitInfo.distance * 10) / 10 == 0)
            {
                Debug.Log("OnGround");
                return true;
            }
            else
                Debug.Log("NotOnGround");
                return false;
        }
        //If the ground is not detected 
        else
        {
            return false;
        }
    }

    public bool IsFalling()
    {
        if (capsuleCollider)
            rayStartingPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + startingPoint_offset, capsuleCollider.bounds.center.z);
        if (Physics.Raycast(rayStartingPoint, Vector3.down, out hitInfo, rayLength, layerMask))
        {
            float newDistance = DistanceFromGround(rayStartingPoint, hitInfo.transform.position);

            if (distance == 0)
            {

            }
            else if (newDistance < distance)
            {
                //Debug.Log("We are falling");

            }

            distance = newDistance;

        }

        return false;
    }
    private float DistanceFromGround(Vector3 startingPoint, Vector3 hitInfo)
    {
        //float distanceFromGround = startingPoint - hitInfo;
        float distance = Vector3.Distance(startingPoint, hitInfo);
        //Debug.Log(distance);
        return distance;
    }

    void DrawRay()
    {
        Debug.DrawRay(rayStartingPoint, Vector2.down * rayLength, Color.blue);
    }
}