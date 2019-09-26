﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCheckpoint : MonoBehaviour
{
    public Vector3 playerShipPosition;
    public Vector3 cameraPosition;
    public string dialogueName;
    public DialogueUI dialogueUI;
    public GameObject dialogueBlackOverlay;
    bool portHub = false;
    public bool moveable = false;

    //how many rooms from the last room should the checkpoint be spawned (typically every 2 rooms equals 1 ish rooms closer to the spawn (by distance))
    public int numberFromLastRoom = 0;

    //checkpoint id is taken in by the dialogue id of the checkpoint dialogue.

    public void startUpDialogue()
    {
        dialogueUI.targetDialogue = FindObjectOfType<DungeonEntryDialogueManager>().loadDialogue(dialogueName, true);
        dialogueUI.waitReveal = 3;
        dialogueUI.gameObject.SetActive(true);
        dialogueBlackOverlay.SetActive(true);
    }

    public void Update()
    {
        if (moveable == false && Vector2.Distance(Camera.main.transform.position, cameraPosition) < 0.5f)
        {
            if (dialogueUI.gameObject.activeSelf == false && portHub == false)
            {
                portHub = true;
                FindObjectOfType<PauseMenu>().loadHub();
            }
            FindObjectOfType<PlayerScript>().shipRooted = true;
        }
    }
}