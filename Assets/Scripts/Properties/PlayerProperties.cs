﻿
using UnityEngine;

public class PlayerProperties
{
    // This class serves as a public reference point to various things about the player to streamline
    // performance.

    public static Vector3 cursorPosition;
    public static PlayerScript playerScript;
    public static GameObject playerShip;
    public static Vector3 playerShipPosition;
    public static Artifacts playerArtifacts;
    public static Inventory playerInventory;
    public static SpriteRenderer spriteRenderer;
    public static float currentPlayerTravelDirection;
    public static Vector3 shipTravellingVector;

    public static PlayerArmorEffect armorIndicator;
    public static DurationUI durationUI;

    public static ShipWeaponScript leftWeapon;
    public static ShipWeaponScript rightWeapon;
    public static ShipWeaponScript frontWeapon;

    public static Vector3 mainCameraPosition;

}
