using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;
    
    private void Start()
    {
        buildManager = BuildManager.instance;
        
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        
        buildManager.SetTurretToBuild(buildManager.standardTurredPrefab);
    }

    public void PurchaseLevel2Turret()
    {
        Debug.Log("Level 2 Turret Purchased");
        
        buildManager.SetTurretToBuild(buildManager.level2TurredPrefab);
    }
}
