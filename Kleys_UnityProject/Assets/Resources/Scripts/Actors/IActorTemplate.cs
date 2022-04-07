using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A total of 4 classes will be using the IActorTemplate interface: Player, Enemy, PlayerSpawner, EnemySpawner 

public interface IActorTemplate 
{
    //Those method acts like contracts to the classes that will inherits the interface
    int SendDamage();
    void TakeDamage(int incomingDamage, GameObject offender);
    void Die();
    void ActorStats(SOActorModel actorModel);
}
