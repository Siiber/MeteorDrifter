using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEx : MonoBehaviour
{

    public GameObject obstacle;
    public GameObject obstacle2;
    public float randomizer;
    public float startime;
    public float spawnfreq;
    public float minspawn;
    public float maxspawn;

    // Start is called before the first frame update
    void Start()
    {
        randomizer = Random.Range(0, 2);

        if (randomizer == 0)
        {
            Instantiate(obstacle, transform.position, transform.rotation);
        }

        if (randomizer == 1)
        {
            Instantiate(obstacle2, transform.position, transform.rotation);
        }

        //Invoke("Spawn", startime);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Spawn()
    {
        //Nämä spawnaa tietyn random tiheyden minspawn - maxspawn väliltä
        Invoke("Spawn", spawnfreq);
        Instantiate(obstacle, transform.position, transform.rotation);
        spawnfreq = Random.Range(minspawn, maxspawn);
    }

}
