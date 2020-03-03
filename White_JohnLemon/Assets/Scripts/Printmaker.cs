using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printmaker : MonoBehaviour
{
    public GameObject Footprint;
    public Transform Intruder;
    public float delay = 1f; //time between footprints
    public Quaternion Rotation;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakePrint", 0f, delay);
    }

    // Update is called once per frame
    void MakePrint()
    {
        Vector3 spawnLocation = new Vector3(Intruder.position.x, 0, Intruder.position.z);
        Instantiate(Footprint, spawnLocation, Rotation);
    }
}
