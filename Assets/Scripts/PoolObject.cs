using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    // Indica si el objeto est� activo en el pool
    public bool IsActive { get; private set; }

    // M�todo base para inicializar el objeto (puedes sobrescribirlo si lo necesitas)
    public virtual void OnActivate()
    {
        gameObject.SetActive(true);  // Hacer visible el objeto
        IsActive = true;  // Marcarlo como activo
    }

    // M�todo base para desactivar el objeto
    public virtual void OnDeactivate()
    {
        gameObject.SetActive(false);  // Ocultar el objeto
        IsActive = false;  // Marcarlo como inactivo
    }

    // M�todo opcional para resetear el estado del objeto (puedes sobrescribirlo)
    public virtual void ResetObject()
    {
        // Aqu� puedes poner l�gica de reseteo adicional si es necesario
    }

    // M�todo que ser� llamado cuando el objeto sea devuelto al pool
    public virtual void ReturnToPool()
    {
        OnDeactivate();  // Llamar a OnDeactivate para desactivar el objeto
    }
}
