﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class load : MonoBehaviour
{
    
    public void loadscene(int index) {
        SceneManager.LoadSceneAsync(index);
    }
}
