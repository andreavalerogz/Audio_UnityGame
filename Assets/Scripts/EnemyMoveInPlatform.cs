using UnityEngine;

public class EnemyMoveInPlatform : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed;
    public LayerMask maskDown;
    public LayerMask maskFront;

    public float distanceDown;
    public float distanceFront;

    public Transform controllerDown;
    public Transform controllerFront;

    public bool infoDown;
    public bool infoFront;

    private bool lookingRight = true;

    private void Update()
    {
        rb2D.linearVelocity = new Vector2 (speed, rb2D.linearVelocity.y);

        infoFront = Physics2D.Raycast(controllerFront.position, transform.right, distanceFront, maskFront);
        infoDown = Physics2D.Raycast(controllerDown.position, transform.up * -1, distanceDown, maskDown);

        if (infoFront || !infoDown)
        {
            Turn();
        }
        
    }

    private void Turn()
    {
        lookingRight = !lookingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0); //Para que cambie de direccion
        speed *= -1; //Para que se mueva en negativo
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controllerDown.transform.position, controllerDown.transform.position + transform.up * -1 * distanceDown);  //Empieza en la posicion del controller i termina en la posicion del controller mas la direccion hacia abajo
        Gizmos.DrawLine(controllerFront.transform.position, controllerFront.transform.position + transform.right * distanceFront);  //Empieza en la posicion del controller i termina en la posicion del controller mas la direccion hacia la derecha
    }
}
