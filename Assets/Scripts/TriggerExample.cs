using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TriggerExample : MonoBehaviour
{

    public GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collect")
        {

            Destroy(other.gameObject);
            gm.AddScore();

        }
    }

}
