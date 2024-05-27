using Enigma.Apoyo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static Enigma.Apoyo.Utils;
using static Enigma.Apoyo.Inactividad;
using static Enigma.Encriptaciones.AesX;
using static Enigma.Encriptaciones.Base64;
using static Enigma.Encriptaciones.Rsa;

namespace Decrypter {
    public partial class Principal : Form {
        private int contadorMensajes;
        private int contadorMensajesAmbasOperaciones;
        private bool mostrarMensaje = true;
        private int operacionElegida = -1;
        private int EncriptacionElegida = 1;
        private string LongitudElegida = string.Empty;
        private string TipoCifrado = string.Empty;
        private JsonConfiguracion configuracion = new JsonConfiguracion();
        private List<Control> controlesDinamicos = new List<Control>();
        private bool esCargaInicio = false;

        public Principal() {
            InitializeComponent();
            ValidarConfiguracionInicial();
            CapturarClicks(Controls, UserActivity);
            IniciarContadorActividad(InactivityTimer_Tick);
        }

        #region Metodos de Validacion
        public void ValidarConfiguracionInicial() {
            string ruta = ObtenerRutaDocumentos() + "\\Enigma";
            string rutaJson = $"{ruta}\\ConfiguracionEnigma.json";

            if (!ExisteCarpeta(ruta)) {
                CrearCarpeta(ruta);
            }

            if (!ExisteArchivo(rutaJson)) {
                JsonPorDefecto iniciarJson = new JsonPorDefecto();
                CrearArchivo(rutaJson);

                configuracion = iniciarJson.ObtenerJsonBienvenida();

                string jsonConfiguracion = ConvertirObjetoCadenaJson(configuracion);

                EscribirReemplazarContenidoJson(rutaJson, jsonConfiguracion);
            } else {
                string jsonConfiguracion = ObtenerContenidoJson(rutaJson);
                configuracion = ConvertirCadenaJsonObjeto<JsonConfiguracion>(jsonConfiguracion);
            }

            esCargaInicio = true;
            LlenarComboBoxEncriptaciones(comboBoxEncriptaciones, configuracion.EncriptacionesDisponibles);
            LongitudElegida = LlenarComboBoxLogitudes(comboBoxLongitudesLlave, configuracion.EncriptacionesDisponibles[configuracion.EncriptacionesDisponibles.Count - 1].Propiedades.LongitudesLlave);
            TipoCifrado = LlenarComboBoxCifrados(comboBoxCifrados, configuracion.EncriptacionesDisponibles[configuracion.EncriptacionesDisponibles.Count - 1].Propiedades.TiposCifrados);
            esCargaInicio = false;

            controlesDinamicos = ObtenerControladoresEspeciales(tableLayoutPanel, 0, 2, 4, 3);
            controlesDinamicos.Add(textBoxEncriptar);

            ActualizarComponentes(controlesDinamicos, null, 1);
        }

        private void DeshabilitarHabilitarControles() {
            // Deshabilitar todos los controles, excepto el TextBox de resultado
            foreach (Control control in tableLayoutPanel.Controls) {
                if (control != textBoxResultado)
                    control.Enabled = false;
            }

            // Deshabilitar el botón durante la espera
            btnRealizar.Enabled = false;

            // Esperar 4 segundos
            Thread.Sleep(4000);

            // Habilitar todos los controles, excepto el TextBox de resultado
            foreach (Control control in tableLayoutPanel.Controls) {
                if (control != textBoxResultado)
                    control.Enabled = true;
            }

            // Habilitar el botón después de la espera
            btnRealizar.Enabled = true;
        }

