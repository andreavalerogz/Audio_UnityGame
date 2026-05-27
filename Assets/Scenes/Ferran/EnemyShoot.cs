using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform shootController; //Posicion del objeto para saber de donde sale y el punto donde hay una linea para disparar al player
    public float lineDistance; //El punto de la linea
    public LayerMask playerMask; //Para saber que objetos detecta para disparar
    public bool playerInRange;
    public GameObject enemyBullet;

    public float timeBetweenShoots;
    public float timeOfLastShoot;
    public float tiempoEsperaDisparo; //No se como ponerlo en ingles pa que se entienda bien jajaja


    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.Raycast(shootController.position, transform.right, lineDistance, playerMask);
        if (playerInRange)
        {
            //Si el tiempo actual del juego es mayor al tiempo entre disparo mas el ultimo disparo
            if (Time.time > timeBetweenShoots + timeOfLastShoot)
            {
                timeOfLastShoot = Time.time;
                //El invoke es para llamar a un metodo despues de un tiempo especifico
                Invoke(nameof(Shoot), tiempoEsperaDisparo); //El nameof es para que no sea una cadena, solo el metodo
            }
        }
    }

    private void Shoot()
    {
        Instantiate(enemyBullet, shootController.position, shootController.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(shootController.position, shootController.position + transform.right * lineDistance);
    }
}
