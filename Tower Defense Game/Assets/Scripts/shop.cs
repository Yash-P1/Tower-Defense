using UnityEngine;

public class shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Turret 1");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Turret 2");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Turret 3");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
