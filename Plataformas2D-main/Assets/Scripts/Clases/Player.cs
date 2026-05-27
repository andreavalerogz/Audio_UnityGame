
using UnityEngine;

public class Player : Damageable
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        currentLifes = maxLifes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        animator.SetTrigger("isDead");
    }

    public override void takeDamage(int damage)
    {
        base.takeDamage(damage);
        if(currentLifes > 0) {
            animator.ResetTrigger("Hurt");
            animator.SetTrigger("Hurt"); 
        }
    }

    public void enableAttack()
    {
        GetComponentInChildren<BoxCollider2D>().enabled = true;
    }

    public void disableAttack()
    {
        GetComponentInChildren<BoxCollider2D>().enabled = false;
    }
}
