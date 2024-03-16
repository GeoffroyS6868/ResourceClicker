using System.Collections;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public WorkerOverlay Overlay;
    private Resource.ResourceType resourceType;
    private Resource resourceManaged;
    private int level = 0;
    private int price = 0;
    private int amountFarmed = 0;
    private bool isBought = false;

    Rigidbody2D rb;
    Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        int randomNumber = Random.Range(0, 2);
        Debug.Log(randomNumber);
        resourceType = (Resource.ResourceType)randomNumber;
        level = Random.Range(1, 5);
        price = level * 50;
    }

    private void FixedUpdate()
    {
        if (!isBought)
        {
            rb.velocity = new Vector2(1, 0);
            animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
            if (transform.position.x >= 23.5f)
            {
                Overlay.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }

    public void Hire()
    {
        Overlay.gameObject.SetActive(false);
        amountFarmed = level;
        isBought = true;
        rb.velocity = new Vector2(0, 0);
        animator.SetFloat("Velocity", 0);
        Resource[] foundResources = FindObjectsOfType<Resource>();
        foreach (Resource foundResource in foundResources)
        {
            if (foundResource.Type == resourceType)
            {
                if (foundResource.worker != null)
                {
                    Destroy(foundResource.worker.gameObject);
                }
                resourceManaged = foundResource;
                transform.position = new(resourceManaged.transform.position.x - 0.75f, resourceManaged.transform.position.y + 0.25f);
                foundResource.worker = this;
                break;
            }
        }
        StartCoroutine(IncrementEverySecond());
    }

    public void DisplayOverlay(Vector2 position)
    {
        if (!isBought)
        {
            Overlay.UpdateOverlay(price, resourceType, level, this);
            Overlay.gameObject.SetActive(true);
            Overlay.transform.position = position;
        }
    }

    public void Upgrade()
    {
        amountFarmed += 1;
    }

    IEnumerator IncrementEverySecond()
    {
        while (true)
        {
            resourceManaged.ManagerFarmed(amountFarmed);
            yield return new WaitForSeconds(1f);
        }
    }
}