using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update
    public float SpinSpeed;
    public Vector3 startPoint;
    public Vector3 endPoint;
    private Vector3 endPointReal;
    public float height;
    public float duration;
    public float time;
    void Start()
    {
        startPoint = transform.position;
        endPointReal = endPoint + startPoint;


    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, SpinSpeed * Time.deltaTime));



        if (time < duration / 2)
        {
            time += Time.deltaTime;
            float t = time / duration;


            // Parabola theo dạng Bezier trung gian
            Vector3 midPoint = (startPoint + endPointReal) * 0.5f + Vector3.up * height;
            Vector3 m1 = Vector3.Lerp(startPoint, midPoint, t);
            Vector3 m2 = Vector3.Lerp(midPoint, endPointReal, t);
            transform.position = Vector3.Lerp(m1, m2, t);
        }

    }
}
