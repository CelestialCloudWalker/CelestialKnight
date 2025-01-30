using UnityEngine;
using Verse;

namespace CelestialKnights
{
    public class CelestialKnightsPawnOverlayNodeProperties : PawnRenderNodeProperties
    {
        public Color overlayColor = Color.white;
        public float overlayAlpha = 1f;
        public Vector3 offset = Vector3.zero;
        public float layerOffset = 0.1f;
        public Vector3 eastOffset = new Vector3(-1, 0, 0);
        public Vector3 westOffset = new Vector3(1, 0, 0);
        public GraphicData graphicData;
        public bool useBodyTypeVariants = false;

        public CelestialKnightsPawnOverlayNodeProperties()
        {
            this.nodeClass = typeof(CelestialKnightsPawnOverlayNode);
            this.workerClass = typeof(CelestialKnightsPawnOverlayNodeWorker);
        }
    }
}