using SGE.Aplicacion.Interfaces;
public abstract class CasoDeUsoUsuario(IUsuarioRepositorio repositorio) {
    protected IUsuarioRepositorio Repositorio { get; } = repositorio;
}