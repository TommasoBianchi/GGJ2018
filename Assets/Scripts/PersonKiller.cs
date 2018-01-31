using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonKiller : MonoBehaviour {

    public LayerMask thingsThatKillPeople;
    public float dieTime = 1f;

    public GameManager.PersonType personType;

    public GameObject bloodPrefab;

    private bool isAlive;
    private SpriteRenderer spriteRenderer;
    private float dieTimer = 0f;
    
	void Start ()
    {
        isAlive = true;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}
	
	void Update ()
    {
		if (!isAlive)
        {
            Color color = spriteRenderer.color;
            color.a = (dieTime - dieTimer) / dieTime;
            spriteRenderer.color = color;
            
            dieTimer += Time.deltaTime;
            if (dieTimer >= dieTime)
            {
                GameManager.RegisterKill(personType);
                Destroy(gameObject);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & thingsThatKillPeople.value) != 0)
        {
            if (isAlive)
            {
                isAlive = false;
                Instantiate(bloodPrefab, transform.position - new Vector3(0, 0, 0.75f), Quaternion.Euler(0, 0, Random.Range(0, 360f)));
                SFXManager.Instance.PlaySample(0);
            }
        }
    }
}
