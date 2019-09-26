﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArtifactSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject imageIcon;
    public DisplayItem displayInfo;
    public Inventory inventory;
    public Artifacts artifacts;
    public GameObject toolTip;

    private void Start()
    {
        inventory = GameObject.Find("PlayerShip").GetComponent<Inventory>();
        artifacts = GameObject.Find("PlayerShip").GetComponent<Artifacts>();
        toolTip = inventory.toolTip;
    }

    public void addSlot(DisplayItem _displayInfo)
    {
        displayInfo = _displayInfo;
        imageIcon.SetActive(true);
        imageIcon.GetComponent<Image>().sprite = displayInfo.displayIcon;
    }

    public void deleteSlot()
    {
        displayInfo = null;
        imageIcon.SetActive(false);
        toolTip.SetActive(false);
    }

    public void removeArtifact()
    {
        if (displayInfo != null && inventory.itemList.Count < inventory.inventorySlots.Length && GameObject.Find("PlayerShip").GetComponent<PlayerScript>().enemiesDefeated == true)
        {
            if (inventory.itemList.Count < inventory.inventorySize)
            {
                displayInfo.isEquipped = false;
                artifacts.activeArtifacts.Remove(displayInfo.gameObject);
                inventory.itemList.Add(displayInfo.gameObject);
                inventory.UpdateUI();
                artifacts.UpdateUI();
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (displayInfo != null)
        {
            toolTip.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (displayInfo != null)
        {
            toolTip.SetActive(true);
            toolTip.transform.position = this.transform.position;
            toolTip.GetComponentInChildren<Text>().text = displayInfo.GetComponent<Text>().text;
        }
    }

}