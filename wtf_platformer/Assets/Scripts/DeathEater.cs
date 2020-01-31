using UnityEngine;
using System.Collections;

public class DeathEater : Enemy
{
    [SerializeField]
    private float rate = 2F;
    [SerializeField]
    private EvilBullet bullet;
    private bool isAlive = true;
    public AudioClip hitDE;

    protected override void Update()
    {
        FlipUpdate();
        rate -= Time.deltaTime;
        if(rate <= 0 && Mathf.Abs(transform.position.x - player.transform.position.x) < 18f && isAlive)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        if (isFacingLeft) position.x -= 0.8f;
        else position.x += 0.8f;

        EvilBullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as EvilBullet;
        rate = 2.0F;
    }

    public override void Die()
    {
        isAlive = false;
        rb.isKinematic = false;
        GetComponent<AudioSource>().PlayOneShot(hitDE);
        Destroy(gameObject, 1F);
    }
}
