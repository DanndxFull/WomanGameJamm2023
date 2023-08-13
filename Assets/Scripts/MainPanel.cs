using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainPanel : MonoBehaviour
{
[Header("Options")]
public Slider volumeFX;
public Slider volumeMaster;
public Toggle mute;
public AudioMixer mixer;
public AudioSource fxSource;
public AudioClip clickSound;
private float lastVolume;

[Header("Panels")]
public GameObject mainPanel;
public GameObject optionsPanel;

private void Awake(){
    volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
    volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
}
public void SetMute(){
    if(mute.isOn){
        mixer.GetFloat("volMaster", out lastVolume);
        mixer.SetFloat("volMaster", -80);
    }else{
        mixer.SetFloat("volMaster", lastVolume);
    }
}
public void OpenPanel(GameObject panel){
    mainPanel.SetActive(false);
    optionsPanel.SetActive(false);

    panel.SetActive(true);
    PlaySoundButton();
}

public void ChangeVolumeMaster(float v){
    mixer.SetFloat("VolMaster", v);
}

public void ChangeVolumeFX(float v){
    mixer.SetFloat("VolFX", v);
}
public void PlaySoundButton()
{
fxSource.PlayOneShot(clickSound);
}
public void ExitGame(){
    Application.Quit();
}
}
