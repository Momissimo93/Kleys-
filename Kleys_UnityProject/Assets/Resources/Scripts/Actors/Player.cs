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

    //A reference to the model used to represent the player
    Animator animator;
    GameObject actor;
    GameObject player;
    InputManager inputManager;
    JumpManager jumpManager;

    void Start()
    {
        player = GameObject.Find("Player");
        inputManager = gameObject.AddComponent<InputManager>();
        jumpManager = gameObject.AddComponent<JumpManager>();

        if (gameObject.GetComponent<Animator>() && inputManager != null)
        {
            animator = gameObject.GetComponent<Animator>();
            inputManager.SetAnimator(animator);
        }
        else
        {
            Debug.Log("You have forgot to attach an animator component to the prefab");
        }
    }
    void Update ()
    {
        if (jumpManager)
        {
            isOnGround = jumpManager.ISGrounded();
        }

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
    public bool IsOnGround ()
    {
        if (isOnGround)
            return true;
        else 
            return false;
    }
    public void Set_IsJumping(bool j)
    {
        if (j == true)
        {
            isJumping = true;
        }
        else
            isJumping = false;
    }
    public Animator GetAnimator ()
    {
        return animator;
    }
}
