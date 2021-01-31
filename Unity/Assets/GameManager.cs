using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool frameLimiter = false;

    [SerializeField]
    private int targetFrameRate = 30;

    private void Start()
    {
        if (frameLimiter)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = targetFrameRate;
        }

        
    }
}
