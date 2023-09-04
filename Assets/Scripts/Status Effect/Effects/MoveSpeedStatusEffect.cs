// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [CreateAssetMenu]
// public class MoveSpeedStatusEffect : StatusEffect
// {
//     public new void HandleEffect(Entity entity)
//     {
//         currentEffectTime += Time.deltaTime;
//         if (currentEffectTime >= lifeTime) {
//             //entity.RemoveEffect();
//             return;
//         }

//         if (DOTAmount != 0 && currentEffectTime > lastTickTime + tickSpeed) {
//             lastTickTime = currentEffectTime; 
//             entity.TakeDamage(DOTAmount);
//         }
//     }
// }
