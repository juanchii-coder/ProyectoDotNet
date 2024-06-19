namespace SGE.Aplicacion.CasosDeUso.Usuario;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Exepciones;

public class CasoDeUsoOtorgarPermisos(IUsuarioRepositorio repositorio, IServicioPermiso autorizacion):CasoDeUsoUsuario(repositorio) {
    private const string PERMISO_ADMIN = "CAMBIO_DE_PERMISOS";
    private const string ERROR_MESSAGE="Error en el Cambio de Permisos - ";
    public void Ejecutar(int idAdmin, int idUsuario, List<Permiso> permisos) {
        // Corroboro permiso de ADMIN
        if(autorizacion.UsuarioTienePermiso(idAdmin, PERMISO_ADMIN))
            Repositorio.CambiarPermisosDeUsuario(idUsuario, permisos);
        else 
            throw new AutorizacionException(ERROR_MESSAGE + "Se necesita permiso de administrador para realizar el cambio");
    }
}