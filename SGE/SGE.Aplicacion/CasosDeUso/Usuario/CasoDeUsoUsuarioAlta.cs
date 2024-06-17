using SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio) {
    private static bool hayAlguno = false;

    public void Ejecutar(Usuario usuario) {
        
        if(!hayAlguno) {
            List<Usuario> listaUsuarios= Repositorio.ObtenerTodosLosUsuarios();
            usuario.Permisos = new List<Permiso> {Permiso.TramiteLectura, Permiso.TramiteModificacion, Permiso.TramiteAlta,
            Permiso.TramiteBaja, Permiso.ExpedienteLectura, Permiso.ExpedienteAlta, Permiso.ExpedienteBaja, Permiso.ExpedienteModificacion};
            hayAlguno = true;
        } else {
            usuario.Permisos = new List<Permiso> {Permiso.TramiteLectura, Permiso.ExpedienteLectura};
        }
        Repositorio.UsuarioAlta(usuario);
    }
}