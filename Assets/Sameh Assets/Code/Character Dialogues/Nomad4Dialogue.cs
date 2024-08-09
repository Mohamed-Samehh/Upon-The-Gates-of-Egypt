using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad4Dialogue : MonoBehaviour
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
                "Nomad 4: Before you go any further, I have to warn you.",
                "Nomad 4: If you continue to go forward, you might meet the other tribe that live here.",
                "Nomad 4: They look like us and dress like us, but they're savages. They will attack you."
            };
                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                Destroy(GetComponent<Nomad4Dialogue>());
            }
        }
    }
}
