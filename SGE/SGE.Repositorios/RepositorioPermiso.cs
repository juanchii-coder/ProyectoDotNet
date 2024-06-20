namespace SGE.Repositorios;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Repositorios.Configuracion;

public class PermisosRepositorio : IPermisosRepositorio
{
    private readonly GestionExpedienteContext _contexto;
    public PermisosRepositorio(GestionExpedienteContext context) {
        _contexto = context;
    }
     public void AsignarPermisoUsuario(int usuarioId, string permisoNombre)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            var permiso = _contexto.Permisos.FirstOrDefault(p => p.Nombre == permisoNombre);

            if (usuario != null && permiso != null)
            {
                usuario.Permisos.Add(permiso);
                _contexto.SaveChanges();
                
            }
        }
    
    public void RemoverPermisoUsuario(int usuarioId, string permisoNombre)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.Id == usuarioId);

            if (usuario != null)
            {
                var permiso = usuario.Permisos.FirstOrDefault(p => p.Nombre == permisoNombre);
                if (permiso != null)
                {
                    usuario.Permisos.Remove(permiso);                    
                    _contexto.SaveChanges();
                }
            }
        }
    public bool UsuarioTienePermiso(int usuarioId, string permisoNombre)
        {
            return _contexto.Usuarios
                           .Any(u => u.Id == usuarioId && u.Permisos.Any(p => p.Nombre== permisoNombre));
        }

    public List<Permiso> PermisosDeUsuario (int usuarioId)
        {
            return _contexto.Usuarios
                           .Where(u => u.Id == usuarioId)
                           .SelectMany(u => u.Permisos)
                           .ToList();
        }
    public void AgregarPermiso(Permiso permiso)
        {
            _contexto.Permisos.Add(permiso);
            _contexto.SaveChanges();
        }
    public void ModificarPermiso(Permiso permiso)
        {
            _contexto.Permisos.Update(permiso);
            _contexto.SaveChanges();
        }
    
    public void BorrarPermiso(string permisoNombre)
        {
             var permiso = _contexto.Permisos.FirstOrDefault(p => p.Nombre == permisoNombre);
    
             if (permiso != null)
                {
                    _contexto.Permisos.Remove(permiso);                    
                    _contexto.SaveChanges();
                 }
        }
    public List<int> UsuariosConPermiso(string permisoNombre)
        {
            return _contexto.Permisos
                           .Where(p => p.Nombre == permisoNombre)
                           .SelectMany(p => p.Usuarios)
                           .Select(u => u.Id)
                           .ToList();
        }

    public List<Permiso> ObtenerTodosLosPermisos()
    {
        return _contexto.Permisos.ToList();
    }

    public Permiso? ObtenerPermisoPorNombre(string nombre)
    {
        return _contexto.Permisos.FirstOrDefault(p => p.Nombre == nombre);
    }
}