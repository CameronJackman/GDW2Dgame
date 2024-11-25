using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float FollowSpeed = 2f;
    [SerializeField] private Transform player, topLeftBound, bottomRightBound;

    [SerializeField] private Camera cam;
    Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update()
    {
        // follow
        Vector3 newpos = new Vector3(player.position.x, player.position.y, -10f);


        Vector3 targetPosition = player.position + newpos;

        float camHeight = cam.orthographicSize * 2;
        float camWidth = camHeight * cam.aspect;

        float minX = topLeftBound.position.x + camWidth / 2;
        float maxX = bottomRightBound.position.x - camWidth / 2;
        float minY = bottomRightBound.position.y + camHeight / 2;
        float maxY = topLeftBound.position.y - camHeight / 2;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, FollowSpeed);
    }

    
}
