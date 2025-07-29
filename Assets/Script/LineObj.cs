using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    public float DrawSoundTimer;
    public float DrawSoundCooldown;
    private GameObject Pen;

    private void LateUpdate()
    {
        for (int i = 0; i < localPoints.Count; i++)
        {
            LineRenderer.SetPosition(i, transform.TransformPoint(localPoints[i]));
        }
    }
    private void Start()
    {
        LineRenderer = gameObject.GetComponent<LineRenderer>();
        EdgeCollider2D = gameObject.GetComponent<EdgeCollider2D>();

        CurrentPosition = transform.position;
        LineRenderer.positionCount = 1;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        Pen = DrawLineController.Instance.Pen;
        Debug.Log(DrawSoundCooldown);



    }
    private void Update()
    {
        DrawSoundTimer += Time.deltaTime;
        if (Input.GetMouseButton(0) && isComplete == false)
        {
            Pen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            Vector3 _tempPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _tempPosition.z = 0;
            if (Vector3.Distance(CurrentPosition, _tempPosition) > MinDistance)
            {

                if (CurrentPosition == transform.position)
                {
                    LineRenderer.SetPosition(0, _tempPosition);
                    LinePositions.Add(_tempPosition);
                    LevelManager.Instance.DecreaseSlideStarValue();
                    AddPoint(_tempPosition);
                    Pen.transform.position = _tempPosition;

                }
                else
                {
                    LineRenderer.positionCount++;
                    LineRenderer.SetPosition(LineRenderer.positionCount - 1, _tempPosition);
                    LinePositions.Add(_tempPosition);
                    LevelManager.Instance.DecreaseSlideStarValue();
                    AddPoint(_tempPosition);
                    Pen.transform.position = _tempPosition;




                }
                if (DrawSoundTimer >= DrawSoundCooldown)
                {
                    ObserverManager.Notify("PlayAudio", "DrawSound");
                    DrawSoundTimer = 0f;
                }
                CurrentPosition = _tempPosition;


            }
        }
        if (Input.GetMouseButtonUp(0) && isComplete == false)
        {

            gameObject.GetComponent<Rigidbody2D>().simulated = true;
            Pen.GetComponent<SpriteRenderer>().DOFade(0f, 1f);

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
    public void PlayDrawSound()
    {


    }



}
