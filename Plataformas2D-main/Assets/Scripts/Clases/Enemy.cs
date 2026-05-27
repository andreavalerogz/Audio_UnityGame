using UnityEngine;

public class Enemy : Damageable
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Die()
    {
        animator.SetTrigger("isDead");
    }

}
