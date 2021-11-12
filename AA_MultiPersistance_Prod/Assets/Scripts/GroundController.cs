using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public float speed;
    public GameObject XRot;
    public GameObject ZRot;

    public bool isPlaying = false;

    private void OnEnable()
    {
        PlayerController.GameStartChanged += ChangeBool;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!isPlaying)
            return;

        float x = Input.GetAxis("Horizontal") * -speed;
        float z = Input.GetAxis("Vertical") * -speed;

        if(XRot.transform.rotation.x + x > -10 && XRot.transform.rotation.x + x < 10)
        {
            XRot.transform.Rotate(new Vector3(x, 0, 0));
        }

        if(ZRot.transform.rotation.z + x > -10 && ZRot.transform.rotation.z + x < 10)
        {
            ZRot.transform.Rotate(new Vector3(0, 0, z));
        }

        //transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x, -10, 10), 0,
        //                         Mathf.Clamp(transform.rotation.z, -10, 10), transform.rotation.w);

    }


    void ChangeBool()
    {
        isPlaying = !isPlaying;
        Debug.Log("Is Playing = " + isPlaying);
    }
}
