using System;
using UnityEngine;

public class DropTrigger:MonoBehaviour
{
    [SerializeField] private DoorController _door1;
    [SerializeField] private DoorController _door2;
    [SerializeField] private Animator _animator1;
    [SerializeField] private Animator _animator2;

    private void Update()
    {
        if (_door1.DoorOpen || _door2.DoorOpen)
        {
            _animator1.SetBool("Start", true);
            _animator2.SetBool("Start", true);
        }
}
}