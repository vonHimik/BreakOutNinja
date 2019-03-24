using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suriken : MonoBehaviour
{
    private float Z;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Z += 10f * Time.deltaTime;
        //transform.rotation = Quaternion.Euler(0f, 0f, Z);
    }
}
