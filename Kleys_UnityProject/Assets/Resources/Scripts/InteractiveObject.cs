using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Player player;
    private int groundLayer = 1 << 6;
    private int objectLayer = 1 << 7;
    [SerializeField] float radius;
    Collider[] colliders;
    float distance;
    void Update()
    {
        /*
         * We check if the Player has enter the sphere
         * If it is true calculate the distance from the Player to the Interactive Object
         * If the distance is < than 1.5:
         *  - the canGrabObject variable of the class Player is set to be TRUE --> this will let the InputManager class to set the canGrab variable of the IKManager class to be TRUE
         *  - the lookObj varible of the ikManager is assigned to this transform 
         *  - the rightHandObj of the iKmanager is also assigned to this transform 
        */
        colliders = Physics.OverlapSphere(this.transform.position, radius, ~(groundLayer + objectLayer));

        foreach (var i in colliders)
        {
            if (i.gameObject.GetComponent<Player>())
            {
                player = i.gameObject.GetComponent<Player>();
                distance = Vector3.Distance(player.transform.Find("mixamorig9:Hips/mixamorig9:Spine/mixamorig9:Spine1/mixamorig9:Spine2/mixamorig9:RightShoulder").gameObject.transform.position, transform.position);
                Debug.Log(distance);

                if (player.gameObject.GetComponent<IKManager>())
                {
                    IKManager iKManager = player.gameObject.GetComponent<IKManager>();
                    //iKManager.Set0bjectToGrab(this.gameObject.transform, true);

                    if (distance < radius )
                    {
                        iKManager.Set0bjectToGrab(this.gameObject.transform, true);
                    }
                    else
                    {
                        iKManager.Set0bjectToGrab(null, false);
                        //At a bigger distance we loose track of the object 
                        /*
                        mainCharacter.canGrabObject = false;
                        mainCharacter.iKManager.canGrab = false;
                        mainCharacter.iKManager.lookObj = null;
                        mainCharacter.iKManager.rightHandObj = null;*/
                    }
                }

            }
            DrawLine(player);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    private void DrawLine(Player r)
    {
        Debug.DrawLine(this.transform.position, r.transform.Find("mixamorig9:Hips/mixamorig9:Spine/mixamorig9:Spine1/mixamorig9:Spine2/mixamorig9:RightShoulder").gameObject.transform.position, Color.red);
    }
}