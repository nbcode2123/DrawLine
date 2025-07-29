using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBasket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (DrawLineController.Instance.isFirstLine == true)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 2f;
        }

    }
}
