using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClock : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject target;

    // Update is called once per frame
    void Update () {
        this.transform.RotateAround(target.transform.position , new Vector3(0, 0, speed * Time.deltaTime), speed);
    }
}
