using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DestructibleType
{
    Bush = 0,
    Box = 1,
    Projectile = 2
}
public class Destructible : MonoBehaviour
{
    [SerializeField] private DestructibleType destructibleType;
    [SerializeField] private GameObject destroyVFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>()) && other.gameObject.GetComponent<Destructible>()?.destructibleType != DestructibleType.Projectile)
        {
            var pickupSpawner = GetComponent<PickupSpawner>();
            if (pickupSpawner)
            {
                pickupSpawner.DropItems();
            }

            Instantiate(destroyVFX, transform.position, Quaternion.identity);

            switch (destructibleType)
            {
                case DestructibleType.Bush:
                    AudioManager.Instance.PlaySFX("ShakeBush");
                    break;
                case DestructibleType.Box:
                    AudioManager.Instance.PlaySFX("BoxCrash");
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
