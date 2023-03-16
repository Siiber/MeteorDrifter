using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palloscript : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Pallero";
        transform.position = new Vector3(0, 9, 2);
        print("Palleropöö");
    }

    // Update is called once per frame
    void Update()
    {
        // Pallo etenee tällä linjalla
        // transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
        transform.Translate(Vector3.back* speed* Time.deltaTime);
    }
}
