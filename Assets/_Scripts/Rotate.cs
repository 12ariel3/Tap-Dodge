using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotSpeed = 2f;
    [SerializeField] float randomRotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomRotSpeed = Random.Range(-rotSpeed,rotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * randomRotSpeed * Time.deltaTime);
    }
}
