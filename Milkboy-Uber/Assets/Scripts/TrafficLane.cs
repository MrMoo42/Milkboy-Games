using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLane : MonoBehaviour
{
    public bool isRight = false; //Is this lane on the right side of the road.
    private bool isSpawning = false;
    [SerializeField] private GameObject car;

    private void Update() {
        if (!isSpawning) {
            StartCoroutine(Car());
        }
    }

    IEnumerator Car() {
        isSpawning = true;
        yield return new WaitForSeconds(Random.Range(2.0f,6.0f));
        GameObject temp = Instantiate(car, this.transform);
        temp.GetComponent<Vroom>().isRight = !isRight; //Reversed because I'm an idiot and too lazy to change it.
        isSpawning = false;
    }
}
