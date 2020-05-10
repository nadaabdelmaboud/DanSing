using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;

public class grabkar : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    Collider cld = null;
    public float power;
    public Collider[] colliders;
    void Start()
    {

    }
    void changecolor()
    {
        RaycastHit col;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out col, Mathf.Infinity, layerMask))
        {
            Color r = Color.black;
            col.collider.GetComponent<MeshRenderer>().material.color = r;
        }

    }
    void force()
    {
        RaycastHit col;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out col, Mathf.Infinity))
        {
            col.collider.GetComponent<Rigidbody>().AddForce(transform.forward * power);
        }

    }
    // Update is called once per frame
    void Update()
    {

        int ind;
        colliders = Physics.OverlapSphere(transform.position, .2f, layerMask);
        if (ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger))
        {
            global::micplaykar.mic = true;
            global::micplaykar.test = true;
            //if (colliders.Length > 0)
            //{

            //     cld=colliders[0];
            //    float dis = (this.transform.position - colliders[0].transform.position).magnitude;
            //    for (int i = 0; i < colliders.Length; i++)
            //    {
            //        if ((this.transform.position - colliders[i].transform.position).magnitude < dis)
            //        {
            //            cld = colliders[i];
            //            ind = i;
            //        }
            //    }

            //        cld.gameObject.transform.parent = this.transform;
            //    cld.gameObject.GetComponent<Rigidbody>().useGravity=false;
            //    cld.gameObject.GetComponent<Rigidbody>().isKinematic=true;
            //    global::micplay.test = true;
            //}

        }

        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Trigger))
        {
            //float f = ViveInput.GetAxis(HandRole.RightHand, ControllerAxis.Trigger, false);
            //uint deviceIndex = ViveRoleProperty.New(HandRole.RightHand).GetDeviceIndex();
            //Vector3 v = VRModule.GetDeviceState(deviceIndex, false).velocity;
            //Vector3 Av = VRModule.GetDeviceState(deviceIndex, false).angularVelocity;
            if (colliders.Length > 0)
            {

                //cld.gameObject.GetComponent<Rigidbody>().useGravity = true;
                //cld.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //cld.gameObject.GetComponent<Rigidbody>().velocity = v;
                //cld.gameObject.GetComponent<Rigidbody>().angularVelocity = Av;
                // cld.transform.parent = null;
            }
        }

    }

}
