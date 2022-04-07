using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public int pushForce = 5;
    public bool isKnockedBack;
    float knockBackLenght = 0.5f;
    float knockBackCounter;
    Vector2 knockBackPower;
    Player player;
    float initialSpeed;
    float initialRotationSpeed;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KnockingBack(GameObject receiver, GameObject offender )
    {
        if (receiver.GetComponent<Player>())
        {
            player = receiver.GetComponent<Player>();
            isKnockedBack = true;
            knockBackCounter = knockBackLenght;
            Vector3 pushDirection = -player.transform.forward;
            player.GetComponent<Rigidbody>().AddForce(pushDirection.normalized *  pushForce,ForceMode.Impulse);
            StartCoroutine (KnockingDuration(knockBackCounter));
        }
    }

    IEnumerator KnockingDuration (float s)
    {
        yield return new WaitForSeconds(s);
        isKnockedBack = false;
        Debug.Log("KnockBack");
    }
}
