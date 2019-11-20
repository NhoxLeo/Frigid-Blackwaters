﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerUpgrades {

    // Weapon Upgrades
    public static List<string> musketUpgrades = new List<string>();
    public static List<string> cannonUpgrades = new List<string>();
    public static List<string> spreadshotUpgrades = new List<string>();
    public static List<string> fireworkUpgrades = new List<string>();
    public static List<string> dragonBreathUpgrades = new List<string>();
    public static List<string> sniperUpgrades = new List<string>();

    public static List<string> hullUpgrades = new List<string>();
    public static List<string> inventoryUpgrades = new List<string>();
    public static List<string> safeUpgrades = new List<string>();
    public static int numberSkillPoints = 0;
    public static int numberMaxSkillPoints = 0;
    public static int numberBossSkillPoints = 0;

    // Each weapon is represented by a number - order they're placed in player scripts
    public static int whichFrontWeaponEquipped = 0;
    public static int whichLeftWeaponEquipped = 0;
    public static int whichRightWeaponEquipped = 0;
    
    public static bool musketUnlocked = true, cannonUnlocked = true, spreadShotUnlocked = true,
                       fireworkUnlocked = true, dragonsBreathUnlocked = true, sniperUnlocked = false;
    public static int unlockLevel = 5;
}
