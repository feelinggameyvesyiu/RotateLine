using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    private static ApplicationManager _instance;
    public static ApplicationManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ApplicationManager>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        InitManagers();
        StartApplication();
    }

    private void InitManagers()
    {


    }

    private void StartApplication()
    {

    }
}
