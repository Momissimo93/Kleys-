using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] Player p;
    [SerializeField] Key k;

    private void Start()
    {
        k = this.gameObject.GetComponent<Key>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.GetComponent<Player>())
        {
            p = collision.gameObject.GetComponent<Player>();
            //p.StoreKey(k);
            Destroy(this.gameObject);
        }
    }

    public string getName()
    {
        return name;
    }
}
