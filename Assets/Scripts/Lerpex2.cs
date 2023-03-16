using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerpex2 : MonoBehaviour
{
    public float dashTime = 0.1f;

    private float _currentDashTime = 0f;
    private bool _isDashing = false;
    private Vector3 _dashStart, _dashEnd;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isDashing == false)
            {
                // dash starts
                _isDashing = true;
                _currentDashTime = 0;
                _dashStart = transform.position;
                _dashEnd = new Vector3(_dashStart.x + 4, _dashStart.y);
            }
        }

        if (_isDashing)
        {
            // incrementing time
            _currentDashTime += Time.deltaTime;

            // a value between 0 and 1
            float perc = Mathf.Clamp01(_currentDashTime / dashTime);

            // updating position
            transform.position = Vector3.Lerp(_dashStart, _dashEnd, perc);

            if (_currentDashTime >= dashTime)
            {
                // dash finished
                _isDashing = false;
                transform.position = _dashEnd;
            }
        }
    }

}
