using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

namespace ElProfesorKudo
{
    [ExecuteInEditMode]
    public class SpriteAtlasAbstract : MonoBehaviour
    {
        [SerializeField] protected SpriteAtlas _spriteAtlas;

        protected Image _imageContainer;
        protected string _defaultValue = "";

        protected virtual void Start()
        {
            // Case instantiate
            if (_imageContainer == null)
            {
                _imageContainer = this.gameObject.GetComponent<Image>();
            }
        }

        protected void SetSpriteFromSpriteAtlasToImage(SpriteAtlas spriteAtlas, string spriteName)
        {
            _imageContainer.sprite = spriteAtlas.GetSprite(spriteName);
        }

        // This function get call each time value on editor change
        protected virtual void OnValidate()
        {
            if (_imageContainer == null)
            {
                _imageContainer = this.gameObject.GetComponent<Image>();
            }
            if (_spriteAtlas != null && _imageContainer != null)
            {
                SetSpriteFromSpriteAtlasToImage(_spriteAtlas, _defaultValue);
            }

        }

#if UNITY_EDITOR
        public void SetSpritesAtlasViaMenu(SpriteAtlas spriteAtlas)
        {
            _spriteAtlas = spriteAtlas;
        }
#endif
    }
}