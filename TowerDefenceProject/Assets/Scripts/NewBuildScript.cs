using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBuildScript : MonoBehaviour
{
    [SerializeField] GameObject turretPrefab;
    private Camera cam = null;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        SpawnAtMousePos();
    }

    private void SpawnAtMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(turretPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
