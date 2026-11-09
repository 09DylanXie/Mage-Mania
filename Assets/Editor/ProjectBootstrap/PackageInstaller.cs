using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace ProjectBootstrap
{
    // One-off bootstrap: installs the project's core packages headless.
    public static class PackageInstaller
    {
        private static readonly string[] PackagesToAdd =
        {
            "com.unity.inputsystem",
            "com.unity.cinemachine",
            "com.unity.render-pipelines.universal",
            "com.unity.2d.tilemap.extras",
            "com.unity.2d.animation",
            "com.unity.test-framework",
        };

        private const double TimeoutSeconds = 600;
        private static AddAndRemoveRequest _request;
        private static double _deadline;

        public static void Install()
        {
            _request = Client.AddAndRemove(packagesToAdd: PackagesToAdd);
            _deadline = EditorApplication.timeSinceStartup + TimeoutSeconds;
            EditorApplication.update += Poll;
        }

        private static void Poll()
        {
            if (_request == null) return;
            if (!_request.IsCompleted)
            {
                if (EditorApplication.timeSinceStartup > _deadline)
                {
                    EditorApplication.update -= Poll;
                    Debug.LogError("[PackageInstaller] Timed out.");
                    EditorApplication.Exit(2);
                }
                return;
            }
            EditorApplication.update -= Poll;
            if (_request.Status == StatusCode.Success)
            {
                Debug.Log("[PackageInstaller] Resolved: " + string.Join(", ", _request.Result.Select(p => p.name + "@" + p.version)));
                EditorApplication.Exit(0);
            }
            else
            {
                Debug.LogError("[PackageInstaller] Failed: " + _request.Error?.message);
                EditorApplication.Exit(1);
            }
        }
    }
}
