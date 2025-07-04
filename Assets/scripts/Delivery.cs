using UnityEngine;

public class Delivery : MonoBehaviour
{
    Vector2 compassPosition = new Vector2();
    GameManager gameManager;
    [SerializeField] GameObject Car;
    [SerializeField] GameObject Customer;
    [SerializeField] public GameObject Compass;
    [SerializeField] public GameObject packagePrefab;
    GameObject Package;
    [SerializeField] public float minx, miny;
    [SerializeField] public float maxx, maxy;
    float xde�eri;
    float yde�eri;
    float x1de�eri;
    float y1de�eri;
    float angle;
    float degree;

   [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float delay;

    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        SpawnPackage();
        Compass.SetActive(true);
        CompassUpdater();
    }

    private void LateUpdate()
    {
        
        CompassUpdater();
    }

    public void SpawnPackage()
    {
        // Yeni package spawn ediliyor
        xde�eri = Random.Range(minx, maxx);
        yde�eri = Random.Range(miny, maxy);
        Vector2 konum = new Vector2(xde�eri, yde�eri);

        GameObject newPackage = Instantiate(packagePrefab, konum, Quaternion.identity);
        Package = newPackage; // Package art�k sahnedeki obje
        Package.SetActive(true);
        CompassUpdater();

    }
    public void SpawnCustomer()
    {
        x1de�eri = Random.Range(minx, maxx);
        y1de�eri = Random.Range(miny, maxy);
        Vector2 konum1 = new Vector2(x1de�eri, y1de�eri);
        GameObject newCustomer = Instantiate(Customer, konum1, Quaternion.identity);
        Customer = newCustomer;
        Customer.SetActive(true);
        CompassUpdater();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package PickedUp");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delay);
            SpawnCustomer();
        }

        if (other.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            SpawnPackage();
            Debug.Log("Package Delivered Succsessfully");
            spriteRenderer.color = noPackageColor;

            Destroy(other.gameObject, delay);
        }
    }
    void CompassUpdater()
    {
        if (hasPackage && Customer != null)
        {
            compassPosition = Car.transform.position - Customer.transform.position;
            angle = Mathf.Atan2(compassPosition.y, compassPosition.x);
            degree = angle * Mathf.Rad2Deg;
            Compass.transform.rotation = Quaternion.Euler(0, 0, degree + 180);
        }

        if (!hasPackage && Package != null && Package.activeSelf)
        {
            compassPosition = Car.transform.position - Package.transform.position;
            angle = Mathf.Atan2(compassPosition.y, compassPosition.x);
            degree = angle * Mathf.Rad2Deg;
            Compass.transform.rotation = Quaternion.Euler(0, 0, degree + 180);
        }
    }


    
}
