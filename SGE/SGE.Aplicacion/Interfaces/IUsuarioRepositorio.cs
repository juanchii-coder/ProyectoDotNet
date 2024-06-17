using SGE.Aplicacion;
public interface IUsuarioRepositorio {
    Usuario? ObtenerUsuarioPorId(int idUsuario);
    List<Usuario> ObtenerTodosLosUsuarios();
    void UsuarioAlta(Usuario usuario);
    void UsuarioBaja(int idUsuario);
    void UsuarioModificacion(int idUsuario, Usuario usuario);
    void CambiarPermisosDeUsuario(int idUsuario, List<Permiso> permisos);
    Usuario? ObtenerUsuarioPorEmail(string email);
}