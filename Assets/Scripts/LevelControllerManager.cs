using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
