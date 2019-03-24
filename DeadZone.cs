using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ball")
        {
            GM.instance.LoseLife();
        }
    }
}
