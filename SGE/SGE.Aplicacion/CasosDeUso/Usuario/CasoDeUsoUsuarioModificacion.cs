public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio) {
    public void Ejecutar(int idUsuario, Usuario usuario) {
        Repositorio.UsuarioModificacion(idUsuario, usuario);
    }
}