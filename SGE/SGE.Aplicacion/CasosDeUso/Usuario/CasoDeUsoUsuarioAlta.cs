namespace SGE.Aplicacion.CasosDeUso.Usuario;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repositorio, IPermisosRepositorio repoPermiso, IServicioCodificacion codificador):CasoDeUsoUsuario(repositorio) {

    public void Ejecutar(Usuario usuario) {
        if(usuario == null) {
            throw new ValidacionException("Usuario no puede ser null");
        } else if(usuario.Nombre == null || usuario.Apellido == null || usuario.Email == null || usuario.Contrasenia == null) {
            throw new ValidacionException("El usuario no puede tener campos nulos");
        } else if(usuario.Nombre.Trim().Equals("") || usuario.Apellido.Trim().Equals("") || usuario.Email.Trim().Equals("") || usuario.Contrasenia.Trim().Equals("")) {
            throw new ValidacionException("El usuario debe tener todos los campos completos sin espacios vacios");
        }

        List<Usuario> usuarios = Repositorio.ObtenerTodosLosUsuarios();
        List<Permiso> permisos = new List<Permiso>();
        if(usuarios.Count() == 0) {
            permisos = repoPermiso.ObtenerTodosLosPermisos();
        } else {
            permisos.Add(repoPermiso.ObtenerPermisoPorNombre("TRAMITE_LECTURA")!);
            permisos.Add(repoPermiso.ObtenerPermisoPorNombre("EXPEDIENTE_LECTURA")!);
        }

        usuario.Permisos = permisos;
        usuario.Contrasenia = codificador.codificarContrasenia(usuario.Contrasenia);
        Repositorio.UsuarioAlta(usuario);
    }
}