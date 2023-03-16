using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpEx : MonoBehaviour
{
    public float moveTime = 0.2f;

    private float currentMoveTime = 0f;
    private bool isMoving = false;
    private Vector3 moveStart, moveEnd;

    public bool isAvailable = true;
    public float cooldownduration = 1f;

    private void Update()
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
                isMoving= true;
                currentMoveTime = 0;
                moveStart = transform.position;
                moveEnd = new Vector3(moveStart.x - 3,moveStart.y);
                StartCoroutine(StartCooldown());
            }
        }

        if (Input .GetKeyDown(KeyCode.D))
        {
            if (isAvailable == false)
            {
                return;
            }

            if (isMoving == false)
            {
                isMoving= true;
                currentMoveTime = 0;
                moveStart = transform.position;
                moveEnd = new Vector3(moveStart.x + 3, moveStart.y);
                StartCoroutine(StartCooldown());
            }
        }


        if(isMoving)
        {
            //ajastin deltatimell‰
            currentMoveTime += Time.deltaTime;

            //laskee ajastimen nollasta(currentMoveTime) asetettuun aikaan (moveTime)
            float perc = Mathf.Clamp01(currentMoveTime / moveTime);

            //liikuta sijaintia lerpill‰ 
            transform.position= Vector3.Lerp(moveStart, moveEnd, perc);

            //kun aika nollasta on t‰yttynyt asetettuun aikaan
            if (currentMoveTime >= moveTime)
            {
                //liikkuminen on p‰‰ttynyt
                isMoving= false;
                transform.position = moveEnd;
            }
        }
    }
    public IEnumerator StartCooldown()
    {
        isAvailable = false;
        print("Cooldown initiated");
        yield return new WaitForSeconds(cooldownduration);
        print("Cooldown ready");
        isAvailable = true;
    }
}
