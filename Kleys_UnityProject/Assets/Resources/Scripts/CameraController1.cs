using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    //Empty game objkect in the scene which is the pivot - camera inside it - 
    [SerializeField] float minDegreesCam, maxDegreesCam;
    [SerializeField] LayerMask wallLayer;

    Transform target;
    Transform myCameraTr;
    float rotationXCamera = 0;
    Vector3 camInitPos;

    [SerializeField] float heightOffset;

    private void Start()
    {
        target = FindObjectOfType<Player>().transform;
        myCameraTr = transform.GetChild(0);
        camInitPos = myCameraTr.localPosition;
    }

    private void FixedUpdate()
    {
        transform.position = target.position + Vector3.up * heightOffset;
        transform.rotation = target.rotation ;
        CameraRotationY();
    }

    void LateUpdate()
    {
        CheckWalls();
    }

    void CameraRotationY()
    {
        rotationXCamera -= Input.GetAxis("Mouse Y");
        rotationXCamera = Mathf.Clamp(rotationXCamera, minDegreesCam, maxDegreesCam);
        myCameraTr.localRotation = Quaternion.Euler(rotationXCamera, 0, 0);
    }

    void CheckWalls() {

        Vector3 dir = transform.position - myCameraTr.position;
        RaycastHit hit;
        
        if (Physics.Raycast(myCameraTr.position, dir, out hit, Vector3.Distance(transform.position, myCameraTr.position), wallLayer)) {
            myCameraTr.position = Vector3.Lerp(myCameraTr.position, hit.point, Time.deltaTime * 5);
        }
        else
        {

            myCameraTr.localPosition = Vector3.Lerp(myCameraTr.localPosition, camInitPos, Time.deltaTime * 5);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.GetChild(0).position, transform.position - transform.GetChild(0).position);
    }
}
