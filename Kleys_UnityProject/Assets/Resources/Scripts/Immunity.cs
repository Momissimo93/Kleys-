using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immunity : MonoBehaviour
{
    Player actor;
    public void SetImmunityTime( int seconds, GameObject a)
    {
        if(a.gameObject.GetComponent<Player>())
        {
            actor = a.gameObject.GetComponent<Player>();
            StartCoroutine(ImmuneFor(seconds, actor));
        }
    }
    IEnumerator ImmuneFor (int seconds, Player a)
    {
        Debug.Log("Immune");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Not anymore immune");
        a.Set_IsImmune(false);
    }
}
