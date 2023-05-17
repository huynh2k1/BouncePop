using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;
    public Transform firePoint;
    public float angleLimit = 75f;
    public Vector3 dir;

    public Ball ballPrefab;
    public float force;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) )
        {

            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;
            Debug.Log("góc: " + angle);
            if(angle <= angleLimit && angle >= -angleLimit)
            {
                transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            ShootBall();
        }
    }

    private void ShootBall()
    {
        Ball ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(dir.normalized * force);
    }
}
