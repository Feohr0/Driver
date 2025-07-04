using UnityEngine;

public class Customer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Customer")
        {
            Debug.Log("Ouch");
        }
    }
}
