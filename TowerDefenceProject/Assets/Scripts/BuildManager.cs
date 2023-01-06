using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turretToBuild;

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

    

    public GameObject getTurretToBuild()
    { 
        return turretToBuild;
    }
}
