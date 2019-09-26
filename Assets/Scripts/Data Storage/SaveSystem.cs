﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save_data.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveOptions()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save_options.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveOptions saveOptions = new SaveOptions();

        formatter.Serialize(stream, saveOptions);
        stream.Close();
    }

    public static SaveData GetSave()
    {
        string path = Application.persistentDataPath + "/save_data.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static SaveOptions GetSaveOptions()
    {
        string path = Application.persistentDataPath + "/save_options.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveOptions data = formatter.Deserialize(stream) as SaveOptions;
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/save_data.save";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static void loadData(SaveData data)
    {
        HubProperties.vaultItems.Clear();
        foreach (string id in data.storedVaultItems)
        {
            HubProperties.vaultItems.Add(id);
        }
        HubProperties.storeGold = data.storedVaultGold;

        PlayerUpgrades.musketUpgrades.Clear();
        foreach (string id in data.musketUpgrades)
        {
            PlayerUpgrades.musketUpgrades.Add(id);
        }
        PlayerUpgrades.spreadshotUpgrades.Clear();
        foreach (string id in data.spreadShotUpgrades)
        {
            PlayerUpgrades.spreadshotUpgrades.Add(id);
        }
        PlayerUpgrades.fireworkUpgrades.Clear();
        foreach (string id in data.fireworkUpgrades)
        {
            PlayerUpgrades.fireworkUpgrades.Add(id);
        }
        PlayerUpgrades.dragonBreathUpgrades.Clear();
        foreach (string id in data.dragonsBreathUpgrades)
        {
            PlayerUpgrades.dragonBreathUpgrades.Add(id);
        }
        PlayerUpgrades.hullUpgrades.Clear();
        foreach (string id in data.hullUpgrades)
        {
            PlayerUpgrades.hullUpgrades.Add(id);
        }
        PlayerUpgrades.inventoryUpgrades.Clear();
        foreach (string id in data.inventoryUpgrades)
        {
            PlayerUpgrades.inventoryUpgrades.Add(id);
        }
        PlayerUpgrades.safeUpgrades.Clear();
        foreach (string id in data.safeUpgrades)
        {
            PlayerUpgrades.safeUpgrades.Add(id);
        }
        PlayerUpgrades.numberSkillPoints = data.numberSkillPoints;
        PlayerUpgrades.numberMaxSkillPoints = data.numberMaxSkillPoints;
        PlayerUpgrades.whichFrontWeaponEquipped = data.whichFrontWeaponEquipped;
        PlayerUpgrades.whichLeftWeaponEquipped = data.whichLeftWeaponEquipped;
        PlayerUpgrades.whichRightWeaponEquipped = data.whichRightWeaponEquipped;
        PlayerUpgrades.musketUnlocked = data.musketUnlocked;
        PlayerUpgrades.cannonUnlocked = data.cannonUnlocked;
        PlayerUpgrades.spreadShotUnlocked = data.spreadShotUnlocked;
        PlayerUpgrades.fireworkUnlocked = data.fireworkUnlocked;
        PlayerUpgrades.dragonsBreathUnlocked = data.dragonsBreathUnlocked;
        PlayerUpgrades.unlockLevel = data.unlockLevel;

        PlayerItems.inventoryItemsIDs.Clear();
        foreach (string id in data.inventoryItemIds)
        {
            PlayerItems.inventoryItemsIDs.Add(id);
        }

        for (int i = 0; i < 3; i++)
        {
            if (data.equippedArtifactIds[i] != null)
            {
                PlayerItems.activeArtifactsIDs[i] = data.equippedArtifactIds[i];
            }
            else
            {
                PlayerItems.activeArtifactsIDs[i] = null;
            }
        }
        PlayerItems.maxInventorySize = data.maxInventorySize;
        PlayerItems.totalGoldAmount = data.totalGoldAmount;

        MiscData.finishedTutorial = data.finishedTutorial;

        MiscData.currentQuestID = data.currentQuestID;
        MiscData.finishedQuest = data.finishedQuest;
        MiscData.availableQuests = data.availableQuests;
        MiscData.availableBossQuest = data.availableBossQuest;
        MiscData.numberQuestsCompleted = data.numberQuestsCompleted;
        MiscData.bossesDefeated.Clear();
        foreach (string id in data.completedBosses)
        {
            MiscData.bossesDefeated.Add(id);
        }

        SavedKeyBindings.moveUp = data.upBinding;
        SavedKeyBindings.moveLeft = data.leftBinding;
        SavedKeyBindings.moveRight = data.rightBinding;
        SavedKeyBindings.moveDown = data.downBinding;
        SavedKeyBindings.dash = data.dashBinding;
        SavedKeyBindings.firstArtifact = data.artActive1;
        SavedKeyBindings.secondArtifact = data.artActive2;
        SavedKeyBindings.thirdArtifact = data.artActive3;
        SavedKeyBindings.targetConesEnabled = data.targetConesEnabled;

        foreach (string id in data.completedTavernDialogues)
        {
            MiscData.completedTavernDialogues.Add(id);
        }

        foreach (string id in data.completedDungeonEntryDialogues)
        {
            MiscData.completedEntryDungeonDialogues.Add(id);
        }

        foreach (string id in data.completedExamineDialogues)
        {
            MiscData.completedExamineDialogues.Add(id);
        }

        foreach (string id in data.completedShopDialogues)
        {
            MiscData.completedShopDialogues.Add(id);
        }

        foreach (string id in data.completedStoryDialogues)
        {
            MiscData.completedStoryDialogues.Add(id);
        }

        foreach (string checkpoint in data.completedCheckPoints)
        {
            MiscData.completedCheckPoints.Add(checkpoint);
        }

        foreach (string building in data.unlockedBuildings)
        {
            MiscData.unlockedBuildings.Add(building);
        }

        foreach(string uniqueRoom in data.completedUniqueRoomDialogues)
        {
            MiscData.completedUniqueRoomsDialogues.Add(uniqueRoom);
        }

        MiscData.playerDied = data.playerDied;
        MiscData.numberDungeonRuns = data.numberDungeonRuns;

        MiscData.enoughRoomsTraversed = data.enoughRoomsTraversed;
        MiscData.dungeonLevelUnlocked = data.dungeonLevelUnlocked;

        MiscData.skillPointsNotification = data.skillPointsNotification;

        MiscData.questSymbolShown = data.questSymbolShown;

        MiscData.dungeonMapSymbolShown = data.dungeonMapSymbolShown;
    }

    public static void LoadOptions(SaveOptions saveOptions)
    {
        MiscData.masterVolume = saveOptions.masterVolume;
        MiscData.effectsVolume = saveOptions.effectsVolume;
        MiscData.musicVolume = saveOptions.musicVolume;
        MiscData.muted = saveOptions.muted;
    }
}