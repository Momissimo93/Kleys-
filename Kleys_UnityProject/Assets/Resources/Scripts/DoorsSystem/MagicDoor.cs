using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDoor : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
        dust.Stop();
        if (gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");
        StartCoroutine(PlayParticleSystem(2.5f));
    }
    IEnumerator PlayParticleSystem(float sec)
    {
        dust.Play();
        yield return new WaitForSeconds(sec);
        dust.Stop();
    }
}
