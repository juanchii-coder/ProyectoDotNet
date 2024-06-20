namespace SGE.Aplicacion.CasosDeUso.Usuario;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repositorio, IPermisosRepositorio repoPermiso, IServicioCodificacion codificador):CasoDeUsoUsuario(repositorio) {

    public void Ejecutar(Usuario usuario) {
        List<Usuario> usuarios = Repositorio.ObtenerTodosLosUsuarios();
        List<Permiso> permisos = new List<Permiso>();

        //Otorgo permisos de Admin segun si hay usuarios en la base de datos o no
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