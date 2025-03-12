using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace CelestialKnights
{
    public class CompProperties_SuitTransformEffect : CompProperties_AbilityEffect
    {
        public bool lightning = true;
        public float visualRadius = 3f;
        public SoundDef sound;

        public CompProperties_SuitTransformEffect()
        {
            compClass = typeof(CompAbilityEffect_SuitTransform);
        }
    }

    public class CompAbilityEffect_SuitTransform : CompAbilityEffect
    {
        public new CompProperties_SuitTransformEffect Props => (CompProperties_SuitTransformEffect)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Map map = parent.pawn.Map;
            IntVec3 effectLocation = parent.pawn.Position;

            // Create visual lightning effects
            CreateLightningVisuals(effectLocation, map);

            // Play sound effect if specified
            if (Props.sound != null)
            {
                Props.sound.PlayOneShot(SoundInfo.InMap(new TargetInfo(effectLocation, map)));
            }
        }

        private void CreateLightningVisuals(IntVec3 position, Map map)
        {
            // Create a bigger bright flash
            FleckMaker.Static(position, map, FleckDefOf.LightningGlow, 4f);  // Increased size from default

            // Create the lightning bolt visual with increased size
            Vector3 loc = position.ToVector3Shifted();
            loc.y = AltitudeLayer.Weather.AltitudeFor();
            FleckMaker.ThrowLightningGlow(loc, map, 3.0f);  // Increased size

            // Add some enhanced smoke effects
            FleckMaker.ThrowSmoke(loc, map, 2.0f);  // Increased size

            // Additional effects for more visual impact
            FleckMaker.ThrowMicroSparks(loc, map);
            FleckMaker.ThrowHeatGlow(position, map, 2.5f);  // Increased size
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            return base.Valid(target, throwMessages) && parent.pawn.Position.Standable(parent.pawn.Map);
        }
    }
}