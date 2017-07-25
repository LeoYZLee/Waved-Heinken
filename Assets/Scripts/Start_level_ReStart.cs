using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_level_ReStart : MonoBehaviour {
    [SerializeField]
    GameObject manager;

    void OnCollisionEnter(Collision collision)
    {
        manager.GetComponent<creatCube>().ReStart();
    }
}
