﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundOptions : MonoBehaviour
{
    public AudioMixer generalMixer;
    public Image buttonImage;
    public Sprite muted, unmuted;
    public Slider generalSlider, effectsSlider, musicSlider;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Title Screen")
        {
            SaveOptions loadedOptions = SaveSystem.GetSaveOptions();
            if (loadedOptions != null)
            {
                SaveSystem.LoadOptions(loadedOptions);
            }
        }

        setGeneralVolume(MiscData.masterVolume);
        generalSlider.value = MiscData.masterVolume;
        setEffectsVolume(MiscData.effectsVolume);
        effectsSlider.value = MiscData.effectsVolume;
        setMusicVolume(MiscData.musicVolume);
        musicSlider.value = MiscData.musicVolume;
        if(MiscData.muted == true)
        {
            FindObjectOfType<AudioListener>().enabled = false;
            buttonImage.sprite = muted;
        }
        else
        {
            FindObjectOfType<AudioListener>().enabled = true;
            buttonImage.sprite = unmuted;
        }
        this.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && this.gameObject.activeSelf == true)
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
            if (GameObject.Find("PlayerShip"))
            {
                GameObject.Find("PlayerShip").GetComponent<PlayerScript>().windowAlreadyOpen = false;
            }
        }
    }

    public void setGeneralVolume(float volume)
    {
        generalMixer.SetFloat("masterVolume", volume);
        MiscData.masterVolume = volume;
    }

    public void setEffectsVolume(float volume)
    {
        generalMixer.SetFloat("effectsVolume", volume);
        MiscData.effectsVolume = volume;
    }

    public void setMusicVolume(float volume)
    {
        generalMixer.SetFloat("musicVolume", volume);
        MiscData.musicVolume = volume;
    }

    public void muteButton()
    {
        if (FindObjectOfType<AudioListener>().enabled == true)
        {
            FindObjectOfType<AudioListener>().enabled = false;
            MiscData.muted = true;
            buttonImage.sprite = muted;
        }
        else
        {
            FindObjectOfType<AudioListener>().enabled = true;
            MiscData.muted = false;
            buttonImage.sprite = unmuted;
        }
    }

    private void OnDisable()
    {
        SaveSystem.SaveOptions();
    }
}