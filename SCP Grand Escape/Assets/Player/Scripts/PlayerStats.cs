using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerstats : MonoBehaviour
{
    [SerializeField]
    private float _healthState;
    [SerializeField]
    private float _staminaState;


    void Start()
    {
        _staminaState = 100.0f;
        _healthState = 100.0f;
       
    }

    public Playerstats()
    {
        _staminaState = 100.0f;
        _healthState = 100.0f;
    }


    public float Stamina
    {
        get { return _staminaState; }
        set { _staminaState = value; }
    }
}
