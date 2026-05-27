using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject menuSettings;
    bool msActive = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(GameManager.instance.actions.UI.Settings.WasPressedThisFrame())
        {
            toggleShowSettings();
        }
    }
    public void toggleShowSettings()
    {
        msActive = !msActive;
        menuSettings.SetActive(msActive);
        if(msActive) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }
}

