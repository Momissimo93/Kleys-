using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] Vector3 startingPoint;

    [SerializeField] [Range(0.0f, 3f)] float rayLength = 2f;
    [SerializeField] [Range(0.0f, 0.5f)] float startingPoint_offset = 0.01f;

    private RaycastHit hitInfo;
    private int layerMask = 1<<6;
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

    public bool GroundCheck ()
    {
        if(capsuleCollider)
            startingPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + startingPoint_offset, capsuleCollider.bounds.center.z);
        DrawRay();
        //1) Case: The raycast is detecting the ground and the distance is tell
        if(Physics.Raycast(startingPoint, Vector3.down,out hitInfo, rayLength, layerMask))
        {
            if(DistanceFromGround(startingPoint.y, hitInfo.collider.gameObject.transform.position.y) <= 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private float DistanceFromGround (float startingPoint, float hitInfo )
    {
        float distanceFromGround = startingPoint - hitInfo;
        return distanceFromGround;
    }

    public bool IsFalling ()
    {
        if (capsuleCollider)
            startingPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + startingPoint_offset, capsuleCollider.bounds.center.z);
        if (Physics.Raycast(startingPoint, Vector3.down, out hitInfo, rayLength, layerMask))
        {
            float newDistance =  DistanceFromGround(startingPoint.y, hitInfo.collider.gameObject.transform.position.y);

            if(distance == 0 )
            {

            }
            else if(newDistance < distance)
            {
                Debug.Log("We are falling");

            }

            distance = newDistance;

        }

        return false;
    }

    void DrawRay()
    {
        Debug.DrawRay(startingPoint, Vector2.down * rayLength, Color.blue);
    }
}
