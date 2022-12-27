using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMemory : MonoBehaviour
{
    public void ResetBrain()
    {
        PlayerPrefs.DeleteAll();
    }
}
