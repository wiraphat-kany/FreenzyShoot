using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlayerBlue : MonoBehaviour
{
    [Header("Skill1")]
    [SerializeField] private Image skill1;
    [SerializeField] private float coolDown1;
    bool isCooldown1 = false;
    public GameObject Gun;

   /* [Header("Skill2")]
    [SerializeField] private Image skill2;
    [SerializeField] private float coolDown2;
    [SerializeField] private float speed;
    bool isCooldown2 = false;*/

   



    // Start is called before the first frame update
    void Start()
    {
        skill1.fillAmount = 0;
        //skill2.fillAmount = 0;


    }

    // Update is called once per frame
    void Update()
    {
        Skill1();

    }

    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCooldown1 == false)
        {
            Gun.SetActive(true);





            isCooldown1 = true;
            skill1.fillAmount = 1;

        }
        if (isCooldown1)
        {
            skill1.fillAmount -= 1 / coolDown1 * Time.deltaTime;

            if (skill1.fillAmount <= 0)
            {
                skill1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
        else
        {
            Gun.SetActive(false);
        }

    }
}