public class CasoDeUsoObtenerUsuarioPorId(IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio) {
    public Usuario? Ejecutar(int idUsuario) {
        return Repositorio.ObtenerUsuarioPorId(idUsuario);
    }
}