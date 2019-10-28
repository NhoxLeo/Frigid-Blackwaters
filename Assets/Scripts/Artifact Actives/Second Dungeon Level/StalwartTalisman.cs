﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalwartTalisman : ArtifactEffect
{
    DisplayItem displayItem;
    Artifacts artifacts;
    PlayerScript playerScript;
    float defensePeriod = 0;
    ArtifactBonus artifactBonus;

    void Start()
    {
        displayItem = GetComponent<DisplayItem>();
        artifacts = GameObject.Find("PlayerShip").GetComponent<Artifacts>();
        playerScript = GameObject.Find("PlayerShip").GetComponent<PlayerScript>();
        artifactBonus = GetComponent<ArtifactBonus>();
    }

    void Update()
    {
        if(defensePeriod > 0)
        {
            defensePeriod -= Time.deltaTime;
            if(artifactBonus.defenseBonus != 0.2f)
            {
                artifactBonus.defenseBonus = 0.2f;
                artifacts.UpdateUI();
            }
        }
        else
        {
            if(artifactBonus.defenseBonus != 0)
            {
                artifactBonus.defenseBonus = 0;
                artifacts.UpdateUI();
            }
        }
    }

    public override void addedKill(string tag)
    {
    }
    // Whenever the player takes damage
    public override void tookDamage(int amountDamage, Enemy enemy)
    {
        if (defensePeriod <= 0)
        {
            defensePeriod = 1;
        }
    }
    // Whenever the player fires the left weapon, and so on
    public override void firedLeftWeapon(GameObject[] bullet)
    {

    }
    public override void firedFrontWeapon(GameObject[] bullet)
    {

    }
    public override void firedRightWeapon(GameObject[] bullet)
    {

    }
    // Whenever the player enters a previously unentered room
    public override void exploredNewRoom(int whatRoomType) { }
    // Whenever the player picks up an item (updates the inventory)
    public override void updatedInventory()
    {
    }
    // whenever the player dashes
    public override void playerDashed()
    {
    }

    public override void dealtDamage(int damageDealt)
    {
    }
}
