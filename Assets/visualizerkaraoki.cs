using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class visualizerkaraoki : MonoBehaviour
{

    public float minHeight = 15.0f;

    public float maxHeight = 425.0f;

    public float updateSentivity = 10.0f;
    public string micdevice;

    public Color visualizerColor = Color.blue;

    [Space(15)]

    public AudioClip audioClip;

    public bool loop = true;

    [Space(15), Range(64, 8192)]

    public int visualizerSimples = 64;

    VisualizerObject[] visualizerObjects;

  //  AudioSource audioSource=global::IBM.Watsson.Examples.ExampleStreaming.audioss;

    // Use this for initialization

    void Start()
    {



    }



    // Update is called once per frame

    void FixedUpdate()
    {

 

    }

}