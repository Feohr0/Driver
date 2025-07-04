using Unity.VisualScripting;
using UnityEngine;

public class Car : MonoBehaviour
{
  [SerializeField] float moveSpeed=7f;
    [SerializeField] float turnSpeed=400f;
    [SerializeField] float boosted = 25f;
    [SerializeField] float bumped = 7f;
    [SerializeField] float time = 3;
    float speed;
    
    private void Start()
    {
        speed = moveSpeed;
    }
    void Update()
    {
        
        
        Turn();
        Move();
        
    }

     void Turn()
    {
        float steer = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steer);

    }
    private void Move()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0,move,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeSpeedTemporarily(bumped);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("Boosted");
            ChangeSpeedTemporarily(boosted);
        }
    }
    void ChangeSpeedTemporarily(float newSpeed)
    {
        moveSpeed = newSpeed;
        CancelInvoke(nameof(ResetSpeed));
        Invoke(nameof(ResetSpeed), time);
    }
    void ResetSpeed()
    {
        moveSpeed = speed;
    }
    
}