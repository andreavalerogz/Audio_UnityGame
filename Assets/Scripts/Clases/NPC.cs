using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public GameObject dialogGO;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI npcName;
    public NPCData npcData;

    public UnityEvent onPlayerColision;
    public UnityEvent onPlayerExitColision;

    int currentLine = 0;
    bool isPlayerInRange = false;
    bool isDialogOn = false;

    private void Start()
    {
        dialogGO.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogOn)
            {
                showDialogue();
            }
            else
            {
                nextLine();
            }
                
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            onPlayerExitColision.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player is in range to interact");
            isPlayerInRange = true;
            onPlayerColision.Invoke();
        }
    }

    public void showDialogue()
    {
        npcName.text = npcData.characterName;
        dialogGO.SetActive(true);
        isDialogOn = true;
        Time.timeScale = 0f;
        //dialogText.text = lines[currentLine];
        StartCoroutine(writeLine(npcData.lines[currentLine]));
        onPlayerExitColision.Invoke();
    }

    public void nextLine()
    {
        currentLine++;
        if (currentLine >= npcData.lines.Length)
        {
            currentLine = 0;
            dialogText.text = "";
            Time.timeScale = 1f;
            dialogGO.SetActive(false);
            isDialogOn = false;
            StopAllCoroutines();
            onPlayerExitColision.Invoke();
        }
        else
        {
            //dialogText.text = lines[currentLine];
            StopAllCoroutines();
            StartCoroutine(writeLine(npcData.lines[currentLine]));
        }
    }

    IEnumerator writeLine(string line)
    {
        dialogText.text = "";
        foreach (char letter in line)
        {
            dialogText.text += letter;
            yield return new WaitForSecondsRealtime(0.08f);
        }
        yield return new WaitForSecondsRealtime(1.3f);
        nextLine();
    }
}
