using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerstats : MonoBehaviour
{
    [SerializeField]
    private float _healthState;
    [SerializeField]
    private float _staminaState;
    [SerializeField]
    private bool _run;


    void Start()
    {
        _staminaState = 100.0f;
        _healthState = 100.0f;
    }


    void Update()
    {
        if (_staminaState >= 30)
        {
            _run = true;
        }
        else
        {
            _run = false;
        }
    }


    bool Run
    {
        get { return _run; }
    }

}