        // Método para evaluar los TextBox de encriptar y desencriptar
        private bool TextBoxCorrectos() {
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
                bool encriptarEsOperacionActiva = ObtenerOperacionActiva();
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

            int idOperacion = IdentificarOperacion();

            if(idOperacion == 0 && string.IsNullOrEmpty(textoEncriptar)) {
                MessageBox.Show("Se detecto que se intenta Encriptar informacion.\nPero el respectivo textbox esta vacio.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(idOperacion == 1 && string.IsNullOrEmpty(textoDesencriptar)) {
                MessageBox.Show("Se detecto que se intenta Desencriptar informacion.\nPero el respectivo textbox esta vacio.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ObtenerOperacionActiva() {
            return !textBoxEncriptar.ReadOnly;
        }

        private int IdentificarOperacion() {
            return ObtenerOperacionActiva() ? 0 : 1;
        }

        private string ObtenerCadenaOperacion(int operacion) {
            if (operacion == 0) {
                return textBoxEncriptar.Text.Trim();
            } else {
                return textBoxDesencriptar.Text.Trim();
            }
        }

        private void MostrarResultado(string cadenaResultado) {
            textBoxResultado.Text = cadenaResultado;
        }

        private void LimpiarTextBoxResultado() {
            textBoxResultado.Clear();
        }

        private bool ValidarTextBoxResultado() {
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
        #endregion

        #region Validacion de Formatos
        private bool ResultadoEsJson(string cadenaResultado) {
            try {
                JsonConvert.DeserializeObject(cadenaResultado);
                return true;
            } catch (JsonException) {
                return false;
            }
        }

        private bool ResultadoEsXml(string cadenaResultado) {
            try {
                XElement.Parse(cadenaResultado);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        private bool ResultadoEsYaml(string cadenaResultado) {
            string patronYaml = @"^(\w+\d*:\r*\n*¬*)|\r* +-* [a-z]*:¬* *.*¬*";
            try {
                // Crear un objeto Regex con el patrón
                Regex regex = new Regex(patronYaml);

                // Evaluar si la cadena coincide con la expresión regular
                bool coincide = regex.IsMatch(cadenaResultado);

                // Mostrar el resultado
                return coincide;
                //var yaml = new YamlDotNet.RepresentationModel.YamlStream();
                //yaml.Load(new StringReader(cadenaResultado));
                //return true;
            } catch (Exception) {
                return false;
            }
        }

        private bool ResultadoEsHtml(string cadenaResultado) {
            // Definir una expresión regular
            string patronHtml = @"<\/?[a-z][\s\S]*>";
            try {
                // Crear un objeto Regex con el patrón
                Regex regex = new Regex(patronHtml);

                // Evaluar si la cadena coincide con la expresión regular
                bool coincide = regex.IsMatch(cadenaResultado);

                // Mostrar el resultado
                return coincide;
            } catch (Exception) {
                return false;
            }
        }

        private string DarFormatoCorrespondiente(string cadenaResultado) {
            string cadenaFormateada = cadenaResultado;
            if (ResultadoEsJson(cadenaResultado)) {
                cadenaFormateada = JsonConvert.SerializeObject(JsonConvert
                    .DeserializeObject(cadenaResultado), Formatting.Indented);
            } else if (ResultadoEsXml(cadenaResultado)) {
                cadenaFormateada = XDocument.Parse(cadenaResultado).ToString();
            } else if (ResultadoEsHtml(cadenaResultado)) {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(cadenaResultado);
                cadenaFormateada = htmlDoc.DocumentNode.OuterHtml;
            } else if (ResultadoEsYaml(cadenaResultado)) {
                //Fase de pruebas para formato yaml
                // Definir una expresión regular
                string nivel1 = @"(\w+:)";

                cadenaFormateada = Regex.Replace(cadenaResultado, nivel1, "$1\n\r", RegexOptions.Multiline);
            }
            return cadenaFormateada;
        }

        private string IdentificarFormato(string cadenaResultado) {
            string tipoFormato = string.Empty;

            if (ResultadoEsJson(cadenaResultado)) {
                tipoFormato = "JSON";
            } else if (ResultadoEsXml(cadenaResultado)) {
                tipoFormato = "XML";
            } else if (ResultadoEsHtml(cadenaResultado)) {
                tipoFormato = "HTML";
            } else if (ResultadoEsYaml(cadenaResultado)) {
                tipoFormato = "YAML";
            }

            return tipoFormato;
        }

        private bool PreguntarDarFormato(string tipoFormato) {
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
        #endregion

        #region Metodos principales
        public string Encriptar(int indice, object dato, List<DatosEncriptacion> informacion) {
            switch (indice) {
                case 1:
                return Codifica(dato);
                case 2:
                if (!string.IsNullOrEmpty(textBoxLlaveEncriPrivada.Text.Trim())) {
                    return Codifica(textBoxLlaveEncriPrivada.Text.Trim(), dato);
                } else {
                    MessageBox.Show("La llave encriptado no puede estar vacia", "Error en llave", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                return string.Empty;
                case 3:
                    if(!string.IsNullOrEmpty(textBoxLlavePublica.Text.Trim())) {
                        return Codifica(dato, LongitudElegida, textBoxLlavePublica.Text.Trim(), TipoCifrado);
                    } else {
                        MessageBox.Show("La llave publica no puede estar vacia", "Error en llave", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    return string.Empty;
                default:
                return default;

            }
        }

        public string Desencriptar(int indice, string datoCodificado, List<DatosEncriptacion> informacion) {
            switch (indice) {
                case 1:
                return Descodifica<string>(datoCodificado);
                case 2:
                if (!string.IsNullOrEmpty(textBoxLlaveEncriPrivada.Text.Trim())) {
                    return Descodifica(textBoxLlaveEncriPrivada.Text.Trim(), datoCodificado);
                } else {
                    MessageBox.Show("La llave encriptado no puede estar vacia", "Error en llave", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                return string.Empty;
                case 3:
                if (!string.IsNullOrEmpty(textBoxLlaveEncriPrivada.Text.Trim())) {
                    return Descodifica(datoCodificado, LongitudElegida, textBoxLlaveEncriPrivada.Text.Trim(), TipoCifrado);
                } else {
                    MessageBox.Show("La llave privada no puede estar vacia", "Error en llave", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                return string.Empty;
                default:
                return default;
            }
        }
        #endregion

        #region Eventos
        private void btnRealizar_Click_1(object sender, EventArgs e) {
            //Se establecen las variables necesarias
            string cadenaResultado;
            string cadenaOperacion;
            string formatoIdentificado;


            // Llamar al método para evaluar los TextBox de encriptar y desencriptar
            if (TextBoxCorrectos() && ValidarTextBoxResultado()) {
                //Antes de Iniciar se limpia el texbox de Resultado por si contiene informacion y evitar que
                //se concatene
                LimpiarTextBoxResultado();

                // Llamar al método para deshabilitar y habilitar los controles después de un tiempo
                DeshabilitarHabilitarControles();

                int idOperacion = IdentificarOperacion();

                //operacion 0 es encriptar, operacion 1 es desencriptar
                cadenaOperacion = ObtenerCadenaOperacion(idOperacion);

                if (idOperacion == 0) {
                    cadenaResultado = Encriptar(EncriptacionElegida, cadenaOperacion, configuracion.EncriptacionesDisponibles);
                } else {
                    cadenaResultado = Desencriptar(EncriptacionElegida, cadenaOperacion, configuracion.EncriptacionesDisponibles);
                    if (!string.IsNullOrEmpty(cadenaResultado)) {
                        formatoIdentificado = IdentificarFormato(cadenaResultado);

                        if (!string.IsNullOrEmpty(formatoIdentificado) && !PreguntarDarFormato(formatoIdentificado)) {
                            cadenaResultado = DarFormatoCorrespondiente(cadenaResultado);
                        }
                    }
                }
                MostrarResultado(cadenaResultado);
            }
        }

        private void textBoxEncriptar_Enter(object sender, EventArgs e) {
            // Deshabilitar el TextBox de Desencriptar cuando el TextBox de Encriptar está activo
            textBoxDesencriptar.ReadOnly = true;
            textBoxEncriptar.ReadOnly = false;
        }

        private void textBoxDesencriptar_Enter(object sender, EventArgs e) {
            // Deshabilitar el TextBox de Encriptar cuando el TextBox de Desencriptar está activo
            textBoxEncriptar.ReadOnly = true;
            textBoxDesencriptar.ReadOnly = false;
        }
        #endregion

        private void comboBoxEncriptaciones_SelectedIndexChanged(object sender, EventArgs e) {
            if (!esCargaInicio) {
                EncriptacionElegida = comboBoxEncriptaciones.SelectedIndex + 1;

                ActualizarComponentes(controlesDinamicos, configuracion.EncriptacionesDisponibles,
                    EncriptacionElegida);
            }

        }

        private void comboBoxLongitudesLlave_SelectedIndexChanged(object sender, EventArgs e) {
            if (!esCargaInicio) {
                LongitudElegida = comboBoxLongitudesLlave.SelectedItem.ToString();
            }
        }

        private void comboBoxCifrados_SelectedIndexChanged(object sender, EventArgs e) {
            if (!esCargaInicio) {
                TipoCifrado = comboBoxCifrados.SelectedItem.ToString();
            }
        }

        private void textBoxLlavePublica_Enter(object sender, EventArgs e) {
            textBoxLlavePublica.ReadOnly = false;
            textBoxEncriptar.ReadOnly = false;
            textBoxDesencriptar.ReadOnly = true;
            textBoxLlaveEncriPrivada.ReadOnly = true;
        }

        private void textBoxLlaveEncriPrivada_Enter(object sender, EventArgs e) {
            textBoxLlaveEncriPrivada.ReadOnly = false;

            if (textBoxLlavePublica.Visible) {
                textBoxLlavePublica.ReadOnly = true;
                textBoxEncriptar.ReadOnly = true;
                textBoxDesencriptar.ReadOnly = false;
            }
        }

        private void textBoxLlaveEncriPrivada_Leave(object sender, EventArgs e) {
            if (!textBoxLlavePublica.Visible) {
                textBoxLlaveEncriPrivada.ReadOnly = true;
            }
        }

        private void UserActivity(object sender, EventArgs e) {
            TiempoInactividad.Stop();
            TiempoInactividad.Start();
        }

        private void InactivityTimer_Tick(object sender, EventArgs e) {
            TiempoInactividad.Stop();

            DialogResult resultadoDecisionInactividad = MessageBox.Show("No se han realizado operaciones en 5 minutos.\n" +
                "¿Desea cerrar el programa?", "Inactividad Detectada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resultadoDecisionInactividad == DialogResult.Yes) {
                Application.Exit();
            }
            else {
                TiempoInactividad.Start();
            }
        }
    }
}
