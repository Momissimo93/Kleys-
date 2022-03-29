using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Commands
{
    protected Player player;
    protected Rigidbody rigidbody;
    protected Animator animator;

    public virtual void Move(Transform transfrom, Vector2 vector2) { }
    public virtual void Turn(Transform transform, float value) { }
    public virtual void Jumping(Transform transform) { }
}
