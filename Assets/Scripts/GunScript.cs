using UnityEngine.UI;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 10f;

    public float range = 100f;

    public float FireRate = 10f;

    private float nextTimeToFire = 0f;

    public Camera fps;

    public ParticleSystem flash;

    public GameObject impact;

    public float Ammo = 20f;

    public Text Reload;

    public Text Health;

    public Text AmmoText;

    public AudioClip gunShot;

    public AudioClip gunShotOut;

    public AudioClip Loading;

    public AudioSource source;

     void Start()
    {
            Reload.enabled = false;
         
    }

    void Update () {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && Ammo > 0f)
        {
            nextTimeToFire = Time.time + 1f / FireRate;

            Shoot();
        }

        if (Ammo <= 0)
        {
            Reload.enabled = true;

            source.PlayOneShot(gunShotOut);
        }

        if (Input.GetKey(KeyCode.R))
        {
            Ammo = 20f;

            AmmoText.text = Ammo + "";

            source.PlayOneShot(Loading);

            Reload.enabled = false;
        }
    }

    void Shoot()
    {
        flash.Play();

        RaycastHit hit;

        if (Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.takeDamage(damage);

                if (hit.transform.name.Equals("Player"))
                {
                    target.Health.text = target.health + "";
                }
                
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 300f);
            }

            GameObject g = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(g, 2f);

            Ammo--;

            AmmoText.text = Ammo + "";

            source.PlayOneShot(gunShot);

        }
    }
}

