using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loaddance : MonoBehaviour
{
    // Start is called before the first frame update
    public void clips(int clip) {
       global::videoclip.clipindex = clip;
    }
    public void load(int index)
    {
       
        SceneManager.LoadSceneAsync(index);
    }

}
