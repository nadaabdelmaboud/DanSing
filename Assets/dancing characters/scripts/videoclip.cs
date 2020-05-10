using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;
public class videoclip : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoClip[] clips = new VideoClip[3];
    public VideoPlayer videoplayer;
    public static int clipindex;
    public AudioSource audio;
    void Start()
    {
        videoplayer.clip = clips[clipindex];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger)) {
            audio.Stop();
            videoplayer.Play();
        }
    }
}
