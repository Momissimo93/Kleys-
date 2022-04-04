using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    [Header("Right Hand IK")]
    [Range(0, 1)] [SerializeField] float rightHandWeight;
    [SerializeField] Transform rightHandObj = null;
    [SerializeField] Transform rightHandWeapon = null;
    [SerializeField] Transform lookObj = null;
    [SerializeField] Transform rightHandHint = null;

    Animator animator;
    Player player;

    int layerMask = 1 << 6;
    int objectLayer = 1 << 7;
    int weaponLayer = 1 << 11;
    [SerializeField] float radius = 0.2f;
    Collider[] collider;
    [SerializeField] enum ActionType {Grabbing, None};
    [SerializeField] ActionType actionType;
    [SerializeField] [Range(0, 1)] float distanceToGround = 0.18f;
    [SerializeField] [Range(-1.0f, -0.5f)] float offSet = -0.8f;
    [SerializeField] bool canGrabObject = false;

    //[SerializeField] float offSet_ = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        actionType = ActionType.None;
    }
    public void Constructor(Player p, Animator a)
    {
        player = p;
        animator = a;
    }
    private void OnAnimatorIK()
    {
        if(animator)
        {
            SetWeight();
            RightFoot_IKManager();
            LeftFoot_IKManager();
            switch (actionType)
            {
                case ActionType.Grabbing:
                    GrabObject();
                    break;
                case ActionType.None:
                    HoldingWeapon();
                    break;
            }
        }
    }
    private void SetWeight()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, animator.GetFloat("RightFootIK"));
        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("LeftFootIK"));

        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, animator.GetFloat("RightFootIK"));
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("LeftFootIK"));

        //I have the same wight for rotation and position
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

            //animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            //animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
    }
    private void RightFoot_IKManager()
    {
        RaycastHit hit;
        Ray rightFootRay = new Ray (animator.GetIKPosition(AvatarIKGoal.RightFoot), Vector3.down);
        DrawRay(rightFootRay.origin, rightFootRay.direction * distanceToGround, Color.red);
        if (Physics.Raycast(rightFootRay, out hit, distanceToGround, layerMask))
        {

            //DrawRay(rightFootRay.origin, rightFootRay.direction);
            //Debug.Log("I am hitting the ground");
            animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + (Vector3.down * distanceToGround) * offSet);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward, hit.normal));
        }
    }
    private void LeftFoot_IKManager()
    {
        RaycastHit hit;
        Ray leftFootRay = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot), Vector3.down);
        DrawRay(leftFootRay.origin, leftFootRay.direction * distanceToGround, Color.red);
        if (Physics.Raycast(leftFootRay, out hit, distanceToGround, layerMask))
        {
            //DrawRay(rightFootRay.origin, rightFootRay.direction);
            //Debug.Log("I am hitting the ground");
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + (Vector3.down * distanceToGround) * offSet);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));
        }
    }

    private void GrabObject()
    {
        /*
        animator.SetLookAtPosition(lookObj.position);
        animator.SetLookAtWeight(animator.GetFloat("lookAt_weightIK"), animator.GetFloat("lookAt_bodyWeightIK"), animator.GetFloat("lookAt_headWeightIK"), animator.GetFloat("lookAt_eyes_weightIK"));
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, animator.GetFloat("rightHand_weightIk"));
        //animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
        collider = Physics.OverlapSphere(animator.GetIKPosition(AvatarIKGoal.RightHand), radius, objectLayer);

        foreach (var i in collider)
        {
            if (collider.GetValue(0) != null)
            {
                Ray rightHandRay = new Ray(animator.GetIKPosition(AvatarIKGoal.RightHand), i.transform.position - animator.GetIKPosition(AvatarIKGoal.RightHand));
                RaycastHit hit;
                Debug.DrawRay(animator.GetIKPosition(AvatarIKGoal.RightHand), i.transform.position - animator.GetIKPosition(AvatarIKGoal.RightHand), Color.red);
                //I need the Normal to set the rotation of the hand 
                if(Physics.Raycast(rightHandRay,out hit,1f,objectLayer))
                {
                    Debug.Log("Contact made");
                    animator.SetIKPosition(AvatarIKGoal.RightHand, hit.transform.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, Quaternion.LookRotation(hit.transform.forward + hit.normal));
                    //rightHandObj.SetParent(player.transform.Find("mixamorig9:Hips/mixamorig9:Spine/mixamorig9:Spine1/mixamorig9:Spine2/mixamorig9:RightShoulder/mixamorig9:RightArm/mixamorig9:RightForeArm/mixamorig9:RightHand").gameObject.transform);
                }
            }
        } */
    }


    private void HoldingWeapon()
    {
        if (rightHandWeapon)
        {
            collider = Physics.OverlapSphere(animator.GetIKPosition(AvatarIKGoal.RightHand), radius, weaponLayer);
            foreach (var i in collider)
            {
                RaycastHit hit;
                Ray r = new Ray(animator.GetIKPosition(AvatarIKGoal.RightHand), i.transform.position - animator.GetIKPosition(AvatarIKGoal.RightHand));
                Debug.DrawRay(animator.GetIKPosition(AvatarIKGoal.RightHand), i.transform.position - animator.GetIKPosition(AvatarIKGoal.RightHand), Color.red);
                animator.SetIKPosition(AvatarIKGoal.RightHand, i.transform.position);
                if (Physics.Raycast(r, out hit, 1, weaponLayer))
                {
                    animator.SetIKRotation(AvatarIKGoal.RightHand, Quaternion.LookRotation(hit.transform.forward, hit.normal));
                }
            }
        }
    }

    public void SetActionType(int i)
    {
        ActionType aT = (ActionType)i;
        actionType = aT;
    }

    public void Set0bjectToGrab(Transform objectToGrab, bool b)
    {
        rightHandObj = objectToGrab;
        lookObj = objectToGrab;
        player.Set_CanGrabObject(b);
    }

    public void SetRightHandWeapon(GameObject objectToGrab)
    {
        rightHandWeapon = objectToGrab.transform;
        if(rightHandWeapon != null)
        {
            //HoldingWeapon();
        }
    }

    private void DrawRay(Vector3 origin, Vector3 direction, Color color)
    {
        Debug.DrawRay(origin, direction, Color.red);
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(animator.GetIKPosition(AvatarIKGoal.RightHand), radius);
    }
}
