using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class Sword : MonoBehaviour
{
    public UnityEvent ExitTrigger;
    public UnityEvent EnterTrigger;
    private bool isPlayerInRange = false;

    [SerializeField] AudioClip swordPickUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        EnterTrigger.Invoke();
        isPlayerInRange = true;

    }

    private void Update()
    {
        if (GameManager.instance.actions.Player.Interact.WasPressedThisFrame() && isPlayerInRange)
        {
            PlayerSounds.instance.GetComponent<AudioSource>().PlayOneShot(swordPickUp, 0.3f);
            Debug.Log("picked up sword");
            GameManager.instance.actions.Player.Attack.Enable();
            Destroy(gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitTrigger.Invoke();
        isPlayerInRange = false;
    }
}
