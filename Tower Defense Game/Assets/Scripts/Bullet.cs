using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;

    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectsIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectsIns, 2f);
        Debug.Log("out");
        if(explosionRadius > 0)
        {
            Debug.Log("In");
            Explode();
        }else{
            Damage(target);
        }

        //Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy"){
                
                Damage(collider.transform);
                
            }
        }
    }

    void Damage(Transform enemy)
    {
        Debug.Log("Damage");
        Destroy(enemy.gameObject);
    }

    void  OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
