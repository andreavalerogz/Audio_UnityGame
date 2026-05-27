using UnityEngine;

public class NPC_Sounds : MonoBehaviour
{
    private AudioSource AudioSource;
    [SerializeField] AudioClip hurt;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void playHurtSound()
    {
        AudioSource.PlayOneShot(hurt);
    }
}
