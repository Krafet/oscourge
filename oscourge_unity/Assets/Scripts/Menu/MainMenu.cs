﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Net;
using Scripts.Networking;
using System;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

    public TMP_InputField ipInput;
    public TMP_InputField portInput;
    public GameObject ErrorBox;
    public TextMeshProUGUI ErrorTxt;
    public GameObject SFX;
    public GameObject waitingPanel;
    public GameObject onlinePanel;


    public AudioMixer mixer;

    public void PlayGame(bool modeOnline) {
        if (modeOnline) {
            try {

                if (string.IsNullOrEmpty(ipInput.text) || string.IsNullOrEmpty(portInput.text)) { EmptyInputFieldError(); }
                else {
                    changePanel();

                    string ip = ipInput.text;
                    IPAddress adresse = IPAddress.Parse(ip);
                    int port = int.Parse(portInput.text);

                    Debug.Log("ip : " + ip + " / port : " + port);
                    ClientUDP.Instance.ConnectToServer(ip, port);
                    //ClientUDP.Instance.ConnectToServer("127.0.0.1", 1331);
                    //Debug.LogError("RESET THESES LIGNES !");
                }
            }
            catch (FormatException e) {
                Debug.LogError(e);
                ErrorTxt.SetText("This is not a correct IP adress");
                ErrorBox.SetActive(true);
            }
        }
        else {
            // Starting the game in local (offline mode)
            Debug.Log("Loading Scene ...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void resetColorIpInput() {
        ipInput.image.color = Color.white;
    }
    public void resetColorPortInput() {
        portInput.image.color = Color.white;
    }

    public void resetInputs() {
        resetColorIpInput();
        resetColorPortInput();
        ipInput.text = "";
        portInput.text = "";
    }

    private void EmptyInputFieldError() {
        if (string.IsNullOrEmpty(ipInput.text))
        ipInput.image.color = Color.red;
        if (string.IsNullOrEmpty(portInput.text))
        portInput.image.color = Color.red;
    }

    private void changePanel() {
        waitingPanel.SetActive(true);
        onlinePanel.SetActive(false);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start() {
        float   sliderValue = PlayerPrefs.GetFloat("Master", 0.75f);
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        sliderValue = PlayerPrefs.GetFloat("Music", 0.75f);
        mixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
        sliderValue = PlayerPrefs.GetFloat("SFX", 0.75f);
        mixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);

        SFX.gameObject.GetComponent<SFX>().MenuMusic();

    }

    // Update is called once per frame
    void Update() {

    }
}
