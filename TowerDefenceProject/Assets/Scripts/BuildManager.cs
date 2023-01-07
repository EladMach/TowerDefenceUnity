using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [Header("GameObjects")]
    private GameObject turretToBuild;
    
    public GameObject standardTurredPrefab;
    public GameObject level2TurredPrefab;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one build manager in scene!");
        }
        instance = this;
    }

  
    public GameObject getTurretToBuild()
    { 
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
