using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Memory : Entity
{
    public TMP_Text lineUI;
    public List<string> lines;

    private float cooldown;
        // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(cooldown < 0f)
        {
            int pickedIndex = Random.Range(0, lines.Count);
            lineUI.text = lines[pickedIndex];
            cooldown = Random.Range(1f, 3f);
        }
    }

    public override void Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
