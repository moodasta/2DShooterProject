using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    public static PowerupManager instance;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}      
 