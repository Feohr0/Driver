using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] public Timer time;
    public float points;
    Vector2 compassPosition = new Vector2();
    GameManager gameManager;
    [SerializeField] GameObject Car;
    [SerializeField] GameObject customerPrefab;
  public  GameObject currentCustomer;

    [SerializeField] public GameObject Compass;
    [SerializeField] public GameObject packagePrefab;
    GameObject Package;
    [SerializeField] public float minx, miny;
    [SerializeField] public float maxx, maxy;
    float xdeðeri;
    float ydeðeri;
    float x1deðeri;
    float y1deðeri;
    float angle;
    float degree;

   [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float delay;

    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        points = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpawnPackage();
        Compass.SetActive(true);
        CompassUpdater();
    }

    private void Update()
    {
        
        CompassUpdater();
    }

    public void SpawnPackage()
    {
        for (int i = 0; i < 10; i++) // maksimum 10 deneme
        {
            float x = Random.Range(minx, maxx);
            float y = Random.Range(miny, maxy);
            Vector2 spawnPos = new Vector2(x, y);

            float radius = 0.5f; // paketin yarýçapýna göre ayarla

            // Etrafýnda çakýþan collider var mý?
            Collider2D hit = Physics2D.OverlapCircle(spawnPos, radius);

            if (hit == null)
            {
                GameObject newPackage = Instantiate(packagePrefab, spawnPos, Quaternion.identity);
                Package = newPackage;
                Package.SetActive(true);
                CompassUpdater();
                return; // baþarýyla spawn ettik
            }
        }

        Debug.LogWarning("Uygun boþ alan bulunamadý, spawn edilemedi.");
    }

    public void DestroyCurrentPackage()
    {
        if (Package != null)
        {
            Destroy(Package);
            Package = null;
        }
    }
    public void DestroyCurrentCustomer()
    {
        if (currentCustomer != null)
        {
            Destroy(currentCustomer);
            currentCustomer = null;
        }
    }


    public void SpawnCustomer()
    {
        // Önceki müþteri varsa yok et
        DestroyCurrentCustomer();

        for (int i = 0; i < 10; i++) // maksimum 10 deneme
        {
            float x = Random.Range(minx, maxx);
            float y = Random.Range(miny, maxy);
            Vector2 spawnPos = new Vector2(x, y);
            float radius = 0.5f;

            Collider2D hit = Physics2D.OverlapCircle(spawnPos, radius);

            if (hit == null)
            {
                GameObject newCustomer = Instantiate(customerPrefab, spawnPos, Quaternion.identity);
                currentCustomer = newCustomer;
                currentCustomer.SetActive(true);
                CompassUpdater();
                return;
            }
        }

        Debug.LogWarning("Customer spawn edilecek boþ alan bulunamadý.");
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
            points += 1;
            time.time = time.resetTime;
            hasPackage = false;
            SpawnPackage();
            Debug.Log("Package Delivered Succsessfully");
            spriteRenderer.color = noPackageColor;
            Destroy(other.gameObject, delay);
            
        }
    }
    void CompassUpdater()
    {
        if (hasPackage && currentCustomer != null)

        {
            compassPosition = Car.transform.position - currentCustomer.transform.position;
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
