using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;
    private RaycastHit2D ray;
    [SerializeField] private LayerMask layermask; //layer để check raycast

    private float angle; // góc bắn
    //public int ballSum; //Số lượng bóng tối đa ở mỗi màn chơi
    //public int currentBall; //Số lượng bóng hiện tại
    //public Ball ballPrefab; //gameObject quả bóng
    //public float forceShoot; //Lực bắn
    [SerializeField] Vector2 minMaxAngle;
    public Dots dotLine;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void FixedUpdate()
    {
        //ray = Physics2D.Raycast(transform.position, transform.up, 20f, layermask);
        //Debug.DrawRay(transform.position, ray.point, Color.red); 
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            DrawLine();
        }
    }

    private void DrawLine()
    {
        ray = Physics2D.Raycast(transform.position, -transform.up, 20f, layermask);
        //Debug.DrawRay(transform.position, ray.point, Color.red);

        Vector2 reflactPos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - transform.position, ray.normal);
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;

        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        
        dotLine.DrawDottedLine(transform.position, ray.point);
        dotLine.DrawDottedLine(ray.point, ray.point + reflactPos.normalized * 3f);
       
        //transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
        DotLineRotate();
    }
    private void DotLineRotate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
    }
}
