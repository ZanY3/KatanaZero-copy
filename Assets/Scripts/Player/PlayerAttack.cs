using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask Bullet;
    public LayerMask enemy; //enemyes layer, who will take damage.
    public float attackRange;
    public int damage;
    public Animator anim;
    public AudioSource source;
    public AudioClip bulletR;
    public AudioClip swordSwing;
   

    private void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                source.PlayOneShot(swordSwing);
                anim.SetTrigger("attack");
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                //finds all enemies within attack radius
                Collider2D[] bullets = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Bullet);


                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                for (int i = 0; i < bullets.Length; i++)
                {
                    bullets[i].GetComponent<Bullet>().GiveDamage(damage);
                    source.PlayOneShot(bulletR);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos() //for clarity of the attack zone
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}