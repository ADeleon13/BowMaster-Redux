using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    public GameObject arrowPrefab;
    bool isDragging;
    public GameObject arrowSpawnLocation;
    public GameObject mouseIndicator;
    private Camera MainCamera;

    private Vector3 IndicatorStart;
    private Vector3 IndicatorOffset;
    public float MaxIndicatorDistance;

    void Start()
    {
        MainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            IndicatorStart = mouseIndicator.transform.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                IndicatorOffset = mouseIndicator.transform.position - IndicatorStart;
                mouseIndicator.transform.localPosition = Vector3.zero;
                LaunchArrow();
            }

            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 MouseWorldPosition = MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            Vector3 MouseOffset = MouseWorldPosition - IndicatorStart;
            Vector3 FinalPosition = Vector3.ClampMagnitude(MouseOffset, MaxIndicatorDistance);
            mouseIndicator.transform.position = FinalPosition;
        }
        mouseIndicator.SetActive(isDragging);
    }


    void LaunchArrow()
    {
        GameObject arrowInstance = Instantiate(arrowPrefab);
        arrowInstance.transform.position = arrowSpawnLocation.transform.position;

        ArrowController arrowController = arrowInstance.GetComponent<ArrowController>();
        arrowController.Launch(IndicatorOffset);
    }
}