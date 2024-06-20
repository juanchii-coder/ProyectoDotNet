namespace SGE.Repositorios;
using SGE.Aplicacion.Entidades;
using SGE.Repositorios.Configuracion;
using SGE.Aplicacion.Interfaces;

public class RepositorioUsuario : IUsuarioRepositorio
{
    private readonly GestionExpedienteContext _db;
    public RepositorioUsuario(GestionExpedienteContext context) {
        _db = context;
    }

    public Usuario? ObtenerUsuarioPorId(int idUsuario)
    {
        Usuario? usuarioDb = _db.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
        if(usuarioDb != null) {
            usuarioDb.Permisos = _db.Usuarios
                           .Where(u => u.Id == idUsuario)
                           .SelectMany(u => u.Permisos)
                           .ToList();
        }
        return usuarioDb;
    }

    public List<Usuario> ObtenerTodosLosUsuarios()
    {
        return _db.Usuarios.ToList();
    }

    public void UsuarioAlta(Usuario usuario)
    {
        Usuario? usuarioDb = ObtenerUsuarioPorEmail(usuario.Email);
        if(usuarioDb == null) {
            _db.Add(usuario);
            _db.SaveChanges();
            Console.WriteLine("Usuario dado de alta");
        }
    }

    public void UsuarioBaja(int idUsuario)
    {
        Usuario? usuarioDb = ObtenerUsuarioPorId(idUsuario);
        if(usuarioDb != null) {
            _db.Usuarios.Remove(usuarioDb);
            _db.SaveChanges();
            Console.WriteLine("Usuario dado de baja");
        }
    }

    public void UsuarioModificacion(int idUsuario, Usuario usuario)
    {
        if(usuario != null) {
            Usuario? usuarioDb = ObtenerUsuarioPorId(idUsuario);
            if(usuarioDb != null) {
                usuarioDb.Nombre = usuario.Nombre;
                usuarioDb.Apellido = usuario.Apellido;
                usuarioDb.Email = usuario.Email;
                usuarioDb.Contrasenia = usuario.Contrasenia;
                
                _db.Update(usuarioDb);
                _db.SaveChanges();
                Console.WriteLine("Usuario Modificado");
            }
        }
    }

    public void CambiarPermisosDeUsuario(int idUsuario, List<Permiso> permisos)
    {
        Usuario? usuarioDb = ObtenerUsuarioPorId(idUsuario);
        if(usuarioDb != null) {
            usuarioDb.Permisos = permisos;
        }
    }

    public Usuario? ObtenerUsuarioPorEmail(string email) {
        Usuario? usuarioDb = _db.Usuarios.FirstOrDefault(u => u.Email == email);
        if(usuarioDb != null) {
            usuarioDb.Permisos = _db.Usuarios
                           .Where(u => u.Email == email)
                           .SelectMany(u => u.Permisos)
                           .ToList();
        }
        return usuarioDb;
    }
}