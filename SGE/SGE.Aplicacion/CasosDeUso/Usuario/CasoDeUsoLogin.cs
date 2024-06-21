namespace SGE.Aplicacion.CasosDeUso.Usuario;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Exepciones;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoLogin(IUsuarioRepositorio repositorio,IServicioAutentificador autentificador ) : CasoDeUsoUsuario(repositorio) {
    private const string ERROR_MESSAGE = "Error en login - ";
    public Usuario Ejecutar(Usuario usuario) {
        if(!autentificador.ValidarLogin(usuario.Email, usuario.Contrasenia))
        {
            throw new AutorizacionException(ERROR_MESSAGE+"Credenciales Incorrectas");
        }
        Usuario usuarioLogeado = Repositorio.ObtenerUsuarioPorEmail(usuario.Email)!;
        return usuarioLogeado;
    }
}