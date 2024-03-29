using System.Collections;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public GameObject WorkerBase;
    public Canvas WorkerOverlay;
    private ResourceManager resourceManager;
    public int workersBought = 0;

    public void Start()
    {
        resourceManager = GetComponent<ResourceManager>();
        WorkerBase.SetActive(false);
        WorkerOverlay.gameObject.SetActive(false);
        WorkerOverlay.GetComponent<WorkerOverlay>().ResourceManager = resourceManager;
        StartCoroutine(SpawnerLoop());
    }

    public void CreateNewCharacter(Vector2 position)
    {
        var NewCharacter = Instantiate(WorkerBase);
        NewCharacter.transform.position = position;
        NewCharacter.SetActive(true);
        var worker = NewCharacter.AddComponent<Worker>();
        worker.Overlay = WorkerOverlay.GetComponent<WorkerOverlay>();
    }

    IEnumerator SpawnerLoop()
    {
        while (true)
        {
            CreateNewCharacter(new Vector2(-25.5f, -4.5f));
            yield return new WaitForSeconds(Random.Range(1, 2) * 60f);
        }
    }
}
