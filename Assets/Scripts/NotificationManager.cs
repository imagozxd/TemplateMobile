using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    // ID �nico del canal de notificaci�n. 
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

    // M�todo para desencadenar una notificaci�n en un tiempo espec�fico
    public void TriggerNotification()
    {
        DateTime fireTime = DateTime.Now.AddSeconds(5f);  // Momento en que se dispara la notificaci�n (aqu� despu�s de 5 segundos)
#if UNITY_ANDROID
        ScheduleNotification(fireTime);
#endif
    }

#if UNITY_ANDROID
    // M�todo para programar la notificaci�n en un momento determinado
    public void ScheduleNotification(DateTime fireTime)
    {
        AndroidNotification androidNotification = new AndroidNotification
        {
            Title = "Your Notification Title",  // El t�tulo que aparecer� en la notificaci�n
            Text = "Your notification message",  // El mensaje o texto que aparecer� en la notificaci�n
            SmallIcon = "default",  // �cono peque�o de la notificaci�n (p. ej., "notification_icon")
            LargeIcon = "default",  // �cono grande de la notificaci�n (opcional)
            FireTime = fireTime  // Hora en que la notificaci�n se mostrar�
        };

        AndroidNotificationCenter.SendNotification(androidNotification, channelId);
    }

    // M�todo que se llama cuando la aplicaci�n se pausa (por ejemplo, cuando el usuario minimiza la app)
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
