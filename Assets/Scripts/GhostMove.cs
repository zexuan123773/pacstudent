using UnityEngine;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class GhostMove : MonoBehaviour
{
    public GameObject[] wayPointsGos;
    public float speed = 0.2f;
    private List<Vector3> wayPoints = new List<Vector3>();
    private int index = 0;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position + new Vector3(0, 3, 0);

        // random next road
        RandomlySelectPath();
    }

    private void FixedUpdate()
    {
        if (transform.position != wayPoints[index])
        {
            Vector2 temp = Vector2.MoveTowards(transform.position, wayPoints[index], speed);
            GetComponent<Rigidbody2D>().MovePosition(temp);
        }
        else
        {
            index++;
            if (index >= wayPoints.Count)
            {
                index = 0;
                // random next road
                RandomlySelectPath();
            }
        }

        Vector2 dir = wayPoints[index] - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    private void LoadAPath(GameObject go)
    {
        wayPoints.Clear();
        Vector3 startPos = transform.position;
        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t.position);
        }
        wayPoints.Insert(0, startPos);
        wayPoints.Add(startPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the Pacman (Player) object when the ghost collides with it.
            Destroy(collision.gameObject);
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("lose game");
        }
    }

    private void RandomlySelectPath()
    {
        int randomPathIndex;
        do
        {
            randomPathIndex = Random.Range(0, wayPointsGos.Length);
        } while (randomPathIndex == index);

        LoadAPath(wayPointsGos[randomPathIndex]);
    }
}
