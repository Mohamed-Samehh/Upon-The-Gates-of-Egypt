using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2Dialogue : MonoBehaviour
{
    public Dialogue dialogueManager;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && FindObjectOfType<PlayerController>().grounded == true)
        {
            if (FindObjectOfType<PlayerController>().isFacingRight == false)
            {
                string[] dialogue =
                {
                "Layla: Good job, we're getting closer. The tomb shouldn't be far.",
                "Layla: There's a key hidden somewhere in this room. You have to find this key and use it to open the door.",
                "Layla: Try Focusing on the temple's vases, there's a pattern. Once you spot the different one, shoot it.",
                "Layla: Since you will also need bullets to shoot the vase, try to save as much bullets as you can."
            };
                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                Destroy(GetComponent<Lvl2Dialogue>());
            }
        }
    }
}
