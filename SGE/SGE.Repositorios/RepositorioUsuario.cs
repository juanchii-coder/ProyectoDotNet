namespace SGE.Repositorios;
using SGE.Aplicacion.Entidades;
using SGE.Repositorios.Configuracion;
using SGE.Aplicacion.Interfaces;


public class RepositorioUsuario : IUsuarioRepositorio
{
    private readonly GestionExpedienteContext _db =new GestionExpedienteContext();

    public Usuario? ObtenerUsuarioPorId(int idUsuario)
    {
        return _db.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
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
        return _db.Usuarios.FirstOrDefault(u => u.Email == email);
    }
}