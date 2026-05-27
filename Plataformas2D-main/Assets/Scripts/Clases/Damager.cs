using Unity.VisualScripting;
using UnityEngine;

// CLASE PARA TODOS LOS OBJETOS QUE PUEDAN RECIBIR DAÑO
[RequireComponent(typeof(BoxCollider2D))]
public class Damager : MonoBehaviour
{
    public int damage; // daño que hace

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable attackTarget = collision.gameObject.GetComponent<Damageable>();
        if (attackTarget != null) attackTarget.takeDamage(damage);
    }
}
