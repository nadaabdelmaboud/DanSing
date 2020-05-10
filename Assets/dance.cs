using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dance : MonoBehaviour
{
    private Transform to;
    public GameObject charc;
    public void rota() {
        to = charc.transform;
        to.transform.RotateAround(new Vector3(0,1,0),90f);
        charc.transform.rotation = Quaternion.Lerp(charc.transform.rotation,to.rotation,Time.deltaTime*10f);
    }
}
