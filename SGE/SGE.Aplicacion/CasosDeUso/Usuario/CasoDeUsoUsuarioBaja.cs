using SGE.Aplicacion.Interfaces;
public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repositorio):CasoDeUsoUsuario(repositorio) {
    public void Ejecutar(int idUsuario) {
        Repositorio.UsuarioBaja(idUsuario);
    }
}