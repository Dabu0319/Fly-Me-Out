using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    
    private Vector2 m_TargetPosition;

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_TargetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Vector2)transform.position != m_TargetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_TargetPosition, speed * Time.deltaTime);
        }
        else
        {
            m_TargetPosition = GetRandomPosition();
        }

    }
    
    //Get Random Position
    private Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
}
