using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    public GameObject arrowPrefab;
    bool isDragging;
    public GameObject arrowSpawnLocation;
    public GameObject clickStartIndicator;
    public GameObject dragIndicator;
    public LineRenderer lineRenderer;
    private Camera MainCamera;

    void Start()
    {
        MainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            clickStartIndicator.SetActive(true);
            dragIndicator.SetActive(true);
            clickStartIndicator.transform.position = MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }

        if (isDragging)
        {
            dragIndicator.transform.position = MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            lineRenderer.positionCount = 2;
            Vector3[] positions = new Vector3[]{
                clickStartIndicator.transform.position,
                dragIndicator.transform.position
            };
            lineRenderer.SetPositions(positions);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                LaunchArrow();
            }

            isDragging = false;
            clickStartIndicator.SetActive(false);
            dragIndicator.SetActive(false);
            lineRenderer.positionCount = 0;
        }
    }


    void LaunchArrow()
    {
        GameObject arrowInstance = Instantiate(arrowPrefab);
        arrowInstance.transform.position = arrowSpawnLocation.transform.position;

        ArrowController arrowController = arrowInstance.GetComponent<ArrowController>();
        Vector3 offset  = dragIndicator.transform.position - clickStartIndicator.transform.position;
        arrowController.Launch(offset);
    }
}