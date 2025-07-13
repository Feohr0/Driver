using UnityEngine;

public class Customer : MonoBehaviour
{
    public Delivery d;
    public Transform tdransform;

    public Vector2 speed;

    private void Start()
    {
        tdransform = GetComponent<Transform>();
        d = FindObjectOfType<Delivery>(); // Eðer Inspector'dan atanmadýysa

        if (d != null && d.currentCustomer != null)
        {
            tdransform.position = d.currentCustomer.transform.position;
        }

        speed = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f));
    }

    private void Update()
    {
        CustomerMovement();
    }

    void CustomerMovement()
    {
        tdransform.Translate(speed * Time.deltaTime);
    }
}
