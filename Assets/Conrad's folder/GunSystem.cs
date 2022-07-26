
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{

    //Gun stas
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap, totalAmmo;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject muzzleFlash, bulletHoleGraphic, specialAudio;
    //public CameraShake camShake;
    //public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text, totalAmmoAvaliabletext;

    

    // Start is called before the first frame update
    void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();

        text.SetText("AMMO " + bulletsLeft + " / " + magazineSize);
        totalAmmoAvaliabletext.SetText("RESERVE " + " / " + totalAmmo);
    }

    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else 
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        //shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
        
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        FindObjectOfType<AudioManager>().Play("GunReload");
    }

    private void ReloadFinished()
    {
        int ammoDifferece;
        ammoDifferece = magazineSize - bulletsLeft;
        if (totalAmmo >= ammoDifferece)
        {
            totalAmmo -= ammoDifferece;
            bulletsLeft += ammoDifferece;
        }
        else if (totalAmmo >= 0 && totalAmmo < ammoDifferece)
        {
            bulletsLeft += totalAmmo;
            totalAmmo = 0;
        }
        
        
        reloading = false;
    }

    private void Shoot()
    {

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        FindObjectOfType<AudioManager>().Play("GunShot");

        readyToShoot = false;

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range))
        {
            Debug.Log(rayHit.collider.name);
            if (rayHit.collider.tag.Contains("Enemy"))
            {
                Debug.Log("Run");
                string enemySpecifier = rayHit.collider.tag;
                //rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
                EventManager.OnkillEnemyEvent?.Invoke(enemySpecifier);
               
                

            }
        }
        if (allowButtonHold)
        {
            specialAudio.SetActive(true);
        }
        else if (allowButtonHold == false)
        {
            specialAudio.SetActive(false);
        }

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;
        Invoke("ResetShot", timeBetweenShooting);
        if(bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void OnEnable()
    {
        EventManager.OnAutomaticGunEvent += AutomaticGunFireChanger;
        EventManager.OnAmmoEvent += AmmoIncreaser;
        EventManager.OnSingleFireEvent += SingleFireChanger;
    }

    private void OnDisable()
    {
        EventManager.OnAutomaticGunEvent -= AutomaticGunFireChanger;
        EventManager.OnAmmoEvent -= AmmoIncreaser;
        EventManager.OnSingleFireEvent -= SingleFireChanger;
    }

    public void AutomaticGunFireChanger()
    {
        allowButtonHold = true;
    }

    public void SingleFireChanger()
    {
        allowButtonHold = false;
    }

    public void AmmoIncreaser()
    {
        totalAmmo += 10;
    }
}
