using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerSounds : MonoBehaviour
{
    public static PlayerSounds instance;
    public AudioSource AudioSource;
    [SerializeField] AudioClip swordClip1;
    [SerializeField] AudioClip swordClip2;

    [SerializeField] AudioClip footstep;

    [SerializeField] AudioClip hurt;
    [SerializeField] AudioClip lifeLost;

    private void Start()
    {
        instance = this;
        AudioSource = GetComponent<AudioSource>();
    }
    void playSwordSound()
    {
        int random = Random.Range(0, 2); // algun clip random de los 2
        AudioSource.pitch = Random.Range(0.7f, 0.9f); // pitch random
        if (random == 0)
        {
            AudioSource.PlayOneShot(swordClip1);
        }
        else
        {
            AudioSource.PlayOneShot(swordClip2);
        }
        
    }

    void playGrassFootstep()
    {
        AudioSource.pitch = Random.Range(0.85f, 1.1f);
        AudioSource.PlayOneShot(footstep, 0.6f);
    }

    public void playHurtSound()
    {
        AudioSource.PlayOneShot(hurt, 0.6f);
        AudioSource.PlayOneShot(lifeLost, 0.4f);
    }
}
