using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject CharacterBase;

    public void Start()
    {
        CharacterBase.SetActive(false);
    }

    public void CreateNewCharacter(Vector2 position, Resource resource)
    {
        var NewCharacter = Instantiate(CharacterBase);
        NewCharacter.transform.position = position;
        NewCharacter.SetActive(true);
        var rcm = NewCharacter.GetComponent<ResourceCharacterManager>();
        rcm.StartCharacter(resource);
    }
}
