using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public int allBullets = 30;
    public int maxGunBullets = 15;
    public int inGunBullets = 0;

    public FixedButton Fire;
    public FixedButton Reload;



    public Animation anim;
    public Camera fpsCamera;
    public ParticleSystem mf;
    public GameObject hitEffect;

    public AudioClip ReloadOut;
    public AudioClip Shooting;

    private AudioSource audiosource;

    public Text textAmmo;
    public Text textAmmoBox;

    // Start is called before the first frame update

    void Start()
    {
        //anim = GetComponent<Animation>();
        audiosource = GetComponent<AudioSource>();
 
        inGunBullets = maxGunBullets;
       
    }

    // Update is called once per frame
    void Update()
    {

        textAmmo.text = Convert.ToString(inGunBullets);
        textAmmoBox.text = Convert.ToString(allBullets);

        if (Fire.Pressed)
        {
            Shoot();
        }

        if (Reload.Pressed)
        {
            Reloading();
        }
    }

    void Shoot()
    {
        if (inGunBullets > 0)
        {

            inGunBullets--;
            anim.CrossFadeQueued("fire", 0.3F, QueueMode.PlayNow);
            mf.Play();
            //GetComponent<AudioSource>().PlayOneShot(shootGun);
            audiosource.clip = Shooting;
            audiosource.Play();
            Fire.Pressed = false;

            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                Health health = hit.transform.GetComponent<Health>();
                
                if (health != null)
                {
                    health.TakeDamage(damage);

                }
                GameObject clone = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(clone, 1.3f);

            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            //GameObject HitParent = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //HitParent.transform.parent = hit.transform;
            //Destroy(HitParent, 3f);

            

        }
        
    }

    void Reloading()
    {
        if (allBullets > 0)
        {
            if (allBullets + inGunBullets <= maxGunBullets)
            {
                inGunBullets = allBullets + inGunBullets;
                allBullets = 0;


            }
            if (allBullets + inGunBullets > maxGunBullets)
            {
                allBullets = allBullets + inGunBullets - maxGunBullets;
                inGunBullets += maxGunBullets - inGunBullets;

            }
            anim.CrossFadeQueued("reload", 0.3F, QueueMode.PlayNow);
            //GetComponent<AudioSource>().PlayOneShot(ReloadOut);
            audiosource.clip = ReloadOut;
            audiosource.Play();
            
            //audiosource[1].clip = ReloadIn;
            //audiosource[1].PlayDelayed(5f);



        }

    }

}
