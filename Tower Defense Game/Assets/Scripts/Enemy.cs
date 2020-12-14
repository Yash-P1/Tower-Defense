using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;
    public int value = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavpointIndex = 0;
    public int random;
    private int destroyPoint = 25;

    void Start()
    {
        target = WayPoints.points[0];  
        random = Random.Range(0,3);
    }

    public void TakeDamage(int amount){
        health -= amount;

        if(health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);
       
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        void GetNextWayPoint()
        {

            if(wavpointIndex > destroyPoint)//WayPoints.points.Length - 1)
            {
                EndPath();
                return;
            }
            if(wavpointIndex == 0)
            {
                if(random == 0)
                {
                    wavpointIndex = 1;
                    destroyPoint = 13;
                    // wavpointIndex++;
                    // target = WayPoints.points[wavpointIndex];
                    // Debug.Log(target);
                    return;
                }else if(random == 1){
                    wavpointIndex = 14;
                    destroyPoint = 19;
                    // target = WayPoints.points[wavpointIndex];
                    // Debug.Log(target);
                    return;
                }else if(random == 2){
                    wavpointIndex = 20;
                    destroyPoint = 25;
                    return;
                }
                // wavpointIndex++;
                target = WayPoints.points[wavpointIndex];
                wavpointIndex++;
            }else{
                target = WayPoints.points[wavpointIndex];
                wavpointIndex++; 
            }
        }

        void EndPath(){
            PlayerStats.Lives--;
            Destroy(gameObject);
        }

    }
}
