using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    float velocity = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z -= velocity * Time.deltaTime;
        transform.position = pos;
    }
}
