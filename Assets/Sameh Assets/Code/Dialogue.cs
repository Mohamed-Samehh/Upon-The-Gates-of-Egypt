using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialogueSentences;
    private int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject SkipButton;
    public GameObject dialogueBox;
    public Rigidbody2D player;
    public bool active;

    public Canvas canvas2;

    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
        SkipButton.SetActive(false);
        active = false;
    }

    void Update()
    {
        
    }

    public IEnumerator TypeDialogue()
    {
        canvas2.sortingOrder = 2;
        dialogueBox.SetActive(true);
        SkipButton.SetActive(true);
        active = true;
        player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        foreach(char letter in dialogueSentences[index].ToCharArray()){
            textDisplay.text += letter;

            yield return new WaitForSeconds(typingSpeed);

            if(textDisplay.text == dialogueSentences[index])
            {
                continueButton.SetActive(true);
            }
        }
    }

    public void SetSentences(string[] sentences)
    {
        this.dialogueSentences = sentences;
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < dialogueSentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            SkipButton.SetActive(false);
            active = false;
            this.dialogueSentences = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
            canvas2.sortingOrder = 1;
        }
    }

    public void Skip()
    {
        textDisplay.text = "";
        continueButton.SetActive(false);
        dialogueBox.SetActive(false);
        SkipButton.SetActive(false);
        active = false;
        this.dialogueSentences = null;
        index = 0;
        player.constraints = RigidbodyConstraints2D.None;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        canvas2.sortingOrder = 1;
    }
}
