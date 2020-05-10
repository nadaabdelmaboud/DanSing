//VacuumShaders 2014
// https://www.facebook.com/VacuumShaders

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LightColorss : MonoBehaviour 
{
    //////////////////////////////////////////////////////////////////////////////
    //                                                                          // 
    //Variables                                                                 //                
    //                                                                          //               
    //////////////////////////////////////////////////////////////////////////////

    //////////////////////////////////////////////////////////////////////////////
    //                                                                          // 
    //Unity Functions                                                           //                
    //                                                                          //               
    //////////////////////////////////////////////////////////////////////////////
	// Use this for initialization
	void Start () 
    {
       
	}
    int count = 0;
    // Update is called once per frame
    Color color=Color.red;
    private void swapcolor()
    {
        if (color == Color.red)
        {
            color = Color.green;
        }
        else if (color == Color.green) {
            color = Color.blue;
        }
        else if (color == Color.blue)
        {
            color = Color.red;
        }
        GetComponent<Light>().color = color;
    }
    void Update () 
    {
        count++;
        if (count % 30 == 0)
        {
            swapcolor();
            GetComponent<Renderer>().sharedMaterial.color = GetComponent<Light>().color;
        }
	}

    //////////////////////////////////////////////////////////////////////////////
    //                                                                          // 
    //Custom Functions                                                          //
    //                                                                          //               
    //////////////////////////////////////////////////////////////////////////////
}
