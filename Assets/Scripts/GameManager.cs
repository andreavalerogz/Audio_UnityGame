using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public InputSystem_Actions actions;

    public GameObject Player;
    public List<GameObject> lifesList = new List<GameObject>(); // PONER PLAYER LIFES (class player que herede)
    [SerializeField] AudioClip interactSound;
    // HACER AUTOMATICO 

    private void Awake()
    {
        instance = this;
        actions = new InputSystem_Actions();
        actions.Enable();
        actions.Player.Attack.Disable();
    }

    private void Update()
    {
        if(actions.Player.Interact.WasPressedThisFrame())
        {
            Player.GetComponent<AudioSource>().PlayOneShot(interactSound, 0.8f);
        }
    }
    public void updateLifes()
    {
        int currentLifes = Player.GetComponent<Damageable>().getCurrentLifes();

        setLifesActiveFalse();
        setCurrentLifesActiveTrue(currentLifes);
    }
    void setLifesActiveFalse()
    {
        for (int i = 0; i < lifesList.Count; i++)
        {
            lifesList[i].SetActive(false);
        }
    }

    public void setCurrentLifesActiveTrue(int currentLifes)
    {
        for (int i = 0; i < currentLifes; i++)
        {
            lifesList[i].SetActive(true);
        }
    }
}
