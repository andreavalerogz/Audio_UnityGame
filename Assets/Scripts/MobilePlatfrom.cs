


using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class MobilePlatfrom : MonoBehaviour
{
    [SerializeField] private Transform[] movementPoint;
    [SerializeField] private float speed;
    private int nextPlatform = 1;
    private bool order = true;


    private void Update()
    {
        if (order && nextPlatform + 1 >= movementPoint.Length)
        {
            order = false;
        }
        if (!order && nextPlatform <= 0)
        {
            order = true;
        }
        if (Vector2.Distance(transform.position, movementPoint[nextPlatform].position) < 0.1f)
        {
            if (order)
            {
                nextPlatform += 1;
            }
            else
            {
                nextPlatform -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, movementPoint[nextPlatform].position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    ////Hacerlo con otra cosa que el collision enter esta prohibido
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.gameObject.CompareTag("Player")) 
    //    {
    //        other.transform.SetParent(this.transform);
    //    }
    //}

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        other.transform.SetParent(null);
    //    }
    //}
}
