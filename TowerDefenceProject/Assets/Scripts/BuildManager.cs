using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one build manager in scene!");
        }
        instance = this;
    }

    public GameObject standardTurredPrefab;

    private void Start()
    {
        turretToBuild = standardTurredPrefab;
    }

    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    { 
        return turretToBuild;
    }
}
