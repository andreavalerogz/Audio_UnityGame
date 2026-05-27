using UnityEngine;
using UnityEngine.Events;

public class WorldSwitcher : MonoBehaviour
{
    bool switchWorlds = false;

    public UnityEvent activateNormalWorld;
    public UnityEvent activateAlternativeWorld;
    void Update()
    {
        if (GameManager.instance.actions.Player.ChangeWorld.WasPressedThisFrame())
        {
            switchWorlds = !switchWorlds;
            if(!switchWorlds) activateNormalWorld.Invoke();
            else activateAlternativeWorld.Invoke();
        }
    }
}
