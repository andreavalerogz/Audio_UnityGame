using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 checkpoint = new Vector3 (0, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpoint = transform.position;
    }
    
    public void respawnCharacter()
    {
        Animator animator = GetComponent<Animator>();
        transform.position = checkpoint;
        Damageable damageable = GetComponent<Damageable>();
        damageable.resetLifes();
        animator.ResetTrigger("isDead");
        animator.Play("Ch_Front_Idle");

        GameManager.instance.setCurrentLifesActiveTrue(damageable.getCurrentLifes());
    }
}
