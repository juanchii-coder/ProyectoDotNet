using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoLogin(IUsuarioRepositorio repositorio) : CasoDeUsoUsuario(repositorio) {
    public bool Ejecutar(Usuario usuario) {
        /*
            Autenticar Usuario
            return servicioAutenticacion(usuario.Email, usuario.Contrasenia);
        */
        return true;
    }
}