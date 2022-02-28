using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; // cresce continuamente

        const float tau = Mathf.PI * 2; // valore fisso 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // oscillazione tra 1 e -1

        movementFactor = (rawSinWave + 1f) / 2f; // ricalcolo per valore pulito di oscillazione da 0 a 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
