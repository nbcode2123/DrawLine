
using UnityEngine;

public class Hint : MonoBehaviour
{
    public GameObject HintLine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            if (HintLine != null)
            {
                HintLine.SetActive(true);
                gameObject.SetActive(false);
                Destroy(other.gameObject);
            }


        }
    }
}
