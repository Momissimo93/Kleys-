using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    Vector2 originalPosition;
    new Transform transform;
    float distance;
    int direction;
    int velocity = 1;

    public void SetParameters(Transform tr, Vector2 originalPos, float dist, int dir)
    {
        transform = tr;
        originalPosition = originalPos;
        distance = dist;
        direction = dir;
    }
    public void Move(Transform tr)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (velocity * direction * Time.deltaTime), transform.position.z);
       
        if (direction == -1 && transform.position.y <= originalPosition.y || direction == 1 && transform.position.y >= originalPosition.y + distance)
        {
            StartCoroutine(WaitFor());
            direction *= -1;
        }
    }

    IEnumerator WaitFor()
    {
        velocity = 0;
        yield return new WaitForSeconds(1);
        velocity = 1;
    }
}
