#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Development.Public.Mvp.Editor
{
    public class MVPGenerator : EditorWindow
    {
        private string prefix = "Sample";

        [MenuItem("Assets/Create/MVP", false, 0)]
        public static void ShowWindow()
        {
            GetWindow<MVPGenerator>("MVP Generator");
        }

        private void OnGUI()
        {
            GUILayout.Label("Enter Prefix for MVP Scripts", EditorStyles.boldLabel);
            prefix = EditorGUILayout.TextField("Prefix", prefix);

            if (GUILayout.Button("Create MVP Scripts"))
            {
                CreateMVPScripts(prefix);
                Close();
            }
        }

        private void CreateMVPScripts(string prefix)
        {
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (!AssetDatabase.IsValidFolder(folderPath))
            {
                Debug.LogError("Please select a valid folder in the Project window.");
                return;
            }

            CreatePresenterScript(prefix, folderPath);
            CreateModelConfigDataScript(prefix, folderPath);
            CreateModelSettingsScript(prefix, folderPath);
            CreateModelScript(prefix, folderPath);
            CreateViewReferencesScript(prefix, folderPath);
            CreateViewScript(prefix, folderPath);
            CreateEventsScript(prefix, folderPath);

            AssetDatabase.Refresh();
        }

        private static void CreatePresenterScript(string prefix, string folderPath)
        {
            string scriptContent = $@"
using Cysharp.Threading.Tasks;
using Development.Public.Mvp;

namespace Development.Core.Elements.{prefix}
{{
    public class {prefix}Presenter : BasePresenter<{prefix}View, {prefix}Model, {prefix}Events>
    {{
        protected override async UniTask InitPresenter()
        {{
            await UniTask.CompletedTask;
        }}

        public override void Dispose()
        {{
        }}
    }}
}}
";
            File.WriteAllText(Path.Combine(folderPath, $"{prefix}Presenter.cs"), scriptContent);
        }

        private static void CreateModelScript(string prefix, string folderPath)
        {
            string scriptContent = $@"
using System;
using Development.Public.Mvp;

namespace Development.Core.Elements.{prefix}
{{
    [Serializable]
    public class {prefix}Model : BaseModel<{prefix}ModelConfigData,{prefix}ModelSettings>
    {{
    }}
}}
";
            File.WriteAllText(Path.Combine(folderPath, $"{prefix}Model.cs"), scriptContent);
        }

        private static void CreateModelConfigDataScript(string prefix, string folderPath)
        {
            string scriptContent = $@"
using System;
using Development.Public.Mvp;

namespace Development.Core.Elements.{prefix}
{{
    [Serializable]
    public class {prefix}ModelConfigData : BaseModelConfigData
    {{
    }}
}}
";
            File.WriteAllText(Path.Combine(folderPath, $"{prefix}ModelConfigData.cs"), scriptContent);
        }

        private static void CreateModelSettingsScript(string prefix, string folderPath)
        {
            string scriptContent = $@"
using Development.Public.Mvp;
using UnityEngine;

namespace Development.Core.Elements.{prefix}
{{
    [CreateAssetMenu(menuName = ""MVP_SO/{prefix}Settings"", fileName = ""{prefix}Settings_SO"")]
    public class {prefix}ModelSettings : BaseModelSettings
    {{
    }}
}}
";
            File.WriteAllText(Path.Combine(folderPath, $"{prefix}ModelSettings.cs"), scriptContent);
        }

        private static void CreateViewScript(string prefix, string folderPath)
        {
            string scriptContent = $@"
using System;
using Development.Public.Mvp;

namespace Development.Core.Elements.{prefix}
{{
    [Serializable]
    public class {prefix}View : BaseView<{prefix}ViewReferences>
    {{
    }}
}}
";
            File.WriteAllText(Path.Combine(folderPath, $"{prefix}View.cs"), scriptContent);
        }

        private static void CreateViewReferencesScript(string prefix, string folderPath)
        {
            string scriptContent = $@"
using System;
using Development.Public.Mvp;

namespace Development.Core.Elements.{prefix}
{{
    [Serializable]
    public class {prefix}ViewReferences : BaseViewReferences
    {{
    }}
}}
";
            File.WriteAllText(Path.Combine(folderPath, $"{prefix}ViewReferences.cs"), scriptContent);
        }

        private static void CreateEventsScript(string prefix, string folderPath)
        {
            string scriptContent = $@"
using System;
using Development.Public.Mvp;

namespace Development.Core.Elements.{prefix}
{{
    [Serializable]
    public class {prefix}Events : BaseEvents
    {{
    }}
}}
";
            File.WriteAllText(Path.Combine(folderPath, $"{prefix}Events.cs"), scriptContent);
        }
    }
}

#endif