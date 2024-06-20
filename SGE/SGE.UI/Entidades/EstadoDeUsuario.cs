﻿namespace SGE.UI.Entidades
{
public class EstadoDeUsuario
{
	public bool IsLoggedIn { get; set; } = false;
	public bool EsAdmin { get; set; } = false;
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

    private void NotifyStateChanged() => OnChange?.Invoke();

}
}
