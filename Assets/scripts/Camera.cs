using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject Car;
    private void LateUpdate()
    {
        transform.position = Car.transform.position + new Vector3 (0,0,-10);
    }
}
