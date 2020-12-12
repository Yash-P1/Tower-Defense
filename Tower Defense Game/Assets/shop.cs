using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void PurchasedStandardTurret()
    {
        Debug.Log("Turret 1");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);

    }
}
