using UnityEngine;

public class BuildManager : MonoBehaviour
{

	public static BuildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			//Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	// void Start()
	// {
	// 	turretToBuild = standardTurretPrefab;
	// }

	//private GameObject turretToBuild;
	private TurretBlueprint turretToBuild;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	
	public void BuildTurretOn(Node node){

		if(PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not enough plasma.");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;

		Vector3 TurretSpwanOffset = new Vector3(0f, 5f, 0f);

		GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition()+ TurretSpwanOffset, Quaternion.identity);
		node.turret = turret;

		GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("Turret Build! Money Left: " + PlayerStats.Money);
	}

	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
	}
	// public void SelectTurretToBuild (TurretBlueprint turret)
	// {
	// 	turretToBuild = turret;
	// }
}