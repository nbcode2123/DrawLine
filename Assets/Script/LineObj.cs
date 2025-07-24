using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineObj : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public Vector3 CurrentPosition;
    public float MinDistance = 0.1f;
    public bool isComplete = false;
    public EdgeCollider2D EdgeCollider2D;
    public List<Vector3> LinePositions;
    public List<Vector3> localPoints = new List<Vector3>();


    private void Start()
    {
        LineRenderer = gameObject.GetComponent<LineRenderer>();
        EdgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();

        CurrentPosition = transform.position;
        LineRenderer.positionCount = 1;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && isComplete == false)
        {
            Vector3 _tempPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _tempPosition.z = 0;
            if (Vector3.Distance(CurrentPosition, _tempPosition) > MinDistance)
            {
                if (CurrentPosition == transform.position)
                {
                    LineRenderer.SetPosition(0, _tempPosition);
                    LinePositions.Add(_tempPosition);
                    AddPoint(_tempPosition);




                }
                else
                {
                    LineRenderer.positionCount++;
                    LineRenderer.SetPosition(LineRenderer.positionCount - 1, _tempPosition);
                    LinePositions.Add(_tempPosition);
                    AddPoint(_tempPosition);


                }
                CurrentPosition = _tempPosition;


            }
        }
        if (Input.GetMouseButtonUp(0) && isComplete == false)
        {

            gameObject.GetComponent<Rigidbody2D>().simulated = true;

            isComplete = true;

        }
    }
    void AddPoint(Vector3 worldPos)
    {
        worldPos.z = 0;

        Vector3 localPos = transform.InverseTransformPoint(worldPos);
        localPoints.Add(localPos);
        LineRenderer.positionCount = localPoints.Count;
        for (int i = 0; i < localPoints.Count; i++)
        {
            LineRenderer.SetPosition(i, transform.TransformPoint(localPoints[i]));
        }

        Vector2[] colliderPoints = new Vector2[localPoints.Count];
        for (int i = 0; i < localPoints.Count; i++)
        {
            colliderPoints[i] = localPoints[i];
        }
        EdgeCollider2D.points = colliderPoints;

        CircleCollider2D circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
        circleCollider2D.offset = worldPos;
        circleCollider2D.radius = LineRenderer.startWidth / 2;

    }
    private void LateUpdate()
    {
        for (int i = 0; i < localPoints.Count; i++)
        {
            LineRenderer.SetPosition(i, transform.TransformPoint(localPoints[i]));
        }
    }


}
