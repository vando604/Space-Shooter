using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public float padding = 0.5f;
    float xmin = -5;
    float xmax = 5;
    float ymin = -5;
    float ymax = 5;


	// Use this for initialization
	void Start () {
        float distanceZ = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceZ));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ));
        Vector3 upMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceZ));
        Vector3 downMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
        ymin = downMost.y + padding;
        ymax = upMost.y - padding;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
