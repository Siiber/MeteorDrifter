using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidArea : MonoBehaviour
{
    public GameObject[] spawner;
    public GameManager gm;
    public GameObject coin;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        int rnd = Random.Range(0, 2);

        if (rnd == 1)
        {
            Instantiate(coin, new Vector3(
                transform.position.x,
                transform.position.y+6,
                transform.position.z),
                transform.rotation);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            for(int i=0; i<spawner.Length; i++)
            {
                spawner[i].SetActive(true);
            }

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gm.SpawnAsteroidField();
        }
        
    }

}
