using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement; // For marking the scene dirty

public class ChangeMaterialEditor : EditorWindow
{
    public GameObject selectedPrefab;   // Prefab or GameObject whose materials will be changed
    public Material newMaterial;        // New material to apply

    // Add a menu item to open this editor window
    [MenuItem("Tools/Change Material In Editor")]
    public static void ShowWindow()
    {
        // Show the window
        GetWindow<ChangeMaterialEditor>("Change Material In Editor");
    }

    // GUI for the Editor window
    void OnGUI()
    {
        GUILayout.Label("Select Prefab or GameObject and New Material", EditorStyles.boldLabel);

        // Fields to select a prefab/GameObject and the new material
        selectedPrefab = (GameObject)EditorGUILayout.ObjectField("Prefab/GameObject", selectedPrefab, typeof(GameObject), true);
        newMaterial = (Material)EditorGUILayout.ObjectField("New Material", newMaterial, typeof(Material), false);

        // Create the Apply button
        if (GUILayout.Button("Apply Material"))
        {
            if (selectedPrefab != null && newMaterial != null)
            {
                ApplyMaterialToPrefab(selectedPrefab, newMaterial);
            }
            else
            {
                Debug.LogError("Please select both a prefab and a material.");
            }
        }
    }

    // Function to apply material changes to the selected prefab/GameObject
    void ApplyMaterialToPrefab(GameObject prefab, Material material)
    {
        // Get all renderers in the prefab or GameObject (including children)
        Renderer[] renderers = prefab.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            // Record undo so changes can be undone in the editor
            Undo.RecordObject(renderer, "Change Material");

            // Apply the new material
            renderer.sharedMaterial = material; // sharedMaterial applies to the actual asset, not just runtime instances

            // Mark the object as dirty to ensure the changes are saved
            EditorUtility.SetDirty(renderer);
        }

        // If it's a prefab, save the modifications
        if (PrefabUtility.IsPartOfPrefabAsset(prefab))
        {
            PrefabUtility.SavePrefabAsset(prefab);
            Debug.Log("Prefab material changed and saved.");
        }
        else
        {
            // Mark the scene as dirty to ensure changes are saved in the scene
            EditorSceneManager.MarkSceneDirty(prefab.scene);
            Debug.Log("GameObject material changed and scene marked dirty.");
        }
    }
}
