using UnityEngine;

[CreateAssetMenu]
public class DogState : State
{
    [SerializeField] private GameObject dog;

    public override void Run()
    {
        if (isFinished)
            return;

        ActiveDog();
    }

    public void ActiveDog()
    {
        Instantiate(dog, enemy.transform.position, Quaternion.identity);
        isFinished = true;
    }
}
