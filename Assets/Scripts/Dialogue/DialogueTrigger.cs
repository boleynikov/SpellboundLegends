using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;


    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    public void Update() 
    {
        if (playerInRange && !DialogueManager.Instance.dialogueIsPlaying) 
        {
            visualCue.SetActive(true);
            if (DialogueManager.Instance.GetInteractPressed()) 
            {
                // DialogueManager.Instance.EnterDialogue(inkJSON);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}