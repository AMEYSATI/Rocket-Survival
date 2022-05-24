using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oc : MonoBehaviour
{
    Vector3 startingposition;
    [SerializeField] Vector3 movementvector;
    [SerializeField] [Range(0,1)] float movementfactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float sinwave = Mathf.Sin(cycles * tau);

        movementfactor = (sinwave + 1f) / 2;

        Vector3 offset = movementvector * movementfactor;
        transform.position = startingposition + offset;
    }
}
