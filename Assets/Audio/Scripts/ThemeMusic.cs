using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    public GameObject normalWorld;

    private AudioSource audioS;
    [SerializeField] private AudioClip normalWorldTheme;
    [SerializeField] private AudioClip alternativeWorldTheme;

    private bool wasNormalWorldActive;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        wasNormalWorldActive = normalWorld.activeInHierarchy;

        ChangeMusic();
    }

    void Update()
    {
        if (wasNormalWorldActive != normalWorld.activeInHierarchy)
        {
            wasNormalWorldActive = normalWorld.activeInHierarchy;
            ChangeMusic();
        }
    }

    void ChangeMusic()
    {
        audioS.Stop();

        if (normalWorld.activeInHierarchy)
        {
            audioS.clip = normalWorldTheme;
        }
        else
        {
            audioS.clip = alternativeWorldTheme;
        }

        audioS.Play();
    }
}