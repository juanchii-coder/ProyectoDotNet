public class CasoDeUsoObtenerTodosLosUsuarios(IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio) {
    public List<Usuario> Ejecutar() {
        // Corroborar identidad de admin: Permiso.LeerTodosLosUsuarios
        return Repositorio.ObtenerTodosLosUsuarios();
    }
}