using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Collectible : MonoBehaviour
{

    public float xAngle, yAngle, zAngle;

    void Update()
    {

        gameObject.transform.Rotate(zAngle, yAngle, xAngle);

    }


}

