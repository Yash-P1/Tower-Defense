using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;

    private int destroyPoint = 25;

    public int random;
	private Enemy enemy;

    private bool odd = true;

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
        
        random = Random.Range(0, WaveSpawner.LevelNumber);

        if(random%2 == 0)
        {
            odd = !odd;
            }

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
                    destroyPoint = 9;
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
                if(wavepointIndex == 6 && odd)
                {
                    wavepointIndex = 10;
                    destroyPoint = 13;
                    return;
                }
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