using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    public SpriteRenderer rend;
    public Sprite rest;
    public Sprite partDraw;
    public Sprite halfDraw;
    public Sprite fullDraw;
    public Sprite drop;

    public float arrowForce;
    public GameObject arrow;
    public GameObject magic;
    public GameObject shotArrow;

    public TMP_Text magicCDText;
    public float chargeModifier;
    public int magicCooldown;
    public int magicTimer;
    public bool magicOnCD;

    public bool strength;

    public float damageMultiplier = 1;

    public void ChangeCD(int delta) {
        if (magicCooldown > 10) {
            magicCooldown += delta;
        }
    }

    public void ChangeDamage(float delta) {
        damageMultiplier += delta;
    }

    public void ChangeCharge(float delta) {
        chargeModifier += delta;
    }

    public void Reset() {
        chargeModifier = 0;
        arrowForce = 0;
        magicCooldown = 15;
        magicOnCD = false;
        damageMultiplier = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        strength = false;
        rend = gameObject.GetComponent<SpriteRenderer>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        magicCDText.text = magicTimer + "";
        float opposite = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        float adjacent = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        float rotation = Mathf.Rad2Deg * Mathf.Atan2(opposite, adjacent);
        transform.rotation = Quaternion.Euler(0,0,rotation);
        //Debug.Log(Input.mousePosition);
        if (Input.GetMouseButton(0)) {
            if ((((2.5f * Mathf.Pow(arrowForce+2, 2)) - 9) * damageMultiplier) < 14) {
                rend.sprite = partDraw;
            } else if ((((2.5f * Mathf.Pow(arrowForce+2, 2)) - 9) * damageMultiplier) >= 14) {
                rend.sprite = halfDraw;
            } 
            if (arrowForce < 2) {
                arrowForce += (2.0f + chargeModifier) * Time.deltaTime;
                //Debug.Log(arrowForce);
            } else {
                rend.sprite = fullDraw;
            }
        } else if (Input.GetMouseButtonUp(0)) {
            rend.sprite = drop;
            if (strength) {
                StartCoroutine(extraArrow(arrowForce));
            }
            shotArrow = Instantiate(arrow, transform.position, transform.rotation);
            shotArrow.GetComponent<ArrowMovement>().speed *= arrowForce + 1;
            shotArrow.GetComponent<ArrowMovement>().damage += ((2.5f * Mathf.Pow(arrowForce+2, 2)) - 9) * damageMultiplier;
            Debug.Log(shotArrow.GetComponent<ArrowMovement>().damage);
            if (arrowForce >= 2) {
                shotArrow.GetComponent<ArrowMovement>().passThrough = true;
            }
            arrowForce = 0;
        } else if (Input.GetMouseButtonDown(1) && !magicOnCD) {
            magicTimer = magicCooldown;
            StartCoroutine(MagicCD());
            Vector3 a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            a.z = 0;
            Instantiate(magic, a, transform.rotation);
        }
    }

    IEnumerator MagicCD() {
        magicOnCD = true;
        magicTimer = magicCooldown;
        for (int i = 0; i < magicCooldown; i++) {
            yield return new WaitForSeconds(1);
            magicTimer -= 1;
        }
        magicOnCD = false;
    }

    IEnumerator extraArrow(float arrowForce) {
        yield return new WaitForSeconds(0.05f);
        GameObject extra = Instantiate(arrow, transform.position, transform.rotation);
        extra.GetComponent<ArrowMovement>().speed *= arrowForce + 1;
        extra.GetComponent<ArrowMovement>().damage += ((2.5f * Mathf.Pow(arrowForce+2, 2)) - 9) * damageMultiplier;
        Debug.Log(extra.GetComponent<ArrowMovement>().damage);
        if (arrowForce >= 2) {
            extra.GetComponent<ArrowMovement>().passThrough = true;
        }
    }
}
