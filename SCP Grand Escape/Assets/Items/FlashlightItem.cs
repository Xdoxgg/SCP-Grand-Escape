using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;

public class FlashlightItem : UsefulItem
{
    [SerializeField] private Light _light;
    private bool _isActive;

    public FlashlightItem()
    {
        _isActive = false;
        Name = "Flashlight";
    }

    public void ToggleFlashlight()
    {
        _isActive = !_isActive;
        _light.enabled = _isActive;
        
    }
}