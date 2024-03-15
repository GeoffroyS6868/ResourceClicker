using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public GameObject WorkerBase;

    public void Start()
    {
        WorkerBase.SetActive(false);
    }

    public void CreateNewCharacter(Vector2 position, Resource resource)
    {
        var NewCharacter = Instantiate(WorkerBase);
        NewCharacter.transform.position = position;
        NewCharacter.SetActive(true);
        var rcm = NewCharacter.GetComponent<Worker>();
        rcm.Start();
    }
}
