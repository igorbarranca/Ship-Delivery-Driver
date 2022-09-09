using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliverer : MonoBehaviour
{
    public bool HasPackage { get; private set; }
    
    GameObject packageToDeliver;

    private void Start()
    {
        HasPackage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Package package = collision.GetComponent<Package>();
        if(package == null) 
        { 
            return; 
        }
        else
        {
            packageToDeliver = collision.gameObject;
        }
        

        if (!HasPackage)
        {
            package.PackageCollected();
            HasPackage = true;
            
            AudioPlayer.instance.PlayPackagePickedClip();
        }
    }

    public void DropPackage()
    {
        HasPackage = false;
        Package package = packageToDeliver.GetComponent<Package>();
        package.gameObject.SetActive(true);
        package.RelocatePackage();

        AudioPlayer.instance.PlayPackageDeliveredClip();
    }
}
