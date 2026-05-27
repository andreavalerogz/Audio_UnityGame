using UnityEngine;
using UnityEngine.Events;
public class Sword : MonoBehaviour
{
    public UnityEvent ExitTrigger;
    public UnityEvent EnterTrigger;
    private bool isPlayerInRange = false;
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
            Debug.Log("picked up sword");
            Destroy(gameObject);
            GameManager.instance.actions.Player.Attack.Enable();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitTrigger.Invoke();
        isPlayerInRange = false;
    }
}
