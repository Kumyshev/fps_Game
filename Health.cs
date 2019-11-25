using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 50f;

    public GameObject GamOb;

    public int point;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {

            Die();

        }

    }

    void Die()
    {

        GameScore.scoreValue = GameScore.scoreValue + point;
        

       
        Destroy(GamOb);

        
        //transform.rotation = Quaternion.Euler(90, 0, 0);
        //transform.position = new Vector3(1.7f, -1.5f, 0f);


    }

}

