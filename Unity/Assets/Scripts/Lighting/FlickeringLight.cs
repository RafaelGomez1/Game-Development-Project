using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {


    Light testlight;
    public float minWaitTime, maxWaitTime;


	// Use this for initialization
	void Start () {

        testlight = GetComponent<Light>();
        StartCoroutine(Flashing());

	}
	
    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testlight.enabled = !testlight.enabled;
        }
    }


}
