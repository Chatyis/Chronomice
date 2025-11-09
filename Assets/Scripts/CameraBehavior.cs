using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 5f;
    [SerializeField]
    private float yAxisTolerance = 2f;

    
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        var yPosition = transform.position.y;
        
        if (Mathf.Abs(player.transform.position.y - transform.position.y) > yAxisTolerance)
        {
            yPosition = player.transform.position.y;
        }
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, yPosition, transform.position.z), cameraSpeed * Time.deltaTime);
    }
}
