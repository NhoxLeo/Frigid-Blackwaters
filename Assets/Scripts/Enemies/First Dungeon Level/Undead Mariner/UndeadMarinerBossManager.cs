﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadMarinerBossManager : MonoBehaviour
{
    public GameObject doorSeal, roomReveal;
    public GameObject undeadMariner;
    QuestManager questManager;
    bool roomInit = false;

    void Start()
    {
        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
        if(questManager.currentQuest.GetComponent<QuestType>().questID == "defeat_the_undead_mariner")
        {
            Camera.main.transform.position = new Vector3(1200, 0, 0);
            GameObject.Find("PlayerShip").transform.position = new Vector3(1200, -3, 0);
        }
    }
    
    void Update()
    {
        if(Vector2.Distance(transform.position, Camera.main.transform.position) < 0.2f && roomInit == false)
        {
            GameObject.Find("PlayerShip").GetComponent<PlayerScript>().enemiesDefeated = false;
            StartCoroutine(adjustPlayer());
            Instantiate(doorSeal, Camera.main.transform.position + new Vector3(0, -10.4f, 0), Quaternion.Euler(0, 0, 90));
            Instantiate(roomReveal, transform.position, Quaternion.identity);
            undeadMariner.SetActive(true);
            roomInit = true;
        }

        if(undeadMariner == null)
        {
            GameObject.Find("PlayerShip").GetComponent<PlayerScript>().enemiesDefeated = true;
            SaveSystem.SaveGame();
        }
    }

    IEnumerator adjustPlayer()
    {
        GameObject playerShip = GameObject.Find("PlayerShip");
        //moves the player forward by a bit to adjust for ice walls spawning
        if (playerShip.transform.position.y > transform.position.y + 5)
        {
            playerShip.transform.position += new Vector3(0, -2f, 0);
        }
        else if (playerShip.transform.position.x > transform.position.x + 5)
        {
            playerShip.transform.position += new Vector3(-2f, 0, 0);
        }
        else if (playerShip.transform.position.x < transform.position.x - 5)
        {
            playerShip.transform.position += new Vector3(2f, 0, 0);
        }
        else
        {
            playerShip.transform.position += new Vector3(0, 2f, 0);
        }
        playerShip.GetComponent<PlayerScript>().shipRooted = true;
        yield return new WaitForSeconds(0.2f);
        playerShip.GetComponent<PlayerScript>().shipRooted = false;
    }
}