namespace SGE.Aplicacion.CasosDeUso.Usuario;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Exepciones;

public class CasoDeUsoObtenerTodosLosUsuarios(IUsuarioRepositorio repositorio, IServicioPermiso autorizacion):CasoDeUsoUsuario(repositorio) {
    private const string PERMISO_ADMIN = "OBTENER_LISTA_USUARIOS";
    private const string ERROR_MESSAGE="Error al obtener lista de usuarios - ";
    public List<Usuario> Ejecutar(int idUsuario) {
        //Corroboro permiso de ADMIN
        if(!autorizacion.UsuarioTienePermiso(idUsuario, PERMISO_ADMIN))
            throw new AutorizacionException(ERROR_MESSAGE + "Se necesita permiso de administrador para realizar el cambio");
        return Repositorio.ObtenerTodosLosUsuarios();
    }
}