using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad3Dialogue : MonoBehaviour
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
        if(other.tag == "Player" && FindObjectOfType<LVL1Scene1PlayerCont>().grounded == true)
        {
            if (FindObjectOfType<LVL1Scene1PlayerCont>().isFacingRight == true)
            {
                string[] dialogue =
            {
                "Nomad 3: I heard you ask about the temple.",
                "Layla: We're on our way. We have to get to the tomb.",
                "Nomad 3: The tomb? Do you know how dangerous and guarded the tomb is.",
                "Layla: I know, I heard many stories about this temple. We know how dangerous our journey is, but we have to."
            };
                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                Destroy(GetComponent<Nomad3Dialogue>());
            }
        }
    }
}
