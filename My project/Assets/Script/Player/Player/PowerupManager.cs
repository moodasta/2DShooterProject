using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    public static PowerupManager Instance;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}      
 