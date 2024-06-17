using SGE.Entidades;
using SGE;

namespace SGE.Repositorios

public class PermisosRepositorio
{
    private readonly PermisoDbContext  contexto;

     public PermisoRepository(PermissionDbContext contexto)
        {
           contexto = context;
        }
     public void AsignarPermisoUsuario(int usuarioId, string permisoNombre)
        {
            var usuario = contexto.GetUsuario(usuarioId);
            var permiso = contexto.Permisos.FirstOrDefault(p => p.nombre == permisoNombre);

            if (usuario != null && permiso != null)
            {
                usuario.Permisos.Add(permiso);
                
            }
        }
    
    public void RemoverPermisoUsuario(int usuarioId, string permisoNombre)
        {
            var usuario = contexto.GetUsuario(usuarioId);

            if (usuario != null)
            {
                var permiso = usuario.Permisos.FirstOrDefault(p => p.Nombre == permisoNombre);
                if (permiso != null)
                {
                    usuario.Permisos.Remove(permiso);                    
                }
            }
        }
    public bool UsuarioTienePermiso(int usuarioId, string permisoNombre)
        {
            return contexto.Usuarios
                           .Any(u => u.Id == usuarioId && u.Permisos.Any(p => p.Nombre== permisoNombre));
        }

    public List<Permiso> PermisosDeUsuario (int usuarioId)
        {
            return contexto.Usuarios
                           .Where(u => u.Id == usuarioId)
                           .SelectMany(u => u.Permisos)
                           .ToList();
        }
    public void AgregarPermiso(Permiso permiso)
        {
            contexto.Permisos.Add(permiso);
        }
    public void ModificarPermiso(Permiso permiso)
        {
            contexto.Permisos.Update(permiso);
        }
    
    public void BorrarPermiso(string permisoNombre)
        {
             var permiso = contexto.Permisos.FirstOrDefault(p => p.nombre == permisoNombre);
    
             if (permiso != null)
                {
                    contexto.Permisos.Remove(permiso);                    
                 }
        }
    public List<int> UsuariosConPermiso(string permisoNombre)
        {
            return contexto.Permisos
                           .Where(p => p.Nombre == permisoNombre)
                           .SelectMany(p => p.Usuarios)
                           .Select(u => u.Id)
                           .ToList();
        }
}