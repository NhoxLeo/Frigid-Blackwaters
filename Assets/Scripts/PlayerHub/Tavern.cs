﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : MonoBehaviour
{
    GameObject playerShip, spawnedIndicator;
    public GameObject examineIndicator, dialogueUI, dialogueBlackOverlay;
    public GameObject tavernIcon;
    public DialogueSet tavernDialogue;

    private void Start()
    {
        playerShip = GameObject.Find("PlayerShip");
    }

    void LateUpdate()
    {
        if (Vector2.Distance(playerShip.transform.position, transform.position) < 5f && MiscData.unlockedBuildings.Contains("tavern") && MiscData.completedTavernDialogues.Count > 0)
        {
            if (dialogueUI.activeSelf == false)
            {
                if (spawnedIndicator == null)
                {
                    spawnedIndicator = Instantiate(examineIndicator, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                    spawnedIndicator.GetComponent<ExamineIndicator>().parentObject = this.gameObject;
                }
            }
            else
            {
                if (spawnedIndicator != null)
                {
                    Destroy(spawnedIndicator);
                }
            }

            if (playerShip.GetComponent<PlayerScript>().windowAlreadyOpen == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(turnOnTavernUI());
                }
            }
        }
        else
        {
            if (spawnedIndicator != null)
            {
                Destroy(spawnedIndicator);
            }
        }
    }

    public void turnOnDialogueUI()
    {
        StartCoroutine(turnOnTavernUI());
    }

    IEnumerator turnOnTavernUI()
    {
        dialogueBlackOverlay.SetActive(true);
        playerShip.GetComponent<PlayerScript>().windowAlreadyOpen = true;
        dialogueUI.GetComponent<DialogueUI>().targetDialogue = tavernDialogue;
        dialogueBlackOverlay.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        dialogueUI.SetActive(true);
        Destroy(spawnedIndicator);
        tavernIcon.SetActive(false);
        this.enabled = false;
    }
}