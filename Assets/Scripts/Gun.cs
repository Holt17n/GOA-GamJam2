using UnityEngine;

public class Gun : MonoBehaviour
{
    //limiting the range and damage of the gun
    public int damage = 10;
    public int range = 100;
    
    //selecting the main camera
    public Camera fpsCam;
    // Update is called once per frame
    void Update()
    {
        //if the mouse is clicked
        if (PlayerManager.instance.getPlayerStatus() == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //shoot command
                Shoot();
            }
        }
    }

    void Shoot ()
    {
        //making a raycast appear when the mouse is clicked
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //log what is hit
            Debug.Log(hit.transform.name);
            //if something is hit it will take damage
            Target target = hit.transform.GetComponent<Target>();
            //if nothing is hit it will not take damage
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
