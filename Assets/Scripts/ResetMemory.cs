using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMemory : MonoBehaviour
{
    public GameObject UISFX;
    public void ResetBrain()
    {
        Instantiate(UISFX,transform.position,transform.rotation);
        PlayerPrefs.DeleteAll();
    }
}
