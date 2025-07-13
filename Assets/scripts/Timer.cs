using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Delivery d;
    [SerializeField] TextMeshProUGUI timerTex;
    [SerializeField] public float time;   // Her d�ng�de s�re
    public float resetTime;
    private bool timerExpired = false;

    private void Start()
    {
        resetTime = time;
    }
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerExpired = false; // s�re devam ediyorsa resetle
        }

        if (time <= 0 && !timerExpired)
        {
            timerExpired = true; // bu blok sadece bir kere �al��s�n

            d.points -= 1;
           
            d.DestroyCurrentPackage();
            d.SpawnPackage();


            // Timer�� yeniden ba�lat
            time = resetTime;
        }

        // UI timer yaz�s� g�ncelle
        int min = Mathf.FloorToInt(time / 60);
        int secs = Mathf.FloorToInt(time % 60);
        timerTex.text = string.Format("{0:00}:{1:00}", min, secs);
    }
}
