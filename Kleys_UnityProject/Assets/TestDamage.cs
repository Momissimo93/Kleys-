using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            Player p = (other.gameObject.GetComponent<Player>());
            p.TakeDamage(1, this.gameObject);
        }
    }
}
