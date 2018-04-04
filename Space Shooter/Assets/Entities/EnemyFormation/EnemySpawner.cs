using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
 
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 0.1f;
    public float padding = 1f;
    float xmin = -5;
    float xmax = 5;

    private bool movingRight = true;
    // Use this for initialization
    void Start () {

        float distanceZ = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ));
        xmin = leftMost.x;
        xmax = rightMost.x;
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child ;
        }
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update () {

        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdge = transform.position.x + (0.5f * width) -padding;
        float leftEdge = transform.position.x - (0.5f * width) + padding;
        if(leftEdge < xmin)
        {
            movingRight = true;
        }
        else if (rightEdge > xmax)
        {
            movingRight = false;
        }

    }
}
