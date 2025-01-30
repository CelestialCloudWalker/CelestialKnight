using UnityEngine;
using Verse;

namespace CelestialKnights
{
    public class CelestialKnightsPawnOverlayNode : PawnRenderNode
    {
        public new CelestialKnightsPawnOverlayNodeProperties Props => (CelestialKnightsPawnOverlayNodeProperties)props;

        public CelestialKnightsPawnOverlayNode(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree) : base(pawn, props, tree)
        {

        }

        public override Graphic GraphicFor(Pawn pawn)
        {
            string texPath = Props.useBodyTypeVariants ? GetBodyTypeTexPath(pawn) : Props.graphicData.texPath;
            return GraphicDatabase.Get<Graphic_Multi>(
                texPath,
                base.ShaderFor(pawn),
                Props.graphicData.drawSize,
                base.ColorFor(pawn),
                Props.graphicData.colorTwo
            );
        }

        private string GetBodyTypeTexPath(Pawn pawn)
        {
            string basePath = Props.graphicData.texPath;

            // Return base path if pawn or story is null
            if (pawn?.story?.bodyType == null) return basePath + "Male";

            return basePath + $"_{pawn.story.bodyType.defName}";
        }




        public override Color ColorFor(Pawn pawn)
        {
            return base.ColorFor(pawn);
        }
    }
}