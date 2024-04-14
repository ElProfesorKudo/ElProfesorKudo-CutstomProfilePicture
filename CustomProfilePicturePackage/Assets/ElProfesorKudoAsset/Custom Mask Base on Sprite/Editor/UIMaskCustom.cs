using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

namespace ElProfesorKudo
{
    public class UIMaskCustom : Editor
    {
        // Menu item to add a UI object with UI elements on right-click
        [MenuItem("GameObject/UI/ElProfesorKudoUI/Custom UI Image Mask", false, 0)]
        private static void AddCustomUIObject(MenuCommand menuCommand)
        {
            // Create a new UI GameObject
            GameObject containerMask = new GameObject("Container Mask");

            Canvas canvas = FindObjectOfType<Canvas>();

            if (canvas == null)
            {
                // If no Canvas found, create a new one
                GameObject canvasObject = new GameObject("Canvas");
                canvas = canvasObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
                canvasScaler.referenceResolution = new Vector2(1920, 1080);
                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                canvasObject.AddComponent<GraphicRaycaster>();
            }

            // Set the Canvas as the parent of the UI object
            containerMask.transform.SetParent(canvas.transform, false);



            RectTransform containerMaskRectTransform = containerMask.AddComponent<RectTransform>();
            // Default size of the mask is 200 * 200 
            containerMaskRectTransform.sizeDelta = Vector2.one * 200;
            containerMaskRectTransform.anchorMin = Vector2.one * 0.5f;
            containerMaskRectTransform.anchorMax = Vector2.one * 0.5f;


            // Create a UI image mask as a child
            GameObject imageMask = new GameObject("Mask Wanted");
            imageMask.transform.SetParent(containerMask.transform, false);

            RectTransform imageMaskRectTransform = imageMask.AddComponent<RectTransform>();
            imageMaskRectTransform.anchorMin = Vector2.zero;
            imageMaskRectTransform.anchorMax = Vector2.one;
            imageMaskRectTransform.sizeDelta = Vector2.zero;

            imageMask.AddComponent<Image>();
            imageMask.AddComponent<Mask>();

            MaskSprites maskSprites = imageMask.AddComponent<MaskSprites>();
            string pathStoreMySpriteAtlas = "Assets/ElProfesorKudoAsset/Custom Mask Base on Sprite/SpritesAtlas/MaskSprites.spriteatlas";
            SpriteAtlas mySprteAtlas = AssetDatabase.LoadAssetAtPath<SpriteAtlas>(pathStoreMySpriteAtlas);
            if (mySprteAtlas == null)
            {
                Debug.LogWarning("The sprite Atlas cannot be found on this path : " + pathStoreMySpriteAtlas);
                Debug.LogWarning("Make sure to have you sprite Atlas in this path");
                Debug.LogWarning("If you moved it you can always change the path of the variable pathStoreMySpriteAtlas and put the new path");
            }
            else
            {
                maskSprites.SetSpritesAtlasViaMenu(mySprteAtlas);
                maskSprites.SetDefaultSpriteViaMenu();
            }


            // Create a UI image for user as a child of mask image
            GameObject imageUser = new GameObject("Image user");
            imageUser.transform.SetParent(imageMask.transform, false);

            RectTransform imageUserRectTransform = imageUser.AddComponent<RectTransform>();
            imageUserRectTransform.anchorMin = Vector2.zero;
            imageUserRectTransform.anchorMax = Vector2.one;
            imageUserRectTransform.sizeDelta = Vector2.zero;

            imageUser.AddComponent<Image>();


            // Ensure the UI object is selected and set it as the active selection
            Selection.activeObject = containerMask;

            // Set the UI object as the parent if a specific object is selected in the hierarchy
            if (menuCommand.context is GameObject selectedObject)
            {
                containerMask.transform.SetParent(selectedObject.transform, false);
            }

            // Notify about the creation of the UI object
            Debug.Log("your custom UI mask elements has added to the hierarchy.");
        }
    }
}
