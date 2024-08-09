using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad1Dialogue : MonoBehaviour
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
                "Nomad 1: Hey, where do you think you're going? You're not supposed to be here!",
                "Layla: We just need help getting to the pharaoh's temple.",
                "Nomad 1: I don't think going to the temple is a good idea. Sorry, but I can't help you. It's for your own good."
            };
                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                Destroy(GetComponent<Nomad1Dialogue>());
            }
        }
    }
}
