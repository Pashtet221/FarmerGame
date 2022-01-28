using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3f;

    private void OnEnable()
    {
        StartCoroutine("LifeRoutine");
    }

    private void OnDisable()
    {
        StopCoroutine("LifeRoutine");
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Diactivate();
    }

    private void Diactivate()
    {
        this.gameObject.SetActive(false);
    }
}
