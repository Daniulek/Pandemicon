using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] SpawnConfig spawnConfig;
    List<Transform> waypoints;
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidbody2D;
    public int waypointIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        waypoints = spawnConfig.GetWaypoints();
        transform.position = waypoints[Random.Range(0,waypoints.Count-1)].transform.position;
        rigidbody2D = this.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        Transform motherCell = spawnConfig.GetMotherCellTrans();
        Vector3 direction = motherCell.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;
        rigidbody2D.rotation = angle;
        direction.Normalize();

        Move();

    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
           
        }
        else if (waypointIndex == waypoints.Count)
        {
            waypointIndex = 0;
        }
    }


}
