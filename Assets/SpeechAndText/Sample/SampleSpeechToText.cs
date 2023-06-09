﻿using UnityEngine;
using UnityEngine.UI;
using TextSpeech;
using System.Collections;

public class SampleSpeechToText : MonoBehaviour
{
    public GameObject loading;
    public InputField inputLocale;
    public InputField inputText;
    public float pitch;
    public float rate;
    int w = 0;

    public Text txtLocale;
    public Text txtPitch;
    public Text txtRate;
    void Start()
    {
        Setting("en-US");
        loading.SetActive(false);
        SpeechToText.instance.onResultCallback = OnResultSpeech;

    }
    

    public void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechToText.instance.StartRecording("Speak any");
#endif
    }

    public void StopRecording()
    {

        StartCoroutine(Waiting());
#if UNITY_EDITOR
        OnResultSpeech("Not support in editor.");
#else
        SpeechToText.instance.StopRecording();
#endif
#if UNITY_IOS
        loading.SetActive(true);
#endif
        //StartCoroutine(ExampleCoroutine());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10);
        w = 100;
        OnClickSpeak();
    }

    void OnResultSpeech(string _data)
    {
        inputText.text = _data;
#if UNITY_IOS
        loading.SetActive(false);
#endif
    }
    public void OnClickSpeak()
    {
        TextToSpeech.instance.StartSpeak(inputText.text);
    }
    public void  OnClickStopSpeak()
    {
        TextToSpeech.instance.StopSpeak();
    }
    public void Setting(string code)
    {
        TextToSpeech.instance.Setting(code, pitch, rate);
        SpeechToText.instance.Setting(code);
        txtLocale.text = "Locale: " + code;
        txtPitch.text = "Pitch: " + pitch;
        txtRate.text = "Rate: " + rate;
    }
    public void OnClickApply()
    {
        Setting(inputLocale.text);
    }
}
