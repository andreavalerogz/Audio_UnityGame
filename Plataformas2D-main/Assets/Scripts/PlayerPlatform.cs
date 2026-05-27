using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    private GroundDetector groundDetector;
    //Guarda la plataforma sobre la que esta el player
    private Transform currentPlatform;
    private Vector3 lastPlatformPos;

    void Awake()
    {
        groundDetector = GetComponent<GroundDetector>();
    }

    void FixedUpdate()
    {
        //Solo lo pegamos al suelo si si lo detecta
        if (groundDetector.isGrounded)
        {
            // Usamos CircleCast para obtener el collider debajo
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, groundDetector.radius, Vector2.down, groundDetector.distance, groundDetector.mask);

            //El CircleCast detecta algo
            if (hit.collider != null)
            {
                //Guardamos la referencia al transform de la plataforma
                Transform platform = hit.collider.transform;

                // Si es una nueva plataforma lo actualizamos y registramos la posición inicial
                if (currentPlatform != platform)
                {
                    currentPlatform = platform;
                    lastPlatformPos = platform.position;
                }

                // Calculamos cuanto se movio la plataforma desde la ultima vez que se actualizo
                Vector3 platformDelta = platform.position - lastPlatformPos;

                // Movemos al jugador junto con la plataforma
                transform.position += new Vector3(platformDelta.x, platformDelta.y, 0);

                // Actualizamos la última posición de la plataforma para la siguiente vez que se actualize
                lastPlatformPos = platform.position;
            }
            //No hay plataforma
            else
            {
                currentPlatform = null;
            }
        }
        //Resetea el seguimiento de la plataforma, ya que sino al saltar etc, cuando volviera a caer se transportaria a la ultima posicion en la que estaba en la plataforma
        else
        {
            currentPlatform = null;
        }
    }
}