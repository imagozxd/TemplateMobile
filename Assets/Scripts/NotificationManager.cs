using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    // ID único del canal de notificación. 
    // Usa un nombre representativo para tu canal, por ejemplo: "game_notification_channel"
    private const string channelId = "yourChannelId";

    private void Start()
    {
#if UNITY_ANDROID
       
        AndroidNotificationChannel androidNotificationChannel = new AndroidNotificationChannel
        {
            Id = channelId, 
            Name = "Nombre del canal de descripcion 'Game Notifications'",  
            Description = "Descripcion de la notificacion", 
            Importance = Importance.Default  // Nivel de importancia de las notificaciones
        };
        AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChannel);

        // Solicitar permisos para enviar notificaciones (no olvidar activar notificaciones en el celu)
        StartCoroutine(RequestNotificationPermission());
#endif
    }

    // Método para desencadenar una notificación en un tiempo específico
    public void TriggerNotification()
    {
        DateTime fireTime = DateTime.Now.AddSeconds(5f);  // Momento en que se dispara la notificación (aquí después de 5 segundos)
#if UNITY_ANDROID
        ScheduleNotification(fireTime);
#endif
    }

#if UNITY_ANDROID
    // Método para programar la notificación en un momento determinado
    public void ScheduleNotification(DateTime fireTime)
    {
        AndroidNotification androidNotification = new AndroidNotification
        {
            Title = "Your Notification Title",  // El título que aparecerá en la notificación
            Text = "Your notification message",  // El mensaje o texto que aparecerá en la notificación
            SmallIcon = "default",  // Ícono pequeño de la notificación (p. ej., "notification_icon")
            LargeIcon = "default",  // Ícono grande de la notificación (opcional)
            FireTime = fireTime  // Hora en que la notificación se mostrará
        };

        AndroidNotificationCenter.SendNotification(androidNotification, channelId);
    }

    // Método que se llama cuando la aplicación se pausa (por ejemplo, cuando el usuario minimiza la app)
    private void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            TriggerNotification();  // Envia cuando se pausa la app
        }
    }


    // Corutina para solicitar permiso 
    IEnumerator RequestNotificationPermission()
    {
        var request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
        {
            yield return null;
        }
    }
#endif
}
