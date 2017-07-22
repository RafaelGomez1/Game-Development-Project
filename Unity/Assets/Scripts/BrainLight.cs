using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BrainLight : MonoBehaviour {

    public float time;
    public Light Light;


    public float intensity;

    private void Start()
    {
        intensity = Light.intensity;
    }

    

	// Update is called once per frame
	void Update () {

        ChangeTime();

	}

    public void ChangeTime()
    {
        time += Time.deltaTime;
        
        if (time < 3)
        {
            Light.intensity += 0.1f;
            Light.range += 0.01f;
           
        }
        else if (time > 3 && time < 6)
        {
            Light.intensity -= 0.1f;
            Light.range -= 0.01f;

        }
        else
        {
            Light.intensity = intensity;
            time = 0.0f;
        }

    }
}
