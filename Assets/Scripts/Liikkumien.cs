using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Liikkumien : MonoBehaviour
{
    public float speed = 3;
    public float originalSpeed;
    public float boostSpeed = 13f;
    public float dashDistance = 5f;
    public Animator shake;
    public ParticleSystem leftTrail;
    public ParticleSystem rightTrail;

    public bool isAvailable = true;
    public float cooldownduration = 2f;

    public GameObject cooldownKnob;

    //lerp movement floatit ja h‰rp‰kkeet
    public float moveTime = 0.2f;

    private float currentMoveTime = 0f;
    private bool isMoving = false;
    private Vector3 moveStart, moveEnd;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
 
    }

    public IEnumerator StartCooldown()
    {
        isAvailable= false;
        cooldownKnob.SetActive(false);
        yield return new WaitForSeconds(cooldownduration);
        cooldownKnob.SetActive(true);
        isAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isAvailable == false)
            {
                return;
            }

            if (isMoving == false)
            {
                //liike alkaa
                isMoving = true;
                currentMoveTime = 0;
                moveStart = transform.position;
                moveEnd = new Vector3(moveStart.x - 3, moveStart.y + 2, moveStart.z);
                Instantiate(rightTrail, transform.position, transform.rotation);
                StartCoroutine(StartCooldown());
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isAvailable == false)
            {
                return;
            }

            if (isMoving == false)
            {
                isMoving = true;
                currentMoveTime = 0;
                moveStart = transform.position;
                moveEnd = new Vector3(moveStart.x + 3, moveStart.y +2, moveStart.z);
                Instantiate(leftTrail, transform.position, transform.rotation);
                StartCoroutine(StartCooldown());
            }
        }

        if (isMoving)
        {
            //ajastin deltatimell‰
            currentMoveTime += Time.deltaTime;

            //laskee ajastimen nollasta(currentMoveTime) asetettuun aikaan (moveTime)
            float perc = Mathf.Clamp01(currentMoveTime / moveTime);

            //liikuta sijaintia lerpill‰ 
            transform.position = Vector3.Lerp(moveStart, moveEnd, perc);

            //kun aika nollasta on t‰yttynyt asetettuun aikaan
            if (currentMoveTime >= moveTime)
            {
                //liikkuminen on p‰‰ttynyt
                isMoving = false;
                transform.position = moveEnd;
            }
        }


        if (Input.GetButton("Jump"))
        {
            
            speed = boostSpeed;

        }

        else
        {
            speed = originalSpeed;
        }
        
        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;



    }


    private void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.tag == "Obstacle")
        {

            

        }

    }

}
