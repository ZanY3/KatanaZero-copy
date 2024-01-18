using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public string[] lines; //array with text lines
    public float speedText;
    public TMP_Text dialogueText;

    private int index; //to count slides
    public bool isOnAllLvlDialog;
    public string nextScene;
    public GameObject fadeOut;
    public AudioSource source;
    public AudioClip BobWhoahSound;
    public bool isBoss;
    public GameObject Boss;

    private void Start()
    {
        dialogueText.text = string.Empty; 
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray()) //to char array - from string to array simbols
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText); // returns text
            source.Play();
        }
    }

    public void scipText() 
    {
        if (dialogueText.text == lines[index])
        {
            NextLine();
            source.Stop();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }

    private void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            source.Stop();
            gameObject.SetActive(false);
            if(isOnAllLvlDialog)
            {
                if(isBoss)
                {
                    Boss.gameObject.SetActive(false);
                    source.PlayOneShot(BobWhoahSound);
                }
                fadeOut.SetActive(true);
                Invoke("LoadScene", 1f);
            }
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
