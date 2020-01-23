using UnityEngine;
using System.Collections;

public class DeathEater : Enemy
{
    [SerializeField]
    private float rate = 2.0F;
    [SerializeField]
    private EvilBullet bullet;

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    protected override void Update()
    {
        FlipUpdate();
        //if (Mathf.Abs(transform.position.x - player.transform.position.x) < 2)
        //{
        //    InvokeRepeating("Shoot", rate, rate);
        //}
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        if (isFacingLeft) position.x -= 0.8f;
        else position.x += 0.8f;

        EvilBullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as EvilBullet;

    }

    
}
