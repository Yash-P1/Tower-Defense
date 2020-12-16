using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;

    private int destroyPoint = 25;

    public int random;
	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		target = WayPoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		// if (wavepointIndex >= Waypoints.points.Length - 1)
		// {
		// 	EndPath();
		// 	return;
		// }
        if(wavepointIndex > destroyPoint)//WayPoints.points.Length - 1)
            {
                EndPath();
                return;
            }
            if(wavepointIndex == 0)
            {
                if(random == 0)
                {
                    wavepointIndex = 1;
                    destroyPoint = 13;
                    // wavpointIndex++;
                    // target = WayPoints.points[wavpointIndex];
                    // Debug.Log(target);
                    return;
                }else if(random == 1){
                    wavepointIndex = 14;
                    destroyPoint = 19;
                    // target = WayPoints.points[wavpointIndex];
                    // Debug.Log(target);
                    return;
                }else if(random == 2){
                    wavepointIndex = 20;
                    destroyPoint = 25;
                    return;
                }
                // wavpointIndex++;
                target = WayPoints.points[wavepointIndex];
                wavepointIndex++;
            }else{
                target = WayPoints.points[wavepointIndex];
                wavepointIndex++; 
            }
        // }
		// wavepointIndex++;
		// target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}