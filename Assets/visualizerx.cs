using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class visualizerx : MonoBehaviour
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

    AudioSource audioSource;
    int count = 0;
    // Use this for initialization
    public GameObject cubemusic;
    void Start()
    {



        if (!audioClip)
            return;

        audioSource = new GameObject("_AudioSource").AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
        instcircle();
        visualizerObjects = GetComponentsInChildren<VisualizerObject>();
    }

    void instcircle()
    {
        var numberofobjects = 60;
        var radius = 5;
        for (var i = 0; i < numberofobjects; i++)
        {
            var angle = i * Mathf.PI * 2 / numberofobjects;
            var pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            GameObject obj = Instantiate(cubemusic, pos, Quaternion.identity);
            obj.transform.parent = cubemusic.transform.parent;
        }
        cubemusic.gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        count++;
        float[] spectrumData = audioSource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Rectangular);

        for (int i = 0; i < visualizerObjects.Length; i++)
        {

            Vector3 newSize = visualizerObjects[i].GetComponent<Transform>().localScale;

            newSize.x = Mathf.Clamp(Mathf.Lerp(newSize.x, minHeight + (spectrumData[i] * (maxHeight - minHeight) * 5.0f), updateSentivity * 0.5f), minHeight, maxHeight);

            visualizerObjects[i].GetComponent<Transform>().localScale = newSize;



            //   visualizerObjects[i].GetComponent<MeshRenderer>().material.color = visualizerColor;

        }

    }

}