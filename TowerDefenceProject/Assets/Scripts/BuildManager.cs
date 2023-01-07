using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [Header("GameObjects")]
    private GameObject turretToBuild;
    
    public GameObject standardTurredPrefab;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one build manager in scene!");
        }
        instance = this;
    }

    

    private void Start()
    {
        turretToBuild = standardTurredPrefab;
    }

    

    public GameObject getTurretToBuild()
    { 
        return turretToBuild;
    }
}
