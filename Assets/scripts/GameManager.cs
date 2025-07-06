using Microsoft.Win32.SafeHandles;
using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Delivery d;
    [SerializeField] TextMeshProUGUI pointstext;

    private void Start()
    {
        pointstext.text = d.points.ToString();
    }
    private void LateUpdate()
    {
       pointstext.text = d.points.ToString();
    }


}
