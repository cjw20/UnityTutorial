using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printmaker : MonoBehaviour
{
    public GameObject Footprint;
    public GameObject Intruder;
    public float delay = 1f; //time between footprints
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timer = delay;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Instantiate(Footprint, Intruder.transform);
            timer = delay;
        }
    }
}
