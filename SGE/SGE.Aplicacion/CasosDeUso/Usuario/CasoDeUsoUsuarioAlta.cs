namespace SGE.Aplicacion.CasosDeUso.Usuario;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repositorio, IPermisosRepositorio repoPermiso):CasoDeUsoUsuario(repositorio) {

    public void Ejecutar(Usuario usuario) {
        List<Usuario> usuarios = Repositorio.ObtenerTodosLosUsuarios();
        List<Permiso> permisos = new List<Permiso>();

        //Otorgo permisos de Admin segun si hay usuarios en la base de datos o no
        if(!(usuarios.Count() == 0)) {
            permisos = repoPermiso.ObtenerTodosLosPermisos();
        } else {
            Permiso? tramiteLectura = repoPermiso.ObtenerPermisoPorNombre("TRAMITE_LECTURA");
            Permiso? expedienteLectura = repoPermiso.ObtenerPermisoPorNombre("EXPEDIENTE_LECTURA");
            if(tramiteLectura != null) permisos.Add(tramiteLectura);
            if(expedienteLectura != null) permisos.Add(expedienteLectura);
        }

        usuario.Permisos = permisos;
        Repositorio.UsuarioAlta(usuario);
    }
}