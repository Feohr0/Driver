using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
