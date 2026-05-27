using UnityEngine;

public class UISounds : MonoBehaviour
{
     AudioSource AudioSource;
    [SerializeField] AudioClip click;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void playClick()
    {
        AudioSource.PlayOneShot(click);
    }
}
