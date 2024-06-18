using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;


namespace SGE.Servicios
{
    public class ServicioPermiso(IPermisosRepositorio permisoRepo) : IServicioPermiso
    {
        public void AsignarPermisoUsuario(int usuarioId, string permisoNombre)
        {
            permisoRepo.AsignarPermisoUsuario(usuarioId, permisoNombre);
        }

        public void RemoverPermisoUsuario(int usuarioId, string permisoNombre)
        {
            permisoRepo.RemoverPermisoUsuario(usuarioId, permisoNombre);
        }

        public bool UsuarioTienePermiso(int usuarioId, string permisoNombre)
        {
            return permisoRepo.UsuarioTienePermiso(usuarioId, permisoNombre);
        }

        public List<Permiso> PermisosDeUsuario(int usuarioId)
        {
            return permisoRepo.PermisosDeUsuario(usuarioId);
        }

        public void AgregarPermiso(Permiso permiso)
        {
            permisoRepo.AgregarPermiso(permiso);
        }

        public void ModificarPermiso(Permiso permiso)
        {
            permisoRepo.ModificarPermiso(permiso);
        }

        public void BorrarPermiso(string permisoNombre)
        {
            permisoRepo.BorrarPermiso(permisoNombre);
        }

        public List<int> UsuariosConPermiso(string permisoNombre)
        {
            return permisoRepo.UsuariosConPermiso(permisoNombre);
        }
    }
}
