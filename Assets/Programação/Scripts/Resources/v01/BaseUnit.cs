using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public Projector projector;
    private bool _isSelected;

    public bool IsSelected
    {
        get { return _isSelected; }
        set 
        {
            if (value)
            {
                projector.enabled = true;
            }
            else
            {
                projector.enabled = false;
            }

            _isSelected = value;
        }
    }

    public void Start()
    {
        //UnitController.AddBaseUnitToList(this);
    }
}
