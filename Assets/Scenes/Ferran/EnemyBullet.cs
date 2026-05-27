using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int damage;

    private void Update()
    {
        //Movimiento bala
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Creo que hay que fixear esto no se si toma el daño
        if (other.TryGetComponent(out Damageable playerLife))
        {
            Destroy(gameObject);
        }
    }
}
