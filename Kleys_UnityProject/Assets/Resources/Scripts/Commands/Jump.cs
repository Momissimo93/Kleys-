using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Commands
{
    public override void Jumping (Transform transform)
    {
        if (transform.gameObject.GetComponent<Player>())
        {
            player = transform.gameObject.GetComponent<Player>();

            if (transform.gameObject.GetComponent<Rigidbody>())
            {
                rigidbody = transform.gameObject.GetComponent<Rigidbody>();
                rigidbody.AddForce(new Vector3(rigidbody.velocity.x, rigidbody.velocity.y + player.JumpingForce, rigidbody.velocity.z), ForceMode.Impulse);
            }
        }
    }
}
