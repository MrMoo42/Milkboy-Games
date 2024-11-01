using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 180f;

    private void Update() {
        float rotationAmt = rotationSpeed * Time.deltaTime;
        float curRotation = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRotation + rotationAmt));
    }
}
