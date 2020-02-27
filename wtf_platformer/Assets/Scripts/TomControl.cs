using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomControl : Enemy
{
    [SerializeField]
    private float rate = 2F;
    [SerializeField]
    private EvilBullet bullet;
    public AudioClip hitDE;
    [SerializeField]
    private int hp = 10;
    public GameObject HpDie;
    public GameObject TrDie;

    protected override void Update()
    {
        FlipUpdate();
        rate -= Time.deltaTime;
        if (rate <= 0 && isAlive)
        {
            Shoot();
        }
        if (hp < 1) Die();
        if (HarryControl.isDie) HpDie.SetActive(true);
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        if (isFacingLeft) position.x -= 0.8f;
        else position.x += 0.8f;

        EvilBullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as EvilBullet;
        rate = 0.5F;
    }

    public override void ReceiveDamage()
    {
        hp--;
    }
    public override void Die()
    {
        TrDie.SetActive(true);
    }
}
