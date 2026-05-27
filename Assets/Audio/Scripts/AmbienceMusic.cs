using UnityEngine;

public class AmbienceMusic : MonoBehaviour
{
    public GameObject alternativeWorld;
    private AudioSource audioS;
    private AudioDistortionFilter distortionFilter;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        distortionFilter = GetComponent<AudioDistortionFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alternativeWorld.activeInHierarchy)
        {
            changePitchandDistrotion();
        }
        else
        {
            audioS.pitch = 0.8f;
            distortionFilter.enabled = false;
        }
    }

    void changePitchandDistrotion()
    {
        audioS.pitch = 0.3f;
        distortionFilter.enabled = true;
    }
}


