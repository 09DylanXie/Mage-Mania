using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ProjectBootstrap
{
    // One-off bootstrap: creates a 2D URP renderer + pipeline asset and assigns it.
    public static class UrpSetup
    {
        private const string Folder = "Assets/_Project/Settings";

        public static void Run()
        {
            var renderer = ScriptableObject.CreateInstance<Renderer2DData>();
            AssetDatabase.CreateAsset(renderer, Folder + "/Renderer2D.asset");

            var pipeline = UniversalRenderPipelineAsset.Create(renderer);
            AssetDatabase.CreateAsset(pipeline, Folder + "/UniversalRP.asset");

            GraphicsSettings.defaultRenderPipeline = pipeline;
            for (int i = 0; i < QualitySettings.names.Length; i++)
            {
                QualitySettings.SetQualityLevel(i, false);
                QualitySettings.renderPipeline = pipeline;
            }

            AssetDatabase.SaveAssets();
            Debug.Log("[UrpSetup] 2D URP assigned.");
            EditorApplication.Exit(0);
        }
    }
}
