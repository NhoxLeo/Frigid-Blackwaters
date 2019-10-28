﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBuckler : ArtifactEffect
{
    DisplayItem displayItem;
    Artifacts artifacts;
    PlayerScript playerScript;
    public GameObject energyShield;
    GameObject energyShieldInstant;

    void Start()
    {
        displayItem = GetComponent<DisplayItem>();
        artifacts = GameObject.Find("PlayerShip").GetComponent<Artifacts>();
        playerScript = GameObject.Find("PlayerShip").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (displayItem.isEquipped == false)
        {
            if(energyShieldInstant != null)
            {
                Destroy(energyShieldInstant);
            }
        }
        else
        {
            if(energyShieldInstant == null)
            {
                energyShieldInstant = Instantiate(energyShield, playerScript.transform.position + new Vector3(0, -1.3f, 0), Quaternion.identity);
            }
        }
    }

    public override void addedKill(string tag)
    {
    }
    // Whenever the player takes damage
    public override void tookDamage(int amountDamage, Enemy enemy)
    {
        if (energyShieldInstant.GetComponent<EnergyBucklerShield>().respawnPeriod <= 0)
            energyShieldInstant.GetComponent<EnergyBucklerShield>().respawnPeriod = 20;
    }
    // Whenever the player fires the left weapon, and so on
    public override void firedLeftWeapon(GameObject[] bullet) { }
    public override void firedFrontWeapon(GameObject[] bullet) { }
    public override void firedRightWeapon(GameObject[] bullet) { }
    // Whenever the player enters a previously unentered room
    public override void exploredNewRoom(int whatRoomType) { }
    // Whenever the player picks up an item (updates the inventory)
    public override void updatedInventory()
    {
    }
    // whenever the player dashes
    public override void playerDashed() { }

    public override void dealtDamage(int damageDealt)
    {
    }
}
