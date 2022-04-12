using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image a1;
    public float cool1 = 5;
    bool isCooldown1 = false;
    public KeyCode ability1;
    public GameObject a1Particle;

    [Header("Ability 2")]
    public Image a2;
    public float cool2 = 25;
    bool isCooldown2 = false;
    public KeyCode ability2;
    public GameObject a2Particle;

    [Header("Ability 3")]
    public Image a3;
    public float cool3 = 10;
    bool isCooldown3 = false;
    public KeyCode ability3;

    //A3 input variables
    Vector3 position;
    public Canvas ability3Canvas;
    public Image skillshot;
    public Transform player;

    public GameObject projPrefab;
    public Transform projSpawnPoint;
    public GameObject targetPos;

    // Start is called before the first frame update
    void Start()
    {
        a1.fillAmount = 0;
        a2.fillAmount = 0;
        a3.fillAmount = 0;

        skillshot.GetComponent<Image>().enabled = false;
        

    }

    // Update is called once per frame
    void Update()
    {

        Ability1();
        Ability2();
        

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject != this.gameObject)
            {
              
                position = hit.point;
            }
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        //ability 3 canvas
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        transRot.eulerAngles = new Vector3(90, transRot.eulerAngles.y, transRot.eulerAngles.z);
        ability3Canvas.transform.rotation = Quaternion.Slerp(transRot, ability3Canvas.transform.rotation, 0.5f);

        //Ability3();
    }

    void Ability1()
    {
        if(Input.GetKey(ability1) && isCooldown1 == false)
        {
            

            isCooldown1 = true;
            a1.fillAmount = 1;
            StartCoroutine(Ability1Action());
        }


        if (isCooldown1)
        {
            a1.fillAmount -= 1 / cool1 * Time.deltaTime;

            if (a1.fillAmount <= 0)
            {
                a1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }

    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            a2.fillAmount = 1;
            StartCoroutine(Ability2Action());
        }

        if (isCooldown2)
        {
            a2.fillAmount -= 1 / cool2 * Time.deltaTime;
            if (a2.fillAmount <= 0)
            {
                a2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            skillshot.GetComponent<Image>().enabled = true;
           
        }

        if(skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(1))
        {
            isCooldown3 = true;
            a3.fillAmount = 1;
            SpawnRangedProj(targetPos);
        }

        if (isCooldown3)
        {
            a3.fillAmount -= 1 / cool3 * Time.deltaTime;
            skillshot.GetComponent<Image>().enabled = false; ;
            if (a3.fillAmount <= 0)
            {
                a3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    private IEnumerator Ability2Action()
    {
        GameObject clone = Instantiate(a2Particle, gameObject.transform);
        PlayerManager.instance.SetHealth(20);
        yield return new WaitForSeconds(0.3f);
        Destroy(clone);
    }

    private IEnumerator Ability1Action()
    {
        GameObject clone = Instantiate(a1Particle, gameObject.transform);
        CheckForEnemy();
        yield return new WaitForSeconds(0.5f);
        Destroy(clone);
    }

    private void CheckForEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        foreach(Collider c in colliders)
        {
            if (c.GetComponent<EnemyStats>())
            {
                //Debug.Log(gameObject.GetComponent<CharacterCombat>().myStats.damage.GetValue());
                c.GetComponent<CharacterStats>().TakeDamage(gameObject.GetComponent<CharacterCombat>().myStats.damage.GetValue() + 20);
            }
        }
    }

    void SpawnRangedProj(GameObject target)
    {
        Instantiate(projPrefab, projSpawnPoint.transform.position, Quaternion.identity);
        projPrefab.GetComponent<RangedProjectile>().target = target.transform.position;
        projPrefab.GetComponent<RangedProjectile>().targetSet = true;
    }
}
