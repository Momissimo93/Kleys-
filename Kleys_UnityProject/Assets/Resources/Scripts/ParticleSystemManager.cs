using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    [SerializeField] float waitFor;
    ParticleSystem fire;
    [SerializeField] ParticleSystem fire_Compoent;
    [SerializeField] bool fireIsPlaying = true;
    float seconds;
    public List<ParticleCollisionEvent> collisionEvents;
    //List<ParticleSystem> lists = new List<ParticleSystem>();
    // Start is called before the first frame update
    void Start()
    {
        Transform[] ts = this.GetComponentsInChildren<Transform>();
        for (int i = 0;i < ts.Length; i ++)
        {
            if(ts[i].name == "Fire_Component")
            {
                if(ts[i].gameObject.GetComponent<ParticleSystem>())
                fire_Compoent = ts[i].gameObject.GetComponent<ParticleSystem>();
                collisionEvents = new List<ParticleCollisionEvent>();
            }
        }
        if (gameObject.GetComponent<ParticleSystem>())
        {
            fire = gameObject.GetComponent<ParticleSystem>();
        }
        else
        {
            Debug.Log("Error");
        }
    }

    // Update is called once per frame
    void Update()
    {
        seconds = seconds + (Time.deltaTime);
        if(seconds >= waitFor)
        {
            if(fireIsPlaying == true)
            {
                fireIsPlaying = false;
                fire.Stop();
                seconds = 0;
            }
            else
            {
                fireIsPlaying = true;
                fire.Play();
                seconds = 0;

            }
        }
        if(fireIsPlaying)
        {
            //CheckPlayer();
            
        }
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = fire_Compoent.GetCollisionEvents(other, collisionEvents);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Debug.Log(rb.name);
        Debug.Log("Collision");
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }
    }
    private IEnumerator PlayRoutine()
    {
        yield return new WaitForSeconds(3);
        fire.Stop();
    }
}
