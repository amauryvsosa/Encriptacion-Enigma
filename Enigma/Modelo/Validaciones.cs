using System.Windows.Forms;

namespace Enigma.Modelo {
    public class Validaciones {
        private TextBox TextBoxEncriptar { get; set; }
        private TextBox TextBoxDesencriptar { get; set; }
        private TextBox TextBoxResultado { get; set; }

        private int contadorMensajesAmbasOperaciones;
        private bool mostrarMensaje = true;
        private int operacionElegida = -1;
        private int contadorMensajes;

        public Validaciones(TextBox textBoxEncriptar, TextBox textBoxDesencriptar, TextBox textBoxResultado) {
            TextBoxEncriptar = textBoxEncriptar;
            TextBoxDesencriptar = textBoxDesencriptar;
            TextBoxResultado = textBoxResultado;
        }

        public bool SonValidosTextboxesOperacion() {
            return TextBoxCorrectos(TextBoxEncriptar, TextBoxDesencriptar) && ValidarTextBoxResultado(TextBoxResultado);
        }

        public void LimpiarTextBoxResultado() {
            TextBoxResultado.Clear();
        }

        public bool PreguntarDarFormato(string tipoFormato) {
            // El texto desencriptado es JSON
            DialogResult resultado = MessageBox.Show($"El texto desencriptado es {tipoFormato}. " +
                $"¿Desea ver la cadena original (Sí) o la formateada (No)?", "Opciones", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes) {
                // El usuario eligió ver la cadena original
                return true;
            } else {
                // El usuario eligió ver la cadena formateada
                return false;
            }
        }

        // Método para evaluar los TextBox de encriptar y desencriptar
        private bool TextBoxCorrectos(TextBox textBoxEncriptar, TextBox textBoxDesencriptar) {
            string textoEncriptar = textBoxEncriptar.Text.Trim();
            string textoDesencriptar = textBoxDesencriptar.Text.Trim();

            // Verificar si ambos están vacíos
            if (string.IsNullOrEmpty(textoEncriptar) && string.IsNullOrEmpty(textoDesencriptar)) {
                MessageBox.Show("Ambos TextBox están vacíos. Ingrese información para encriptar o desencriptar.",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Verificar si ambos contienen información
            else if (!string.IsNullOrEmpty(textoEncriptar) && !string.IsNullOrEmpty(textoDesencriptar)) {
                bool encriptarEsOperacionActiva = !textBoxEncriptar.ReadOnly;
                if (contadorMensajesAmbasOperaciones < 3 && contadorMensajesAmbasOperaciones >= 0) {
                    // Muestra un mensaje preguntando si desea realizar la operación de Encriptar
                    DialogResult decision = MessageBox.Show($"Solo se puede realizar una operación a la vez. Sin embargo, se detecto que" +
                        $" intenta {(encriptarEsOperacionActiva ? "Encriptar" : "Desencriptar")} informacion. " +
                        $"¿Desea continuar con la operación?.", "Operación no permitida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk);

                    contadorMensajesAmbasOperaciones++;
                    return decision == DialogResult.Yes;
                } else {
                    // Muestra un mensaje confirmando que se procederá con la operación de Encriptar
                    if (contadorMensajesAmbasOperaciones > 0) {
                        contadorMensajesAmbasOperaciones = -1;
                        MessageBox.Show(
                        "Se procederá con la operación del textbox activo.",
                        "Operación por defecto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    return true;
                }

            }
            contadorMensajesAmbasOperaciones = 0;

            int idOperacion = !textBoxEncriptar.ReadOnly ? 0 : 1;

            if (idOperacion == 0 && string.IsNullOrEmpty(textoEncriptar)) {
                MessageBox.Show("Se detecto que se intenta Encriptar informacion.\nPero el respectivo textbox esta vacio.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (idOperacion == 1 && string.IsNullOrEmpty(textoDesencriptar)) {
                MessageBox.Show("Se detecto que se intenta Desencriptar informacion.\nPero el respectivo textbox esta vacio.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarTextBoxResultado(TextBox textBoxResultado) {
            if (!string.IsNullOrEmpty(textBoxResultado.Text.Trim())) {
                // Si ya eligió no mostrar más el mensaje, simplemente retorna true
                if (!mostrarMensaje) {
                    return true;
                }

                if (operacionElegida == 1) {
                    // Copiar al portapapeles y no borrar el contenido
                    Clipboard.SetText(textBoxResultado.Text);
                    return true;
                }


                if (contadorMensajes < 3 || operacionElegida == 0) {
                    contadorMensajes++;
                    DialogResult resultado = MessageBox.Show("El TextBox de resultado contiene información. " +
                        "Si continúa, se perderá la información actual. ¿Desea continuar?", "Advertencia",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes) {
                        textBoxResultado.Clear();
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    DialogResult resultado = MessageBox.Show("El TextBox de resultado contiene información. " +
                        "Si continúa, se perderá la información actual. ¿Desea continuar? \n\n Si elige 'Sí', " +
                        "se le seguirá preguntando. Si elige 'No', no se mostrará más este mensaje. Si elige " +
                        "'Cancelar', no se mostrará más este mensaje y el resultado se copiará al portapapeles.",
                        "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes) {
                        operacionElegida = 0;
                        return true;
                    } else if (resultado == DialogResult.No) {
                        mostrarMensaje = false;
                        return false;
                    } else {
                        operacionElegida = 1;
                        // Copiar al portapapeles y no borrar el contenido
                        Clipboard.SetText(textBoxResultado.Text);
                        return true;
                    }
                }
            }

            return true;

        }




    }
}
