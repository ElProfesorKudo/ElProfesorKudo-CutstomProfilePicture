using UnityEngine;
using System;

namespace ElProfesorKudo
{
    [ExecuteInEditMode]
    public class MaskSprites : SpriteAtlasAbstract
    {
        public enum MaskSpritesElements
        {
            ArrowUpWhiteMask,
            Circle1WhitheMask,
            Circle2WhiteMask,
            Circle3WhiteMask,
            Circle4WhiteMask,
            Circle5WhiteMask,
            Circle6WhiteMask,
            Circle7WhiteMask,
            Circle8WhiteMask,
            CloverWhiteMask,
            Cross1WhiteMask,
            Cross2WhiteMask,
            Cross3WhiteMask,
            Diamond1WhiteMask,
            Diamond2WhiteMask,
            FullCylinderWhiteMask,
            HalfCylindeWhiteMask,
            HeartsWhiteMask,
            ParallelogramWhiteMask,
            PentagoneWhiteMask,
            QuarterCircleWhiteMask,
            RectangleVariantWhiteMask,
            SpeechBubbleWhiteMask,
            Square1WhiteMask,
            Square2WhiteMask,
            Square3WhiteMask,
            StainWhiteMask,
            Star1WhiteMask,
            Star2WhiteMask,
            Star3WhiteMask,
            Triangle1WhiteMask,
            Triangle2WhiteMask
        }

        [SerializeField] private MaskSpritesElements _maskElement;

        protected override void OnValidate()
        {
            _defaultValue = _maskElement.ToString();
            base.OnValidate();
        }

#if UNITY_EDITOR
        public void SetDefaultSpriteViaMenu()
        {
            if (_spriteAtlas != null)
            {
                // We take the default sprite circle, keep in mind if you mess with the order of the enum you ll maybe have another default maskElement
                _maskElement = (MaskSpritesElements)1;
                SetSpriteFromSpriteAtlasToImage(_spriteAtlas, _maskElement.ToString());
            }
        }
#endif
    }
}
