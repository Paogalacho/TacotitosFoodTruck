using System;
using System.Windows.Forms;

public static class Prompt
{
    // Mostrar un cuadro de entrada de texto simple
    public static string ShowDialog(string text, string caption, string defaultValue = "")
    {
        string result = Microsoft.VisualBasic.Interaction.InputBox(
            text,     // Texto a mostrar
            caption,  // Título de la ventana
            defaultValue, // Valor por defecto
            -1,       // Posición X en la pantalla
            -1        // Posición Y en la pantalla
        );
        return result;
    }
}