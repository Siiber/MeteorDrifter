using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObstacleSpt : MonoBehaviour
{

    public float speed;
    public float timer;
    private float variab;
    public Transform target;
    public float timer2;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(12, 20);
        variab = Random.Range(0, 2);
        int dir = Random.Range(0, 2);

       
        
        if (dir == 0)
        {
            speed = -speed;
        }

        else
        {
            speed=speed;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        transform.position = transform.position + Vector3.right * speed * Time.deltaTime;

        /*
        if (variab == 0)
        {

            if (timer > 1)
            {

                speed = -speed;
                timer = 0f;

            }
        }

        if (variab == 1)
        {

            if (timer > 2)
            {

                speed = -speed;
                timer = 0f;

            }
        }
        */

        if (timer2 > 20)
        {
            Destroy(gameObject);
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="Asteroidspawn") 
        {
           speed = -speed;
        }

    }

}
