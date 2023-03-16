using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collisionexample : MonoBehaviour
{
    public float speed;
    public GameObject retryButton;
    public GameObject quitButton;
    public ParticleSystem explosion;
    public ParticleSystem explosion2;
    public ParticleSystem collect;
    public Animator cameraAnim;

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Wall")
        {
            print("sein‰‰n osu");
        }

         if(other.gameObject.tag == "Floor")
        {
            print("Lattiaan osu osu");
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Obstacle")
        {
            StartCoroutine(Hitstop());
            
        }

        if (other.gameObject.tag == "Collect")
        {
            Instantiate(collect, new Vector3(
                transform.position.x,
                transform.position.y+4,
                transform.position.z),
                transform.rotation);
        }

    }

    public IEnumerator Hitstop()
    {
        Instantiate(explosion2,transform.position, transform.rotation);
        GetComponent<Collider>().enabled = false;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 1f;

        Instantiate(explosion, transform.position, transform.rotation);

        GameObject.Find("Rocket").SetActive(false);
        GameObject.Find("JET").SetActive(false);

        cameraAnim.SetTrigger("Shake");

        

        yield return new WaitForSeconds(0.5f);
        retryButton.SetActive(true);
        quitButton.SetActive(true);
        Destroy(gameObject);
    }
}
