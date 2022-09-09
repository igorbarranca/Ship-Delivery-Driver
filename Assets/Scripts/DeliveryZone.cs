using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    Deliverer deliverer;
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        deliverer = collision.GetComponent<Deliverer>();
        if(deliverer == null) { return; }

        if (deliverer.HasPackage)
        {
            Debug.Log("consegno");
            DeliverPackage();
            
            gameManager.IncreaseScore();
        }
    }

    void DeliverPackage()
    {
        deliverer.DropPackage();
    }
}
