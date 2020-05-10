using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;
public class loadmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Grip))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
