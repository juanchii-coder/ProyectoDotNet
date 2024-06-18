using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces
{
    public interface IPermisosRepositorio
    {
        void AsignarPermisoUsuario(int usuarioId, string permisoNombre);
        void RemoverPermisoUsuario(int usuarioId, string permisoNombre);
        bool UsuarioTienePermiso(int usuarioId, string permisoNombre);
        List<Permiso> PermisosDeUsuario(int usuarioId);
        void AgregarPermiso(Permiso permiso);
        void ModificarPermiso(Permiso permiso);
        void BorrarPermiso(string permisoNombre);
        List<int> UsuariosConPermiso(string permisoNombre);
        List<Permiso> ObtenerTodosLosPermisos();
        Permiso? ObtenerPermisoPorNombre(string nombre);
    }
}