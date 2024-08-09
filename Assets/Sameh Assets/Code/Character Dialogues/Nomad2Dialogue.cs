using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad2Dialogue : MonoBehaviour
{
    public MapDialogue dialogueManager;

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
                "Nomad 2: Hmmm...you look different.",
                "Layla: We're actually not from around here. We're lost, do you know where the pharaoh's temple is?",
                "Nomad 2: It's not so far from here. Take, here's a map to help you get there.",
            };
                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                Destroy(GetComponent<Nomad2Dialogue>());
            }
        }
    }
}
