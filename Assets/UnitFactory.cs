using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    public UnitMoveAI prefab;
    public List<Player> players;

    public void Start()
    {
        StartCoroutine(Cor());
    }
    
    public IEnumerator Cor()
    {
        while(true)
        {
            var units = GameObject.FindGameObjectsWithTag("unit");
            if (units.Count() < 10)
            {
                var unit = players.GetRandomElement();
                Instantiate(prefab, transform.position, Quaternion.identity).SetUnit(unit);
                
                yield return new WaitForSeconds(Random.Range(2, 5));
            }
        }
    }
}
