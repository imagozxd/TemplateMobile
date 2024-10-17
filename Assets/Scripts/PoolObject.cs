using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    // Indica si el objeto está activo en el pool
    public bool IsActive { get; private set; }

    // Método base para inicializar el objeto (puedes sobrescribirlo si lo necesitas)
    public virtual void OnActivate()
    {
        gameObject.SetActive(true);  // Hacer visible el objeto
        IsActive = true;  // Marcarlo como activo
    }

    // Método base para desactivar el objeto
    public virtual void OnDeactivate()
    {
        gameObject.SetActive(false);  // Ocultar el objeto
        IsActive = false;  // Marcarlo como inactivo
    }

    // Método opcional para resetear el estado del objeto (puedes sobrescribirlo)
    public virtual void ResetObject()
    {
        // Aquí puedes poner lógica de reseteo adicional si es necesario
    }

    // Método que será llamado cuando el objeto sea devuelto al pool
    public virtual void ReturnToPool()
    {
        OnDeactivate();  // Llamar a OnDeactivate para desactivar el objeto
    }
}
