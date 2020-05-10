//VacuumShaders 2014
// https://www.facebook.com/VacuumShaders

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LightColors : MonoBehaviour 
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
    Color color;
	void Start () 
    {
        if (this.gameObject.tag.Equals("zero")) { color = Color.red; }
        else if (this.gameObject.tag.Equals("one")) { color = Color.green; }
        else if (this.gameObject.tag.Equals("two")) { color = Color.blue; }
        else if (this.gameObject.tag.Equals("three")) { color = Color.yellow; }
        else { color = Color.red; }
	}
    int count = 0;
    // Update is called once per frame
    
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
            color = Color.yellow;
        }
        else if (color == Color.yellow)
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
