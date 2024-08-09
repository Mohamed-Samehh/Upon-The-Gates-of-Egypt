using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Scene2Dialogue : MonoBehaviour
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
                "Layla: Looks like he was right, they do look like savages.",
                "Carter: Time to use the gun! Stay here and don't move."
            };
                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                Destroy(GetComponent<Lvl1Scene2Dialogue>());
            }
        }
    }
}
