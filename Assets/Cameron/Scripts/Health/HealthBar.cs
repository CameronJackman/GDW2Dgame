using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

   [SerializeField] private Health Playerheath;
   [SerializeField] private Image totalhealthbar;
   [SerializeField] private Image currenthealthBar;
    // Start is called before the first frame update
    void Start()
    {
        totalhealthbar.fillAmount = Playerheath.health / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthBar.fillAmount = Playerheath.health / 10;
    }
}
