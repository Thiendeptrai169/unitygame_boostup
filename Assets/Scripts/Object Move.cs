using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    Vector3 startingPoint;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        float T = Time.time / period;
        float omega = Mathf.PI * 2;
        movementFactor = (Mathf.Sin(omega * T) + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;   
        transform.position = startingPoint + offset;
    }
}
