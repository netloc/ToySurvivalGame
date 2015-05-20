using UnityEngine;
using System.Collections;

public class PlayerBuffs : MonoBehaviour
{

    public int armor;
    public float speed;
    public int damage;
    public bool hasSpeedBuff = false;
    public bool hasDamageBuff = false;
    public float speedTimer = 10.0f;
    public float damageTimer = 10f;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasDamageBuff && damageTimer >= 0)
        {
            damageTimer -= Time.deltaTime;

            if (damageTimer <= 0)
            {
                RemoveDamageBonus();
                hasDamageBuff = false;

                damageTimer = 10f;
            }
        }
        if (hasSpeedBuff && speedTimer >= 0)
        {
            speedTimer -= Time.deltaTime;

            if (speedTimer <= 0)
            {
                RemoveSpeedBonus();
                hasSpeedBuff = false;
                speedTimer = 10f;
            }
        }
    }

    public void AddShieldBonus()
    {
        armor += 3;
    }

    // Returns true if a tick was removed
    public bool RemoveShieldTick()
    {
        bool HadShieldTick = true;

        if (armor > 0)
        {
            armor--;
        }
        else
        {
            HadShieldTick = false;
        }

        return HadShieldTick;
    }

    public void AddSpeedBonus()
    {
        speed += 12;
        hasSpeedBuff = true;
    }

    public void RemoveSpeedBonus()
    {
        if (hasSpeedBuff)
        {
            speed -= 12;
            hasSpeedBuff = false;
        }
    }

    public void AddDamageBonus()
    {
        var lineRenderer = (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LineRenderer>() as LineRenderer);
        SetLineRendererColor(lineRenderer, Color.red, Color.red);
        hasDamageBuff = true;
        damage += 10;
    }

    public void RemoveDamageBonus()
    {
        var lineRenderer = (GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LineRenderer>() as LineRenderer);
        SetLineRendererColor(lineRenderer, Color.white, Color.white);
        hasDamageBuff = false;
        if (damage >= 10)
            damage -= 10;
    }

    private void SetLineRendererColor(LineRenderer lineRenderer, Color startColor, Color endColor)
    {
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

        lineRenderer.SetColors(startColor, endColor);
    }
}
