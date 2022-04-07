using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  The Player scripts is in contact with the following scripts: 
  AdditionalPlayerBehaviours: if the player has any extra information attached to it as well as abilities, the AdditionalPlayerBehaviour will cover this  
  PlayerSpawner: The Player script is created from the PlayerSpawner class 
  IActorTemplate: Contains damage control and the properties for Player
  GameManager: Extra informations sucg as the number of lives, the score, the level and whatever objects the player has collected will be stored in the GameManager class
  SOActorModel: Holds ScriptableObject properties for Player
*/

public class Player : MonoBehaviour, IActorTemplate
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] int health;
    [SerializeField] int jumpingForce;
    [SerializeField] bool isOnGround;
    [SerializeField] bool isJumping;
    [SerializeField] bool isFalling;
    [SerializeField] bool canGrabObject;
    [SerializeField] bool isGrabbing;
    [SerializeField] bool isImmume = false;
    //[SerializeField]Key[] bag = new Key[1]; //Da rivedere
    [SerializeField] int keyCounter;
    //A reference to the model used to represent the player
    Animator animator;
    GameObject actor;
    GameObject player;
    InputManager inputManager;
    JumpManager jumpManager;
    IKManager iKManager;
    KnockBack knockBack;
    Immunity immunity;

    void Start()
    {
        player = GameObject.Find("Player");
        inputManager = gameObject.AddComponent<InputManager>();
        jumpManager = gameObject.AddComponent<JumpManager>();
        iKManager = gameObject.AddComponent<IKManager>();
        immunity = gameObject.AddComponent<Immunity>();
        knockBack = gameObject.AddComponent<KnockBack>();

        if (gameObject.GetComponent<Animator>() && inputManager != null)
        {
            animator = gameObject.GetComponent<Animator>();
            inputManager.SetAnimator(animator);
            jumpManager.SetAnimator(animator);
            iKManager.Constructor(this, this.animator);
        }
        else
        {
            Debug.Log("You have forgot to attach an animator component to the prefab");
        }
    }
    void Update ()
    {
        //The JumpManager class manages everything that is related to the action of jumping 
        if (jumpManager)
            jumpManager.UpdateManger();
        //The InputManager class deals with incoming external inputs 
        if(inputManager)
            inputManager.UpdateAnimations();
    }
    //Variables updated from the player's SOActorModel script
    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        rotationSpeed = actorModel.rotationSpeed;
        health = actorModel.health;
        jumpingForce = actorModel.jumpingForce;
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Fire" && isImmume == false)
        {
            TakeDamage(1, other);
        }
    }
    public void TakeDamage(int incomingDamage, GameObject offender)
    {
        Set_IsImmune(true);
        health -= incomingDamage;

        if (health > 0)
        {
            knockBack.KnockingBack(this.gameObject, offender);
            immunity.SetImmunityTime(2, this.gameObject);
            GameManager.Instance.LifeLost();
        }
        else if (health == 0)
        {
            Debug.Log("Die");
            Die();
        }
    }
    public void Die()
    {
        GameManager.Instance.LifeLost();
        Destroy(this.gameObject);
    }
    public int SendDamage()
    {
        return 0;
    }
    /*public void StoreKey(Key k)
    {
        if (keyCounter == 0 && k.getName() == "B")
        {
        }
        else if (keyCounter == 0 && k.getName() == "A")
        {
            keyCounter++;
        }
        else if (keyCounter == 1 && k.getName() == "B")
        {
            keyCounter++;
        }
    }*/


    //----Setters and Getters 
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float RotationSpeed
    {
        get { return rotationSpeed; }
        set { rotationSpeed = value; }
    }
    public int JumpingForce
    {
        get { return jumpingForce; }
        set { jumpingForce = value; }
    }
    public void Set_IsOnGround(bool b)
    {
        if (b == true)
            isOnGround = true;
        else
            isOnGround = false;
    }
    public void Set_IsJumping(bool j)
    {
        if (j == true)
            isJumping = true;
        else
            isJumping = false;
    }
    public void Set_IsFalling(bool b)
    {
        if (b == true)
            isFalling = true;
        else
            isFalling = false;
    }
    public void Set_CanGrabObject(bool b)
    {
        if (b == true)
            canGrabObject = true;
        else
            canGrabObject = false;
    }
    public void Set_IsGrabbing(bool b)
    {
        if (b == true)
            isGrabbing = true;
        else
            isGrabbing = false;
    }
    public void Set_IsImmune(bool b)
    {
        if (b == true)
            isImmume = true;
        else
            isImmume = false;
    }

    public Animator GetAnimator ()
    {
        return animator;
    }
    public IKManager GetIkManager()
    {
        return iKManager;
    }
    public bool Get_IsOnGround()
    {
        if (isOnGround)
            return true;
        else
            return false;
    }
    public bool Get_IsJumping()
    {
        if (isJumping)
            return true;
        else
            return false;
    }
    public bool Get_IsFalling()
    {
        if (isFalling)
            return true;
        else
            return false;
    }
    public bool Get_CanGrabObject()
    {
        if (canGrabObject)
            return true;
        else
            return false;
    }
    public bool Get_IsImmune()
    {
        if (isImmume)
            return true;
        else
            return false;
    }
    public int Get_KeyNumber()
    {
        return keyCounter;
    }
    public bool Get_IsKnocking()
    {
        return knockBack.isKnockedBack;
    }

}
