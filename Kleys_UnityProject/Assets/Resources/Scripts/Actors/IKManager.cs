using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    Animator animator;
    Player player;
    int layerMask = 1 << 6;
    [SerializeField] enum ActionType {Grabbing, None};
    [SerializeField] ActionType actionType;
    [SerializeField] [Range(0, 1)] float distanceToGround = 0.18f;
    [SerializeField] [Range(-1.0f, -0.5f)] float offSet = -0.8f;
    [SerializeField] bool canGrabObject = false;
    [SerializeField] Transform rightHandObj = null;
    [SerializeField] Transform lookObj = null;
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
    private void OnAnimatorIK(int layerIndex)
    {
        SetWeight();
        RightFoot_IKManager();
        LeftFoot_IKManager();
    }
    private void SetWeight()
    {
        if (animator)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, animator.GetFloat("RightFootIK"));
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("LeftFootIK"));
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, animator.GetFloat("RightFootIK"));
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("LeftFootIK"));

            //animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            //animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
            //animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            //animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

        }
    }
    private void RightFoot_IKManager()
    {
        RaycastHit hit;
        Ray rightFootRay = new Ray (animator.GetIKPosition(AvatarIKGoal.RightFoot), Vector3.down);
        DrawRay(rightFootRay.origin, rightFootRay.direction * distanceToGround, Color.red);
        if (Physics.Raycast(rightFootRay, out hit, distanceToGround, layerMask))
        {

            //DrawRay(rightFootRay.origin, rightFootRay.direction);
            Debug.Log("I am hitting the ground");
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
            Debug.Log("I am hitting the ground");
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + (Vector3.down * distanceToGround) * offSet);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));
        }
    }

    public void Set0bjectToGrab(Transform objectToGrab, bool b)
    {
        rightHandObj = objectToGrab;
        lookObj = objectToGrab;
        player.Set_CanGrabObject(b);
    }
    private void DrawRay(Vector3 origin, Vector3 direction, Color color)
    {
        Debug.DrawRay(origin, direction, Color.red);
    }
}
