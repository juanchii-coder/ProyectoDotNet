﻿namespace SGE.UI.Entidades;
using SGE.Aplicacion.Entidades;
public class EstadoDeUsuario
{
	public bool IsLoggedIn { get; set; } = false;
	public bool EsAdmin { get; set; } = false;
	public Usuario? usuario { get; set;}
	public event Action? OnChange;

	public void SetLoggedIn(bool loggedIn)
	{
		IsLoggedIn = loggedIn;
		NotifyStateChanged();
	}
    public void SetAdmin(bool admin)
    {
        EsAdmin = admin;
        NotifyStateChanged();
    }
    public void CerrarSesion()
    {
        IsLoggedIn = false;
        EsAdmin = false;
        usuario = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();

}

