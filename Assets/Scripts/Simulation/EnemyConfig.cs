using UnityEngine;

public class EnemyConfig : MonoBehaviour {

    public virtual void PlaceSelf () {
        transform.position = new Vector3(Random.Range(10,140), 0, Random.Range(10,140));
    }
}
