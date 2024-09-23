using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    [SerializeField] protected GameObject _prefabAmmunition;
    protected const float _speed = 0.5f;
    public virtual void Shoot(int levelPlayer) { }
    public void DestroyAmmunition() => Destroy(this.gameObject);

}
