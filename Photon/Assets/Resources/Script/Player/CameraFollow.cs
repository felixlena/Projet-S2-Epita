using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float min = 4f;
    public float max = 15f;
    [Range(4, 15)]
    public float distance = 10f;
    [Range(4, 15)]
    public float heigth = 10f;

    private float zoom = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + heigth, target.position.z + distance);
        transform.LookAt(target);

        if (Input.mouseScrollDelta.y > 0)
        {
            distance -= Time.deltaTime * zoom;
            heigth -= Time.deltaTime * zoom;
            if (distance < min)
            {
                distance = min;
            }
            if (heigth < min)
            {
                heigth = min;
            }

        }
        if (Input.mouseScrollDelta.y < 0)
        {
            distance += Time.deltaTime * zoom;
            heigth += Time.deltaTime * zoom;
            if (distance > max)
            {
                distance = max;
            }
            if (heigth > max)
            {
                heigth = max;
            }
        }
    }
}
