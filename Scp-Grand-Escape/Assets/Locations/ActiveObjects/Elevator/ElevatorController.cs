using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorController : MonoBehaviour, IInteracteble
{
    [SerializeField] private Animator _animatorMain;
    [SerializeField] private Animator _animator1;
    [SerializeField] private Animator _animator2;

    private enum Mode
    {
        up,
        down
    }

    [SerializeField] private Mode _mode;

    public void Interact()
    {
        if (_mode == Mode.up)
        {
            _animator1.SetBool("Start", true);
            _animator2.SetBool("Start", true);
      
            _animatorMain.SetBool("MoveUp", true);
            _mode = Mode.down;
        }
        else
        {
            _animator1.SetBool("Start", false);
            _animator2.SetBool("Start", false);

            _animatorMain.SetBool("MoveUp", false);
            _mode = Mode.up;
        }
    
    }

    public string GetDesciption()
    {
        return "Firstly close doors";
    }

    public bool IsInventereble()
    {
        return false;
    }
}