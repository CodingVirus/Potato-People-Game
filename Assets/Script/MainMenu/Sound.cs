using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Slider backVolume;
    public AudioSource audio;
    private float backVol = 1f;
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;
    }


    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        audio.volume = backVolume.value;
        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }

    // https://berkbach.com/unity2d-9-slider%EB%A5%BC-%EC%9D%B4%EC%9A%A9%ED%95%9C-%EB%B3%BC%EB%A5%A8%EC%A1%B0%EC%A0%88-c88ec75f752d 이거 보고 만들었지롱//
}
