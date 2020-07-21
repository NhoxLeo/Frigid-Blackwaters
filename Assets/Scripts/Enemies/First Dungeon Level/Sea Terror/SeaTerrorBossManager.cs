﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaTerrorBossManager : BossManager
{
    public GameObject doorSeal;
    public GameObject seaTerror;
    bool roomInit = false;


    void Update()
    {
        if (Vector2.Distance(transform.position, Camera.main.transform.position) < 0.2f && roomInit == false)
        {
            GameObject.Find("PlayerShip").GetComponent<PlayerScript>().enemiesDefeated = false;
            StartCoroutine(adjustPlayer());
            Instantiate(doorSeal, Camera.main.transform.position + new Vector3(Mathf.Cos((transform.parent.rotation.eulerAngles.z - 90) * Mathf.Deg2Rad), Mathf.Sin((transform.parent.rotation.eulerAngles.z - 90) * Mathf.Deg2Rad)) * 10.4f, Quaternion.Euler(0, 0, transform.parent.rotation.eulerAngles.z + 90));
            Instantiate(roomReveal, transform.position, Quaternion.identity);
            seaTerror.SetActive(true);
            roomInit = true;
        }

        if (seaTerror == null)
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
        PlayerProperties.playerScript.addRootingObject();
        yield return new WaitForSeconds(0.2f);
        PlayerProperties.playerScript.removeRootingObject();
    }
}
