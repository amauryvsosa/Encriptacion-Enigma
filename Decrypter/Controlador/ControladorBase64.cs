﻿using Enigma.Diseños;
using Enigma.Modelo;
using System.Windows.Forms;
using static Enigma.Apoyo.Utils;
using static Enigma.Encriptaciones.Base64;

namespace Enigma.Controlador {
    public class ControladorBase64 {
        DiseñoBase64 diseño;
        Validaciones validar;

        public TableLayoutPanel ObtenerDiseño() {
            diseño = new DiseñoBase64();
            TableLayoutPanel contenedor = diseño.tlpContenedorBase64;

            return contenedor;
        }

        public int ObtenerOperacion() {
            return diseño.txtDesencriptar.ReadOnly ? 0 : 1;
        }

        private void IniciarValidar() {
            validar = new Validaciones(diseño.txtEncriptar, diseño.txtDesencriptar, diseño.txtResultado);
        }

        public void Encriptar() {
            if (validar == null) {
                IniciarValidar();
            }

            if (validar.SonValidosTextboxesOperacion()) {
                validar.LimpiarTextBoxResultado();

                string cadenaEncriptar = diseño.txtEncriptar.Text;
                string cadenaEncriptada = Codifica(cadenaEncriptar);

                diseño.txtResultado.Text = cadenaEncriptada;
            }
        }

        public void Desencriptar() {
            string formatoIdentificado;
            if (validar == null) {
                IniciarValidar();
            }

            if (validar.SonValidosTextboxesOperacion()) {
                validar.LimpiarTextBoxResultado();

                string cadenaEncriptada = diseño.txtDesencriptar.Text;
                string cadenaDesencriptada = Descodifica<string>(cadenaEncriptada);

                if (!string.IsNullOrEmpty(cadenaDesencriptada)) {
                    formatoIdentificado = IdentificarFormato(cadenaDesencriptada);

                    if (!string.IsNullOrEmpty(formatoIdentificado) && validar.PreguntarDarFormato(formatoIdentificado)) {
                        cadenaDesencriptada = DarFormatoCorrespondiente(cadenaDesencriptada);
                    }
                }

                diseño.txtResultado.Text = cadenaDesencriptada;
            }
        }
    }
}
