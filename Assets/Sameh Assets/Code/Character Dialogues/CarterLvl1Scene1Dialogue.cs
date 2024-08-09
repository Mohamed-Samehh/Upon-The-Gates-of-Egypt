using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarterLvl1Scene1Dialogue : MonoBehaviour
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
            if (FindObjectOfType<LVL1Scene1PlayerCont>().isFacingRight == false)
            {
                string[] dialogue =
            {
                "Carter: Where...where are we?!",
                "Layla: Looks like we traveled through time!",
                "Carter: We need to find the tomb quickly. It's the only thing that has the power to get us back.",
                "Layla: But where to start? We don't even know where we are.",
                "Carter: Look, there are people standing behind us.",
                "Layla: Wait, I think I might be able to understand their language. I have to try and talk to them. We need directions for the temple.",
                "Carter: Just take care, they might be up to harm."
            };
                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                Destroy(GetComponent<CarterLvl1Scene1Dialogue>());
            }
        }
    }
}
