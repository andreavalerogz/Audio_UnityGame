using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isGrounded;
    public float distance;
    public float radius;
    public LayerMask mask;
    // Update is called once per frame

    private void OnDrawGizmosSelected()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position + Vector3.down * distance, radius);
    }

    void Update()
    {
        //Visualizar raycast
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        //Raycast
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.down, distance, mask);

        if (hit.collider == null)
        {
            //No ha chocado
            isGrounded = false;
        }
        else
        {
            //Si ha chocado
            //Cambia el rayo a color verde
            isGrounded = true;
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.green);
        }
    }
}
