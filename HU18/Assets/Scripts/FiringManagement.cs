using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum GunState
{
    Overheat,
    Normal
}

public class FiringManagement : MonoBehaviour
{
    public KeyCode FireKey;
    public UnityEvent fire;
    private bool firing = false;

    private GunState gunState = GunState.Normal;
    private float heat = 0;
    private IEnumerator coolingCoroutine;
    
    public Slider slider;

    public GameObject Bullet;
    public GameObject BigBullet;
    

    // Use this for initialization
    void Awake()
    {
        fire = new UnityEvent();
        fire.AddListener(Fire);
        fire.AddListener(SetGunState);
        fire.AddListener(SetSlider);
        fire.AddListener(StartGunCooling);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(FireKey) && !firing)
        {
            StartCoroutine(AutoFire(ModeToWeaponCoolDownTime(gunState)));
        }
    }

    IEnumerator AutoFire(float checktime)
    {
        firing = true;
        while (firing)
        {
            fire.Invoke();
            yield return new WaitForSeconds(ModeToWeaponCoolDownTime(gunState));
            firing = Input.GetKey(FireKey);
        }

    }

    private void StartGunCooling()
    {
        if(coolingCoroutine != null)
            StopCoroutine(coolingCoroutine);
        
        coolingCoroutine = CoolGunDown(.05f, 3);
        StartCoroutine(coolingCoroutine);
    }

    private IEnumerator CoolGunDown(float cooldownPerSecond, float initialWaitPeriod)
    {
        yield return new WaitForSeconds(initialWaitPeriod);
        bool going = true;
        while(going)
        {
            
            heat -= cooldownPerSecond * Time.deltaTime;
            if (heat <= 0)
            {
                heat = 0;
                StopCoroutine(coolingCoroutine);
                going = false;
            }
            SetSlider();
            yield return new WaitForEndOfFrame();
            
        }
    }

    private void SetSlider()
    {
        slider.value = heat;
    }

    float ModeToWeaponCoolDownTime(GunState state)
    {
        if (state == GunState.Overheat)
        {
            return 1f;
        }
        else
        {
            return 0.3f;
        }
    }

    private void Fire()
    {
        GameObject temp;
        if (gunState == GunState.Normal)
        {
            heat += 0.1f;
            temp = Instantiate(Bullet, transform.position + transform.right, Quaternion.identity);
        }
        else
        {
            heat -= 0.5f;
            temp = Instantiate(BigBullet, transform.position + transform.right, Quaternion.identity);
        }
        AccelerateShot(temp);
    }

    void AccelerateShot(GameObject gameObject)
    {
        Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (gunState == GunState.Normal)
        {
            rb2d.AddForce(transform.right, ForceMode2D.Impulse);
        }
        else
        {
            rb2d.AddForce(transform.right * 3f, ForceMode2D.Impulse);
        }
    }

    void SetGunState()
    {
        if (heat < 1f)
        {
            gunState = GunState.Normal;
        }
        else
        {
            gunState = GunState.Overheat;
        }
    }
}


