using UnityEngine;

// CLASE PARA TODOS LOS OBJETOS QUE PUEDAN RECIBIR DAÑO

public class Damageable : MonoBehaviour
{
    public int maxLifes; // maxima vida
    protected int currentLifes; // vida que tiene ahora

    // para que al principio la vida se ponga automaticamente
    private void Awake()
    {
        resetLifes();
    }
    // metodo publico para recibir daño
    public virtual void takeDamage(int damage)
    {
        currentLifes -= damage;
        GameManager.instance.updateLifes();
        if (currentLifes <= 0)
        {
            Die();
        }
    }
    // metodo publico para mirar vidas del jugador
    public int getCurrentLifes() { return currentLifes; }

    public virtual void Die()
    {
        Debug.Log("Something died.");
    }

    public void resetLifes()
    {
        currentLifes = maxLifes;
    }

    public virtual void destroy()
    {
        Destroy(gameObject);
    }

}

