namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;


    public interface IServicioPermiso
    {
        void AsignarPermisoUsuario(int usuarioId, string permisoNombre);
        void RemoverPermisoUsuario(int usuarioId, string permisoNombre);
        bool UsuarioTienePermiso(int usuarioId, string permisoNombre);
        List<Permiso> PermisosDeUsuario(int usuarioId);
        void AgregarPermiso(Permiso permiso);
        void ModificarPermiso(Permiso permiso);
        void BorrarPermiso(string permisoNombre);
        List<int> UsuariosConPermiso(string permisoNombre);
    }