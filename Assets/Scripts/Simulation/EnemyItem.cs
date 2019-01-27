using UnityEngine;
using Zenject;
using Server;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(EnemyConfig))]
public class EnemyItem : MonoBehaviour {

    public class Factory : PlaceholderFactory<UnityEngine.Object, EnemyItem>
    {
    }

    public string EnemyName;
    public int Id;

    [Inject] private ServerSimulation serverSim;
    [Inject] private EnemySpawner spawner;

    private EnemyConfig _enemyConfig;
    private EnemyConfig enemyConfig {
        get {
            if(_enemyConfig == null) {
                _enemyConfig = GetComponent<EnemyConfig>();
            }
            return _enemyConfig;
        }
    }

    public EnemyInfo GetEnemyState() {
        return new EnemyInfo(EnemyName, new Vector3Sim(transform.position.x, transform.position.y, transform.position.z),  Id);
    }

    public virtual void PlaceSelf(int id) {
        enemyConfig.PlaceSelf();
        Id = id;
    }

    public void OnTriggerEnter(Collider collider) {
        var damagable = collider.GetComponent<IDamagable>();
        if(damagable != null) {
            damagable.GetHit(10);
        }
    }
}
