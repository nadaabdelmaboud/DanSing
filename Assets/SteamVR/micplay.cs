using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class micplay : MonoBehaviour
{
     public VideoPlayer video;
     public GameObject visualizer;
     public GameObject []rain;
    static public bool test = false;
    static public bool mic = false;
    int count = 0;
    
    private void Start()
    {
        
    }
     public void onpick() {
        Debug.Log("picked");
        visualizer.SetActive(true);
        video.Play();
    }

    private void Update()
    {
        if (video.time == 10) {
            for (int i = 0; i < rain.Length; i++) {
                rain[i].gameObject.SetActive(true);
            }
        }
        if (test == true) {
            Debug.Log("mic updated");
            count++;
            if (count == 1) { onpick(); }
            test = false;
        }
    }
}
