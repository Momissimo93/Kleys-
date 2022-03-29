using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Commands
{
    public override void Turn(Transform transform, float value)
    {
        if (transform.gameObject.GetComponent<Player>())
        {
            player = transform.gameObject.GetComponent<Player>();

            if (transform.gameObject.GetComponent<Rigidbody>())
            {
                rigidbody = transform.gameObject.GetComponent<Rigidbody>();
                transform.rotation = transform.rotation * Quaternion.AngleAxis(value * player.RotationSpeed * Time.deltaTime, Vector3.up);
            }
        }
    }
}
