using Rust;
using UnityEngine;

namespace SafeZoneProtection
{
    [Info("SafeZoneAircraftProtection", "RustFlash", "1.0.0")]
    [Description("No Vehicle Damage in SafeZone")]
    public class SafeZoneProtection : RustPlugin
    {
        void OnEntityTakeDamage(BaseCombatEntity entity, HitInfo info)
        {
            if (entity is BaseVehicle && info != null && info.damageTypes.Has(DamageType.Decay))
            {
                if (Zones.Contains(entity.transform.position))
                {
                    info.damageTypes.ScaleAll(0f);
                    Puts("Vehicle damage prevented in safe zone");
                }
            }
        }
    }
}
