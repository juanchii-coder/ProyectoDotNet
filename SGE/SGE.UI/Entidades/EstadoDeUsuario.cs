using System;
using Microsoft.AspNetCore.Components;
using SGE.Aplicacion.Entidades;

namespace SGE.UI.Entidades
{
    public class EstadoDeUsuario
    {
        public bool IsLoggedIn { get; set; } = false;
        public bool EsAdmin { get; set; } = false;
        public Usuario usuario { get; set; }

        // Evento para notificar cambios de estado
        public event Action OnChange;
        // Método para establecer el estado de inicio de sesión
        public void SetLoggedIn(bool isLoggedIn)
        {
            IsLoggedIn = isLoggedIn;
            NotifyStateChanged();
        }

        // Método para establecer el estado de administrador
        public void SetAdmin(bool esAdmin)
        {
            EsAdmin = esAdmin;
            NotifyStateChanged();
        }

        // Método para establecer el usuario
        public void SetUsuario(Usuario usuario)
        {
            usuario = usuario;
            NotifyStateChanged();
        }

        // Método para cerrar sesión
        public void CerrarSesion()
        {
            IsLoggedIn = false;
            EsAdmin = false;
            usuario = null;
            NotifyStateChanged();
        }

        // Método privado para notificar cambios de estado
        private void NotifyStateChanged()
        {
            OnChange?.Invoke(); // Invocar evento de cambio de estado
        }
    }
}
