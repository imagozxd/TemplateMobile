using UnityEngine;

// Esta clase hereda de ScriptableObject, permitiendo que se creen instancias de este tipo de datos en el editor.
[CreateAssetMenu(fileName = "NuevoScriptable", menuName = "ScriptablesConfigurables/ScriptablesData")]
public class BaseScriptableTemplate : ScriptableObject
{
    // Atributos públicos que serán configurables en el inspector de Unity.
    // Puedes modificar o agregar más según lo que necesites en cada caso.

    [Header("Basic Info")]
    [Tooltip("Nombre representativo del objeto o entidad")] //esto es re util
    public string objectName;  

    [Tooltip("Descripción general")]
    public string description; 

    [Header("Numeric Values")]
    [Tooltip("Puntos de vida o cualquier valor numérico relacionado")]
    public int health;  

    [Tooltip("Velocidad de movimiento o cualquier otra variable numérica")]
    public float speed;  

    [Header("Other Settings")]
    [Tooltip("Añade cualquier objeto o referencia que se necesite")]

    public GameObject modelPrefab; 

    
}
